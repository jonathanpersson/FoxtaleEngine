namespace Foxtale.Components.UI;

public class Text : UIComponent
{
    public string Content { get; set; }

    public Text(string content)
    {
        Content = content;
    }
}
