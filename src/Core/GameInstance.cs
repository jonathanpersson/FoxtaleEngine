﻿using System;
using Foxtale.Components;
using Foxtale.Components.Physics;
using Foxtale.Entities;
using Foxtale.Entities.Scenes;
using Foxtale.Systems;
using Foxtale.Systems.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.BitmapFonts;

namespace Foxtale.Core;

public class GameInstance : Game
{
    private static GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    protected static Scene2D ActiveScene { get; set; }
    public static IEnvironment ActiveSceneEnvironment => ActiveScene.Environment;
    
    public static ContentManager ContentManager { get; set; }
    public static Color ClearColor { get; set; } = Color.Black;
    public static GameWindow ActiveWindow { get; private set; }

    public GameInstance()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Logger.Log(LogLevel.Information, "Foxtale Engine is starting...");
    }

    public void Run(Scene2D scene)
    {
        ActiveScene = scene;
        Run();
    }

    protected override void Initialize()
    {

        // init graphics settings
        IsFixedTimeStep = false;
        _graphics.GraphicsProfile = GraphicsProfile.HiDef;
        _graphics.PreferredBackBufferWidth = 960;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.PreferMultiSampling = true;
        _graphics.SynchronizeWithVerticalRetrace = false;
        _graphics.ApplyChanges();

        ContentManager = Content;
        Window.AllowUserResizing = true;

        ActiveWindow = Window;

        // initialize UI system
        UserInterfaceSystem.Initialize(_graphics, Window);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        //TODO: Load the most essential content here, then
        // load the rest of the content during loading screens
        UserInterfaceSystem.LoadContent(Content.Load<BitmapFont>("Fonts/PressStart2P"));
        
        SetScene(new Loading(ActiveScene));
    }

    protected override void Update(GameTime gameTime)
    {
        Input.Update();
        
        if (Input.KeyDown(Keys.Escape)) {
            Logger.Log(LogLevel.Information ,"ESC pressed, shutting down...");
            Exit();
        }
        
        ScriptSystem.Update(gameTime);
        AnimationSetSystem.InitializeComponents();
        AnimatedSpriteSystem.Update(gameTime);

        ActiveScene?.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(ClearColor);

        _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

        // TODO: Add your drawing code here
        //UserInterface.Active.Draw(_spriteBatch);
        
        SpriteSystem.Draw(_spriteBatch);
        AnimatedSpriteSystem.Draw(_spriteBatch);
        TextureStackSystem.Draw(_spriteBatch);

        _spriteBatch.End();
    }

    public static void SetScene(Scene2D scene)
    {
        Logger.Log(LogLevel.Information, "Switching active scene");
        ActiveScene?.Unload();
        ActiveScene = scene;
        ActiveScene.Load();
    }
}
