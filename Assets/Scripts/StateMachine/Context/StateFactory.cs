using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFactory
{
    internal StateEntity CreateState(StateMachine stateMachine, State newState, GameObject board)
    {
        switch (newState)
        {
            case State.MainMenu:
                return new MainMenuState(stateMachine);

            case State.GamePlay:
                return new GamePlayState(stateMachine, board);
        }

        return null; // TODO: Find a better strategy
    }
}
