using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcBPMS.Models.Entities
{
    public class StaffCart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(staff stf)
        {
            CartLine line = lineCollection.Where(p => p.Staff.id == stf.id).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Staff = stf });
            }
        }

        public void RemoveLine(staff stf)
        {
            lineCollection.RemoveAll(p => p.Staff.id == stf.id);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public class CartLine
        {
            public staff Staff { get; set; }
          
        }
    }
}