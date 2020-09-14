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
        Vector2 velocity;
        float distance; 

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
            velocity = Vector2.Zero;
            distance = 0;
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
            

            if (mouse.Position.X < Screen.ClientBounds.Width / 3
             || mouse.Position.X > Screen.ClientBounds.Width * 2 / 3
             || mouse.Position.Y < Screen.ClientBounds.Height / 3
             || mouse.Position.Y > Screen.ClientBounds.Height * 2 / 3)
            {
                velocity = World.objects["player"].position - mouse.Position.ToVector2();
                velocity.Normalize();
                distance = (float)Math.Sqrt((World.objects["player"].position.X - mouse.Position.ToVector2().X) 
                                          * (World.objects["player"].position.X - mouse.Position.ToVector2().X)
                                          + (World.objects["player"].position.Y - mouse.Position.ToVector2().Y) 
                                          * (World.objects["player"].position.Y - mouse.Position.ToVector2().Y));
            }
            else
            {
                velocity = Vector2.Zero;
                distance = 0; 
            }

            if (World.objects["player"].Boundary().Left < World.objects["bg"].Boundary().Left && velocity.X > 0) velocity.X = 0; 
            if (World.objects["player"].Boundary().Right > World.objects["bg"].Boundary().Right && velocity.X < 0) velocity.X = 0; 
            if (World.objects["player"].Boundary().Top < World.objects["bg"].Boundary().Top && velocity.Y > 0) velocity.Y = 0; 
            if (World.objects["player"].Boundary().Bottom > World.objects["bg"].Boundary().Bottom && velocity.Y < 0) velocity.Y = 0; 

            Console.WriteLine("v " + velocity); 

            foreach (var obj in World.objects)
            {
                if (obj.Key != "player")
                    World.objects[obj.Key].position += velocity * 2f * distance * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}