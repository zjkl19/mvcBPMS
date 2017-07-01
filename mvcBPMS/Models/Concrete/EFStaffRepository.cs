using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

using mvcBPMS.Models.Abstract;
//using mvcBPMS.Models.Entities;

using System.Security.Cryptography;     //Md5加密
using System.Text;

namespace mvcBPMS.Models.Concrete
{
    public class EFStaffRepository:IStaffRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<staff> prop_staff
        {
            get
            {
                //var query = from p in context.staff
                 //           where p.staff_no == 1743
                 //           select p;
                //return query;
                return context.staff;
            }
        }

        public IEnumerable<staff> QueryStaffBystaff_no(int staff_no)
        {
            return context.staff.Where(p=>p.staff_no==staff_no);
        }

        public bool AddStaff(FormCollection fc)
        {
            int staff_no = Convert.ToInt32(fc["staff_no"]);
            string staff_password = Convert.ToString(fc["staff_password"]);
            string staff_name = Convert.ToString(fc["staff_name"]);
            string gender = Convert.ToString(fc["gender"]);
            string office_phone = Convert.ToString(fc["office_phone"]);
            string mobile_phone = Convert.ToString(fc["mobile_phone"]);
            string position = Convert.ToString(fc["position"]);

            //Models.BPMSxEntities db = new Models.BPMSxEntities();
            

            var newData = new Models.staff();

            newData.id = Guid.NewGuid().ToString("N"); //去掉短横杠

            newData.staff_no = staff_no;

            newData.staff_password = "";

            MD5 md5 = MD5.Create(); //实例化一个md5对像
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(staff_password));//加密后是一个字节类型的数组

            //字符串拼接
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                newData.staff_password = newData.staff_password + bytes[i].ToString("x2");
                //sb.Append(bytes[i]);
            }
            //return sb.ToString();

            //newData.staff_password = sb.ToString();

            newData.staff_name = staff_name;
            if (gender == "男")
            {
                newData.gender = false;
            }
            else
            {
                newData.gender = true;
            }

            newData.office_phone = office_phone;
            newData.mobile_phone = mobile_phone;
            newData.position = position;

            try
            {
                context.staff.Add(newData);
                context.SaveChanges();
                //db.staff.Add(newData);
                //db.SaveChanges();
                //ViewBag.message = "添加信息成功！";    //数据库操作回显信息
                return true;
            }
            catch (Exception ex)
            //catch (DbEntityValidationException dbEx)

            {
                throw new Exception("数据库添加信息出现异常。");     
            }
        }

    }
}