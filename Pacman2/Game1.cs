using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Formats.Asn1.AsnWriter;

namespace Pacman2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 position;
        Texture2D pacmanSprite;
        Texture2D backgroundSprite;
        Player1 player1;
        public enum GameState { Idle, Start, Play, CheckEnd };

        public Game1() //constructor, basic settings
        {
            graphics = new GraphicsDeviceManager(this);
            // _graphics.IsFullScreen = true;  // set to full screen
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() //occurs immediately when the game starts, used to apply certain settings
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent() //images, sounds, other content
        {   
            backgroundSprite = Content.Load<Texture2D>("background");
            pacmanSprite = Content.Load<Texture2D>("pacman");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player1 = new Player1(pacmanSprite, Vector2.Zero, 200, 0.3f);
            
           
            
            // TODO: use this.Content to load your game content here
        }



        protected override void UnloadContent()
        {
            

        }

        protected override void Update(GameTime gameTime) //game loop, runs every frame
        { 
           if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
              Exit();

            player1.Update(gameTime); 
            
            
            
            base.Update(gameTime); 
        }

        protected override void Draw(GameTime gameTime) //also runs every frame, draws only images and text
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(player1.Texture, player1.Position, null, Color.White);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}