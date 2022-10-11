using HomeCare.Controllers;
using Kendo.Mvc.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HomeHealthCareUnitTest
{
    [TestClass]
    public class HomeCareUnitTest
    {
        [TestMethod]
       
            public void GetRecordTest()
            {
                var controller = new AppointmentController();
                DataSourceRequest request = new DataSourceRequest();
                var GetAppointment_result = controller.AppointmentRecord();
                //Assert    
                Assert.IsNotNull(GetAppointment_result);
            }
        }
}
