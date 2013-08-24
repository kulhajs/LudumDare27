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

        int currentLevel;

        public Level(int level)
        {
            background = new Background();
            currentLevel = level;
        }

        public void LoadContent(ContentManager contentManager)
        {
            this.LoadObstacles();
            background.LoadContent(contentManager);
            foreach (Obstacle o in LevelObstacles)
            {
                o.LoadContent(contentManager);
            }
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
        }
    }
}
