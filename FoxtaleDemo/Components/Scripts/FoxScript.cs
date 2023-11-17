using Foxtale.Components;
using Foxtale.Core;
using FoxtaleDemo.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FoxtaleDemo.Components.Scripts;

public class FoxScript : Script
{
    private const float _maxSpeed = 120;
    private float _speed = 0;
    private double _jumpTimer = 0;
    private bool _jumping = false;

    private enum Animations
    {
        Idle = 0,
        Jump = 1,
        Land = 2,
        Sniff = 3,
        Hang = 4,
        Walk = 5,
        Run = 6
    }

    public Fox Fox { get; set; }
    public Texture2D IdleAnimation { get; }
    
    public FoxScript(Fox fox)
    {
        Fox = fox;
        IdleAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/standing");
    }

    public override void Update(GameTime gameTime)
    {
        Move(gameTime);
        Jump(gameTime);
    }

    public void LoadAnimations()
    {
        const int spriteWidth = 78;
        Fox.Animations.AddAnimation((int)Animations.Idle, IdleAnimation, spriteWidth);
        Fox.Animations.AddAnimation((int)Animations.Jump, 
            GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/pounce"), spriteWidth);
        Fox.Animations.AddAnimation((int)Animations.Land,
            GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/landing"), spriteWidth);
        Fox.Animations.AddAnimation((int)Animations.Sniff,
            GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/sniff"), spriteWidth);
        Fox.Animations.AddAnimation((int)Animations.Hang,
            GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/hang"), spriteWidth);
        Fox.Animations.AddAnimation((int)Animations.Walk,
            GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/walk"), spriteWidth);
        Fox.Animations.AddAnimation((int)Animations.Run,
            GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/run"), spriteWidth);
        Fox.Animations.Atlas();
        Fox.Animations.SetActive((int)Animations.Idle);
    }

    private void Move(GameTime gameTime)
    {
        if (Input.KeyDown(Keys.A) || Input.KeyDown(Keys.Left))
        {
            _speed = -_maxSpeed;
            if (Fox.Animations.ActiveAnimation != (int)Animations.Run && !_jumping) 
                Fox.Animations.SetActive((int)Animations.Run);
            if (Fox.Sprite.Effect != SpriteEffects.FlipHorizontally) 
                Fox.Sprite.Effect = SpriteEffects.FlipHorizontally;
        }
        else if (Input.KeyDown(Keys.D) || Input.KeyDown(Keys.Right))
        {
            _speed = _maxSpeed;
            if (Fox.Animations.ActiveAnimation != (int)Animations.Run && !_jumping) 
                Fox.Animations.SetActive((int)Animations.Run);
            if (Fox.Sprite.Effect != SpriteEffects.None) 
                Fox.Sprite.Effect = SpriteEffects.None;
        }
        else
        {
            _speed = 0;
            if (Fox.Animations.ActiveAnimation != (int)Animations.Idle && !_jumping) Fox.Animations.SetActive((int)Animations.Idle);
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
        
        switch (_jumpTimer)
        {
            case < 0.75 when Fox.Animations.ActiveAnimation != (int)Animations.Jump:
                Fox.Animations.SetActive((int)Animations.Jump);
                break;
            case >= 0.75 when Fox.Animations.ActiveAnimation != (int)Animations.Land:
                Fox.Animations.SetActive((int)Animations.Land);
                break;
        }

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