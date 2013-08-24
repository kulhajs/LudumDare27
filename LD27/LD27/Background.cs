using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD27
{
    class Background : Sprite
    {
        string[] assetNames = new string[] {
            "Images/backgrounds/background1",
            "Images/backgrounds/background2",
            "Images/backgrounds/background3"
        };

        Random random = new Random();

        public void LoadContent(ContentManager theContentManager)
        {
            base.LoadContent(theContentManager, assetNames[random.Next(assetNames.Length)]);
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            base.Draw(theSpriteBatch, Vector2.Zero, Vector2.Zero, Color.White, 0.0f);
        }
    }
}
