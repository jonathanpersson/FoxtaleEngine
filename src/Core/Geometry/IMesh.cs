namespace Foxtale.Core.Geometry;

public interface IMesh
{
    public bool Intersects(IMesh m);
    public IMesh Intersection(IMesh m);
}
