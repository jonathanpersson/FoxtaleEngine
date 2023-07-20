using Foxtale.Engine.Entities;
using Foxtale.Components.Scripts;
using Foxtale.Engine.Components;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Entities;

public class Fox : Entity2D
{
    public AnimatedSprite Sprite { get; set; }
    public FoxScript Script { get; set; }
    
    public Fox()
    {
        Script = new FoxScript();
        Sprite = new AnimatedSprite(Script.WalkingAnimation, 78, 64, 10);
        AddComponent(Sprite);
        AddComponent(Script);
    }
}