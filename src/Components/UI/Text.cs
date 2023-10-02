namespace Foxtale.Components.UI;

public class Text : UIComponent
{
    public string Content { get; set; }
    public int Length => Content.Length;

    public Text(string content)
    {
        Content = content;
    }
}
