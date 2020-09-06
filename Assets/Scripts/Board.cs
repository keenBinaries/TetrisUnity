using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    public const int Height = 20;
    public const int Width = 10;

    public static readonly Transform[,] Grid = new Transform[Width, Height];
    public static readonly Vector3 BlockRootSpawningPoint = new Vector3((Width / 2) + .5f, Height - .5f);

    [SerializeField] 
    private List<GameObject> _blockPrefabs = new List<GameObject>();

    private void Awake() => Instance = this;
    private void Start() => SpawnBlock();

    public void SpawnBlock()
    {
        var index = Random.Range(0, _blockPrefabs.Count);
        var block = Instantiate(_blockPrefabs[index]);

        block.transform.SetParent(transform);
        // block.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 3) * 90);

        var highestPiecePosition = Vector3.zero; // TODO: Simplify this
        foreach (Transform child in block.transform)
        {
            if (child.position.y > highestPiecePosition.y)
            {
                highestPiecePosition = child.position;
            }
        }

        block.transform.position = new Vector3(BlockRootSpawningPoint.x, BlockRootSpawningPoint.y - highestPiecePosition.y, 0);
    }

    public void PassBlockPiecesToGrid(Transform block)
    {
        foreach (Transform piece in block)
        {
            var rowIndex = (int) (piece.transform.position.x - .5f);
            var columnIndex = (int) (piece.transform.position.y - .5f);
            Grid[rowIndex, columnIndex] = piece;
        }
    }

    public bool IsRowFilled(int y)
    {
        for (var x = 0; x < Width; x++)
        {
            if (Grid[x, y] == null)
            {
                return false;
            }
        }

        return true;
    }

    public void DeleteRow(int y)
    {
        for (var x = 0; x < Width; x++)
        {
            Destroy(Grid[x, y].gameObject);
            Grid[x, y] = null;
        }
    }

    public void LowerRowsAbove(int y)
    {
        for (int i = y; i < Height; i++)
        {
            // LowerRows
            for (int x = 0; x < Width; x++)
            {
                if (Grid[x, i] != null)
                {
                    Grid[x, i - 1] = Grid[x, i];
                    Grid[x, i] = null;
                    Grid[x, i - 1].position += new Vector3(0, -1, 0);
                }
            }
        }
    }

    public void DeleteFilledRows()
    {
        for (int y = 0; y < Height; y++)
        {
            if (IsRowFilled(y))
            {
                DeleteRow(y);
                LowerRowsAbove(y + 1);
                --y;
            }
        }
    }
}
