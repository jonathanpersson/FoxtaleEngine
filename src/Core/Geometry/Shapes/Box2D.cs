using Foxtale.Core.Geometry;

namespace Foxtale.Core.Geometry.Shapes;

/// <summary>
/// Wrapper for Mesh2D representing a simple two-dimensional box
/// </summary>
public class Box2D
{
    public Origin2D Origin { get; set; }

    public Box2D(float width, float height)
    {
        Origin = Origin2D.MiddleCenter;
    }
}
