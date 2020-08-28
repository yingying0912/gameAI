using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Comora;
using System;
using System.Collections.Generic;
namespace Project
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static Dictionary<string, Texture2D> Assets = new Dictionary<string, Texture2D>();
        public static GameWindow Screen;
        private Camera camera;
        private float moveSpeed, speedMultiplier; 

        public Random rand = new Random();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Content.RootDirectory = "Content";
            Screen = this.Window;
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
            moveSpeed = 100;

            IsMouseVisible = true;
            camera = new Camera(GraphicsDevice);
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
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
            Assets.Add("background", Content.Load<Texture2D>("background"));
            Assets.Add("backgroundwgrid", Content.Load<Texture2D>("backgroundwgrid"));
            Assets.Add("wbackground", Content.Load<Texture2D>("wall"));
            Assets.Add("player", Content.Load<Texture2D>("player"));
            Assets.Add("blueWhale", Content.Load<Texture2D>("blue whale"));

            World.Add("player", new Character());
            World.Add("blueWhale", new BlueWhale());
            World.Initialize(rand);
            camera.Position = World.objects["player"].position;
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
            
            // TODO: Add your update logic here
            World.Update(gameTime);

            Vector2 temp = camera.Position; 
            camera.Update(gameTime);

            if (World.objects["player"].position.X > Screen.ClientBounds.Width / 2 &&
                World.objects["player"].position.X < World.worldSize.X - Screen.ClientBounds.Width / 2)
                temp.X = World.objects["player"].position.X;
                //camera.Position = new Vector2(World.objects["player"].position.X, temp.Y);
            if (World.objects["player"].position.Y > Screen.ClientBounds.Height / 2 &&
                World.objects["player"].position.Y < World.worldSize.Y - Screen.ClientBounds.Height / 2)
                temp.Y = World.objects["player"].position.Y;
                //camera.Position = new Vector2(temp.X, World.objects["player"].position.Y);
            
            camera.Position = temp;
            Input(gameTime); 
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(camera); 
                // TODO: Add your drawing code here
                World.Draw(spriteBatch, gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
            
        }

        public void Input(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            foreach (var obj in World.objects)
            {
                if (obj.Key != "player")
                {
                    /*
                    speedMultiplier: 
                    3 3 3 3 3 3 3 3 3 
                    3 2 2 2 2 2 2 2 3 
                    3 2 1 1 1 1 1 2 3 
                    3 2 1 0 0 0 1 2 3 
                    3 2 1 0 0 0 1 2 3 
                    3 2 1 0 0 0 1 2 3 
                    3 2 1 1 1 1 1 2 3 
                    3 2 2 2 2 2 2 2 3 
                    3 3 3 3 3 3 3 3 3 
                    */
                    if (mouse.Position.X < Screen.ClientBounds.Width / 3)
                    {
                        speedMultiplier = 1;
                        //World.objects[obj.Key].position.X += 100f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (mouse.Position.X < Screen.ClientBounds.Width * 2 / 9)
                        {
                            speedMultiplier++;
                            if (mouse.Position.X < Screen.ClientBounds.Width * 1 / 9)
                                speedMultiplier++;
                        }
                        World.objects[obj.Key].position.X += moveSpeed * speedMultiplier * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    if (mouse.Position.X > Screen.ClientBounds.Width * 2 / 3)
                    {
                        speedMultiplier = 1; 
                        if (mouse.Position.X > Screen.ClientBounds.Width * 7 / 9)
                        {
                            speedMultiplier++; 
                            if (mouse.Position.X > Screen.ClientBounds.Width * 8 / 9)
                                speedMultiplier++;
                        }
                        World.objects[obj.Key].position.X -= moveSpeed * speedMultiplier * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    if (mouse.Position.Y < Screen.ClientBounds.Height / 3)
                    {
                        speedMultiplier = 1;
                        if (mouse.Position.Y < Screen.ClientBounds.Height * 2 / 9)
                        {
                            speedMultiplier++;
                            if (mouse.Position.Y < Screen.ClientBounds.Height * 1 / 9)
                                speedMultiplier++;
                        }
                        World.objects[obj.Key].position.Y += moveSpeed * speedMultiplier * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    if (mouse.Position.Y > Screen.ClientBounds.Height * 2 / 3)
                    {
                        speedMultiplier = 1;
                        if (mouse.Position.Y > Screen.ClientBounds.Height * 7 / 9)
                        {
                            speedMultiplier++;
                            if (mouse.Position.Y > Screen.ClientBounds.Height * 8 / 9)
                                speedMultiplier++;
                        }
                        World.objects[obj.Key].position.Y -= moveSpeed * speedMultiplier * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                }
            }
        }
    }
}
