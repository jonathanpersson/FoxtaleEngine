using System;
using System.Collections.Generic;
using Foxtale.Exceptions;
using Microsoft.Xna.Framework;

namespace Foxtale.Core.Geometry;

/// <summary>
/// A two-dimensional mesh consisting of triangles
/// </summary>
/// <param name="tris">Mesh faces</param>
public struct Mesh2D(params Tri2D[] tris) : IMesh
{
    public List<Tri2D> Tris { get; set; } = new List<Tri2D>(tris);
    public Vector2 Origin { get; set; }

    public bool Intersects(IMesh m)
    {
        if (m is not Mesh2D m2) throw new UndefinedMeshOperationException("Mesh2D can only intersect with other Mesh2D instances.");
        return Intersects(m2);
    }

    public IMesh Intersection(IMesh m)
    {
        if (!Intersects(m)) return new Mesh2D();
        return IntersectionMesh((Mesh2D)m);
    }

    public bool Intersects(Mesh2D m)
    {
        foreach (Tri2D t in m.Tris)
        {
            foreach (Tri2D t1 in Tris) if (t.Intersects(t)) return true;
        }
        return false;
    }

    /// <summary>
    /// Create a new mesh from intersecting area
    /// </summary>
    /// <remarks>Assumes meshes **ARE** intersecting!</remarks>
    /// <param name="m">Mesh to create intersection mesh with</param>
    /// <returns>The mesh of area intersecting with m</returns>
    private Mesh2D IntersectionMesh(Mesh2D m)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Create a new Mesh2D from a polygon with vertex count 3 <= n < int.Max
    /// </summary>
    /// <param name="face">The polygon</param>
    /// <returns>A new (tri-) mesh based on face</returns>
    /// <remarks>Assumes face does not have holes!</remarks>
    /// <exception cref="ArgumentException">face vertex count 0 <= n < 3</exception>
    public static Mesh2D FromPolygon(Polygon2D face)
    {
        if (face.Vertices.Length < 3)
            throw new ArgumentException("Polygon face must have at least three vertices!");
        else if (face.Vertices.Length == 3)
            return new Mesh2D(new Tri2D(face.Vertices[0], face.Vertices[1], face.Vertices[2]));
        return new Mesh2D([..Triangulate(face)]);
    }

    private static List<Tri2D> Triangulate(Polygon2D face)
    {
        if (face.Edges.Length < 2) return [];
        List<Tri2D> tris = [];
        foreach (Vertex2D v in face.Vertices)
        {
            Edge2D[] edges = face.GetEdges(v);
            if (edges.Length != 2) continue;
            Vertex2D u = edges[0].GetConnectedVertex(v);
            Vertex2D w = edges[1].GetConnectedVertex(v);
            Edge2D c = new(u, w);
            float gamma = MathF.Acos((MathF.Pow(edges[0].Length, 2f) 
                + MathF.Pow(edges[1].Length, 2f) 
                - MathF.Pow(c.Length, 2f))
                / (2 * edges[0].Length * edges[1].Length));

            if (gamma < MathF.PI)
            {
                tris.Add(new Tri2D(u, v, w));
                face.Remove(v);
                face.Remove(edges[0]);
                face.Remove(edges[1]);
                face.Add(c);
                break;
            }
        }
        return [..tris, ..Triangulate(face)];
    }
}
