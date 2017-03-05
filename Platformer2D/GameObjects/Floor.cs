using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Factories;

namespace Platformer2D.GameObjects
{
    class Floor : IGameObject
    {

        public World World { get; private set; }

        public SpriteBatch SpriteBatch { get; private set; }
        
        public Body Body { get; private set; }

        public Texture2D Texture { get; private set; }

        public int NbSprites { get; private set; }

        public float Height => Texture.Height / Game1.MeterInPixel;

        public Floor(World world, SpriteBatch spriteBatch, Vector2 position, Texture2D texture, int nbSprites = 1)
        {
            World = world;
            SpriteBatch = spriteBatch;
            Texture = texture;
            NbSprites = nbSprites;

            Body = BodyFactory.CreateRectangle(world, Texture.Width * nbSprites / (float)Game1.MeterInPixel , Texture.Height / (float)Game1.MeterInPixel, 1, position);
            Body.IsStatic = true;
            Body.Friction = 0.5f;
            Body.UserData = this;
        }

        public void Draw(GameTime gameTime)
        {
            var groundOrigin = new Vector2(Texture.Width / 2f, Texture.Height / 2f);

            for (int i = 0; i < NbSprites; i++)
            {
                SpriteBatch.Draw(Texture, Body.Position * Game1.MeterInPixel + new Vector2((-(NbSprites-1)/2f + i)*Texture.Width, 0), null, Color.White, 0f, groundOrigin, 1f, SpriteEffects.None, 0f);
            }


        }

        public void Update(GameTime gameTime)
        {}
    }
}
