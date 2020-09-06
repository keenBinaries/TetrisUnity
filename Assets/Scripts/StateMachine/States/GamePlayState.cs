using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GamePlayState : StateEntity
{
    private GameObject _board;

    public GamePlayState(StateMachine stateMachine, GameObject board)
        : base(stateMachine)
    {
        _board = board;
    }

    public override void BeginState()
    {
        Debug.Log("GamePlayState started!");
        _board.SetActive(true);
    }

    public override void EndState()
    {
        _board.SetActive(false);
    }

    public override void Tick()
    {
    }
}
