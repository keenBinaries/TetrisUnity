using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIContext : MonoBehaviour
{
    public static UIContext Instance { get; private set; } // TODO: See if you reference the instance in a better way.

    private WindowLayer _windowLayer;
    private WidgetLayer _widgetLayer;

    private Canvas _canvas;

    private void Awake()
    {
        Instance = this;

        _widgetLayer = GetComponentInChildren<WidgetLayer>(); // true param
        _windowLayer = GetComponentInChildren<WindowLayer>(); // true param

        _widgetLayer.Initialize();
        _windowLayer.Initialize();
    }

    public void OpenWindow(string screenId) => _windowLayer.ShowScreenById(screenId);
    public void CloseWindow(string screenId) => _windowLayer.HideScreenById(screenId);
    public void ShowWidget(string screenId) => _widgetLayer.ShowScreenById(screenId);
    public void HideWidget(string screenId) => _widgetLayer.HideScreenById(screenId);

    public void ShowScreen(string screenId)
    {
        if (IsScreenRegistered(screenId, out var type))
        {
            if (type == typeof(IWidgetController))
            {
                ShowWidget(screenId);
            }

            if (type == typeof(IWindowController))
            {
                OpenWindow(screenId);
            }
        }
    }

    public bool IsScreenRegistered(string screenId, out Type type)
    {
        if (_widgetLayer.IsScreenRegistered(screenId))
        {
            type = typeof(IWidgetController);
            return true;
        }

        if (_windowLayer.IsScreenRegistered(screenId))
        {
            type = typeof(IWindowController);
            return true;
        }

        type = null;
        return false;
    }

    internal void RegisterScreen(string screenId, IUIScreenController controller, Transform screenTransform)
    {
        var widget = controller as IWidgetController;

        if (widget != null)
        {
            _widgetLayer.RegisterScreen(screenId, widget);

            if (screenTransform != null)
            {
                _widgetLayer.ReparentScreen(controller, screenTransform);
            }
        }

        var window = controller as IWindowController;

        if (window != null)
        {
            _windowLayer.RegisterScreen(screenId, window);

            if (screenTransform != null)
            {
                _windowLayer.ReparentScreen(controller, screenTransform);
            }
        }
    }
}
