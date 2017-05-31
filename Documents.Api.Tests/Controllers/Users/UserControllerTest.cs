using Microsoft.VisualStudio.TestTools.UnitTesting;
using Documents.Api.Controllers;
using DataAccess.Domains.Users;

namespace Documents.Api.Tests.Controllers.Users
{
    [TestClass]
    public class UserControllerTest
    {
        UserController userController;

        public UserControllerTest()
        {
            userController = new UserController(new UserDomain());
        }

        [TestMethod]
        public void ListAll()
        {
            
        }
    }
}
