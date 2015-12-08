using CAR.PE.Models;
using CAR.PL.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace CARApi.Tests.Controllers
{
    [TestClass]
    public class EmailControllerTest
    {
        [TestMethod]
        public async Task Add_Unique_Email()
        {
            EmailController controller = new EmailController();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            EmailModel email = new EmailModel()
            {
                Email = string.Format("{0}@email.com", (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds)
            };


            IHttpActionResult response = await controller.Post(email);
            OkNegotiatedContentResult<string> emailResult = response as OkNegotiatedContentResult<string>;
            Assert.IsNotNull(emailResult);
            Assert.IsNotNull(emailResult.Content);
            Assert.AreEqual(email, emailResult.Content);
        }

        [TestMethod]
        public async Task Add_Existing_Email_Bad_Request()
        {
            EmailController controller = new EmailController();
            controller.Request = new System.Net.Http.HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            EmailModel email = new EmailModel()
            {
                Email = "albert.herd27@gmail.com"
            };

            IHttpActionResult response = await controller.Post(email);

            Assert.IsInstanceOfType(response, typeof(BadRequestErrorMessageResult));
        }
    }
}
