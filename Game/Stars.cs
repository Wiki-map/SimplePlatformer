using System.Numerics;
using Main;
using Raylib_cs;

namespace GameObjects;

public class Stars
{
    
    //list of all existing stars
    public List<Vector2> StarList = new List<Vector2>();
    
    Random rand = new Random();

    public Stars(int StarMaxCount)
    {
        int StarSize = rand.Next(StarMaxCount / 3,StarMaxCount);

        for (int i = 0; i < StarSize; i++)
        {
            
            //pick random position and add the star
            int StarX = rand.Next(1, Program.Width);
            int StarY = rand.Next(1, Program.Height);
            
            StarList.Add(new Vector2(StarX,StarY));
        }
    }

    public void Draw(int offsetX, int offsetY)
    {
        foreach (var x in StarList)
        {
            int X = (int) x.X + offsetX, Y = (int) x.Y + offsetY;
            Raylib.DrawPixel(X,Y,Color.White);
                
            Raylib.DrawPixel(X+1,Y,Color.White);
            Raylib.DrawPixel(X-1,Y,Color.White);
            Raylib.DrawPixel(X,Y+1,Color.White);
            Raylib.DrawPixel(X,Y-1,Color.White);
        }
    }

}