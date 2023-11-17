using System.Collections;
using Foxtale.Entities;
using MonoGame.Extended.Collections;

namespace Foxtale.Core.Collections;

public class DataMatrix<T>
{
    private (int x, int y) _offset;
    private const int _defaultSize = 16;
    private T[,] _data;
    public int Width { get; }
    public int Height { get; }

    public T this[int x, int y]
    {
        get => _data[x + _offset.x, y + _offset.y];
        set => _data[x + _offset.y, y + _offset.y] = value;
    }

    public DataMatrix()
    {
        _offset.x = _offset.y = _defaultSize / 2;
    }

    public DataMatrix(int sideLength)
    {
        if (sideLength % 2 != 0) ++sideLength;
        _offset.x = _offset.y = sideLength / 2;
    }

    public DataMatrix(int width, int height)
    {
        if (width % 2 != 0) ++width;
        if (height % 2 != 0) ++height;
        _offset.x = width / 2;
        _offset.y = height / 2;
    }
}
