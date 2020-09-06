using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUIScreenController
{
    string ScreenId { get; set; }
    bool IsVisible { get; }

    // void Show(IScreenProperties props = null);
    void Show();
    void Hide(bool animate = true);

    /* 
     * Don't know how to use this
     
        Action<IUIScreenController> InTransitionFinished { get; set; }
        Action<IUIScreenController> OutTransitionFinished { get; set; }
        Action<IUIScreenController> CloseRequest { get; set; }
        Action<IUIScreenController> ScreenDestroyed { get; set; }
    */
}

public interface IWidgetController : IUIScreenController { }
public interface IWindowController : IUIScreenController { }