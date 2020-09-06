using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UISettings", menuName = "UI/UI Settings")]
public class UISettings : ScriptableObject
{
    [SerializeField] private UIContext _uiContextPrefab;
    [SerializeField] private List<GameObject> _screensToRegister;

    public UIContext CreateUIRoot()
    {
        var uiRoot = Instantiate(_uiContextPrefab);

        foreach (var screen in _screensToRegister)
        {
            var screenInstance = Instantiate(screen);
            var screenController = screenInstance.GetComponent<IUIScreenController>();

            if (screenController != null)
            {
                uiRoot.RegisterScreen(screen.name, screenController, screenInstance.transform);
                screenInstance.SetActive(false);
            }
            else
            {
                Debug.LogError($"{screen.name} couldn't be loaded because it doesn't contain a ScreenController!");
            }
        }

        return uiRoot;
    }
}
