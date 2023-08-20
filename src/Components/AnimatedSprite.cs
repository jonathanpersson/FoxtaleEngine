using Foxtale.Core;
using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Components;

public class AnimatedSprite : IComponent, ISprite
{
    private double _timer;
    public Texture2D Texture { get; set; }
    public IEntity Entity { get; set; }
    public Color RenderTint { get; set; } = Color.White;
    public Origin2D Origin { get; set; } = Origin2D.TopLeft;
    public Vector2 SpriteSize { get; set; }
    public SpriteEffects Effect { get; set; }
    public Rectangle SourceRectangle { get; set; }
    public float Framerate { get; set; }
    public int Frames { get; set; }
    public int Frame { get; set; }

    public AnimatedSprite()
    {
        _timer = 0;
        Framerate = 0;
        Frames = 0;
        Frame = 0;
        SpriteSize = Vector2.Zero;
        AnimatedSpriteSystem.AddComponent(this);
    }
    
    public AnimatedSprite(Texture2D texture, int width, int  height, float framerate)
    {
        Texture = texture;
        SpriteSize = new Vector2(width, height);
        SourceRectangle = new Rectangle(0, 0, width, height);
        Framerate = framerate;
        Frames = texture.Width / width;
        Frame = 0;
        AnimatedSpriteSystem.AddComponent(this);
        _timer = 0;
    }
    
    public void Initialize() { }

    public void Update(GameTime gameTime)
    {
        _timer += gameTime.ElapsedGameTime.TotalSeconds;

        if (Framerate != 0)
        {
            if (_timer < 1 / Framerate) return;
            if (++Frame >= Frames) Frame = 0;
        }

        Rectangle sourceRectangle = SourceRectangle;
        sourceRectangle.X = (int)SpriteSize.X * Frame;
        SourceRectangle = sourceRectangle;
        _timer = 0;
    }

    public void Destroy()
    {
        AnimatedSpriteSystem.RemoveComponent(this);
    }
}