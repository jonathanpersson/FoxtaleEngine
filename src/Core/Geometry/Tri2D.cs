using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Foxtale.Core.Geometry;

public struct Tri2D : IFace2D
{
    public Edge2D[] Edges { get; } = new Edge2D[3];
    public Vertex2D[] Vertices { get; } = new Vertex2D[3];

    public Tri2D()
    {

    }

    public Tri2D(Edge2D e1, Edge2D e2, Edge2D e3)
    {
        List<Vertex2D> vertices = new(){e1.Start, e1.End, e2.Start, e2.End, e3.Start, e3.End};
        Edges[0] = e1;
        Edges[1] = e2;
        Edges[2] = e3;
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
        Edges[0] = new Edge2D(v1, v2);
        Edges[1] = new Edge2D(v2, v3);
        Edges[2] = new Edge2D(v3, v1);
    }

    public Tri2D(Vector2 a, Vector2 b, Vector2 c)
    {
        Vertices[0] = new Vertex2D(a);
        Vertices[1] = new Vertex2D(b);
        Vertices[2] = new Vertex2D(c);
        Edges[0] = new Edge2D(Vertices[0], Vertices[1]);
        Edges[1] = new Edge2D(Vertices[1], Vertices[2]);
        Edges[2] = new Edge2D(Vertices[2], Vertices[0]);
    }

    public bool Intersects(IFace2D tri)
    {
        throw new NotImplementedException();
    }

    public bool Contains(Vector2 point)
    {
        throw new NotImplementedException();
    }
}
