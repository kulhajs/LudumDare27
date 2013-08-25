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
            else if (level == 3)
            {
                return new List<Obstacle>(){
                    new Obstacle(new Vector2(-64, 96)),
                    new Obstacle(new Vector2(160, 96)),
                    new Obstacle(new Vector2(352, 96)),
                    new Obstacle(new Vector2(96, 160)),
                    new Obstacle(new Vector2(352, 192)),
                    new Obstacle(new Vector2(0, 224)),
                    new Obstacle(new Vector2(224, 256)),
                    new Obstacle(new Vector2(-160, 320)),
                    new Obstacle(new Vector2(64, 320)),
                    new Obstacle(new Vector2(320, 320)),
                    new Obstacle(new Vector2(-32, 416)),
                    new Obstacle(new Vector2(224, 384)),
                    new Obstacle(new Vector2(-128, 480)),
                    new Obstacle(new Vector2(96, 480)),
                    new Obstacle(new Vector2(320, 480)),
                    new Obstacle(new Vector2(-32, 576)),
                    new Obstacle(new Vector2(224, 576)),
                    new Obstacle(new Vector2(0, 640)),
                    new Obstacle(new Vector2(288, 640)),
                };
            }
            else if (level == 4)
            {
                return new List<Obstacle>(){
                    new Obstacle(new Vector2(-128, 64)),
                    new Obstacle(new Vector2(96, 64)),
                    new Obstacle(new Vector2(192, 64)),
                    new Obstacle(new Vector2(416, 64)),
                    new Obstacle(new Vector2(0, 128)),
                    new Obstacle(new Vector2(288, 128)),
                    new Obstacle(new Vector2(-96, 224)),
                    new Obstacle(new Vector2(128, 224)),
                    new Obstacle(new Vector2(224, 224)),
                    new Obstacle(new Vector2(0, 288)),
                    new Obstacle(new Vector2(288, 288)),
                    new Obstacle(new Vector2(32, 384)),
                    new Obstacle(new Vector2(256, 384)),
                    new Obstacle(new Vector2(-128, 448)),
                    new Obstacle(new Vector2(128, 448)),
                    new Obstacle(new Vector2(0, 512)),
                    new Obstacle(new Vector2(224, 512)),
                    new Obstacle(new Vector2(416, 512)),
                    new Obstacle(new Vector2(-96, 576)),
                    new Obstacle(new Vector2(128, 576)),
                    new Obstacle(new Vector2(352, 576)),
                    new Obstacle(new Vector2(-64, 640)),
                    new Obstacle(new Vector2(352, 640)),
                };
            }
            else if (level == 5)
            {
                return new List<Obstacle>(){
                    new Obstacle(new Vector2(-96, 96)),
                    new Obstacle(new Vector2(-64, 192)),
                    new Obstacle(new Vector2(128, 96)),
                    new Obstacle(new Vector2(384, 96)),
                    new Obstacle(new Vector2(352, 192)),
                    new Obstacle(new Vector2(64, 256)),
                    new Obstacle(new Vector2(288, 256)),
                    new Obstacle(new Vector2(192, 320)),
                    new Obstacle(new Vector2(256, 320)),
                    new Obstacle(new Vector2(0, 384)),
                    new Obstacle(new Vector2(416, 384)),
                    new Obstacle(new Vector2(-128, 448)),
                    new Obstacle(new Vector2(160, 448)),
                    new Obstacle(new Vector2(384, 448)),
                    new Obstacle(new Vector2(32, 512)),
                    new Obstacle(new Vector2(288, 512)),
                    new Obstacle(new Vector2(0, 608)),
                    new Obstacle(new Vector2(160, 608)),
                    new Obstacle(new Vector2(416, 608)),
                };
            }
            else
                return new List<Obstacle>();
        }

        public static List<Trap> LevelTraps(int level)
        {
            if (level == 1)
            {
                return new List<Trap>() {
                    new Trap(new Vector2(160, 128)),
                    new Trap(new Vector2(288, 256)),
                    new Trap(new Vector2(160, 352)),
                    new Trap(new Vector2(160, 480)),
                    new Trap(new Vector2(352, 480)),
                };
            }
            else if (level == 2)
            {
                return new List<Trap>(){
                    new Trap(new Vector2(192, 96)),
                    new Trap(new Vector2(288, 96)),
                    new Trap(new Vector2(32, 160)),
                    new Trap(new Vector2(256, 256)),
                    new Trap(new Vector2(160, 416)),
                    new Trap(new Vector2(96, 512)),
                    new Trap(new Vector2(256, 512)),
                };
            }
            else if (level == 3)
            {
                return new List<Trap>(){
                    new Trap(new Vector2(320, 192)),
                    new Trap(new Vector2(288, 320)),
                    new Trap(new Vector2(128, 384)),
                    new Trap(new Vector2(256, 448)),
                    new Trap(new Vector2(128, 544)),
                    new Trap(new Vector2(256, 544)),
                };
            }
            else if (level == 4)
            {
                return new List<Trap>(){
                    new Trap(new Vector2(256, 128)),
                    new Trap(new Vector2(160, 192)),
                    new Trap(new Vector2(224, 320)),
                    new Trap(new Vector2( 96, 448)),
                    new Trap(new Vector2(352, 448)),
                };
            }
            else if (level == 5)
            {
                return new List<Trap>(){
                    new Trap(new Vector2(128, 160)),
                    new Trap(new Vector2(352, 128)),
                    new Trap(new Vector2(256, 192)),
                    new Trap(new Vector2(288, 224)),
                    new Trap(new Vector2( 32, 288)),
                    new Trap(new Vector2( 96, 352)),
                    new Trap(new Vector2(288, 384)),
                    new Trap(new Vector2(224, 416)),
                    new Trap(new Vector2(352, 416)),
                    new Trap(new Vector2(128, 448)),
                    new Trap(new Vector2( 96, 480)),
                    new Trap(new Vector2(256, 512)),
                    new Trap(new Vector2(320, 576)),
                    new Trap(new Vector2(384, 640)),
                };
            }
            else
                return new List<Trap>();
        }
    }
}
