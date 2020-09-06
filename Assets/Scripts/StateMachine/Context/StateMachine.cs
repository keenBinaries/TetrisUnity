using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    None = 0,
    MainMenu,
    GamePlay
}

public class StateMachine : MonoBehaviour
{
    private const State _initialState = State.MainMenu;

    private Dictionary<State, StateEntity> _statesCollection = new Dictionary<State, StateEntity>();
    private StateFactory _stateFactory = new StateFactory();

    private StateEntity _stateEntity = null;

    [SerializeField] private State _currentState;
    [SerializeField] private State _previousState;

    [SerializeField] private GameObject _board;

    private void Awake() => InitializeStatesCollection();
    private void Start() => ChangeState(_initialState);
    private void Update() => _stateEntity.Tick();

    private void InitializeStatesCollection()
    {
        foreach (var state in (State[])Enum.GetValues(typeof(State)))
        {
            if (state != State.None)
            {
                _statesCollection[state] = _stateFactory.CreateState(this, state, _board);
            }
        }
    }

    internal void ChangeState(State state)
    {
        if (_stateEntity != null)
        {
            _stateEntity.EndState();
            _stateEntity = null;
        }

        _previousState = _currentState;
        _currentState = state;

        _stateEntity = _statesCollection[state]; 
        _stateEntity.BeginState();
    }
}
