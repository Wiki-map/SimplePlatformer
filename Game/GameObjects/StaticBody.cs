using System.Numerics;
using System.Security.Cryptography;
using Main;
using Raylib_cs;

namespace GameObjects;

public class StaticBody : Body
{
    private Vector2 position;

    private int Height;

    private int Width;

    private Color color;

    public StaticBody(int x, int y, int w, int h, Color color)
    {
        this.position = new Vector2(x, y);
        this.Height = h;
        this.Width = w;
        this.color = color;
    }

    public void Draw()
    {
        Raylib.DrawRectangle((int) position.X, (int) position.Y, Width, Height, color);
    }

    public Vector2 GetPosition()
    {
        return position;
    }

    public int GetHeight()
    {
        return Height;
    }

    public int GetWidth()
    {
        return Width;
    }

}