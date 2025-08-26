using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using cyberisntreal.Screens;

namespace cyberisntreal
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private RenderTarget2D _renderTarget;
        private Screen _currentScreen;
        
        public static readonly Point VirtualSize = new(320, 180);
        public static readonly Point WindowSize = new(1280, 720);
        
        public SpriteFont Font { get; private set; }
        public Texture2D Pixel { get; private set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            _graphics.PreferredBackBufferWidth = WindowSize.X;
            _graphics.PreferredBackBufferHeight = WindowSize.Y;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // Create render target for pixel-perfect scaling
            _renderTarget = new RenderTarget2D(GraphicsDevice, VirtualSize.X, VirtualSize.Y);
            
            // Load font
            Font = Content.Load<SpriteFont>("PixelFont");
            
            // Create 1x1 white pixel texture
            Pixel = new Texture2D(GraphicsDevice, 1, 1);
            Pixel.SetData(new[] { Color.White });
            
            // Initialize first screen
            _currentScreen = new BriefingScreen(this);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _currentScreen = _currentScreen.Update(gameTime) ?? _currentScreen;
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Draw to virtual resolution render target
            GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(Color.Black);
            
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _currentScreen.Draw(_spriteBatch);
            _spriteBatch.End();
            
            // Draw render target to screen with pixel-perfect scaling
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);
            
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_renderTarget, 
                new Rectangle(0, 0, WindowSize.X, WindowSize.Y), 
                Color.White);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
        
        protected override void UnloadContent()
        {
            _renderTarget?.Dispose();
            Pixel?.Dispose();
        }
    }
}