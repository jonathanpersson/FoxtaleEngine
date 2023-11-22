using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Foxtale.Core.Geometry;

public interface IFace2D
{
    public Edge2D[] Edges { get; }
    public Vertex2D[] Vertices { get; }
    public bool Contains(Vector2 point);
    public bool Intersects(IFace2D face);
}
