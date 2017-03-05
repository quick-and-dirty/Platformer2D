using Microsoft.Xna.Framework;

namespace Platformer2D.GameObjects
{
    public interface IGameObject
    {
        void Update(GameTime gameTime);

        void Draw(GameTime gameTime);
    }
}
