using Foxtale.Core.Geometry;
using Foxtale.Entities;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.Physics.Colliders;

public class Box2DCollider : ICollider
{
    private Mesh2D _mesh;
    private Transform2D _transform;
    public IEntity Entity { get; set; }
    public Mesh2D Mesh => _mesh;
    public Transform2D Transform => _transform;

    public Box2DCollider(Transform2D transform)
    {
        //TODO: mesh location should be linked to transform!
        _transform = transform;
        Vertex2D a = new(0 - transform.Origin.X, 
            transform.Size.Y - transform.Origin.Y);
        Vertex2D b = new(transform.Size.X - transform.Origin.X,
            transform.Size.Y - transform.Origin.Y);
        Vertex2D c = new(transform.Size.X - transform.Origin.X,
            0 - transform.Origin.Y);
        Vertex2D d = new(0 - transform.Origin.X,
            0 - transform.Origin.Y);
        Polygon2D quad = new(a, b, c, d);
        _mesh = Mesh2D.FromPolygon(quad);
    }

    public bool Intersects(ICollider collider)
    {
        Vector2 dist = Transform.Position - Transform.Origin -
                       (collider.Transform.Position - collider.Transform.Origin);
        return _mesh.Intersects(collider.Mesh, dist);
    }

    public void Destroy()
    {

    }
}
