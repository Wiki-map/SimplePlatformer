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
        
        
        //WorldComponents.Add(new StaticBody(-100, 300, 1000, 100, Color.White));
        //WorldComponents.Add(new StaticBody(350, 150, 100, 200, Color.White));

        var file = File.OpenRead("/Users/andreialecuizsak/Programing Projects/Simple Platformer/Game/Recourses/world.txt");

        var streamReader = new StreamReader(file);

        string line;

        int LineCount = 0;
        
        while ((line = streamReader.ReadLine()) != null)
        {
            
            Console.WriteLine(line);
            
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '#')
                {
                    WorldComponents.Add(new StaticBody(i* 32, LineCount * 32, 32, 32, Color.White));
                }
                
            }

            LineCount++;

        }

    }

    public static void DrawWorld()
    {
        foreach (var x in WorldComponents)
        {
            x.Draw();
        }
    }

}