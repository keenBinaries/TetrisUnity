using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangeEvents
{
    public static event Action<State> OnGamePlayStarted;
    public static void TriggerOnGamePlayStarted() => OnGamePlayStarted?.Invoke(State.GamePlay);
}
