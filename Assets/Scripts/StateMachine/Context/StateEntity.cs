using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateEntity
{
    protected readonly StateMachine _stateMachine;

    public abstract void BeginState();
    public abstract void EndState();
    public virtual void Tick() { }

    public StateEntity(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    internal virtual void SwitchTo(State state) => _stateMachine.ChangeState(state);
}
