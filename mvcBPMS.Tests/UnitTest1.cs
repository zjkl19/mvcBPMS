using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;

//using mvcBPMS.Models;
using mvcBPMS.Models;
using mvcBPMS.Models.Abstract;
using mvcBPMS.Models.Concrete;
//using mvcBPMS.Models.Entities;

using mvcBPMS.Controllers;


using System.Web;
using System.Web.Mvc;

using Moq;

namespace mvcBPMS.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Phy_CanQuery()
        {
            //Arrange

            var fc = new FormCollection();
            fc.Add("staff_no", "1743");
            int staff_no = Convert.ToInt32(fc["staff_no"]);

            var EF = new EFStaffRepository();
            StaffController staffController = new StaffController(EF);

            //var controller = new StaffController(EF);

            //Act
            //IEnumerable <staff> result = (IEnumerable<staff>)staffController.QueryStaff(fc);
            var result = (IEnumerable<staff>) staffController.QueryStaff(fc).Model;
            //var result = staffController.QueryStaff(fc);

            //Assert
            staff[] staffArray = result.ToArray();
            //staffArray.Count();
            //var staffArray = result.
            Assert.AreEqual(staffArray[0].staff_name, "林迪南");
  

        }

        [TestMethod]
        public void CanQuery()
        {
            //Arrange

            var ns = (new staff[] {
                   new staff {id="4e5de6d52e33412f964ae9213beb5dd8",staff_no= 1743,staff_password="e10adc3949ba59abbe56e057f20f883e",
                    staff_name="林迪南", gender=false, office_phone="26811111",mobile_phone="15980565057",position="检测员" }
            });

            Mock<IStaffRepository> mock = new Mock<IStaffRepository>();
            mock.Setup(m => m.QueryStaffBystaff_no(1743)).Returns(ns);

            var fc = new FormCollection();
            fc.Add("staff_no", "1743");
            int staff_no = Convert.ToInt32(fc["staff_no"]);


            StaffController staffController = new StaffController(mock.Object);



            //var controller = new StaffController(EF);

            //Act
            //IEnumerable <staff> result = (IEnumerable<staff>)staffController.QueryStaff(fc);
            var result = mock.Object.QueryStaffBystaff_no(staff_no);
            //var result = staffController.QueryStaff(fc);
            //Assert
            staff[] staffArray = result.ToArray();
            //var staffArray = result.
            Assert.AreEqual(staffArray[0].staff_name,"林迪南");
            mock.VerifyAll();


        }

        [TestMethod]
        public void CanQuery1()
        {
            //Arrange

            var ns = (new staff[] {
                   new staff {id="4e5de6d52e33412f964ae9213beb5dd8",staff_no= 1743,staff_password="e10adc3949ba59abbe56e057f20f883e",
                    staff_name="林迪南", gender=false, office_phone="26811111",mobile_phone="15980565057",position="检测员" }
            });

            Mock<IStaffRepository> mock = new Mock<IStaffRepository>();
            mock.Setup(m => m.QueryStaffBystaff_no(1743)).Returns(ns);

            var fc = new FormCollection();
            fc.Add("staff_no", "1743");
            int staff_no = Convert.ToInt32(fc["staff_no"]);


            StaffController staffController = new StaffController(mock.Object);



            //var controller = new StaffController(EF);

            //Act
            //IEnumerable <staff> result = (IEnumerable<staff>)staffController.QueryStaff(fc);
            //var result = mock.Object.QueryStaffBystaff_no(staff_no);
            IEnumerable<staff> result = (IEnumerable <staff>) staffController.QueryStaff(fc).Model;
            //Assert
            staff[] staffArray = result.ToArray();
            //var staffArray = result.
            Assert.AreEqual(staffArray[0].staff_name, "林迪南");
            //mock.VerifyAll();


        }

        [TestMethod]
        public void CanAdd()
        {
            //Arrange

            var fc = new FormCollection();
            fc.Add("staff_no", "1743");
            fc.Add("staff_password","123456");
            fc.Add("staff_name", "林迪南");
            fc.Add("gender","男");
            fc.Add("office_phone", "26811111");
            fc.Add("mobile_phone", "15980565057");
            fc.Add("position", "检测员");


            Mock<IStaffRepository> mock = new Mock<IStaffRepository>();
            mock.Setup(m => m.AddStaff(fc)).Returns(true);

            StaffController staffController = new StaffController(mock.Object);

            //Act
            //IEnumerable <staff> result = (IEnumerable<staff>)staffController.QueryStaff(fc);
            //var result = mock.Object.QueryStaffBystaff_no(staff_no);
            //var result = (string) staffController.AddStaff(fc).ViewBag.message;

            var result = mock.Object.AddStaff(fc);

            Assert.AreEqual(true, result);


        }
    }
}
