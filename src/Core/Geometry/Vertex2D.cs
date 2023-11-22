using Foxtale.Core.Geometry;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public struct Vertex2D : IEquatable<Vertex2D>
{
    public Vector2 Position { get; set; }
    public Vector2 Normal { get; set; }
    public Vector2 UVPosition { get; set; }
    public readonly float X => Position.X;
    public readonly float Y => Position.Y;

    public Vertex2D(float x, float y)
    {
        Position = new Vector2(x, y);
        Normal = Vector2.Zero;
        UVPosition = Vector2.Zero;
    }

    public Vertex2D(Vector2 pos)
    {
        Position = pos;
        Normal = Vector2.Zero;
        UVPosition = Vector2.Zero;
    }

    public Vertex2D(Vertex2D copy)
    {
        Position = copy.Position;
        Normal = Vector2.Zero;
        UVPosition = Vector2.Zero;
    }

    public static bool operator ==(Vertex2D a, Vertex2D b)
        => a.GetHashCode() == b.GetHashCode();
    public static bool operator !=(Vertex2D a, Vertex2D b)
        => a.GetHashCode() != b.GetHashCode();

    public bool Equals(Vertex2D vert)
    {
        return GetHashCode() == vert.GetHashCode();
    }
    
    public override bool Equals(object obj)
    {
        return obj is Vertex2D && Equals((Vertex2D)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Position.GetHashCode(), Normal.GetHashCode(), UVPosition.GetHashCode());
    }
}