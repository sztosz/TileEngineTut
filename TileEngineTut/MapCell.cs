﻿using System.Collections.Generic;

namespace TileEngineTut {
    public class MapCell {
        public List<int> BaseTiles = new List<int>();
        public List<int> HeightTiles = new List<int>();

        public MapCell(int tileID) {
            TileID = tileID;
        }

        public int TileID {
            get { return BaseTiles.Count > 0 ? BaseTiles[0] : 0; }
            set {
                if (BaseTiles.Count > 0) {
                    BaseTiles[0] = value;
                }
                else {
                    AddBaseTile(value);
                }
            }
        }

        public void AddBaseTile(int tileID) {
            BaseTiles.Add(tileID);
        }

        public void AddHeightTile(int tileID) {
            HeightTiles.Add(tileID);
        }
    }
}