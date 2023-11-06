using System;
using System.Reflection.Metadata;
using Foxtale.Core;
using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Components;

public enum DockStyle
{
    TopLeft,
    TopCenter,
    TopRight,
    MiddleLeft,
    MiddleCenter,
    MiddleRight,
    BottomLeft,
    BottomCenter,
    BottomRight,
    None
}

public class DockTransform : IComponent
{
    private DockStyle _style = DockStyle.None;
    private Vector2 _offset = Vector2.Zero;
    public IEntity Entity { get; set; }
    public Transform2D Transform { get; }
    public DockStyle Style
    {
        get => _style;
        set
        {
            _style = value;
            PerformDock();
        }
    }
    public Vector2 Offset
    {
        get => _offset;
        set
        {
            _offset = value;
            PerformDock();
        }
    }
    
    public DockTransform(Transform2D transform, DockStyle dock)
    {
        _style = dock;
        Transform = transform;
        _offset = Transform.Position;
        GameInstance.ActiveWindow.ClientSizeChanged += HandleWindowResize;
        DockTransformSystem.AddComponent(this);
        PerformDock();
    }

    private void PerformDock() {
        Vector2 newPos = Transform.Position;

        switch(Style)
        {
            case DockStyle.TopLeft:
                break;
            case DockStyle.TopCenter:
                newPos.X = GameInstance.ActiveWindow.ClientBounds.Width / 2;
                break;
            case DockStyle.TopRight:
                newPos.X = GameInstance.ActiveWindow.ClientBounds.Width;
                break;
            case DockStyle.MiddleLeft:
                newPos.Y = GameInstance.ActiveWindow.ClientBounds.Height / 2;
                break;
            case DockStyle.MiddleCenter:
                newPos.X = GameInstance.ActiveWindow.ClientBounds.Width / 2;
                newPos.Y = GameInstance.ActiveWindow.ClientBounds.Height / 2;
                break;
            case DockStyle.MiddleRight:
                newPos.X = GameInstance.ActiveWindow.ClientBounds.Width;
                newPos.Y = GameInstance.ActiveWindow.ClientBounds.Height / 2;
                break;
            case DockStyle.BottomLeft:
                newPos.Y = GameInstance.ActiveWindow.ClientBounds.Height;
                break;
            case DockStyle.BottomCenter:
                newPos.X = GameInstance.ActiveWindow.ClientBounds.Width / 2;
                newPos.Y = GameInstance.ActiveWindow.ClientBounds.Height;
                break;
            case DockStyle.BottomRight:
                newPos.X = GameInstance.ActiveWindow.ClientBounds.Width;
                newPos.Y = GameInstance.ActiveWindow.ClientBounds.Height;
                break;
            default:
                break;
        }

        newPos.X += _offset.X;
        newPos.Y += _offset.Y;

        Transform.Position = newPos;
    }

    private void HandleWindowResize(object sender, EventArgs e)
    {
        PerformDock();
    }

    public void Destroy()
    {
        
    }
}
