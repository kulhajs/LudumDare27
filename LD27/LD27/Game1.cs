using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Microsoft.Phone.Info;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading;

namespace LD27
{
    enum GameState { 
        StartMenu,
        Running,
        LevelCompleted,
        LevelFailed,
        Completed
    };

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont font30;
        SpriteFont font20;
        SpriteFont font10;

        LevelHandler levelHandler;
        Player player;
        Lava lava;

        TouchCollection tc;

        Vector2 oldTouchPosition;

        GameState currentGameState = GameState.StartMenu;

        Thread saveScoreThread;

        float totalTime = 0.0f;

        string deviceId = string.Empty;

        bool scoreSaved = false;

        public static MobileServiceClient MobileService = new MobileServiceClient("https://sotmj.azure-mobile.net/", "RALRKzZdaIXXvUDqGiszKRDsIBCGAm44");


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 480;
            graphics.PreferredBackBufferHeight = 800;
            graphics.IsFullScreen = true;
            graphics.SupportedOrientations = DisplayOrientation.Portrait;
            Content.RootDirectory = "Content";

            deviceId = Convert.ToBase64String((byte[])Microsoft.Phone.Info.DeviceExtendedProperties.GetValue("DeviceUniqueId"));
  
            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);
        }

        protected override void Initialize()
        {
            levelHandler = new LevelHandler(Content);
            levelHandler.InitializeLevel();
            player = new Player()
            {
                CurrentLevel = levelHandler.CurrentLevel
            };
            lava = new Lava();


            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(Content);
            lava.LoadContent(Content);

            font30 = Content.Load<SpriteFont>("Fonts/font_30");
            font20 = Content.Load<SpriteFont>("Fonts/font_20");
            font10 = Content.Load<SpriteFont>("Fonts/font_10");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (currentGameState == GameState.StartMenu)
            {
                tc = TouchPanel.GetState();
                if (tc.Count > 0)
                {
                    foreach (TouchLocation tl in tc)
                    {
                        if (tl.Position != oldTouchPosition)
                        {
                            oldTouchPosition = tl.Position;
                            currentGameState = GameState.Running;
                        }
                    }
                }
            }
            else if (currentGameState == GameState.LevelCompleted && levelHandler.CurrentLevelId == 5)
            {
                currentGameState = GameState.Completed;
                if(!scoreSaved)
                {
                    saveScoreThread = new Thread(SaveScoreThread);
                    saveScoreThread.Start();
                }
            }
            else if (currentGameState == GameState.LevelCompleted || currentGameState == GameState.LevelFailed)
            {
                tc = TouchPanel.GetState();
                if (tc.Count > 0)
                {
                    foreach (TouchLocation tl in tc)
                    {
                        if (tl.Position != oldTouchPosition)
                        {
                            oldTouchPosition = tl.Position;
                            if (currentGameState == GameState.LevelCompleted) levelHandler.CurrentLevelId += 1;
                            levelHandler.InitializeLevel();
                            lava.Initialize();
                            player.Initialize();
                            player.CurrentLevel = levelHandler.CurrentLevel;
                            currentGameState = GameState.StartMenu;
                        }
                    }
                }
            }
                        
            if (currentGameState == GameState.Running)
            {

                totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (player.Y - lava.TopPosition.Y > 100)
                {
                    currentGameState = GameState.LevelFailed;
                }

                if (player.Y > -110) player.Update(TargetElapsedTime); else currentGameState = GameState.LevelCompleted;

            }
            if (currentGameState != GameState.StartMenu)
            {
                lava.Update(TargetElapsedTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            levelHandler.DrawLevel(this.spriteBatch);
            player.Draw(this.spriteBatch);
            lava.Draw(this.spriteBatch);

            if (currentGameState == GameState.StartMenu)
            {
                spriteBatch.DrawString(font30, "TAP TO START", new Vector2((480 - font30.MeasureString("TAP TO START").X) / 2, 400), Color.Black);
            }
            else if (currentGameState == GameState.LevelCompleted)
            {
                spriteBatch.DrawString(font20, "TAP FOR NEXT LEVEL", new Vector2((480 - font20.MeasureString("TAP FOR NEXT LEVEL").X) / 2, 400), Color.Black);
            }
            else if (currentGameState == GameState.LevelFailed)
            {
                spriteBatch.DrawString(font20, "TAP TO TRY AGAIN", new Vector2((480 - font20.MeasureString("TAP TO TRY AGAIN").X) / 2, 400), Color.Black);
            }
            else if (currentGameState == GameState.Completed)
            { 
                spriteBatch.DrawString(font20, "YOU'RE VICTORIOUS!", new Vector2((480 - font20.MeasureString("YOU'RE VICTORIOUS!").X) / 2, 400), Color.Black);
            }

            spriteBatch.DrawString(font10, "Elapsed time: " + totalTime.ToString("0.00"), new Vector2(15, 770), Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void SaveScoreThread()
        {

            if (!scoreSaved)
            {
                ScoreHandler.SaveScore(deviceId, totalTime);
                scoreSaved = true;
                saveScoreThread = null;
            }

        }
    }
}
