﻿#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media; 
#endregion
#region Shortcuts
using GDM = Microsoft.Xna.Framework.GraphicsDeviceManager;
using GD = Microsoft.Xna.Framework.Graphics.GraphicsDevice;
using CM = Microsoft.Xna.Framework.Content.ContentManager;
using SB = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using V2 = Microsoft.Xna.Framework.Vector2;
using V3 = Microsoft.Xna.Framework.Vector3;
using MH = Microsoft.Xna.Framework.MathHelper;
using MX = Microsoft.Xna.Framework.Matrix;
using T2 = Microsoft.Xna.Framework.Graphics.Texture2D;
using F = System.Single;
using SE = Microsoft.Xna.Framework.Graphics.SpriteEffects;
using REC = Microsoft.Xna.Framework.Rectangle;
using KS = Microsoft.Xna.Framework.Input.KeyboardState;
using MS = Microsoft.Xna.Framework.Input.MouseState;
using C = Microsoft.Xna.Framework.Color;
using BSM = Microsoft.Xna.Framework.Graphics.BlendState;
using SSM = Microsoft.Xna.Framework.Graphics.SpriteSortMode;
#endregion
namespace Online
{
    static class Tools
    {
        #region Names
        public static GDM gdm;
        public static GD gd;
        public static CM cm;
        public static SB sb;
        public static KS ks;
        public static int w, h;
        public static string msg;
        #endregion
        #region Initialize
        public static void Initialize(GDM gdm, GD gd, CM cm, SB sb)
        {
            Tools.gdm = gdm;
            Tools.gd = gd;
            Tools.cm = cm;
            Tools.sb = sb;
            w = gdm.PreferredBackBufferWidth = 1024;
            h = gdm.PreferredBackBufferHeight = 768;
            gdm.ApplyChanges();

            
        }

        #endregion
        public static void update_input()
        {
            ks = Keyboard.GetState();
        }
        public static V2  sovev_vector(F zavit)
        {
            MX cli_sivoov = MX.CreateRotationZ(zavit);
            return V2.Transform(-V2.UnitY, cli_sivoov);
        }
    }
}
