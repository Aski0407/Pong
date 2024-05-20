using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace basic
{
    public delegate void DlgUpdate();
    public delegate void DlgDraw();
    static class G
    {
        public const int INPUTNUM = 3;
        public const int SCREENW = 2000;
        public const int SCREENH = 1200;
        public const int SPEED = SCREENW / 200;
        public const float GRAVITY = 0.4f;
        public const float FLAPSIZE = 9.0f;
        public static Pillar pil;
        public static int pillarcntr = 0;
        public static Texture2D pixel;
        public static SpriteBatch sb;
        public static KeyboardState kb;
        public static ContentManager cm;
        public static Random rnd = new Random();
        public static List<Bird> birdlist;
        public static void init(GraphicsDevice gd, ContentManager cm)
        {
            G.cm = cm;
            birdlist = new List<Bird>();
            sb = new SpriteBatch(gd);
            Game1.updating += update;
            pixel = new Texture2D(gd, 1, 1);
            pixel.SetData<Color>(new Color[1] { Color.White });
        }

        private static void update()
        {
            kb = Keyboard.GetState();
        }
    }
}
