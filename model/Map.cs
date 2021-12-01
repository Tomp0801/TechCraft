using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCraft.model
{
    public class Position
    {
        public uint X { get; set; }
        public uint Y { get; set; }
        public Position(uint x, uint y)
        {
            X = x;
            Y = y;
        }
    }
    public class Map
    {
        public Field[,] Fields;
        public int Width { get; }
        public int Height { get; }

        public Map(int width, int height)
        {
            Fields = new Field[width,height];
            Width = width;
            Height = height;

            for (uint y = 0; y < Height; y++)
            {
                for (uint x = 0; x < Width; x++)
                {
                    Fields[x, y] = new Field();
                }
            }
        }

        public void PlaceItem(FieldItem item, uint x, uint y)
        {
            if (x < Width && y < Height)
            {
                Fields[x, y].Item = item;
            } else
            {

            }
        }

        public bool MoveItem(Position pos, Direction dir)
        {
            return MoveItem(pos.X, pos.Y, dir);
        }
        public bool MoveItem(uint x, uint y, Direction dir)
        {
            FieldItem item = Fields[x, y].Item;
            bool failed = false;
            switch (dir)
            {
                case Direction.NORTH:
                    if (y >= 1)
                        Fields[x, y - 1].Item = item;
                    else failed = true;
                    break;
                case Direction.SOUTH:
                    if (y <= Height - 2)
                        Fields[x, y + 1].Item = item;
                    else failed = true;
                    break;
                case Direction.WEST:
                    if (x >= 1)
                        Fields[x - 1, y].Item = item;
                    else failed = true;
                    break;
                case Direction.EAST:
                    if (x <= Width - 2)
                        Fields[x + 1, y].Item = item;
                    else failed = true;
                    break;
            }
            if (!failed) Fields[x, y].Item = null;

            return !failed;
        }

        public override string ToString()
        {
            string retString = "";
            for (uint y = 0; y < Height; y++)
            {
                for (uint x = 0; x < Width; x++) retString += "|-------|";
                retString += "\n";
                for (uint x = 0; x < Width; x++) retString += "|       |";
                retString += "\n";
                for (uint x = 0; x < Width; x++)
                {
                    if (Fields[x, y].Item == null)
                        retString += "|       |";
                    else if (Fields[x, y].Item is Player)
                        retString += "|   P   |";
                    else if (Fields[x, y].Item is MovableEntity)
                        retString += "|   O   |";
                    else
                        retString += "|   X   |";
                }
                retString += "\n";
                for (uint x = 0; x < Width; x++) retString += "|       |";
                retString += "\n";
                for (uint x = 0; x < Width; x++) retString += "|-------|";
                retString += "\n";
            }
            return retString;
        }
    }
}
