using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcBPMS.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 合同信息查询
        /// </summary>
        public ActionResult QueryContact()
        {
            ViewBag.query = 0;
            return View();
        }
        /// <summary>
        /// 列出指定查询条件的合同信息
        /// </summary>
        /// <param name="fc">页面表单元素的数据</param>
        /// <returns>指定查询条件的Contact数据</returns>
        [HttpPost]
        public ActionResult QueryContact(FormCollection fc)
        {
            string contact_no = Convert.ToString(fc["contact_no"]);     //读入表单数据

            contact_no = contact_no.ToUpper();

            Models.BPMSxEntities db = new Models.BPMSxEntities();

            var query = from q in db.contact
                        where q.contact_no ==contact_no 
                        select q;

            ViewBag.staff_no = contact_no;
            ViewBag.query = 1;

            return View(query);
        }

        public ActionResult AddContact()
        {

            return View();
        }
        /// <summary>
        /// 添加合同信息
        /// </summary>
        /// <param name="fc">页面表单元素的数据</param>
        [HttpPost]
        public ActionResult AddContact(FormCollection fc)
        {


            string contact_no = Convert.ToString(fc["contact_no"]);
            string contact_name = Convert.ToString(fc["contact_name"]);
            Decimal contact_amount = Convert.ToDecimal(fc["contact_amount"]);
            DateTime contact_signing_data = Convert.ToDateTime(fc["contact_signing_data"]);
            int contact_deadline = Convert.ToInt32(fc["contact_deadline"]);
            string delegation_client = Convert.ToString(fc["delegation_client"]);
            string dlg_contactperson = Convert.ToString(fc["dlg_contactperson"]);
            string dlg_contactperson_phone = Convert.ToString(fc["dlg_contactperson_phone"]);
            string accept_way = Convert.ToString(fc["accept_way"]);
            string is_corporation_signed = Convert.ToString(fc["is_corporation_signed"]);
            string is_client_signed = Convert.ToString(fc["is_client_signed"]);

            int staff_no = Convert.ToInt32(fc["staff_no"]);     //承接人工号
            //string staff_id="";

            Models.BPMSxEntities db = new Models.BPMSxEntities();

            var query = (from p in db.staff
                         where p.staff_no == staff_no
                         select new
                         {
                             p.id
                         }
                         ).DefaultIfEmpty();


            //或
            //foreach (var q in query)
            //{
            //   staff_id=q.id;
            //}

            //其它参考代码
            //staff_id = query.First().id;

            var newData = new Models.contact();

            newData.id = Guid.NewGuid().ToString("N"); //去掉短横杠
            newData.contact_no = contact_no;
            newData.contact_name = contact_name;
            newData.contact_amount = contact_amount;
            newData.contact_signing_data = contact_signing_data;
            newData.contact_deadline = contact_deadline;
            newData.delegation_client = delegation_client;
            newData.dlg_contactperson = dlg_contactperson;
            newData.dlg_contactperson_phone = dlg_contactperson_phone;
            newData.accept_way = accept_way;

            if (is_corporation_signed == "是")
            {
                newData.is_corporation_signed = true;
            }
            else
            {
                newData.is_corporation_signed = false;
            }

            if (is_client_signed == "是")
            {
                newData.is_client_signed = true;
            }
            else
            {
                newData.is_client_signed = false;
            }

            newData.staff_id = query.First().id;

            try
            {
                db.contact.Add(newData);
                db.SaveChanges();

                ViewBag.message = "添加信息成功！";    //数据库操作回显信息
            }
            catch (Exception ex)
            //catch (DbEntityValidationException dbEx)

            {
                throw new Exception("数据库添加信息出现异常。");
            }

            //var data = new Models.staff();
            return View();

        }

        public ActionResult ModContact()
        {

            return View();
        }

        /// <summary>
        /// 修改指定合同编号的合同信息
        /// </summary>
        /// <param name="fc">页面表单元素的数据</param>
        [HttpPost]
        public ActionResult ModContact(FormCollection fc)
        {
            string contact_no = Convert.ToString(fc["contact_no"]);
            string contact_name = Convert.ToString(fc["contact_name"]);
            Decimal contact_amount = Convert.ToDecimal(fc["contact_amount"]);
            DateTime contact_signing_data = Convert.ToDateTime(fc["contact_signing_data"]);
            int contact_deadline = Convert.ToInt32(fc["contact_deadline"]);
            string delegation_client = Convert.ToString(fc["delegation_client"]);
            string dlg_contactperson = Convert.ToString(fc["dlg_contactperson"]);
            string dlg_contactperson_phone = Convert.ToString(fc["dlg_contactperson_phone"]);
            string accept_way = Convert.ToString(fc["accept_way"]);
            string is_corporation_signed = Convert.ToString(fc["is_corporation_signed"]);
            string is_client_signed = Convert.ToString(fc["is_client_signed"]);

            int staff_no = Convert.ToInt32(fc["staff_no"]);     //承接人工号
            //string staff_id="";

            Models.BPMSxEntities staff_db = new Models.BPMSxEntities();

            var q = (from p in staff_db.staff
                         where p.staff_no == staff_no
                         select new
                         {
                             p.id
                         }
                         ).DefaultIfEmpty();


            using (Models.BPMSxEntities db = new Models.BPMSxEntities())
            {
                //var query = (from p in db.contact
                //            where p.contact_no == contact_no
                //            select p).DefaultIfEmpty();

                var query = db.contact.FirstOrDefault(p => p.contact_no == contact_no);

                if (query != null)
                {
                    
                    query.contact_name = contact_name;
                    query.contact_amount = contact_amount;
                    query.contact_signing_data = contact_signing_data;
                    query.contact_deadline = contact_deadline;
                    query.delegation_client = delegation_client;
                    query.dlg_contactperson = dlg_contactperson;
                    query.dlg_contactperson_phone = dlg_contactperson_phone;
                    query.accept_way = accept_way;

                    if (is_corporation_signed == "是")
                    {
                        query.is_corporation_signed = true;
                    }
                    else
                    {
                        query.is_corporation_signed = false;
                    }

                    if (is_client_signed == "是")
                    {
                        query.is_client_signed = true;
                    }
                    else
                    {
                        query.is_client_signed = false;
                    }

                    query.staff_id = q.First().id;  //注意，是职工id，不是合同表的id

                    try
                    {
                        db.SaveChanges();
                        ViewBag.message = "修改信息成功！";    //数据库操作回显信息
                    }
                    catch (Exception ex)
                    //catch (DbEntityValidationException dbEx)

                    {
                        throw new Exception("数据库更新信息出现异常。");
                    }

                }
            }
            return View();
        }
    }
}