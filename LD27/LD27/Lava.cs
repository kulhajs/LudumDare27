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

        const int topAnimationLength = 2;
        const int bottomAnimationLength = 2;
        int topFrame = 0;
        int bottomFrame = 0;

        int topCurrentFrame = 0;
        int bottomCurrentFrame = 0;

        public bool Finished { get; set; }

        Rectangle[] topSources = new Rectangle[] {
            new Rectangle(0, 0, 480, 200),
            new Rectangle(0, 200, 480, 200), 
            new Rectangle(0, 400, 480, 200), 
            new Rectangle(0, 600, 480, 200),
            new Rectangle(0, 800, 480, 200),
            new Rectangle(0, 1000, 480, 200),
            new Rectangle(0, 1200, 480, 200),
            new Rectangle(0, 1400, 480, 200)
        };

        Rectangle[] bottomSources = new Rectangle[] {
            new Rectangle(0, 0, 480, 800),
            new Rectangle(480, 0, 480, 800), 
            new Rectangle(960, 0, 480, 800), 
            new Rectangle(1440, 0, 480, 800)
        };

        Vector2 velocity = new Vector2(0, 90);

        Rectangle topSource;
        public Vector2 TopPosition;

        Rectangle bottomSource;
        Vector2 bottomPosition;

        private const string top_asset = "Images/lava/lava_front";
        private const string bottom_asset = "Images/lava/lava_bottom";

        public Lava()
        {
            TopPosition = new Vector2(0, 800);
            bottomPosition = new Vector2(0, 1000);
        }

        public void Initialize()
        {
            TopPosition = new Vector2(0, 800);
            bottomPosition = new Vector2(0, 1000);
            Finished = false;
        }

        public void LoadContent(ContentManager theContentManager)
        {
            top = theContentManager.Load<Texture2D>(top_asset);
            topSource = topSources[0];

            bottom = theContentManager.Load<Texture2D>(bottom_asset);
            bottomSource = bottomSources[0];
        }

        public void Update(TimeSpan theGameTime)
        {
            this.AnimateTop();
            this.AnimateBottom();
            if (TopPosition.Y > -195)
            {
                TopPosition.Y -= velocity.Y * (float)theGameTime.TotalSeconds;
            }
            if (bottomPosition.Y > 5)
            {
                bottomPosition.Y -= velocity.Y * (float)theGameTime.TotalSeconds;
            }
            else
            {
                Finished = true;
            }
        }

        private void AnimateTop()
        {
            if (topCurrentFrame < topSources.Length)
            {
                this.topSource = topSources[topCurrentFrame];
            }
            else
            {
                topCurrentFrame = 0;
            }

            topFrame++;
            if (topFrame > topAnimationLength)
            {
                topCurrentFrame++;
                topFrame = 0;
            }
        }

        private void AnimateBottom()
        {
            if (bottomCurrentFrame < bottomSources.Length)
            {
                this.bottomSource = bottomSources[bottomCurrentFrame];
            }
            else
            {
                bottomCurrentFrame = 0;
            }

            bottomFrame++;
            if (bottomFrame > bottomAnimationLength)
            {
                bottomCurrentFrame++;
                bottomFrame = 0;
            }
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(top, TopPosition, topSource, Color.White);
            theSpriteBatch.Draw(bottom, bottomPosition, bottomSource, Color.White);
        }
    }
}
