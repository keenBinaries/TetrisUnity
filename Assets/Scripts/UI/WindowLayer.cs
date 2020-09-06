using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowLayer : UILayer<IWindowController>
{
    public override void ShowScreen(IWindowController screen)
    {
        screen.Show();
    }

    public override void HideScreen(IWindowController screen)
    {
        screen.Hide();
    }
}