using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TheBeerGame
{
    public class ScreenManager : DrawableGameComponent
    {
        /// <summary>
        /// This boolean is set when the Initialize() method is called.
        /// </summary>
        public bool Initialized { get; private set; }

        /// <summary>
        /// This is the list of active screens in the game.
        /// </summary>
        private Stack<Screen> screens;

        /// <summary>
        /// The current active screen.
        /// </summary>
        public Screen ActiveScreen
        {
            get { return this.Peek(); }
        }

        public ScreenManager(Game game, Screen start)
            : base(game)
        {
            this.screens = new Stack<Screen>();
            if (start != null)
                this.Push(start);
            this.Initialized = false;
        }

        /// <summary>
        /// Initialize all screens in the active screen list.
        /// </summary>
        public override void Initialize()
        {
            foreach (Screen s in this.screens)
                s.Initialize();
            this.Initialized = true;
            base.Initialize();
        }

        /// <summary>
        /// Only update the top of the screen stack.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            this.screens.Peek().Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw all visible screens. A screen that is not translucent will stop the iteration of screens.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            List<Screen> visible = new List<Screen>();
            foreach (Screen s in this.screens)
            {
                visible.Add(s);
                if (!s.Translucent)
                    break;
            }

            // Draw from back to front:
            for (int i = visible.Count - 1; i >= 0; i--)
                visible[i].Draw(gameTime);

            base.Draw(gameTime);
        }

        /// <summary>
        /// Add a screen to the top of the stack, if the manager is initialized but the screen isn't initialize it.
        /// Also set it's manager to this.
        /// </summary>
        /// <param name="screen">The screen to add.</param>
        public void Push(Screen screen)
        {
            screen.Manager = this;
            if (!screen.Initialized && this.Initialized)
                screen.Initialize();
            if (this.ActiveScreen != null)
                this.ActiveScreen.Deactivated();
            this.screens.Push(screen);
        }

        /// <summary>
        /// Get the top of the screen stack. The most active screen.
        /// </summary>
        /// <returns>The active screen.</returns>
        public Screen Peek()
        {
            if (this.screens.Count < 1)
                return null;
            return this.screens.Peek();
        }

        /// <summary>
        /// Remove a screen from the screen stack.
        /// </summary>
        /// <returns>The removed screen.</returns>
        public Screen Pop()
        {
            if (this.screens.Count < 1)
                return null;
            Screen prev = this.screens.Pop();
            if (this.ActiveScreen != null)
                this.ActiveScreen.Activated();
            return prev;
        }
    }
}
