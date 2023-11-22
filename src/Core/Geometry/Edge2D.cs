using System;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Core.Geometry;

public struct Edge2D
{
    public Vertex2D Start { get; set; }
    public Vertex2D End { get; set; }
    public readonly float X1 => Start.X;
    public readonly float X2 => End.X;
    public readonly float Y1 => Start.Y;
    public readonly float Y2 => End.Y;
    public readonly float Length => 
        MathF.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1));

    public (Edge2D, Edge2D) Subdivide()
    {
        throw new NotImplementedException();
    }

    public Vertex2D Connected(Vertex2D vert)
    {
        return vert == Start ? End : Start;
    }
}
