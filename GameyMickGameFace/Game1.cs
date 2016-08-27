using GameyMickGameFace.GameObjects;
using GameyMickGameFace.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        Texture2D Platform1Texture;
        Texture2D Platform2Texture;
        Texture2D Platform3Texture;
        Tile Floor;
        Tile Platform1;
        Tile Platform2;
        Tile Platform3;

        PowerUp Health;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";

            Health = new PowerUp();
            Health.Name = "Health";
            
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

            Media.Animations.PlayerWalk = new Animation(500);
            Media.Animations.PlayerIdel = new Animation(1000);

            Media.Fonts.GUI = Content.Load<SpriteFont>("GUIFont");
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Images/playersqaure"));
            Media.Animations.PlayerWalk.AddTexture(Content.Load<Texture2D>("Images/playersqaure2"));
            Media.Animations.PlayerIdel.AddTexture(Content.Load<Texture2D>("Images/playersqaure"));

            TempPlayer = new Player();
            physicsManager.AddBody(TempPlayer.PhysicsBody);

            Floor = new Tile(new Point(0, 650), 30000, 30, 0, 0);
            physicsManager.AddBody(Floor.Body);

            BackGround = Content.Load<Texture2D>("Images/woodenwallwithfloor");

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

            Health.Update(gameTime);

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
            spriteBatch.Draw(Platform1Texture, new Vector2(150, 200), Color.White);
            spriteBatch.Draw(Platform2Texture, new Vector2(50, 400), Color.White);
            spriteBatch.Draw(Platform3Texture, new Vector2(750, 400), Color.White);
            spriteBatch.DrawString(Media.Fonts.GUI, "Welcome to LD 36", new Vector2(100, 100), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0);
            TempPlayer.Draw(gameTime, spriteBatch);

            Health.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
