using Foxtale.Engine.Components;
using Foxtale.Engine.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Components.Scripts;

public class FoxScript : Script
{
    public Texture2D WalkingAnimation { get; }
    public Texture2D RunningAnimation { get; }
    public Texture2D IdleAnimation { get; }
    public Texture2D JumpAnimation { get; }
    public Texture2D LandingAnimation { get; }
    public Texture2D SniffAnimation { get; }
    public Texture2D HangAnimation { get; }
    
    public FoxScript()
    {
        WalkingAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/walk");
        RunningAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/run");
        IdleAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/stand");
        JumpAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/pounce");
        LandingAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/landing");
        SniffAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/sniff");
        HangAnimation = GameInstance.ContentManager.Load<Texture2D>("Textures/Fox/hanging");
    }

    public override void Update(GameTime gameTime)
    {
        
    }
}