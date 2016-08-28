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
        Title, InGame
    }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static GameStates GameState;
        public static List<Player> Players = new List<Player>();
        public static List<Point> PlayerSpawnPoints = new List<Point>();
        public static List<Point> PickupSpots = new List<Point>();

        public static List<Particle> Particles = new List<Particle>();

        public Random rand = new Random();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        PhysicsManager physicsManager = new PhysicsManager();
        public KeyboardState PreviousKeyState { get; set; }
        private bool PhysicsDrawn = false;

        Texture2D BackGround;
        Texture2D Platform1Texture;
        Texture2D Platform2Texture;
        Texture2D Platform3Texture;
        Texture2D PhysicsBox;
        Tile Floor;
        Tile Platform1;
        Tile Platform2;
        Tile Platform3;
        Title TitleScreen;

        int levelOne = 420;
        int levelTwo = 220;
        int levelFloor = 650;

        double GameTimeSeconds = 300;
        double TimeLeft;

        Level Level;

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
            PlayerSpawnPoints.Add(new Point(100, 130));
            PlayerSpawnPoints.Add(new Point(800, 130));
            PlayerSpawnPoints.Add(new Point(100, 560));
            PlayerSpawnPoints.Add(new Point(800, 560));

            PickupSpots.Add(new Point(400, levelOne));
            PickupSpots.Add(new Point(890, levelOne));
            PickupSpots.Add(new Point(910, levelOne));
            PickupSpots.Add(new Point(740, levelOne));
            PickupSpots.Add(new Point(350, levelOne));
            PickupSpots.Add(new Point(450, levelOne));
            PickupSpots.Add(new Point(650, levelTwo));
            PickupSpots.Add(new Point(550, levelTwo));
            PickupSpots.Add(new Point(475, levelTwo));
            PickupSpots.Add(new Point(700, levelTwo));
            PickupSpots.Add(new Point(725, levelTwo));
            PickupSpots.Add(new Point(650, levelFloor));
            PickupSpots.Add(new Point(550, levelFloor));
            PickupSpots.Add(new Point(475, levelFloor));
            PickupSpots.Add(new Point(700, levelFloor));
            PickupSpots.Add(new Point(725, levelFloor));

            spriteBatch = new SpriteBatch(GraphicsDevice);

            Media.Fonts.Load(Content);
            Media.Animations.Load(Content);
            Media.Audio.Load(Content);
            Media.Textures.Load(Content);
            Media.Music.Load(Content);

            Floor = new Tile(new Point(-100, 650), 1800, 30, 0, 0);
            physicsManager.AddBody(Floor.Body);

            BackGround = Content.Load<Texture2D>("Images/woodenwallwithfloor");

            TitleScreen = new Title();

            Platform1Texture = Content.Load<Texture2D>("Images/longshelf");
            Platform1 = new Tile(new Point(150, levelTwo), Platform1Texture.Width, Platform1Texture.Height - 30, 0, 0);
            physicsManager.AddBody(Platform1.Body);

            Platform2Texture = Content.Load<Texture2D>("Images/mediumshelf");
            Platform2 = new Tile(new Point(50, levelOne), Platform2Texture.Width, Platform2Texture.Height - 30, 0, 0);
            physicsManager.AddBody(Platform2.Body);

            Platform3Texture = Content.Load<Texture2D>("Images/shortshelf");
            Platform3 = new Tile(new Point(750, levelOne), Platform3Texture.Width, Platform3Texture.Height - 30, 0, 0);
            physicsManager.AddBody(Platform3.Body);

            PhysicsBox = Content.Load<Texture2D>("Images/blacksquare");

            Level = new Level(physicsManager);

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
                Level.Update(gameTime, physicsManager);
            }

            PreviousKeyState = currentState;

            //update all blood particles
            for (int i = 0; i < Particles.Count; i++)
            {
                Particles[i].Update(gameTime, physicsManager);
            }

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
                spriteBatch.Draw(Platform1Texture, new Vector2(150, levelTwo), Color.White);
                spriteBatch.Draw(Platform2Texture, new Vector2(50, levelOne), Color.White);
                spriteBatch.Draw(Platform3Texture, new Vector2(750, levelOne), Color.White);

                string str = "OST Games: Ludum Dare 36";
                Vector2 strSize = Media.Fonts.GUI.MeasureString(str);
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(((GraphicsDevice.Viewport.Width / 2) - strSize.X), GraphicsDevice.Viewport.Height - 50), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                str = "Player 1: " + Level.Player1.Health.ToString();
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(20, 10), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                str = "Score:  " + Level.Player1.Score.ToString();
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(20, 40), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                str = "Player 2: " + Level.Player2.Health.ToString();
                strSize = Media.Fonts.GUI.MeasureString(str);
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(GraphicsDevice.Viewport.Width - strSize.X * 2.5f, 10), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                str = "Score:  " + Level.Player2.Score.ToString();
                strSize = Media.Fonts.GUI.MeasureString(str);
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(GraphicsDevice.Viewport.Width - strSize.X * 2.5f, 40), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                str = "Player 3: " + Level.Player3.Health.ToString();
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(20, GraphicsDevice.Viewport.Height - 40), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                str = "Score: " + Level.Player3.Score.ToString();
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(20, GraphicsDevice.Viewport.Height - 70), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                str = "Player 4: " + Level.Player4.Health.ToString();
                strSize = Media.Fonts.GUI.MeasureString(str);
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(GraphicsDevice.Viewport.Width - strSize.X * 2.5f, GraphicsDevice.Viewport.Height - 40), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                str = "Score: " + Level.Player4.Score.ToString();
                strSize = Media.Fonts.GUI.MeasureString(str);
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(GraphicsDevice.Viewport.Width - strSize.X * 2.5f, GraphicsDevice.Viewport.Height - 70), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                TimeLeft = GameTimeSeconds - Level.TimeSpent.Seconds;

                str = "Time Left: " + (int)(TimeLeft / 60) + " " + (int)(TimeLeft % 60);
                spriteBatch.DrawString(Media.Fonts.GUI, str, new Vector2(((GraphicsDevice.Viewport.Width / 2) - strSize.X), 10), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                Level.Draw(gameTime, spriteBatch);
            }

            if (PhysicsDrawn)
            {
                foreach (Body Body in physicsManager.GetBodies())
                {
                    if (Body.reactsToCollision)
                    {
                        spriteBatch.Draw(PhysicsBox, new Rectangle((int)Body.Position.X, (int)Body.Position.Y, Body.width, Body.height), Color.White);
                    }
                }

                foreach (Body body in Level.Player1.DetectionPhysicsBodies)
                {
                    spriteBatch.Draw(PhysicsBox, new Rectangle((int)(Level.Player1.PhysicsBody.Position.X + body.parentOffset.X), (int)(Level.Player1.PhysicsBody.Position.Y + body.parentOffset.Y), body.width, body.height), Color.White);
                }

                foreach (Body body in Level.Player2.DetectionPhysicsBodies)
                {
                    spriteBatch.Draw(PhysicsBox, new Rectangle((int)(Level.Player2.PhysicsBody.Position.X + body.parentOffset.X), (int)(Level.Player2.PhysicsBody.Position.Y + body.parentOffset.Y), body.width, body.height), Color.White);
                }

                foreach (Body body in Level.Player3.DetectionPhysicsBodies)
                {
                    spriteBatch.Draw(PhysicsBox, new Rectangle((int)(Level.Player3.PhysicsBody.Position.X + body.parentOffset.X), (int)(Level.Player3.PhysicsBody.Position.Y + body.parentOffset.Y), body.width, body.height), Color.White);
                }

                foreach (Body body in Level.Player4.DetectionPhysicsBodies)
                {
                    spriteBatch.Draw(PhysicsBox, new Rectangle((int)(Level.Player4.PhysicsBody.Position.X + body.parentOffset.X), (int)(Level.Player4.PhysicsBody.Position.Y + body.parentOffset.Y), body.width, body.height), Color.White);
                }
            }

            foreach (Particle particle in Particles)
            {
                particle.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
