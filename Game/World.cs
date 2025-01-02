using System.Data;
using GameObjects;
using Raylib_cs;

namespace Game;

public class World
{

    public static List<Body> WorldComponents = new List<Body>();

    private static Random rand = new Random();

    public static void InitWorld()
    {

        //StaticBody body1 = new StaticBody(100, 100, 100, 400, Color.White);
        //StaticBody body2 = new StaticBody(350, 350, 100, 80, Color.White);
        
        WorldComponents.Add(new StaticBody(-100, 300, 1000, 100, Color.White));
        WorldComponents.Add(new StaticBody(350, 150, 100, 200, Color.White));
        
    }

    public static void DrawWorld()
    {
        foreach (var x in WorldComponents)
        {
            x.Draw();
        }
    }

}