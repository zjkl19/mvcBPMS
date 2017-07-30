using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcBPMS.Models.Entities
{
    public class ProjectCart
    {


        private List<CartLine> lineCollection = new List<CartLine>();

        /// <summary>给项目购物车中添加项目
        /// <param name="prj">项目对象(与数据库中的定义相关联)<see cref="project"/> for information about output statements.</param>
        /// </summary>
        public void AddItem(project prj)
        {
            CartLine line = lineCollection.Where(p => p.Project.id == prj.id).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine { Project = prj });
            }
        }

        /// <summary>从购物车中删除已添加的项目
        /// <param name="prj">项目对象(与数据库中的定义相关联)<see cref="project"/> for information about output statements.</param>
        /// </summary>
        public void RemoveLine(project prj)
        {
            lineCollection.RemoveAll(l => l.Project.id == prj.id);
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
            public project Project { get; set; }
        }
    }

}