using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD27
{
    class Sprite
    {
        public Texture2D texture;
        private Rectangle source;
        private Rectangle size;
        private float scale = 1.0f;
        public Vector2 Position = Vector2.Zero;
        public ContentManager contentManager;

        public float Rotation { get; set; }

        public float X
        {
            get { return this.Position.X; }
            set { this.Position.X = value; }
        }

        public float Y
        {
            get { return this.Position.Y; }
            set { this.Position.Y = value; }
        }

        public Color Color { get; set; }

        public float Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                size = new Rectangle(0, 0, (int)(source.Width * scale), (int)(source.Height * scale));
            }
        }

        public Rectangle Source
        {
            get { return source; }
            set
            {
                source = value;
                size = new Rectangle(0, 0, source.Width, source.Height);
            }
        }

        public void LoadContent(ContentManager theContentManager, string assetName)
        {
            texture = theContentManager.Load<Texture2D>(assetName);
            Source = new Rectangle(0, 0, (int)(texture.Width * Scale), (int)(texture.Height * Scale));
            size = new Rectangle(0, 0, (int)(texture.Width * Scale), (int)(texture.Height * Scale));
        }

        public virtual void Draw(SpriteBatch theSpriteBatch, Vector2 origin, Vector2 position, Color color, float rotation)
        {
            theSpriteBatch.Draw(texture, Position, Source, color, rotation, origin, Scale, SpriteEffects.None, 0);
        }

        public float Fcos(float x)
        {
            return (float)Math.Cos((double)x);
        }

        public float Fsin(float x)
        {
            return (float)Math.Sin((double)x);
        }

        public float FPI { get { return (float)Math.PI; } }
    }
}
