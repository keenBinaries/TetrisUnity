using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : StateEntity
{
    public MainMenuState(StateMachine stateMachine) 
        : base(stateMachine) 
    { }

    public override void BeginState()
    {
        Debug.Log("MainMenuState started!");
        StateChangeEvents.OnGamePlayStarted += SwitchTo;
    }

    public override void EndState()
    {
        Debug.Log("MainMenuState ended!");
        StateChangeEvents.OnGamePlayStarted -= SwitchTo;
        UIContext.Instance.CloseWindow("MainMenuWindow"); // TODO: Consider constructing the state objects with a reference to an UIContext object.
    }
}
