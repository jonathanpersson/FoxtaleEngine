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
    private double _jumpTimer = 0;
    private bool _jumping = false;

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
        Move(gameTime);
        Jump(gameTime);
    }

    private void Move(GameTime gameTime)
    {
        if (Input.KeyDown(Keys.A) || Input.KeyDown(Keys.Left))
        {
            _speed = -_maxSpeed;
            if (Fox.Sprite.Texture != RunningAnimation && !_jumping) Fox.Sprite.Texture = RunningAnimation;
            if (Fox.Sprite.Effect != SpriteEffects.FlipHorizontally) Fox.Sprite.Effect = SpriteEffects.FlipHorizontally;
        }
        else if (Input.KeyDown(Keys.D) || Input.KeyDown(Keys.Right))
        {
            _speed = _maxSpeed;
            if (Fox.Sprite.Texture != RunningAnimation && !_jumping) Fox.Sprite.Texture = RunningAnimation;
            if (Fox.Sprite.Effect != SpriteEffects.None) Fox.Sprite.Effect = SpriteEffects.None;
        }
        else
        {
            _speed = 0;
            if (Fox.Sprite.Texture != IdleAnimation && !_jumping) Fox.Sprite.Texture = IdleAnimation;
        }
        if (_speed != 0) Fox.Transform.Move(_speed, 0, gameTime);
    }

    private void Jump(GameTime gameTime)
    {
        if (Input.KeyDown(Keys.Space) && !_jumping)
        {
            _jumping = true;
            return;
        }

        if (!_jumping) return;

        Fox.Sprite.Texture = _jumpTimer switch
        {
            < 0.75 => JumpAnimation,
            >= 0.75 => LandingAnimation,
            _ => Fox.Sprite.Texture
        };

        switch (_jumpTimer)
        {
            case < 0.75:
                Fox.Transform.Move(0, -_maxSpeed * 2, gameTime);
                break;
            case < 1.5:
                Fox.Transform.Move(0, _maxSpeed * 2, gameTime);
                break;
            default:
                _jumping = false;
                _jumpTimer = 0;
                break;
        }

        _jumpTimer += gameTime.ElapsedGameTime.TotalSeconds;
    }
}