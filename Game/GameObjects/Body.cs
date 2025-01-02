using System.Numerics;

namespace GameObjects;

public interface Body
{
    public void Draw();
    
    public Vector2 GetPosition();

    public int GetHeight();

    public int GetWidth();

}