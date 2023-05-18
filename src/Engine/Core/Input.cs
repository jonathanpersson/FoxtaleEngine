using Microsoft.Xna.Framework.Input;

namespace MgGame.Engine.Core;

public static class Input
{
    private static KeyboardState _currentKeyboardState;
    private static KeyboardState _previousKeyboardState;
    
    public static void Update()
    {
        _previousKeyboardState = _currentKeyboardState;
        _currentKeyboardState = Keyboard.GetState();
    }

    public static bool IsKeyDown(Keys key)
    {
        return _currentKeyboardState.IsKeyDown(key);
    }

    public static bool IsKeyUp(Keys key)
    {
        return _currentKeyboardState.IsKeyUp(key);
    }

    public static bool IsKeyPressed(Keys key)
    {
        return _currentKeyboardState.IsKeyDown(key) && _previousKeyboardState.IsKeyUp(key);
    }

    public static bool IsKeyReleased(Keys key)
    {
        return _currentKeyboardState.IsKeyUp(key) && _previousKeyboardState.IsKeyDown(key);
    }
}
