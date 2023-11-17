using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Foxtale.Core;

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
        _previousMouseState = _currentMouseState;
        _currentMouseState = Mouse.GetState();
        //todo: gamepad state
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

    public static Vector2 GetMousePosition()
    {
        return new Vector2(_currentMouseState.X, _currentMouseState.Y);
    }

    public static bool LeftMouseDown()
    {
        return _currentMouseState.LeftButton == ButtonState.Pressed;
    }

    public static bool RightMouseDown()
    {
        return _currentMouseState.RightButton == ButtonState.Pressed;
    }

    public static bool MiddleMouseDown()
    {
        return _currentMouseState.MiddleButton == ButtonState.Pressed;
    }
}
