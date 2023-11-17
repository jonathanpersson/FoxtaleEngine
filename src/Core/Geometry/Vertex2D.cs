using Microsoft.Xna.Framework;

public struct Vertex2D
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
}