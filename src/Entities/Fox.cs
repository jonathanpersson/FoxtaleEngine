using Foxtale.Engine.Entities;
using Foxtale.Components.Scripts;
using Foxtale.Engine.Components;
using Foxtale.Engine.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Entities;

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
        AddComponent(Sprite);
        AddComponent(Script);
    }
}