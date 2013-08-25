using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD27
{
    static class CollisionHandler
    {
        static Rectangle obstacleRectangle;

        public static bool IsVerticalCollision(Rectangle playerRectangle, List<Obstacle> obstacles)
        {
            foreach (Obstacle o in obstacles)
            {
                obstacleRectangle = new Rectangle((int)o.X, (int)o.Y, o.texture.Width, o.texture.Height);
                if (playerRectangle.Intersects(obstacleRectangle) && playerRectangle.Top < obstacleRectangle.Bottom && playerRectangle.Bottom > obstacleRectangle.Bottom)
                    return true;
            }

            return false;
        }

        public static bool IsLeftHorizontalCollision(Rectangle playerRectangle, List<Obstacle> obstacles)
        {
            foreach (Obstacle o in obstacles)
            {
                obstacleRectangle = new Rectangle((int)o.X, (int)o.Y, o.texture.Width, o.texture.Height);
                if (playerRectangle.Intersects(obstacleRectangle) &&  playerRectangle.Left < obstacleRectangle.Right && playerRectangle.Right > obstacleRectangle.Right)
                    return true;
            }

            return false;
        }

        public static bool IsRightHorizontalCollision(Rectangle playerRectangle, List<Obstacle> obstacles)
        {
            foreach (Obstacle o in obstacles)
            {
                obstacleRectangle = new Rectangle((int)o.X, (int)o.Y, o.texture.Width, o.texture.Height);
                if (playerRectangle.Intersects(obstacleRectangle) && playerRectangle.Right > obstacleRectangle.Left && playerRectangle.Left < obstacleRectangle.Left)
                    return true;
            }

            return false;
        }

        public static Vector2 TrapCollisions(Vector2 playerPosition, List<Trap> traps)
        {
            foreach (Trap trap in traps)
            {
                if ((playerPosition - trap.Position).LengthSquared() < 300)
                    return trap.Position;
            }
            return Vector2.Zero;
        }
    }
}
