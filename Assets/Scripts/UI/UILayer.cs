using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UILayer<TScreen> : MonoBehaviour
    where TScreen : IUIScreenController
{
    protected Dictionary<string, TScreen> registeredScreens;

    public abstract void ShowScreen(TScreen screen);
    public abstract void HideScreen(TScreen screen);

    public virtual void Initialize()
    {
        registeredScreens = new Dictionary<string, TScreen>();
    }

    public void RegisterScreen(string screenId, TScreen controller)
    {
        if (!registeredScreens.ContainsKey(screenId))
        {
            controller.ScreenId = screenId;
            registeredScreens.Add(screenId, controller);
        }
        else
        {
            Debug.LogError("[AUILayerController] Screen controller already registered for id: " + screenId);
        }
    }

    public void ReparentScreen(IUIScreenController controller, Transform screenTransform)
    {
        screenTransform.SetParent(transform, false);
    }

    public bool IsScreenRegistered(string screenId)
    {
        return registeredScreens.ContainsKey(screenId);
    }

    internal void ShowScreenById(string screenId)
    {
        if (registeredScreens.TryGetValue(screenId, out var controller))
        {
            ShowScreen(controller);
        }
        else
        {
            Debug.LogError("Screen Id " + screenId + " was not registered!");
        }
    }

    internal void HideScreenById(string screenId)
    {
        if (registeredScreens.TryGetValue(screenId, out var controller))
        {
            HideScreen(controller);
        }
        else
        {
            Debug.LogError("Screen Id " + screenId + " was not registered!");
        }
    }

    //public void UnregisterScreen(string screenId, TScreen controller)
    //{
    //    if (registeredScreens.ContainsKey(screenId))
    //    {
    //        ProcessScreenUnregister(screenId, controller);
    //    }
    //    else
    //    {
    //        Debug.LogError("[AUILayerController] Screen controller not registered for id: " + screenId);
    //    }
    //}

    //protected virtual void ProcessScreenRegister(string screenId, TScreen controller)
    //{
    //    controller.ScreenId = screenId;
    //    registeredScreens.Add(screenId, controller);
    //    // controller.ScreenDestroyed += OnScreenDestroyed;
    //}

    //protected virtual void ProcessScreenUnregister(string screenId, TScreen controller)
    //{
    //    // controller.ScreenDestroyed -= OnScreenDestroyed;
    //    registeredScreens.Remove(screenId);
    //}
}
