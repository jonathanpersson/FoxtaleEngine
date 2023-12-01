using System;

namespace Foxtale.Core.Collections;

public class DataMatrix<T>
{
    private const int DefaultSize = 16;
    private (int x, int y) _offset;
    private T[,] _data;
    public int Width => _data.GetLength(0);
    public int Height => _data.GetLength(1);

    public T this[int x, int y]
    {
        get => _data[x + _offset.x, y + _offset.y];
        set => _data[x + _offset.y, y + _offset.y] = value;
    }

    public DataMatrix()
    {
        _data = new T[DefaultSize,DefaultSize];
        _offset.x = _offset.y = DefaultSize / 2;
    }

    /// <summary>
    /// Construct a new DataMatrix with given side length
    /// </summary>
    /// <remarks>sideLength must be an even number!</remarks>
    /// <param name="sideLength">Length of matrix side, must be an even number!</param>
    public DataMatrix(int sideLength)
    {
        if (sideLength % 2 != 0) 
            throw new ArgumentException("DataMatrix side length must be an even number!");
        _data = new T[sideLength, sideLength];
        _offset.x = _offset.y = sideLength / 2;
    }

    /// <summary>
    /// Construct a new DataMatrix of given width and height
    /// </summary>
    /// <remarks>Width and height must both be even numbers!</remarks>
    /// <param name="width">Width of matrix, must be an even number</param>
    /// <param name="height">Height of matrix, must be an even number</param>
    public DataMatrix(int width, int height)
    {
        if (width % 2 != 0 || height % 2 != 0) 
            throw new ArgumentException("DataMatrix side length must be an even number!");
        _data = new T[width, height];
        _offset.x = width / 2;
        _offset.y = height / 2;
    }
}
