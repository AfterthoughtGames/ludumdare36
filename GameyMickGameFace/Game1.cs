﻿using GameyMickGameFace.GameObjects;
using GameyMickGameFace.Menus;
using GameyMickGameFace.Physics;
using GameyMickGameFace.PowerUps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameyMickGameFace
{
    public enum GameStates
    {
        Title, InGame
    }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static GameStates GameState;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        PhysicsManager physicsManager = new PhysicsManager();
        public KeyboardState PreviousKeyState { get; set; }
        private bool PhysicsDrawn = false;

        // Temp Code
        Player Player1;
        Player Player2;
        Player Player3;
        Player Player4;
        Texture2D BackGround;
        Texture2D Platform1Texture;
        Texture2D Platform2Texture;
        Texture2D Platform3Texture;
        Texture2D PhysicsBox;
        Tile Floor;
        Tile Platform1;
        Tile Platform2;
        Tile Platform3;

        healthPowerUp Health;

        Title TitleScreen;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";


            GameState = GameStates.Title;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Media.Fonts.Load(Content);
            Media.Animations.Load(Content);
            Media.Audio.Load(Content);
            Media.Textures.Load(Content);

            Health = new healthPowerUp(Media.Textures.healthTexture);

            Player1 = new Player();
            Player1.PlayerNumber = 0;
            physicsManager.AddBody(Player1.PhysicsBody);
            Player2 = new Player();
            Player2.PlayerNumber = 1;
            physicsManager.AddBody(Player2.PhysicsBody);
            Player3 = new Player();
            Player3.PlayerNumber = 2;
            physicsManager.AddBody(Player3.PhysicsBody);
            Player4 = new Player();
            Player4.PlayerNumber = 3;
            physicsManager.AddBody(Player4.PhysicsBody);

            Floor = new Tile(new Point(-100, 650), 1800, 30, 0, 0);
            physicsManager.AddBody(Floor.Body);

            BackGround = Content.Load<Texture2D>("Images/woodenwallwithfloor");

            TitleScreen = new Title();

            Platform1Texture = Content.Load<Texture2D>("Images/longshelf");
            Platform1 = new Tile(new Point(150, 200), Platform1Texture.Width, Platform1Texture.Height - 30, 0, 0);
            physicsManager.AddBody(Platform1.Body);

            Platform2Texture = Content.Load<Texture2D>("Images/mediumshelf");
            Platform2 = new Tile(new Point(50, 400), Platform2Texture.Width, Platform2Texture.Height - 30, 0, 0);
            physicsManager.AddBody(Platform2.Body);

            Platform3Texture = Content.Load<Texture2D>("Images/shortshelf");
            Platform3 = new Tile(new Point(750, 400), Platform3Texture.Width, Platform3Texture.Height - 30, 0, 0);
            physicsManager.AddBody(Platform3.Body);

            
            physicsManager.AddBody(Health.PhysicsBody);

            PhysicsBox = Content.Load<Texture2D>("Images/blacksquare");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState currentState = Keyboard.GetState();
            if (PreviousKeyState == null)
            {
                PreviousKeyState = currentState;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (currentState.IsKeyDown(Keys.F1) && !PreviousKeyState.IsKeyDown(Keys.F1))
            {
                if (PhysicsDrawn)
                {
                    PhysicsDrawn = false;
                }
                else
                {
                    PhysicsDrawn = true;
                }
            }

            if (GameState == GameStates.Title)
            {
                TitleScreen.Update(gameTime);
            }
            else
            {
                physicsManager.UpdatePhysics(gameTime);

                Player1.Update(gameTime);
                Player2.Update(gameTime);
                Player3.Update(gameTime);
                Player4.Update(gameTime);
            }

            Health.Update(gameTime);

            PreviousKeyState = currentState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            if (GameState == GameStates.Title)
            {
                TitleScreen.Draw(gameTime, spriteBatch);
            }
            else
            {
                spriteBatch.Draw(BackGround, Vector2.Zero, Color.White);
                spriteBatch.Draw(Platform1Texture, new Vector2(150, 200), Color.White);
                spriteBatch.Draw(Platform2Texture, new Vector2(50, 400), Color.White);
                spriteBatch.Draw(Platform3Texture, new Vector2(750, 400), Color.White);

                string str = "OST Games: Ludum Dare 36";
                Vector2 strSize = Media.Fonts.GUI.MeasureString(str);
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(((GraphicsDevice.Viewport.Width / 2) - strSize.X), GraphicsDevice.Viewport.Height - 50), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                str = "Player 1: " + Player1.Health.ToString();
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(20, 10), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                str = "Player 2: " + Player2.Health.ToString();
                strSize = Media.Fonts.GUI.MeasureString(str);
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(GraphicsDevice.Viewport.Width - strSize.X * 2.5f, 10), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                str = "Player 3: " + Player3.Health.ToString();
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(20, GraphicsDevice.Viewport.Height - 40), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                str = "Player 4: " + Player4.Health.ToString();
                strSize = Media.Fonts.GUI.MeasureString(str);
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(GraphicsDevice.Viewport.Width - strSize.X * 2.5f, GraphicsDevice.Viewport.Height - 40), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                Player1.Draw(gameTime, spriteBatch);
                Player2.Draw(gameTime, spriteBatch);
                Player3.Draw(gameTime, spriteBatch);
                Player4.Draw(gameTime, spriteBatch);
            }
            Health.Draw(gameTime, spriteBatch);

            if (PhysicsDrawn)
            {
                foreach (Body Body in physicsManager.GetBodies())
                {
                    spriteBatch.Draw(PhysicsBox, new Rectangle((int)Body.Position.X, (int)Body.Position.Y, Body.width, Body.height), Color.White);
                }

                foreach (Body body in Player1.DetectionPhysicsBodies)
                {
                    spriteBatch.Draw(PhysicsBox, new Rectangle((int)(Player1.PhysicsBody.Position.X + body.parentOffset.X), (int)(Player1.PhysicsBody.Position.Y + body.parentOffset.X), body.width, body.height), Color.White);
                }

                foreach (Body body in Player2.DetectionPhysicsBodies)
                {
                    spriteBatch.Draw(PhysicsBox, new Rectangle((int)(Player2.PhysicsBody.Position.X + body.parentOffset.X), (int)(Player2.PhysicsBody.Position.Y + body.parentOffset.X), body.width, body.height), Color.White);
                }

                foreach (Body body in Player3.DetectionPhysicsBodies)
                {
                    spriteBatch.Draw(PhysicsBox, new Rectangle((int)(Player3.PhysicsBody.Position.X + body.parentOffset.X), (int)(Player3.PhysicsBody.Position.Y + body.parentOffset.X), body.width, body.height), Color.White);
                }

                foreach (Body body in Player4.DetectionPhysicsBodies)
                {
                    spriteBatch.Draw(PhysicsBox, new Rectangle((int)(Player4.PhysicsBody.Position.X + body.parentOffset.X), (int)(Player4.PhysicsBody.Position.Y + body.parentOffset.X), body.width, body.height), Color.White);
                }
            }

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
