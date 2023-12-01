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
    
    /// <summary>
    /// Construct a 2D polygon from an array of edges
    /// </summary>
    /// <remarks>Polygon should be assumed to be non-hollow</remarks>
    /// <param name="edges">The edges </param>
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
    /// Construct a 2D polygon from an array of vertices.
    /// An edge is made between edge subsequent vertex
    /// </summary>
    /// <remarks>Vertices are assumed to be in order, and polygon should be assumed to be non-hollow</remarks>
    /// <param name="vertices">Vertices (in order) to create edges between</param>
    /// <exception cref="ArgumentOutOfRangeException">Polygon must define at least two vertices to create an edge from</exception>
    public Polygon2D(params Vertex2D[] vertices)
    {
        if (vertices.Length < 2)
            throw new ArgumentOutOfRangeException(nameof(vertices), "Polygon must contain at least one edge!");
        List<Edge2D> edges = [];
        for (int i = 1; i < vertices.Length; i++)
        {
            edges.Add(new Edge2D(vertices[i - 1], vertices[i]));
        }

        edges.Add(new Edge2D(vertices[^1], vertices[0]));
        Vertices = vertices;
        Edges = edges.ToArray();
    }

    public void Add(Vertex2D vertex)
    {
        Vertices = [..Vertices, vertex];
    }

    public void Add(Edge2D edge)
    {
        Edges = [..Edges, edge];
    }

    public void Remove(Vertex2D vertex)
    {
        List<Vertex2D> vertices = [..Vertices];
        vertices.Remove(vertex);
        Vertices = [..vertices];
    }

    public void Remove(Edge2D edge)
    {
        List<Edge2D> edges = [..Edges];
        edges.Remove(edge);
        Edges = [..edges];
    }

    /// <summary>
    /// Get the edges connected to vertex
    /// </summary>
    /// <param name="vertex">The vertex to query connections for</param>
    /// <returns>An array of all edges containing vertex</returns>
    public readonly Edge2D[] GetEdges(Vertex2D vertex)
    {
        return [.. from edge in Edges
            where edge.Start == vertex 
            || edge.End == vertex
            select edge];
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
