using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcBPMS.Models.Entities
{
    public class StaffCart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        /// <summary>给职工购物车中添加项目
        /// <param name="stf">职工对象(与数据库中的定义相关联)<see cref="staff"/></param>
        /// </summary>
        public void AddItem(staff stf)
        {
            CartLine line = lineCollection.Where(p => p.Staff.id == stf.id).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Staff = stf });
            }
        }

        /// <summary>从职工购物车中删除已添加的项目
        /// <param name="stf">职工对象(与数据库中的定义相关联)<see cref="staff"/></param>
        /// </summary>
        public void RemoveLine(staff stf)
        {
            lineCollection.RemoveAll(p => p.Staff.id == stf.id);
        }

        /// <summary>删除全部物品重置购物车
        /// </summary>
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