using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private UISettings _uiSettings;
    private UIContext _uiContext;

    private void Awake()
    {
        _uiContext = _uiSettings.CreateUIRoot();
        _uiContext.ShowScreen("MainMenuWindow");
    }
}
