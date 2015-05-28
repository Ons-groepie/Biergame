using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TheBeerGame
{
    class MainMenu : Game
    {
        GraphicsDeviceManager graphics;
        GraphicsDevice device;
        SpriteBatch spriteBatch;
        MouseState mouseState;
        
        // Background
        Texture2D background;

        // Start buttons
        Texture2D startNormal;
        Texture2D startHover;
        Texture2D startClick;

        // Mouse control
        Texture2D mouseImage;

        // Vars
        int screenWidth;
        int screenHeight;

        public MainMenu()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("background-main");
            mouseImage = Content.Load<Texture2D>("cursor");
            startNormal = Content.Load<Texture2D>("start-normal");
            startHover = Content.Load<Texture2D>("start-hover");
            startClick = Content.Load<Texture2D>("start-click");

            device = graphics.GraphicsDevice;

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // Start de spriteBatch
            spriteBatch.Begin();

            // Bepaal de schermresolutie
            screenWidth = device.PresentationParameters.BackBufferWidth;
            screenHeight = device.PresentationParameters.BackBufferHeight;

            // Teken de sprites
            spriteBatch.Draw(background, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            spriteBatch.Draw(startNormal, new Rectangle(screenWidth/6, screenHeight/2, 400, 144), Color.White);

            // End de spireBatch
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
