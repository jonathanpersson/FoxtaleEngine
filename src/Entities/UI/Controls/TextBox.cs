using Foxtale.Components;
using Foxtale.Components.Scripts;
using Foxtale.Components.UI;

namespace Foxtale.Entities.UI.Controls;

public class TextBox : UIEntity
{
    public Text Content { get; }
    public Event OnInput { get; }
    public TextBoxScript Script { get; }

    public TextBox(string content = null)
    {
        Content = new Text(content ?? string.Empty);
        OnInput = new Event();
        Script = new TextBoxScript(this);
        AddComponent(Content);
        AddComponent(OnInput);
        AddComponent(Script);
    }
}