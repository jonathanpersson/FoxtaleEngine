using Foxtale.Engine.Components;
using Foxtale.Engine.Core;
using Foxtale.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Foxtale.Components.Scripts;

public class FoxScript : Script
{
    private float _maxSpeed = 80;
    private float _speed = 0;

    public Fox Fox { get; set; }
    public Texture2D WalkingAnimation { get; }
    public Texture2D RunningAnimation { get; }
    public Texture2D IdleAnimation { get; }
    public Texture2D JumpAnimation { get; }
    public Texture2D LandingAnimation { get; }
    public Texture2D SniffAnimation { get; }
    public Texture2D HangAnimation { get; }
    
    public FoxScript(Fox fox)
    {
        Fox = fox;
        WalkingAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/walk");
        RunningAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/run");
        IdleAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/standing");
        JumpAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/pounce");
        LandingAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/landing");
        SniffAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/sniff");
        HangAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/hang");
    }

    public override void Update(GameTime gameTime)
    {
        Move();
        if (_speed != 0) Fox.Transform.Move(_speed, 0, gameTime);
    }

    private void Move()
    {
        if (Input.KeyDown(Keys.A) || Input.KeyDown(Keys.Left))
        {
            _speed = -_maxSpeed;
            if (Fox.Sprite.Texture != RunningAnimation) Fox.Sprite.Texture = RunningAnimation;
            if (Fox.Sprite.Effect != SpriteEffects.FlipHorizontally) Fox.Sprite.Effect = SpriteEffects.FlipHorizontally;
        }
        else if (Input.KeyDown(Keys.D) || Input.KeyDown(Keys.Right))
        {
            _speed = _maxSpeed;
            if (Fox.Sprite.Texture != RunningAnimation) Fox.Sprite.Texture = RunningAnimation;
            if (Fox.Sprite.Effect != SpriteEffects.None) Fox.Sprite.Effect = SpriteEffects.None;
        }
        else
        {
            _speed = 0;
            if (Fox.Sprite.Texture != IdleAnimation) Fox.Sprite.Texture = IdleAnimation;
        }
    }
}