using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventorySystemForms
{
    class MixBox
    {
        int boxID = 0;
        List<object> items = new List<object> { };
        List<object> totals = new List<object> { };


        public void AddItem(object item)
        {
            items.Add(item);
        }
        public void AddTotal(object total)
        {
            totals.Add(total);
        }
        public void SetBoxID(int boxID)
        {
            this.boxID = boxID;
        }
        public List<object> GetItems()
        {
            return items;
        }
        public List<object> GetTotals()
        {
            return totals;
        }
        public int GetID()
        {
            return boxID;
        }
    }
}
