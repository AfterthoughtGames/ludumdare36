using GameyMickGameFace.GameObjects;
using GameyMickGameFace.GameObjects.PowerUps;
using GameyMickGameFace.GameObjects.Weapons;
using GameyMickGameFace.Menus;
using GameyMickGameFace.Particles;
using GameyMickGameFace.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace GameyMickGameFace
{
    public enum GameStates
    {
        Title, InGame, EndGame
    }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static GameStates GameState;
        

        

        public Random rand = new Random();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public KeyboardState PreviousKeyState { get; set; }

        Title TitleScreen;
        Score ScoreBoard;

        public static Level Level;

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
            Media.Music.Load(Content);

            TitleScreen = new Title();
            Level = new Level();

            ScoreBoard = new Score();

            //TODO: Should be moved
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Media.Music.Music1);
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
                if (Level.PhysicsDrawn)
                {
                    Level.PhysicsDrawn = false;
                }
                else
                {
                    Level.PhysicsDrawn = true;
                }
            }

            if (currentState.IsKeyDown(Keys.F2) && !PreviousKeyState.IsKeyDown(Keys.F2))
            {
                GameState = GameStates.EndGame;
            }

            switch (GameState)
            {
                case GameStates.Title:
                    TitleScreen.Update(gameTime);
                    break;
                case GameStates.InGame:
                    Level.Update(gameTime);
                    break;
                case GameStates.EndGame:
                    ScoreBoard.currentLevel = Level;
                    ScoreBoard.Update(gameTime);
                    break;
            }

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

            switch (GameState)
            {
                case GameStates.Title:
                    TitleScreen.Draw(gameTime, spriteBatch);
                    break;
                case GameStates.InGame:
                    Level.Draw(gameTime, spriteBatch);
                    break;
                case GameStates.EndGame:
                    Level.Draw(gameTime, spriteBatch);
                    ScoreBoard.Draw(gameTime, spriteBatch);
                    break;
            }

            

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
