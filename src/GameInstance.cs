using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.BitmapFonts;
using MgGame.Engine.Systems;
using MgGame.Engine.UI;

namespace MgGame;

public class GameInstance : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public GameInstance()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {

        // init graphics settings
        IsFixedTimeStep = false;
        _graphics.GraphicsProfile = GraphicsProfile.HiDef;
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.PreferMultiSampling = true;
        _graphics.SynchronizeWithVerticalRetrace = false;
        _graphics.ApplyChanges();

        // initialize UI system
        UserInterface.Initialize();

        // init systems here
        Transform2DSystem.Initialize();
        SpriteSystem.Initialize();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        //TODO: Load the most essential content here, then
        // load the rest of the content during loading screens
        UserInterface.LoadContent(Content.Load<BitmapFont>("Fonts/PressStart2P"));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Transform2DSystem.Update(gameTime);
        SpriteSystem.Update(gameTime);

        UserInterface.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();

        // TODO: Add your drawing code here
        //UserInterface.Active.Draw(_spriteBatch);

        UserInterface.Draw(_spriteBatch);

        _spriteBatch.End();
    }
}
