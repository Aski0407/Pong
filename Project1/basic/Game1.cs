using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace basic
{
     public class Game1 : Game
    {
        public static DlgDraw drawing;
        public static DlgUpdate updating;
        GraphicsDeviceManager graphics;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = G.SCREENW;
            graphics.PreferredBackBufferHeight = G.SCREENH;
            graphics.ApplyChanges();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            G.init(GraphicsDevice, Content);
            for (int i = 0; i < 10; i++)
            {
                G.birdlist.Add(new Bird(new Vector2( G.rnd.Next(100,300), G.rnd.Next(400, 600))));
            }
            G.pil = new Pillar(G.SCREENW - 50, 200, 600);
        }

        protected override void UnloadContent()
        {
        }

        void make_new_birds()
        {
         
        }

        protected override void Update(GameTime gameTime)
        {
            updating?.Invoke();
            base.Update(gameTime);
            make_new_birds();
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            G.sb.Begin(SpriteSortMode.FrontToBack);
            drawing?.Invoke();
            G.sb.End();
            base.Draw(gameTime);
        }
    }
}
