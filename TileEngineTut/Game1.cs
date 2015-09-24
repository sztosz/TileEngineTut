using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TileEngineTut {
    /// <summary>
    ///     This is the main type for your game.
    /// </summary>
    public class Game1 : Game {
        private readonly TileMap map = new TileMap();
        private readonly int squaresAcross = 17;
        private readonly int squaresDown = 37;
        private int baseOffsetX = -32;
        private int baseOffsetY = -64;
        private float heightRowDepthMod = 0.0000001f;
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
            Tile.TileSetTexture2D = Content.Load<Texture2D>(@"Textures\TileSets\part4_tileset");
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
                    (map.MapWidth - squaresAcross) * Tile.TileStepX);
            }
            if (ks.IsKeyDown(Keys.Right)) {
                Camera.Location.X = MathHelper.Clamp(Camera.Location.X + 2, 0,
                    (map.MapWidth - squaresAcross) * Tile.TileStepX);
            }
            if (ks.IsKeyDown(Keys.Down)) {
                Camera.Location.Y = MathHelper.Clamp(Camera.Location.Y + 2, 0,
                    (map.MapWidth - squaresDown) * Tile.TileStepY);
            }
            if (ks.IsKeyDown(Keys.Up)) {
                Camera.Location.Y = MathHelper.Clamp(Camera.Location.Y - 2, 0,
                    (map.MapWidth - squaresDown) * Tile.TileStepY);
            }

            base.Update(gameTime);
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            var firstSquare = new Vector2(Camera.Location.X / Tile.TileStepX, Camera.Location.Y / Tile.TileStepY);
            var firstX = (int) firstSquare.X;
            var firstY = (int) firstSquare.Y;

            var squareOffset = new Vector2(Camera.Location.X % Tile.TileStepX, Camera.Location.Y % Tile.TileStepY);
            var offsetX = (int) squareOffset.X;
            var offsetY = (int) squareOffset.Y;

            var maxDepth = ((map.MapWidth + 1) * (map.MapHeight + 1) * Tile.TileWidth) / 10;

            for (var y = 0; y < squaresDown; y++) {
                var rowOffset = (firstY + y) % 2 == 1 ? Tile.OddRowXOffset : 0;
                for (var x = 0; x < squaresAcross; x++) {
                    var mapx = firstX + x;
                    var mapy = firstY + y;
                    var depthOffset = 0.7f - ((float)(mapx + (mapy * Tile.TileWidth)) / maxDepth);
                    foreach (var tileID in map.Rows[mapy].Columns[mapx].BaseTiles) {
                        spriteBatch.Draw(
                            Tile.TileSetTexture2D,
                            new Rectangle(
                                x * Tile.TileStepX - offsetX + rowOffset + baseOffsetX, 
                                y * Tile.TileStepY - offsetY + baseOffsetY,
                                Tile.TileWidth,
                                Tile.TileHeight),
                            Tile.GetSourceRectangle(tileID),
                            Color.White,
                            0.0f,
                            Vector2.Zero, 
                            SpriteEffects.None, 
                            1.0f);
                    }

                    var heightRow = 0;

                    foreach (var tileID in map.Rows[mapy].Columns[mapx].HeightTiles) {
                        spriteBatch.Draw(
                            Tile.TileSetTexture2D,
                            new Rectangle(
                                x * Tile.TileStepX - offsetX + rowOffset + baseOffsetX, 
                                y * Tile.TileStepY - offsetY + baseOffsetY - (heightRow * Tile.HeightTileOffset),
                                Tile.TileWidth,
                                Tile.TileHeight),
                            Tile.GetSourceRectangle(tileID),
                            Color.White,
                            0.0f,
                            Vector2.Zero, 
                            SpriteEffects.None, 
                            depthOffset - (heightRow * heightRowDepthMod));
                        heightRow++;
                    }
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}