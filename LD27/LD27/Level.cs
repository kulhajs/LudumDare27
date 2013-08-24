using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD27
{
    class Level
    {
        Background background;
        ContentManager contentManager;

        public Level(ContentManager theContentManager)
        {
            background = new Background();
            contentManager = theContentManager;
        }

        public void LoadContent()
        {
            background.LoadContent(contentManager);
        }


        public void Draw(SpriteBatch theSpriteBatch)
        {
            background.Draw(theSpriteBatch);
        }
    }
}
