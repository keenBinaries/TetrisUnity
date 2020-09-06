using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : WindowController
{
    public void OnPlayButtonPressed()
    {
        StateChangeEvents.TriggerOnGamePlayStarted();
    }
}
