using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework.Input;

namespace Platformer2D.GameObjects
{
    public class Player : IGameObject
    {

        public World World { get; private set; }

        public SpriteBatch SpriteBatch { get; private set; }

        public Texture2D Texture { get; private set; }

        public Body Body { get; private set; }

        public float Height => Texture.Height / Game1.MeterInPixel;

        public Player(World world, SpriteBatch spriteBatch, Vector2 position, Texture2D texture)
        {
            World = world;
            SpriteBatch = spriteBatch;
            Texture = texture;

            Body = BodyFactory.CreateRectangle(world, Texture.Width / (float)Game1.MeterInPixel, Texture.Height / (float)Game1.MeterInPixel, 1, position);
            Body.FixedRotation = true;
            Body.BodyType = BodyType.Dynamic;
            Body.UserData = this;
        }


        public void Draw(GameTime gameTime)
        {
            var origin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);
            SpriteBatch.Draw(Texture, Body.Position * Game1.MeterInPixel, null, Color.White, 0f, origin, 1f, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                var contact = Body.ContactList;
                while(contact != null)
                {
                    var floor = contact.Contact.FixtureA.Body.UserData as Floor ?? contact.Contact.FixtureB.Body.UserData as Floor;

                    if (floor != null && floor.Body.Position.Y  - floor.Height / 2 >= this.Body.Position.Y + this.Height/2)
                    {
                         Body.ApplyLinearImpulse(new Vector2(0, -1));
                        break;
                    }

                    contact = contact.Next;
                }
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                Body.LinearVelocity = new Vector2(-1, Body.LinearVelocity.Y);
            }else if(keyboardState.IsKeyDown(Keys.D))
            {
                Body.LinearVelocity = new Vector2(1, Body.LinearVelocity.Y);
            }else
            {
                Body.LinearVelocity = new Vector2(0, Body.LinearVelocity.Y);
            }
        }
    }
}
