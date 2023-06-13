﻿using MgGame.Engine.Components;
using MgGame.Engine.Components.UI;
using MgGame.Engine.Entities;

namespace MgGame.Engine.Entities.UI.Controls;

public class Label : UIEntity
{
    public Label(int x, int y, string text) 
    {
        AddComponent(new Transform2D(x, y));
        AddComponent(new Text(text));
        AddComponent(new Sprite());
    }
}