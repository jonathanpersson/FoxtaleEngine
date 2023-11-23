using System;
using System.Collections.Generic;
using Foxtale.Exceptions;

namespace Foxtale.Core.Geometry;

public struct Mesh2D : IMesh
{
    public List<Tri2D> Tris { get; set; } = [];

    public Mesh2D()
    {

    }

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
        throw new NotImplementedException();
    }

    /// <summary>
    /// Create a new mesh from intersecting area
    /// </summary>
    /// <remarks>Assumes meshes _ARE_ intersecting!</remarks>
    /// <param name="m"></param>
    /// <returns></returns>
    private Mesh2D IntersectionMesh(Mesh2D m)
    {
        throw new NotImplementedException();
    }
}
