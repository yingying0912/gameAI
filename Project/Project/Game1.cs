using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
namespace Project
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public enum gameState {Start, Pause, Win, Lose }
        public static Dictionary<string, Texture2D> Assets = new Dictionary<string, Texture2D>();
        public static GameWindow Screen;
        Vector2 velocity;
        float distance;
        public static gameState gameStatus;
        HUD scoreHUD, levelHUD;
        Input input;
        Score scoreCal;

        public Random rand = new Random();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public SpriteFont spriteFont;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Content.RootDirectory = "Content";
            Screen = this.Window;
            velocity = Vector2.Zero;
            distance = 0;
            gameStatus = gameState.Start;
            input = new Input();
            scoreCal = new Score();
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
            IsMouseVisible = true;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            scoreCal.Initialize();
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

            // TODO: use this.Content to load your game content here
            spriteFont = Content.Load<SpriteFont>("font");
            scoreHUD = new HUD("Score", new Vector2(Screen.ClientBounds.Width / 15, Screen.ClientBounds.Height / 15));
            levelHUD = new HUD("Score", new Vector2(Screen.ClientBounds.Width / 15, Screen.ClientBounds.Height / 15), 5);
            
            Assets.Add("background", Content.Load<Texture2D>("background"));
            Assets.Add("backgroundwgrid", Content.Load<Texture2D>("backgroundwgrid"));
            Assets.Add("player", Content.Load<Texture2D>("player"));
            Assets.Add("blueWhale", Content.Load<Texture2D>("blue whale"));
            Assets.Add("barracudina", Content.Load<Texture2D>("barracudina"));
            Assets.Add("flatfish", Content.Load<Texture2D>("flatfish"));
            Assets.Add("opah", Content.Load<Texture2D>("opah"));
            Assets.Add("tripodfish", Content.Load<Texture2D>("tripodfish"));

            World.Add("bg", new Background());
            World.Add("player", new Character());
            World.Add("blueWhale", new BlueWhale());
            World.Add("opah", new Opah());
            World.Add("barracudina", new Barracudina());
            World.Add("tripodfish", new Tripodfish());
            World.Add("flatfish", new Flatfish());
            World.Initialize(rand);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            World.Clear();
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

            switch (gameStatus)
            {
                case gameState.Start:
                    StartGame(gameTime);
                    break;
                case gameState.Pause:
                    Console.WriteLine("pauseGame()");
                    break;
                case gameState.Win:
                    Console.WriteLine("WinGame");
                    break;
                case gameState.Lose:
                    Console.WriteLine("LoseGame");
                    break;
            }

            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
                World.Draw(spriteBatch, gameTime); 
                scoreHUD.Draw(spriteBatch, spriteFont, GraphicsDevice); 
                levelHUD.Draw(spriteBatch, spriteFont, GraphicsDevice); 
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void StartGame(GameTime gameTime)
        {
            World.Update(gameTime);
            scoreHUD.Update("value", new Color(255, 255, 255));
            levelHUD.Update("value", new Color(255, 255, 255), 2);
            input.Update(Screen, gameTime);
            scoreCal.Update(gameStatus);
        }
    }
}