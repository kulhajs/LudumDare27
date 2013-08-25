using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD27
{
    class Trap : Sprite
    {
        const string assetName = "Images/trap";

        public Trap(Vector2 position)
        {
            this.Position = position;
        }

        public void LoadContent(ContentManager theContentManager)
        {
            base.LoadContent(theContentManager, assetName);
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            base.Draw(theSpriteBatch, new Vector2(this.texture.Width / 2, this.texture.Height / 2), Position, Color.White, 0f);
        }
    }
}
