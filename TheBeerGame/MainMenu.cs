using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TheBeerGame
{
    /// <summary>
    /// Struct used to contain a Size
    /// </summary>
    struct Size
    {
        public int height { get; private set; }

        public int width { get; private set; }

        public Size(int width, int height)
            : this()
        {
            this.height = height;
            this.width = width;

        }
    }
    class MainMenu
    {


    }
}
