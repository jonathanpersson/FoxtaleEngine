using System;
using Microsoft.Xna.Framework;

namespace MgGame.Engine.Core;

public class Quadrilateral
{
    public Vector2 A { get; set; }
    public Vector2 B { get; set; }
    public Vector2 C { get; set; }
    public Vector2 D { get; set; }

    public float AB => Distance(A, B);
    public float BC => Distance(B, C);
    public float CD => Distance(C, D);
    public float DA => Distance(D, A);
    public float AC => Distance(A, C);
    public float BD => Distance(B, D);

    public float AngleA => Angle(DA, AC, CD) + Angle(BC, AB, AC);
    public float AngleB => Angle(DA, AB, BD) + Angle(CD, BD, BC);
    public float AngleC => Angle(AB, BC, AC) + Angle(DA, AC, CD);
    public float AngleD => Angle(BC, CD, BD) + Angle(AB, BD, DA);

    public Quadrilateral()
    {
        A = Vector2.Zero;
        B = Vector2.Zero;
        C = Vector2.Zero;
        D = Vector2.Zero;
    }

    public static float Distance(Vector2 a, Vector2 b)
    {
        return (float)Math.Abs(Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2)));
    }

    private static float Angle(float a, float b, float c)
    {
        return (float)Math.Acos(((b * b) + (c * c) - (a * a)) / (2 * b * c));
    }
}
