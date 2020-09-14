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
        public static Dictionary<string, Texture2D> Assets = new Dictionary<string, Texture2D>();
        public static GameWindow Screen;
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
            moveSpeed = 500;

            IsMouseVisible = true;
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
            
            // TODO: Add your update logic here
            World.Update(gameTime);
            
            Input(gameTime); 
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
            World.Draw(spriteBatch, gameTime);

            base.Draw(gameTime);
            
        }

        public void Input(GameTime gameTime)
        {
            //System.Diagnostics.Debug.WriteLine("Y coord: " + World.objects["bg"].position.Y); 
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
                        if (mouse.Position.X < Screen.ClientBounds.Width * 2 / 9)
                        {
                            speedMultiplier++;
                            if (mouse.Position.X < Screen.ClientBounds.Width * 1 / 9)
                                speedMultiplier++;
                        }
                        if (World.objects["bg"].position.X < World.objects["player"].position.X - World.objects["player"].size.X / 3)
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
                        if (World.objects["bg"].position.X + World.objects["bg"].size.X > World.objects["player"].position.X + World.objects["player"].size.X / 3)
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
                        if (World.objects["bg"].position.Y < World.objects["player"].position.Y - World.objects["player"].size.Y / 3)
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
                        if (World.objects["bg"].position.Y + World.objects["bg"].size.Y > World.objects["player"].position.Y + World.objects["player"].size.Y / 3)
                            World.objects[obj.Key].position.Y -= moveSpeed * speedMultiplier * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                }
            }
        }
    }
}
