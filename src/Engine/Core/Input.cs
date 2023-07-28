using Microsoft.Xna.Framework.Input;

namespace Foxtale.Engine.Core;

//todo: extend
public static class Input
{
    private static KeyboardState _currentKeyboardState;
    private static KeyboardState _previousKeyboardState;
    private static MouseState _currentMouseState;
    private static MouseState _previousMouseState;
    private static GamePadState _currentGamePadState;
    private static GamePadState _previousGamePadState;
    
    public static void Update()
    {
        _previousKeyboardState = _currentKeyboardState;
        _currentKeyboardState = Keyboard.GetState();
    }

    public static bool KeyDown(Keys key)
    {
        return _currentKeyboardState.IsKeyDown(key);
    }

    public static bool KeyUp(Keys key)
    {
        return _currentKeyboardState.IsKeyUp(key);
    }

    public static bool KeyPressed(Keys key)
    {
        return _currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key);
    }

    public static bool KeyReleased(Keys key)
    {
        return _currentKeyboardState.IsKeyUp(key) && _previousKeyboardState.IsKeyDown(key);
    }
}
