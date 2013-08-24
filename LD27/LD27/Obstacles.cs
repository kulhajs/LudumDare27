using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD27
{
    static class Obstacles
    {
        public static List<Obstacle> LevelObstacles(int level)
        {
            if (level == 1)
            {
                return new List<Obstacle>() {
                    new Obstacle(new Vector2(-64, 96)),
                    new Obstacle(new Vector2(192, 96)),
                    new Obstacle(new Vector2(96, 192)),
                    new Obstacle(new Vector2(288, 288)),
                    new Obstacle(new Vector2(-96, 352)),
                    new Obstacle(new Vector2(160, 416)),
                    new Obstacle(new Vector2(-32, 512)),
                    new Obstacle(new Vector2(352, 512)),
                    new Obstacle(new Vector2(0, 608)),
                    new Obstacle(new Vector2(288, 608))
                };
            }
            else if (level == 2)
            {
                return new List<Obstacle>(){
                    new Obstacle(new Vector2(-32, 96)),
                    new Obstacle(new Vector2(320, 96)),
                    new Obstacle(new Vector2(64, 192)),
                    new Obstacle(new Vector2(288, 192)),
                    new Obstacle(new Vector2(-32, 288)),
                    new Obstacle(new Vector2(256, 288)),
                    new Obstacle(new Vector2(-64, 352)),
                    new Obstacle(new Vector2(192, 352)),
                    new Obstacle(new Vector2(416, 352)),
                    new Obstacle(new Vector2(32, 448)),
                    new Obstacle(new Vector2(288, 448)),
                    new Obstacle(new Vector2(-128, 544)),
                    new Obstacle(new Vector2(128, 544)),
                    new Obstacle(new Vector2(384, 544)),
                    new Obstacle(new Vector2(-64, 608)),
                    new Obstacle(new Vector2(352, 608)),
                };
            }
            else
                return new List<Obstacle>();
        }
    }
}
