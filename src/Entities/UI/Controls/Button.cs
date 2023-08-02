using System;
using Foxtale.Components;
using Foxtale.Components.UI;
using Microsoft.Xna.Framework;

namespace Foxtale.Entities.UI.Controls;

public class Button : UIEntity
{
    public Text Text { get;  }
    public Sprite Sprite { get; }
    public Event OnClick;

    public Button(int x, int y, string text, EventHandler onClick)
    {
        OnClick = new Event(onClick);
        AddComponent(OnClick);
        Transform.Position = new Vector2(x, y);
        Render();
    }

    public void Render()
    {
        
    }
}