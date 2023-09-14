using Foxtale.Components;
using Foxtale.Components.Scripts;
using Foxtale.Components.UI;
using Foxtale.Systems.UI;
using Microsoft.Xna.Framework;

namespace Foxtale.Entities.UI.Controls;

public class TextBox : UIEntity
{
    public bool Focused => Script.Focused;
    public Text Content { get; }
    public Event OnInput { get; }
    public TextureStack Textures { get; }
    public TextBoxScript Script { get; }

    public TextBox(int x, int y, int length, string content = null)
    {
        Transform.Position = new Vector2(x, y);
        Transform.Size = new Vector2(4 + UserInterfaceSystem.Font.LineHeight, 
            4 + length * UserInterfaceSystem.Font.MeasureString("O").Width); //TODO: probably do this better
        Content = new Text(content ?? string.Empty);
        OnInput = new Event();
        Textures = new TextureStack();
        Script = new TextBoxScript(this);
        AddComponent(Content);
        AddComponent(OnInput);
        AddComponent(Textures);
        AddComponent(Script);
    }
}