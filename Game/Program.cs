using System.Numerics;
using System.Security.Cryptography;
using Game;
using GameObjects;
using Raylib_cs;

namespace Main;

class Program
{
    
    public static int Width = 800;
    public static int Height = 400;
    
    public static Player Player = new Player(100, 100, 30, 30);

    public static Camera2D camera = new Camera2D(new Vector2(Width/2, Height/2),
        Player.GetPosition() + new Vector2(Player.GetWidth(), Player.GetHeight()), 0, 1);
    
    public static void Main()
    {
        World.InitWorld();
        
        Raylib.InitWindow(Width, Height, "Hello World");
        
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            Update();
            
            Draw();
        }

        Raylib.CloseWindow();
    }

    public static void Update()
    {
        Player.Update();
        camera.Target = Player.GetPosition();
    }


    public static void Draw()
    {
        
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.SkyBlue);
        
        Raylib.BeginMode2D(camera);
        
        Mode2D();
        
        Raylib.EndMode2D();
        
        Raylib.EndDrawing();
        
    }
    
    public static void Mode2D()
    {
        //stars.Draw((int)camera.Target.X - Width / 2, (int)camera.Target.Y - Height / 2);
            
        Player.Draw();
            
        World.DrawWorld();
    }
}