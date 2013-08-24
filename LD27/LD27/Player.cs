using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD27
{
    class Player : Sprite
    {
        const string assetName = "Images/player";

        Accelerometer accelerometer;

        private const int w = 32;
        private const int h = 32;

        private Vector2 acceleration = Vector2.Zero;
        private Vector2 velocity = new Vector2(2f, 2f);

        public Vector2 Direction = new Vector2(1, 1);

        public Player()
        {
            this.Position = new Vector2(480 / 2 - w / 2, 750); //yay magic numbers
            this.Scale = 0.8f;
            accelerometer = new Accelerometer();
            accelerometer.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(accelerometer_CurrentValueChanged);

            accelerometer.Start(); 
        }

        public void LoadContent(ContentManager theContentManager)
        {
            base.LoadContent(theContentManager, assetName);
        }

        public void Update(TimeSpan theGameTime)
        {
            this.Position += velocity * acceleration * (float)theGameTime.TotalSeconds;
        }

        private void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            acceleration.X = e.SensorReading.Acceleration.X * 175;
            acceleration.Y = e.SensorReading.Acceleration.Z * 50;
        }

        public void Draw(SpriteBatch theSpriteBatch)
        {
            base.Draw(theSpriteBatch, new Vector2(this.texture.Width / 2, this.texture.Height / 2), this.Position, Color.White, this.Rotation);
        }
    }
}
