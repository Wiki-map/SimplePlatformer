using System.Numerics;
using Raylib_cs;

namespace Game;

public class Player
{

    private Vector2 position;
    private Vector2 velocity;
    private int height, width;
    private const float FrictionConst = 0.2f;
    public bool IsOnGround;

    public Player(int x, int y, int h, int w)
    {

        position = new Vector2(x, y);
        height = h;
        width = w;

        velocity = new Vector2(0, 0);

    }

    public void Update()
    {
        
        position += velocity;
        
        float Gravity = 1.2f;

        velocity.Y += Gravity;
        
        //moves left
        if (Raylib.IsKeyDown(KeyboardKey.A) || Raylib.IsKeyDown(KeyboardKey.Left))
        {
            velocity.X -= 3;
        }
        
        //moves right
        if (Raylib.IsKeyDown(KeyboardKey.D) || Raylib.IsKeyDown(KeyboardKey.Right))
        {
            velocity.X += 3;
        }
        
        //adds friction to the players velocity
        float Friction = Math.Abs(velocity.X) * FrictionConst;

        if (velocity.X > 0)
        {
            velocity.X -= Friction;
        }
        else
        {
            velocity.X += Friction;
        }

        if (velocity.X < 0.01 && velocity.X > -0.1) velocity.X = 0;
        
        //jumps
        if (IsOnGround && (Raylib.IsKeyDown(KeyboardKey.Space) || Raylib.IsKeyDown(KeyboardKey.Up)))
        {
            velocity.Y -= 20;
        }

        IsOnGround = false;
        
        foreach (var x in World.WorldComponents)
        {
            Collision.MakeCollision(this, x);
        }
        
       // Console.WriteLine(velocity);

    }

    public void Draw()
    {
        
        Raylib.DrawRectangle((int) position.X, (int) position.Y, height, width, Color.White);
        
    }

    public Vector2 GetPosition()
    {
        return position;
    }

    public int GetHeight()
    {
        return height;
    }

    public int GetWidth()
    {
        return width;
    }

    public void ChangePosition(int x,int y)
    {
        position = new Vector2(x, y);
    }

    public void IsGround(bool IsOnGround)
    {
        this.IsOnGround = IsOnGround;
    }

    public void ChangeVelocityY(float y)
    {
        velocity.Y = y;
    }

    public void ChangeVelocityX(float x)
    {
        velocity.X = x;
    }
    

}