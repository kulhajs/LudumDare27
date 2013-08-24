using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD27
{
    class LevelHandler
    {

        public int CurrentLevelId { get; set; }

        public Level CurrentLevel { get; private set; }
        
        ContentManager contentManager;

        public LevelHandler(ContentManager theContentManager)
        {
            CurrentLevelId = 1;
            contentManager = theContentManager;
        }

        public void InitializeLevel()
        {
            CurrentLevel = new Level(CurrentLevelId);
            CurrentLevel.LoadContent(contentManager);
        }

        public void DrawLevel(SpriteBatch theSpriteBatch)
        {
            CurrentLevel.Draw(theSpriteBatch);
        }
    }
}
