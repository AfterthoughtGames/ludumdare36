﻿using GameyMickGameFace.GameObjects;
using GameyMickGameFace.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameyMickGameFace
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        PhysicsManager physicsManager = new PhysicsManager();

        // Temp Code
        Player TempPlayer;
        Texture2D BackGround;
        Tile BlockerTest;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
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
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Media.Fonts.GUI = Content.Load<SpriteFont>("GUIFont");
            Media.Textures.PlayerTemp = Content.Load<Texture2D>("Images/playersqaure");
            // TODO: use this.Content to load your game content here

            //Temp Code
            BackGround = Content.Load<Texture2D>("Images/Background");
            TempPlayer = new Player();
            physicsManager.AddBody(TempPlayer.PhysicsBody);
            BlockerTest = new Tile(new Point(250, 250), 95, 86, 0, 0);
            physicsManager.AddBody(BlockerTest.Body);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            physicsManager.UpdatePhysics(gameTime);

            TempPlayer.Update(gameTime);

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

            spriteBatch.Draw(BackGround, Vector2.Zero, Color.White);
            spriteBatch.DrawString(Media.Fonts.GUI, "Welcome to LD 36", new Vector2(100, 100), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);
            TempPlayer.Draw(gameTime, spriteBatch);
            BlockerTest.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
