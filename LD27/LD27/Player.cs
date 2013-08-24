using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD27
{
    class Player : Sprite
    {
        const string assetName = "Images/player";

        private const int w = 32;
        private const int h = 32;

        public Player()
        {
            this.Position = new Vector2(480 / 2 - w / 2, 750); //yay magic numbers
        }

        public void LoadContent(ContentManager theContentManager)
        {
            base.LoadContent(theContentManager, assetName);
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            base.Draw(theSpriteBatch, new Vector2(this.texture.Width / 2, this.texture.Height / 2), this.Position, Color.White, this.Rotation);
        }
    }
}
