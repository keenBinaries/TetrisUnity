using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidgetLayer : UILayer<IWidgetController>
{
    public override void HideScreen(IWidgetController screen)
    {
        screen.Hide();
    }

    public override void ShowScreen(IWidgetController screen)
    {
        screen.Show();
    }
}
