using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman2
{
    internal class Player1 //pacman character
    {
        public Texture2D Texture { get; set;} 
        public Vector2 Position {get; set;} 
        public float Speed { get; set;} 
        public float Scale { get; set;} 

        public Player1(Texture2D tex, Vector2 pos, float speed, float scale)
        {
            this.Texture = tex;
            this.Position = pos;
            this.Speed = 200;
            this.Scale = 0.3f;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Vector2 movement = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.W))
            {
                movement.Y -=1; //move up
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                movement.X -= 1; //move left
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                movement.Y += 1; //move down
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                movement.X += 1;  //move right
            }

            if (movement != Vector2.Zero)
            {
                // Normalize the movement vector to ensure consistent speed in all directions
                movement.Normalize();
            }
            // Update player position based on movement vector and speed
            Position += movement * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
            // Calculate the origin point for scaling (usually the center of the sprite)
            Vector2 origin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);

            // Draw the player sprite with scaling
            //spriteBatch.Draw(texture, Position, null, Color.White, 0f, origin, Scale, SpriteEffects.None, 0f);

        }

    }
}
