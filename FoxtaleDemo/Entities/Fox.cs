using Foxtale.Components;
using Foxtale.Core;
using Foxtale.Entities;
using FoxtaleDemo.Components.Scripts;
using Microsoft.Xna.Framework;

namespace FoxtaleDemo.Entities;

public class Fox : Entity2D
{
    public AnimatedSprite Sprite { get; set; }
    public FoxScript Script { get; set; }
    
    public Fox()
    {
        Script = new FoxScript(this);
        Sprite = new AnimatedSprite(Script.IdleAnimation, 78, 64, 10)
        {
            Origin = Origin2D.BottomCenter
        };
        Transform.Position = new Vector2(200, 400);
        Transform.Scale = new Vector2(2, 2);
        AddComponent(Sprite);
        AddComponent(Script);
    }
}