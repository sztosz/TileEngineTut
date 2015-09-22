﻿using System.Collections.Generic;

namespace TileEngineTut {
    public class TileMap {
        public List<MapRow> Rows = new List<MapRow>();
        public int MapWidth = 50;
        public int MapHeight = 50;

        public TileMap() {
            for (var y = 0; y < MapHeight; y++) {
                var thisRow = new MapRow();
                for (var x = 0; x < MapWidth; x++) {
                    thisRow.Columns.Add(new MapCell(0));
                }
                Rows.Add(thisRow);
            }
            // Create Sample Map Data
            Rows[0].Columns[3].TileID = 3;
            Rows[0].Columns[4].TileID = 3;
            Rows[0].Columns[5].TileID = 1;
            Rows[0].Columns[6].TileID = 1;
            Rows[0].Columns[7].TileID = 1;

            Rows[1].Columns[3].TileID = 3;
            Rows[1].Columns[4].TileID = 1;
            Rows[1].Columns[5].TileID = 1;
            Rows[1].Columns[6].TileID = 1;
            Rows[1].Columns[7].TileID = 1;

            Rows[2].Columns[2].TileID = 3;
            Rows[2].Columns[3].TileID = 1;
            Rows[2].Columns[4].TileID = 1;
            Rows[2].Columns[5].TileID = 1;
            Rows[2].Columns[6].TileID = 1;
            Rows[2].Columns[7].TileID = 1;

            Rows[3].Columns[2].TileID = 3;
            Rows[3].Columns[3].TileID = 1;
            Rows[3].Columns[4].TileID = 1;
            Rows[3].Columns[5].TileID = 2;
            Rows[3].Columns[6].TileID = 2;
            Rows[3].Columns[7].TileID = 2;

            Rows[4].Columns[2].TileID = 3;
            Rows[4].Columns[3].TileID = 1;
            Rows[4].Columns[4].TileID = 1;
            Rows[4].Columns[5].TileID = 2;
            Rows[4].Columns[6].TileID = 2;
            Rows[4].Columns[7].TileID = 2;

            Rows[5].Columns[2].TileID = 3;
            Rows[5].Columns[3].TileID = 1;
            Rows[5].Columns[4].TileID = 1;
            Rows[5].Columns[5].TileID = 2;
            Rows[5].Columns[6].TileID = 2;
            Rows[5].Columns[7].TileID = 2;

            Rows[3].Columns[5].AddBaseTile(30);
            Rows[4].Columns[5].AddBaseTile(27);
            Rows[5].Columns[5].AddBaseTile(28);

            Rows[3].Columns[6].AddBaseTile(25);
            Rows[5].Columns[6].AddBaseTile(24);

            Rows[3].Columns[7].AddBaseTile(31);
            Rows[4].Columns[7].AddBaseTile(26);
            Rows[5].Columns[7].AddBaseTile(29);

            Rows[4].Columns[6].AddBaseTile(104);

            // End Create Sample Map Data
        }
    }

    public class MapRow {
        public List<MapCell> Columns = new List<MapCell>();
    }
}