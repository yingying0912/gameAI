using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

using System;
using System.Collections.Generic;
namespace Project
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public enum gameState {Start, Pause, Win, Lose}
        public static gameState gameStatus;
        public static bool endState;
        public static bool triggerEnd;

        Song bgm;
        public static List<SoundEffect> soundEffects;
        private float soundCD = 10f;
        private float currentTime = 0f;

        public static Dictionary<string, Texture2D> Assets = new Dictionary<string, Texture2D>();
        public static GameWindow Screen;
        Vector2 velocity;
        
        HUD scoreHUD, levelHUD, pauseHUD, loseHUD, winHUD;
        Input input;
        Score scoreCal;

        public static Random rand = new Random();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public SpriteFont spriteFont;

        int anglerNo    = 3; 
        int barraNo     = 15; 
        int blueNo      = 1; 
        int bristleNo   = 10; 
        int clownNo     = 30; 
        int cuttleNo    = 5; 
        int flatNo      = 8; 
        int lancetNo    = 3; 
        int opahNo      = 3; 
        int spermNo     = 4; 
        int stingrayNo  = 6; 
        int surgeonNo   = 20; 
        int tripodNo    = 4;

        int turtleNo    = 2;
        int jellyNo     = 20;
        int prawnNo     = 2;
        int crabNo      = 3; 


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Content.RootDirectory = "Content";
            Screen = Window;
            soundEffects = new List<SoundEffect>();
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
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            input = new Input();
            scoreCal = new Score();
            velocity = Vector2.Zero;
            gameStatus = gameState.Start;
            endState = false;
            triggerEnd = false;
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
            spriteFont = Content.Load<SpriteFont>("font");//levelHUD = new HUD("Level", new Vector2(Screen.ClientBounds.Width / 15, Screen.ClientBounds.Height / 7), new Vector2(200, 50), 5);
            levelHUD = new HUD("Level", new Vector2(Screen.ClientBounds.Width / 15, Screen.ClientBounds.Height / 11), new Vector2(500, 50), 5);
            scoreHUD = new HUD("Score", new Vector2(Screen.ClientBounds.Width / 15, Screen.ClientBounds.Height / 7));
            pauseHUD = new HUD();
            loseHUD = new HUD("lose");
            winHUD = new HUD("win");

            // Audio 
            //////////////////////////////////////////////////////////////////////////
            bgm = Content.Load<Song>("bgm");
            MediaPlayer.Volume = 0.25f; 
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(bgm);

            soundEffects.Add(Content.Load<SoundEffect>("levelUp"));
            soundEffects.Add(Content.Load<SoundEffect>("ambience"));
            soundEffects.Add(Content.Load<SoundEffect>("bubble"));
            soundEffects.Add(Content.Load<SoundEffect>("swallow"));

            SoundEffect.MasterVolume = 0.25f;
            var instance = soundEffects[1].CreateInstance();
            instance.IsLooped = true;
            instance.Play();
            //////////////////////////////////////////////////////////////////////////
            
            // Textures 
            //////////////////////////////////////////////////////////////////////////
            Assets.Add("background", Content.Load<Texture2D>("background"));
            Assets.Add("backgroundwgrid", Content.Load<Texture2D>("backgroundwgrid"));
            Assets.Add("player", Content.Load<Texture2D>("player"));
            // Fishes
            Assets.Add("anglerfish", Content.Load<Texture2D>("anglerfish"));
            Assets.Add("barracudina", Content.Load<Texture2D>("barracudina"));
            Assets.Add("blueWhale", Content.Load<Texture2D>("blue whale"));
            Assets.Add("bristlemouth", Content.Load<Texture2D>("bristlemouth"));
            Assets.Add("clownfish", Content.Load<Texture2D>("clownfish"));
            Assets.Add("cuttlefish", Content.Load<Texture2D>("cuttlefish"));
            Assets.Add("flatfish", Content.Load<Texture2D>("flatfish"));
            Assets.Add("lancetfish", Content.Load<Texture2D>("lancetfish"));
            Assets.Add("opah", Content.Load<Texture2D>("opah"));
            Assets.Add("spermWhale", Content.Load<Texture2D>("sperm whale"));
            Assets.Add("stingray", Content.Load<Texture2D>("stingray"));
            Assets.Add("surgeonfish", Content.Load<Texture2D>("surgeonfish"));
            Assets.Add("tripodfish", Content.Load<Texture2D>("tripodfish"));
            // Others 
            Assets.Add("crab", Content.Load<Texture2D>("crab"));
            Assets.Add("jellyfish", Content.Load<Texture2D>("jellyfish"));
            Assets.Add("prawn", Content.Load<Texture2D>("prawn"));
            Assets.Add("turtle", Content.Load<Texture2D>("turtle"));
            Assets.Add("mermaid", Content.Load<Texture2D>("mermaid"));
            Assets.Add("mermaid2", Content.Load<Texture2D>("mermaid2"));
            Assets.Add("alo", Content.Load<Texture2D>("Alo"));
            //////////////////////////////////////////////////////////////////////////

            // Objects 
            //////////////////////////////////////////////////////////////////////////
            World.Add("bg", new Background()); 
            World.Add("player", new Player());

            for (int i = 0; i < anglerNo; i++)
            {
                string n = "anglerfish" + i.ToString();
                World.Add(n, new Anglerfish());
            }

            for (int i = 0; i < barraNo; i++)
            {
                string n = "barracudina" + i.ToString();
                World.Add(n, new Barracudina());
            }

            for (int i = 0; i < blueNo; i++)
            {
                string n = "blueWhale" + i.ToString();
                World.Add(n, new BlueWhale());
            }

            for (int i = 0; i < bristleNo; i++)
            {
                string n = "bristlemouth" + i.ToString();
                World.Add(n, new Bristlemouth());
            }

            for (int i = 0; i < clownNo; i++)
            {
                string n = "clownfish" + i.ToString();
                World.Add(n, new Clownfish());
            }

            for (int i = 0; i < cuttleNo; i++)
            {
                string n = "cuttlefish" + i.ToString();
                World.Add(n, new Cuttlefish());
            }

            for (int i = 0; i < flatNo; i++)
            {
                string n = "flatfish" + i.ToString();
                World.Add(n, new Flatfish());
            }

            for (int i = 0; i < lancetNo; i++)
            {
                string n = "lancetfish" + i.ToString();
                World.Add(n, new Lancetfish());
            }

            for (int i = 0; i < opahNo; i++)
            {
                string n = "opah" + i.ToString();
                World.Add(n, new Opah());
            }

            for (int i = 0; i < spermNo; i++)
            {
                string n = "spermWhale" + i.ToString();
                World.Add(n, new SpermWhale());
            }

            for (int i = 0; i < stingrayNo; i++)
            {
                string n = "stingray" + i.ToString();
                World.Add(n, new Stingray());
            }

            for (int i = 0; i < surgeonNo; i++)
            {
                string n = "surgeonfish" + i.ToString();
                World.Add(n, new Surgeonfish());
            }

            for (int i = 0; i < tripodNo; i++)
            {
                string n = "tripodfish" + i.ToString();
                World.Add(n, new Tripodfish());
            }

            for (int i = 0; i < crabNo; i++)
            {
                string n = "crab" + i.ToString();
                World.Add(n, new Crab());
            }

            for (int i = 0; i < jellyNo; i++)
            {
                string n = "jellyfish" + i.ToString();
                World.Add(n, new Jellyfish());
            }

            for (int i = 0; i < prawnNo; i++)
            {
                string n = "prawn" + i.ToString();
                World.Add(n, new Prawn());
            }

            for (int i = 0; i < turtleNo; i++)
            {
                string n = "turtle" + i.ToString();
                World.Add(n, new Turtle());
            }
            

            World.Add("mermaid", new Mermaid()); 
            World.Add("alo", new Alo());
            //////////////////////////////////////////////////////////////////////////

            World.Sort(); 
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

            if (endState && triggerEnd)
                gameStatus = gameState.Win;

            switch (gameStatus)
            {
                case gameState.Start:
                    StartGame(gameTime);
                    break;
                case gameState.Pause:
                    PauseGame(gameTime);
                    break;
                case gameState.Win:
                    WinGame(gameTime);
                    break;
                case gameState.Lose:
                    LoseGame(gameTime);
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
                levelHUD.Draw(spriteBatch, spriteFont, GraphicsDevice);
                scoreHUD.Draw(spriteBatch, spriteFont, GraphicsDevice); 
            if (gameStatus == gameState.Pause)
                pauseHUD.Draw(spriteBatch, spriteFont, GraphicsDevice);
            if (gameStatus == gameState.Lose)
                loseHUD.Draw(spriteBatch, spriteFont, GraphicsDevice);
            if (gameStatus == gameState.Win)
                winHUD.Draw(spriteBatch, spriteFont, GraphicsDevice);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void StartGame(GameTime gameTime)
        {
            World.Update(gameTime);
            scoreHUD.Update(Score.score.ToString(), new Color(255, 255, 255));
            levelHUD.Update(World.objects["player"].gameSize);
            input.Update(Screen, gameTime);
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (currentTime >= soundCD)
            {
                currentTime = 0;
                soundEffects[2].Play();
            }
            
            scoreCal.Update();
        }

        private void PauseGame(GameTime gameTime)
        {
            input.Update();
        }

        private void LoseGame(GameTime gameTime)
        {
            input.Update();
        }

        private void WinGame(GameTime gameTime)
        {
            input.Update();
        }

        public static void RestartGame()
        {
            World.objects["player"].alive = true;
            endState = false;
            triggerEnd = false; 
            Score.score = 0;
            Score.level = 1;
            World.Reset();
            gameStatus = gameState.Start;
        }
    }
}