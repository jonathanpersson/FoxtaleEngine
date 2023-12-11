using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Foxtale.Core.Geometry;

public struct Tri2D : IFace2D
{
    public Vertex2D[] Vertices { get; } = new Vertex2D[3];
    public readonly Vertex2D A => Vertices[0];
    public readonly Vertex2D B => Vertices[1];
    public readonly Vertex2D C => Vertices[2];
    public readonly Edge2D AB => new(A, B);
    public readonly Edge2D BC => new(B, C);
    public readonly Edge2D CA => new(C, A);
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

    public Tri2D(Edge2D e1, Edge2D e2, Edge2D e3)
    {
        List<Vertex2D> vertices = new(){e1.Start, e1.End, e2.Start, e2.End, e3.Start, e3.End};
        int j = 0;

        for (int i = 0; i < vertices.Count; i++)
        {
            if (Vertices.Contains(vertices[i])) continue;
            Vertices[j++] = vertices[i];
        }
    }

    public Tri2D(Vertex2D v1, Vertex2D v2, Vertex2D v3)
    {
        Vertices[0] = v1;
        Vertices[1] = v2;
        Vertices[2] = v3;
    }

    public Tri2D(Vector2 a, Vector2 b, Vector2 c)
    {
        Vertices[0] = new Vertex2D(a);
        Vertices[1] = new Vertex2D(b);
        Vertices[2] = new Vertex2D(c);
    }

    public void Move(Vector2 dist)
    {
        for (int i = 0; i <= 3; i++)
            Vertices[i].Position += dist;
    }

    /// <summary>
    /// Calculate if a face intersects the tri
    /// </summary>
    /// <param name="face">Face to calculate intersection with</param>
    /// <returns>True iff tri intersects face</returns>
    /// <exception cref="InvalidOperationException">If face is not a tri</exception>
    public bool Intersects(IFace2D face)
    {
        if (face is not Tri2D tri)
            throw new InvalidOperationException("Tri can only calculate intersection with tris");
        return Intersects(tri);
    }

    /// <summary>
    /// Caclulate if tri intersects another
    /// </summary>
    /// <param name="tri">Tri to check intersection against</param>
    /// <returns>True iff tri intersects</returns>
    public bool Intersects(Tri2D tri)
    {
        return Contains(tri.A.Position) || Contains(tri.B.Position) || Contains(tri.C.Position);
    }

    /// <summary>
    /// Calculate if a given point exists within the tri
    /// </summary>
    /// <param name="point">Point to check</param>
    /// <returns>True iff point exists within the tri</returns>
    public bool Contains(Vector2 point)
    {
        static float distFromVertexPlane(Vector2 point, Vertex2D v1, Vertex2D v2) 
            => (v1.X - v2.X) * (point.Y - v2.Y) - (v1.Y - v2.Y) * (point.X - v2.X);

        // calculate distance from two of the planes created between vertices
        float distP1 = distFromVertexPlane(point, Vertices[0], Vertices[2]);
        float distP2 = distFromVertexPlane(point, Vertices[1], Vertices[0]);

        // if distP1 and distP2 have opposite signs (and != 0)
        // then tri cannot contain point
        if (distP1 != 0 && distP2 != 0 && (distP1 < 0) != (distP2 < 0))
            return false;
        
        float distP3 = distFromVertexPlane(point, Vertices[2], Vertices[1]);
        return distP3 == 0 || (distP3 < 0) == (distP1 + distP2 <= 0);
    }

    /// <summary>
    /// Get a polygon representing tri
    /// </summary>
    /// <returns>Polygon sharing vertices with this tri</returns>
    public Polygon2D ToPolygon()
    {
        return new Polygon2D(AB, BC, CA);
    }

    /// <summary>
    /// Draw edges and vertices of tri
    /// </summary>
    /// <param name="sb">SpriteBatch to draw with</param>
    /// <param name="color">Color to draw polygon in</param>
    /// <remarks>Should only be used for debug purposes, no care is given to optimization</remarks>
    public void Draw(SpriteBatch sb, Color? color)
    {
        Polygon2D p = ToPolygon();
        foreach (Edge2D edge in p.Edges) edge.Draw(sb, color);
    }
}
