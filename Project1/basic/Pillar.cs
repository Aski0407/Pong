using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace basic
{
    class Pillar
    {
        #region data
        public Texture2D texture { get; private set; }
        public float x;
        public float top;
        public float bottom;

        #endregion
        #region ctor
        public Pillar(float x, float top, float bottom)
        {
            this.x = x;
            this.top = top;
            this.bottom = bottom;
            Game1.drawing += draw;
            Game1.updating += update;
        }
        #endregion
        #region funcs
         void update()
        {
            x = x - G.SPEED;
            if (x <= 0)
            {
                x = G.SCREENW - 50;
                int holesize = 400 - G.pillarcntr * 10;
                top = 40 + G.rnd.Next(G.SCREENH - 40 - 40 - holesize);
                bottom = holesize + top;
                G.pillarcntr++;

            }
        }
         void draw()
        {
            G.sb.Draw(G.pixel, new Vector2(x, 0), null, Color.Green, 0,
            Vector2.Zero, new Vector2(40, top), 0, 0);
            G.sb.Draw(G.pixel, new Vector2(x, G.SCREENH), null, Color.Green, 0,
            Vector2.UnitY, new Vector2(40, G.SCREENH - bottom), 0, 0);
        }


        #endregion
    }
}
