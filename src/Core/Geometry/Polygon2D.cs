using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Foxtale.Core.Geometry;

/// <summary>
/// Generic polygon with n faces
/// </summary>
public struct Polygon2D : IFace2D
{
    public Vertex2D[] Vertices { get; set; }
    public Edge2D[] Edges { get; set; }
    public readonly Vertex2D TopmostVertex
    {
        get
        {
            Vertex2D v = Vertices[0];
            for (int i = 1; i <= 2; i++) if (v.Y < Vertices[i].Y) v = Vertices[i];
            return v;
        }
    }
    public readonly Vertex2D BottommostVertex
    {
        get
        {
            Vertex2D v = Vertices[0];
            for (int i = 1; i <= 2; i++) if (v.Y > Vertices[i].Y) v = Vertices[i];
            return v;
        }
    }
    public readonly Vertex2D LeftmostVertex
    {
        get
        {
            Vertex2D v = Vertices[0];
            for (int i = 1; i <= 2; i++) if (v.X < Vertices[i].X) v = Vertices[i];
            return v;
        }
    }
    public readonly Vertex2D RightmostVertex
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
        return Raycast(Axis2D.X, point, LeftmostVertex.X >= point.X) % 2 == 1;
    }

    /// <summary>
    /// Count edge intersections on ray cast from point in given direction
    /// </summary>
    /// <param name="axis">Axis to cast ray on</param>
    /// <param name="point">Origin of raycat</param>
    /// <param name="direction">Single bit direction, false = -axis, true = +axis</param>
    /// <returns>Amount of times ray with origin (point) intersects an edge when cast on (dir +/-) axis</returns>
    public int Raycast(Axis2D axis, Vector2 point, bool direction)
    {
        // cast a ray on given axis from point, heading in (true = +, false = -) direction
        Edge2D ray = axis == Axis2D.X 
            ? new(new Vertex2D(point), new Vertex2D(direction ? RightmostVertex.X + 1 : LeftmostVertex.X - 1, point.Y)) 
            : new(new Vertex2D(point), new Vertex2D(point.X, direction ? TopmostVertex.Y + 1 : BottommostVertex.Y - 1));
        int res = 0;
        foreach (Edge2D edge in Edges)
        {
            if (edge.Intersects(ray)) ++res;
        }
        return res;
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

    /// <summary>
    /// Draw edges and vertices of polygon
    /// </summary>
    /// <param name="sb">SpriteBatch to draw with</param>
    /// <param name="color">Color to draw polygon in</param>
    /// <remarks>Should only be used for debug purposes, no care is given to optimization</remarks>
    public void Draw(SpriteBatch sb, Color? color)
    {
        foreach (Edge2D edge in Edges) edge.Draw(sb, color);
    }
}
