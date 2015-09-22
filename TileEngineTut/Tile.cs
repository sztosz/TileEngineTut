using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileEngineTut {
    public static class Tile {
        public static Texture2D TileSetTexture2D;
        public static int TileWidth = 48;
        public static int TileHeight = 48;


        public static Rectangle GetSourceRectangle(int tileIndex) {
            var tileY = tileIndex / (TileSetTexture2D.Width / TileWidth);
            var tileX = tileIndex % (TileSetTexture2D.Width / TileWidth);
            return new Rectangle(tileX * TileWidth, tileY * TileHeight, TileWidth, TileHeight);
        }
    }
}