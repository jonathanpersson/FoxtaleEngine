using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Foxtale.Core.Geometry;

public struct Edge2D(Vertex2D start, Vertex2D end)
{
    public Vertex2D Start { get; set; } = start;
    public Vertex2D End { get; set; } = end;
    public readonly float X1 => Start.X;
    public readonly float X2 => End.X;
    public readonly float Y1 => Start.Y;
    public readonly float Y2 => End.Y;
    public readonly float MaxX => MathF.Max(X1, X2);
    public readonly float MaxY => MathF.Max(Y1, Y2);
    public readonly float MinX => MathF.Min(X1, X2);
    public readonly float MinY => MathF.Min(X1, X2);
    public readonly float Length => 
        MathF.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1));

    /// <summary>
    /// The axis relative to which the edge is longer
    /// </summary>
    /// <remarks>Slight bias toward X-axis</remarks>
    public readonly Axis2D Horizon
    {
        get
        {
            float diffX = MathF.Abs(Start.X - End.X);
            float diffY = MathF.Abs(Start.Y - End.Y);
            return diffX >= diffY ? Axis2D.X : Axis2D.Y; 
        }
    }

    public (Edge2D, Edge2D) Subdivide()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get connected vertex
    /// </summary>
    /// <param name="vert">The vertex to get connected vertex of</param>
    /// <returns>Start iff vert is End, End iff vert is Start</returns>
    /// <exception cref="ArgumentException">If vertex is not one of the edges two vertices</exception>
    public Vertex2D GetConnectedVertex(Vertex2D vert)
    {
        if (vert != Start && vert != End)
            throw new ArgumentException("Vertex is not part of edge!");
        return vert == Start ? End : Start;
    }

    /// <summary>
    /// Check if edge shares a vertex (is connected)
    /// </summary>
    /// <param name="edge">Edge to check</param>
    /// <returns>True iff edge shares a vertex (is connected to) this edge</returns>
    public bool Connected(Edge2D edge)
    {
        return Start == edge.Start || Start == edge.End
            || End == edge.Start || End == edge.End;
    }

    /// <summary>
    /// Check if edge intersects another
    /// </summary>
    /// <param name="edge">Edge to check against</param>
    /// <returns>True iff edges intersect</returns>
    public bool Intersects(Edge2D edge)
    {
        static bool isCCW(Vertex2D a, Vertex2D b, Vertex2D c) 
            => (c.Y-a.Y)*(b.X-a.X) > (b.Y-a.Y)*(c.X-a.X);
        return isCCW(Start, edge.Start, edge.End) != isCCW(End, edge.Start, edge.End)
            && isCCW(Start, End, edge.Start) != isCCW(Start, End, edge.End);
    }

    public void Draw(SpriteBatch sb, Color? color = null)
    {
        sb.DrawLine(Start.Position, End.Position, color ?? Color.Blue, 1f);
        Start.Draw(sb, color);
        End.Draw(sb, color);
    }
}