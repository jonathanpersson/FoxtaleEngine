using System;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace MgGame.Engine.Core;

public class Quadrilateral
{
    public Vector2 A { get; set; }
    public Vector2 B { get; set; }
    public Vector2 C { get; set; }
    public Vector2 D { get; set; }

    public Vector2 Centerpoint
    {
        get
        {
            float m = 1 / (6 * Area);

            float fx(Vector2 first, Vector2 second)
            {
                return (first.X + second.X) * ((first.X * second.Y) - (second.X * first.Y));
            }

            float fy(Vector2 first, Vector2 second)
            {
                return (first.Y + second.Y) * ((first.X * second.Y) - (second.X * first.Y));
            }

            return new Vector2(
                m * (fx(A, B) + fx(B, C) + fx(C, D) + fx(D, A)),
                m * (fy(A, B) + fy(B, C) + fy(C, D) + fy(D, A))
            );
        }
    }

    public Vector2 Origin { get; set; }

    public float AB => Distance(A, B);
    public float BC => Distance(B, C);
    public float CD => Distance(C, D);
    public float DA => Distance(D, A);
    public float AC => Distance(A, C);
    public float BD => Distance(B, D);

    public float Area => 0.5 *
        ((A.X * B.Y) - (A.Y * B.X) + (B.X * C.Y) - (B.Y * C.X) + (C.X * D.Y) - (C.Y * D.X) + (D.X * A.Y) - (D.Y * A.X));

    public float AngleA => Angle(DA, AC, CD) + Angle(BC, AB, AC);
    public float AngleB => Angle(DA, AB, BD) + Angle(CD, BD, BC);
    public float AngleC => Angle(AB, BC, AC) + Angle(DA, AC, CD);
    public float AngleD => Angle(BC, CD, BD) + Angle(AB, BD, DA);

    /// <summary>
    /// Construct a quadrilateral from the cartesian coordinates of its corners
    /// </summary>
    /// <param name="a">Bottom-left coordinate</param>
    /// <param name="b">Bottom-right coordinate</param>
    /// <param name="c">Top-right coordinate</param>
    /// <param name="d">Top-left coordinate</param>
    public Quadrilateral(Vector2 a, Vector2 b, Vector2 c, Vector2 d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
        Origin = Centerpoint - D;
    }

    /// <summary>
    /// Construct a quadrilateral from a simple rectangle
    /// </summary>
    /// <param name="rectangle">Rectangle to copy</param>
    public Quadrilateral(RectangleF rectangle)
    {
        A = new Vector2(rectangle.BottomLeft.X, rectangle.BottomLeft.Y);
        B = new Vector2(rectangle.BottomRight.X, rectangle.BottomRight.Y);
        C = new Vector2(rectangle.TopRight.X, rectangle.TopRight.Y);
        D = new Vector2(rectangle.TopLeft.X, rectangle.TopLeft.Y);
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
