using HomeCare.Models;
using NLog;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace HomeCare.Controllers
{
    public class AccountController : ApiController
    {
        private HomeHealthCareEntities entities = new HomeHealthCareEntities();
        private object varhashedBytes;
        public static int UserId;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public AccountController()
        {
            this.entities = new HomeHealthCareEntities();
        }

        [Route("api/account/register")]

        [HttpPost]

        public IHttpActionResult Register(Users model)
        {

            if (ModelState.IsValid)
            {
                using (entities)
                {
                    entities.AddUser(model.Username, model.Password, model.FirstName, model.LastName);
                    entities.SaveChanges();
                    return Ok();

                }


            }
            return BadRequest();
        }

        [Route("api/account/login")]
        [HttpPost]
        public HttpResponseMessage Login(Users userLogin)
        {
            if (ModelState.IsValid)
            {
                using (entities)
                {

                    using (var sha512 = SHA512.Create())
                    {
                        try
                        {
                            varhashedBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(userLogin.Password));
                        }
                        catch (Exception e)
                        {
                            logger.Error("Error During hashing the Password During login");
                            logger.Error(e);

                        }
                        try
                        {
                            entities.Users.Any(user => user.UserName == userLogin.Username && user.Password== varhashedBytes);
                         
                            
                                string userName = userLogin.Username;
                                
                                Debug.WriteLine("Success &&");
                                logger.Info("User Logged in Successfully");
                                return Request.CreateResponse(HttpStatusCode.Created,
                                                     new
                                                     {

                                                         Success = true,
                                                         RedirectUrl = ("https://localhost:44386/Home/index"),
                                                         userName=userName
                                                         

                                                     });
                            
                        }
                        catch (Exception e)
                        {
                            logger.Error("Error Occoured During User Validation");
                            logger.Error(e);

                        }


                    }

                }
            }
            logger.Error("Invalid User");
            logger.Error("ModelState is Invalid");
            return null;
        }

        [Route("api/account/Logout")]
        [HttpGet]
        public HttpResponseMessage Logout()
        {
            UserId = 0;
            var loginUrl = this.Url.Link("Default", new
            {
                Controller = "HomeHealthCare",
                Action = "Logout"
            });
            logger.Info("User Logged Out Successfully");
            return Request.CreateResponse(HttpStatusCode.Created,
                                     new { Success = true, RedirectUrl = loginUrl });
        }
    }
}
