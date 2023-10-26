using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace inventorySystemForms
{
    internal class Item
    {
        int ID;
        string name;
        string colour;
        string size;

        public Item(int ID, string name)
        {
            this.ID = ID;
            this.name = name;
            this.colour = colour;
            this.size = size;
        }
        public int GetID()
        {
            return ID;
        }
        public string GetName()
        {
            return name;
        }
        public string GetColour()
        {
            return colour;
        }
        public string GetSize()
        {
            return size;
        }

        
    }
}
