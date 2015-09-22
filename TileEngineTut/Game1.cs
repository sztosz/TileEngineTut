using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TileEngineTut {
    /// <summary>
    ///     This is the main type for your game.
    /// </summary>
    public class Game1 : Game {
        private readonly TileMap map = new TileMap();
        private readonly int squaresAcross = 18;
        private readonly int squaresDown = 11;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;


        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        ///     Allows the game to perform any initialization it needs to before starting to run.
        ///     This is where it can query for any required services and load any non-graphic
        ///     related content.  Calling base.Initialize will enumerate through any components
        ///     and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Tile.TileSetTexture2D = Content.Load<Texture2D>(@"Textures\TileSets\part2_tileset");
        }

        /// <summary>
        ///     UnloadContent will be called once per game and is the place to unload
        ///     game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                Exit();
            }

            var ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Left)) {
                Camera.Location.X = MathHelper.Clamp(Camera.Location.X - 2, 0,
                    (map.MapWidth - squaresAcross) * Tile.TileWidth);
            }
            if (ks.IsKeyDown(Keys.Right)) {
                Camera.Location.X = MathHelper.Clamp(Camera.Location.X + 2, 0,
                    (map.MapWidth - squaresAcross) * Tile.TileWidth);
            }
            if (ks.IsKeyDown(Keys.Down)) {
                Camera.Location.Y = MathHelper.Clamp(Camera.Location.Y + 2, 0,
                    (map.MapWidth - squaresDown) * Tile.TileHeight);
            }
            if (ks.IsKeyDown(Keys.Up)) {
                Camera.Location.Y = MathHelper.Clamp(Camera.Location.Y - 2, 0,
                    (map.MapWidth - squaresDown) * Tile.TileHeight);
            }

            base.Update(gameTime);
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            var firstSquare = new Vector2(Camera.Location.X / 32, Camera.Location.Y / Tile.TileHeight);
            var firstX = (int) firstSquare.X;
            var firstY = (int) firstSquare.Y;

            var squareOffset = new Vector2(Camera.Location.X % 32, Camera.Location.Y % Tile.TileHeight);
            var offsetX = (int) squareOffset.X;
            var offsetY = (int) squareOffset.Y;

            for (var y = 0; y < squaresDown; y++) {
                for (var x = 0; x < squaresAcross; x++) {
                    foreach (var tileID in map.Rows[y + firstY].Columns[x + firstX].BaseTiles) {
                        spriteBatch.Draw(
                            Tile.TileSetTexture2D,
                            new Rectangle(
                                x * Tile.TileWidth - offsetX,
                                y * Tile.TileHeight - offsetY,
                                Tile.TileHeight,
                                Tile.TileHeight),
                            Tile.GetSourceRectangle(tileID),
                            Color.White);
                    }
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}