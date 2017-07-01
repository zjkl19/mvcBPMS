using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcBPMS.Models.Entities
{
    public class ProjectCart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(project prj) {
            CartLine line = lineCollection.Where(p => p.Project.id == prj.id).FirstOrDefault();
        
        if (line == null)
            {
                lineCollection.Add(new CartLine { Project = prj });
            }
        }
        
        public void RemoveLine(project prj) {
            lineCollection.RemoveAll(l => l.Project.id == prj.id);
        }
        
        public void Clear() {
            lineCollection.Clear();
        }
        
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }  

        public class CartLine
        {
            public project Project { get; set; }
        }
    }

}