using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LD27
{
    class Level
    {
        Background background;
        public List<Obstacle> LevelObstacles = new List<Obstacle>();
        public List<Trap> LevelTraps = new List<Trap>();

        int currentLevel;

        Random random = new Random();

        public Level(int level)
        {
            background = new Background();
            currentLevel = level;
        }

        public void LoadContent(ContentManager contentManager)
        {
            this.LoadObstacles();
            this.LoadTraps();
            background.LoadContent(contentManager);
            foreach (Obstacle o in LevelObstacles)
            {
                o.LoadContent(contentManager);
            }
            foreach (Trap t in LevelTraps)
            {
                t.LoadContent(contentManager);
            }
        }

        private void LoadTraps()
        {
            if (LevelTraps.Count > 0)
                LevelTraps.Clear();

            LevelTraps = Obstacles.LevelTraps(currentLevel);
        }

        private void LoadObstacles()
        {
            if (LevelObstacles.Count > 0)
                LevelObstacles.Clear();

            LevelObstacles = Obstacles.LevelObstacles(currentLevel);
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            background.Draw(theSpriteBatch);
            foreach (Obstacle o in LevelObstacles)
            {
                o.Draw(theSpriteBatch);
            }
            foreach (Trap t in LevelTraps)
            {
                t.Draw(theSpriteBatch);
            }
        }
    }
}
