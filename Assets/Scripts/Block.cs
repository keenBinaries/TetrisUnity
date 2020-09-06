using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private static float fallTimeOffset = 0.5f;
    private static float lastFallClock;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (!RemainsOnScreen())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);

            if (!RemainsOnScreen())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(new Vector3(0, 0, - 90));

            if (!RemainsOnScreen())
            {
                transform.Rotate(new Vector3(0, 0, -90));
            }
        }

        if ((Time.time - lastFallClock) > (Input.GetKey(KeyCode.DownArrow) ? fallTimeOffset / 10 : fallTimeOffset))
        {
            transform.position += new Vector3(0, -1, 0);

            if (!RemainsOnScreen())
            {
                transform.position -= new Vector3(0, -1, 0);
                Board.Instance.PassBlockPiecesToGrid(transform);
                Board.Instance.DeleteFilledRows();
                this.enabled = false;
                Board.Instance.SpawnBlock();
            }

            lastFallClock = Time.time;
        }
    }

    private bool RemainsOnScreen()
    {
        foreach (Transform piece in transform)
        {
            var xPosition = piece.transform.position.x;
            var yPosition = piece.transform.position.y;

            if (xPosition > Board.Width || xPosition < 0 || yPosition < 0)
            {
                return false;
            }

            var rowIndex = (int)(xPosition - .5f);
            var columnIndex = (int)(yPosition - .5f);

            if (Board.Grid[rowIndex, columnIndex] != null /* && Board.Grid[rowIndex, columnIndex].parent != transform*/) // TODO: See if it need to be splited also see Board.PassBlockPiecesToGrid()
                return false;
        }

        return true;
    }
}
