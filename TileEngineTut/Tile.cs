using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileEngineTut {
    public static class Tile {
        public static Texture2D TileSetTexture2D;
        public static int TileWidth = 33;
        public static int TileHeight = 27;
        public static int TileStepX = 52;
        public static int TileStepY = 14;
        public static int OddRowXOffset = 26;


        public static Rectangle GetSourceRectangle(int tileIndex) {
            var tileY = tileIndex / (TileSetTexture2D.Width / TileWidth);
            var tileX = tileIndex % (TileSetTexture2D.Width / TileWidth);
            return new Rectangle(tileX * TileWidth, tileY * TileHeight, TileWidth, TileHeight);
        }
    }
}