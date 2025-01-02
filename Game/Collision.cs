using System.ComponentModel;

namespace Game;

public class Collision
{

    public static bool IsColliding(Player player, GameObjects.Body block)
    {

        int x1 = (int) player.GetPosition().X, y1 = (int) player.GetPosition().Y;

        int h1 = player.GetHeight(), w1 = player.GetWidth();

        int x2 = (int) block.GetPosition().X, y2 = (int) block.GetPosition().Y;

        int h2 = block.GetHeight(), w2 = block.GetWidth();

        if (x1 + w1 > x2 && x1 < x2 + w2)
        {
            if (y1 + h1 > y2 && y1 < y2 + h2)
            {
                return true;
            }
        }

        return false;

    }

    public static void MakeCollision(Player player, GameObjects.Body block)
    {
        if (!IsColliding(player, block))
        {
            return;
        }
        
        int x1 = (int) player.GetPosition().X, y1 = (int) player.GetPosition().Y;

        int h1 = player.GetHeight(), w1 = player.GetWidth();

        int x2 = (int) block.GetPosition().X, y2 = (int) block.GetPosition().Y;

        int h2 = block.GetHeight(), w2 = block.GetWidth();

        int left = (x1 + w1) - x2;
        int right = (x2 + w2) - x1;
        int top = (y1 + h1) - y2;
        int bottom = (y2 + h2) - y1;

        if (left < right && left < top && left < bottom)
        {
            player.ChangePosition(x2 - w1, y1);
            player.ChangeVelocityX(0);
        }
        else if (right < left && right < top && right < bottom)
        {
            player.ChangePosition(x2 + w2, y1);
            player.ChangeVelocityX(0);
        }
        else if (top < left && top < bottom && top < right)
        {
            player.ChangePosition(x1,y2 - h1);
            player.ChangeVelocityY(0);
            player.IsGround(true);
        }
        else if (bottom < right && bottom < left && bottom < right)
        {
            player.ChangePosition(x1,y2 + h2);
            player.ChangeVelocityY(0);
        }

    }
    
}