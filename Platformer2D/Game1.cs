using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer2D
{
    /// <summary>
    /// Classe principale
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public const int MeterInPixel = 100;

        private World World{get; set;}

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Initialisation de Farseer
            World = new World(new Vector2(0, 10));


        }

        /// <summary>
        /// Permet de procéder aux initialisations qui doivent avoir lieu avant que le geu ne puisse démarrer.
        /// C'est ici que sont pré-chargés tous les éléments non graphiques nécessaires à l'application.
        /// Appeller base.Initialise() permet également d'initialiser les parents qui nécessiteraient de l'être.
        /// </summary>
        protected override void Initialize()
        {
            // ToDo: Initialisations

            base.Initialize();
        }

        /// <summary>
        /// LoadContent sera appellé une fois par par partie. C'est ici que les contenus peuvent être chargés.
        /// </summary>
        protected override void LoadContent()
        {
            // Crée  un nouveau SpriteBatch qui sera utilisé pour afficher les différentes textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent sera appellé une fois par partie. C'est ici que sont libérées les ressources qui doivenet l'être.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Permet au jeu d'exécuter les oppérations de mises à jour des différents éléments, telles que:
        /// - détection des collisions
        /// - récupération des entrées
        /// - son
        /// </summary>
        /// <param name="gameTime">Horloge du jeu.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // ToDo: ajouter la logique du jeu ici.

            base.Update(gameTime);
        }

        /// <summary>
        /// Cette méhtode est appellée lorsque le jeu doit s'afficher.
        /// </summary>
        /// <param name="gameTime">Horloge du jeu.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // ToDo: ajouter les oppérations d'affichage ici.

            base.Draw(gameTime);
        }
    }
}
