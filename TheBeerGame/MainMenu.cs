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
        MouseState oldMouseState;
        
        // Background
        Texture2D background;

        // Start buttons
        Texture2D startNormal;
        Texture2D startHover;
        Texture2D startClick;
        Texture2D startClicked;

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
            startClicked = Content.Load<Texture2D>("start-clicked");


            device = graphics.GraphicsDevice;
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

            int startPosX = 300;
            int startPosY = 500;
            int startWidth = 400;
            int startHeight = 144;

            // Teken de sprites
            spriteBatch.Draw(background, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
            

            if (mouseState.X >= startPosX && mouseState.X <= startPosX+startWidth)
            {
                if (mouseState.Y >= startPosY && mouseState.Y <= startPosY+startHeight)
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        spriteBatch.Draw(startClick, new Rectangle(startPosX, startPosY, startWidth, startHeight), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(startHover, new Rectangle(startPosX, startPosY, startWidth, startHeight), Color.White);
                    }
                    if (oldMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
                    {
                       // Load other screen
                       
                    }
                }
                else
                {
                    spriteBatch.Draw(startNormal, new Rectangle(startPosX, startPosY, startWidth, startHeight), Color.White);
                }
            }
            else
            {
                spriteBatch.Draw(startNormal, new Rectangle(startPosX, startPosY, startWidth, startHeight), Color.White);
            }

            oldMouseState = mouseState;

            // End de spireBatch
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
