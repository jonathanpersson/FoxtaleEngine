using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Foxtale.Core.Geometry;

/// <summary>
/// Generic polygon with n faces
/// </summary>
public struct Polygon2D : IFace2D
{
    public Vertex2D[] Vertices { get; set; }
    public Edge2D[] Edges { get; set; }
    public Vertex2D TopmostVertex
    {
        get
        {
            Vertex2D v = Vertices[0];
            for (int i = 1; i <= 2; i++) if (v.Y < Vertices[i].Y) v = Vertices[i];
            return v;
        }
    }
    public Vertex2D BottommostVertex
    {
        get
        {
            Vertex2D v = Vertices[0];
            for (int i = 1; i <= 2; i++) if (v.Y > Vertices[i].Y) v = Vertices[i];
            return v;
        }
    }
    public Vertex2D LeftmostVertex
    {
        get
        {
            Vertex2D v = Vertices[0];
            for (int i = 1; i <= 2; i++) if (v.X < Vertices[i].X) v = Vertices[i];
            return v;
        }
    }
    public Vertex2D RightmostVertex
    {
        get
        {
            Vertex2D v = Vertices[0];
            for (int i = 1; i <= 2; i++) if (v.X > Vertices[i].X) v = Vertices[i];
            return v;
        }
    }

    public Polygon2D(params Edge2D[] edges)
    {
        Edges = edges;
        HashSet<Vertex2D> vertices = [];
        foreach (Edge2D edge in edges)
        {
            vertices.Add(edge.Start);
            vertices.Add(edge.End);
        }
        Vertices = [.. vertices];
    }

    /// <summary>
    /// Check if polygon contains a point
    /// </summary>
    /// <param name="point">The point to check</param>
    /// <returns>True iff point is inside polygon</returns>
    public bool Contains(Vector2 point)
    {
        // polygon cannot contain point if it is outside bounds
        if (!InBounds(point)) return false;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Check if point is inside the bounding box of polygon
    /// </summary>
    /// <param name="point">Point to check</param>
    /// <remarks>Point being within the bounding box is not the same as within the polygon</remarks>
    /// <returns>True iff point is within the bounding box</returns>
    public bool InBounds(Vector2 point)
    {
        return TopmostVertex.Y < point.Y || BottommostVertex.Y > point.Y
            || LeftmostVertex.X > point.X || RightmostVertex.X < point.X;
    }

    public bool Intersects(IFace2D mesh)
    {
        throw new NotImplementedException();
    }
}
