using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD27
{
    class Lava : Sprite
    {
        Texture2D top;
        Texture2D bottom;

        const int animationLength = 200;
        int currentFrame = 0;

        Rectangle[] topSources = new Rectangle[] {
            new Rectangle(0, 0, 480, 200),
            new Rectangle(0, 200, 480, 200), 
            new Rectangle(0, 400, 480, 200), 
            new Rectangle(0, 600, 480, 200)
        };

        Vector2 velocity = new Vector2(0, 100);

        Rectangle topSource;
        Vector2 topPosition;

        private const string top_asset = "Images/lava/lava_front";
        private const string bottom_asset = "Images/lava/back";

        public Lava()
        {
            topPosition = new Vector2(0, 800);
        }

        public void LoadContent(ContentManager theContentManager)
        {
            top = theContentManager.Load<Texture2D>(top_asset);
            topSource = topSources[0];
        }

        public void Update(TimeSpan theGameTime)
        {
            this.Animate();
            topPosition.Y -= velocity.Y * (float)theGameTime.TotalSeconds; 
        }

        private void Animate()
        {
            if (currentFrame < animationLength / 4)
                topSource = topSources[0];
            else if (currentFrame < animationLength / 2)
                topSource = topSources[1];
            else if (currentFrame < 3 * animationLength / 4)
                topSource = topSources[2];
            else if (currentFrame < animationLength)
                topSource = topSources[3];
            else
                currentFrame = 0;

            currentFrame++;
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(top, topPosition, topSource, Color.White);
        }
    }
}
