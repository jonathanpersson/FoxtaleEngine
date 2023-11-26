using Foxtale.Core.Geometry;
using Foxtale.Entities;

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
        _transform = transform;
        Vertex2D a = new(transform.Position.X - transform.Origin.X, 
            transform.Position.Y - transform.Origin.Y);
        Vertex2D b = new(transform.Position.X + transform.Size.X - transform.Origin.X,
            transform.Position.Y - transform.Origin.Y);
        Vertex2D c = new(transform.Position.X + transform.Size.X - transform.Origin.X,
            transform.Position.Y - transform.Size.Y - transform.Origin.Y);
        Vertex2D d = new(transform.Position.X - transform.Origin.X,
            transform.Position.Y - transform.Size.Y - transform.Origin.Y);
        Polygon2D quad = new(new Edge2D(a, b), 
                                new Edge2D(b, c), 
                                new Edge2D(c, d), 
                                new Edge2D(d, a));
        _mesh = Mesh2D.FromPolygon(quad);
    }

    public bool Intersects(ICollider collider)
    {
        return _mesh.Intersects(collider.Mesh);
    }

    public void Destroy()
    {

    }
}
