using GameyMickGameFace.GameObjects;
using GameyMickGameFace.Menus;
using GameyMickGameFace.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        Player TempPlayer;
        Texture2D BackGround;
        Texture2D Platform1Texture;
        Texture2D Platform2Texture;
        Texture2D Platform3Texture;
        Texture2D PhysicsBox;
        Tile Floor;
        Tile Platform1;
        Tile Platform2;
        Tile Platform3;

        PowerUp Health;


        Title TitleScreen;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";

            Health = new PowerUp();
            Health.Name = "Health";
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

            Media.Animations.PlayerWalk = new Animation(50);
            Media.Animations.PlayerIdel = new Animation(10);

            Media.Fonts.GUI = Content.Load<SpriteFont>("GUIFont");
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_000"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_001"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_002"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_003"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_004"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_005"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_006"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_007"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_008"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_009"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_010"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_011"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_012"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_013"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_014"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_015"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_016"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_017"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_018"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_019"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_020"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_021"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_022"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_023"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_024"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_025"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_026"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_027"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_028"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Otter_Otter_Walking_029"));

            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_000"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_001"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_002"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_003"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_004"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_005"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_006"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_007"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_008"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_009"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_010"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_011"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_012"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_013"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_014"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_015"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_016"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_017"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_018"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_019"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_020"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_021"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_022"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_023"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_024"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_025"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_026"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_027"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_028"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Otter_Otter_Idle_029"));

            TempPlayer = new Player();
            physicsManager.AddBody(TempPlayer.PhysicsBody);

            Floor = new Tile(new Point(0, 650), 1280, 30, 0, 0);
            physicsManager.AddBody(Floor.Body);

            BackGround = Content.Load<Texture2D>("Images/woodenwallwithfloor");
            
                        TitleScreen = new Title();
            Media.Textures.TitleScreen = Content.Load<Texture2D>("Images/Title");

            Platform1Texture = Content.Load<Texture2D>("Images/longshelf");
            Platform1 = new Tile(new Point(150, 200), Platform1Texture.Width, Platform1Texture.Height, 0, 0);
            physicsManager.AddBody(Platform1.Body);

            Platform2Texture = Content.Load<Texture2D>("Images/mediumshelf");
            Platform2 = new Tile(new Point(50, 400), Platform2Texture.Width, Platform2Texture.Height, 0, 0);
            physicsManager.AddBody(Platform2.Body);

            Platform3Texture = Content.Load<Texture2D>("Images/shortshelf");
            Platform3 = new Tile(new Point(750, 400), Platform3Texture.Width, Platform3Texture.Height, 0, 0);
            physicsManager.AddBody(Platform3.Body);

            Health.Image = Content.Load<Texture2D>("Images/healthUp");
            physicsManager.AddBody(Health.PhysicsBody);

            Media.Audio.damage = Content.Load<SoundEffect>("Sounds/Generic_Cowboy_Hurt");

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

                TempPlayer.Update(gameTime);
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
                spriteBatch.DrawString(Media.Fonts.GUI, "Welcome to LD 36", new Vector2(100, 100), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);

                TempPlayer.Draw(gameTime, spriteBatch);
            }
            Health.Draw(gameTime, spriteBatch);

            if (PhysicsDrawn)
            {
                foreach (Body Body in physicsManager.GetBodies())
                {
                    spriteBatch.Draw(PhysicsBox, new Rectangle((int)Body.Position.X, (int)Body.Position.Y, Body.width, Body.height), Color.White);
                }
            }

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
