using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WidgetController : UIScreenController, IWidgetController { }
public abstract class WindowController : UIScreenController, IWindowController { }

public class UIScreenController : MonoBehaviour, IUIScreenController
{
    public string ScreenId { get; set; }
    public bool IsVisible { get; private set; }

    public void Hide(bool animate = true)
    {
        if (gameObject.activeSelf)
        {
            // DoAnimation(animIn, OnTransitionInFinished, true);
            gameObject.SetActive(false);
        }
    }

    public void Show()
    {
        if (!gameObject.activeSelf)
        {
            // DoAnimation(animIn, OnTransitionInFinished, true);
            gameObject.SetActive(true);
        }
    }
}