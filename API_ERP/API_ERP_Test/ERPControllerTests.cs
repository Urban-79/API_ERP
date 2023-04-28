using API_ERP.Class;
using API_ERP.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ERP_Test
{
    public class ERPControllerTests
    {
        private ERPcontextMock _contextMock = new ERPcontextMock();
        [Fact]
        public async Task GetAllCommands()
        {
           //arrage 
           CommandesController controller = new CommandesController(_contextMock);
           
           //Act
           var result = await controller.GetAllCommands();

            //Assert 
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Order>>(actionResult.Value) ;
            Assert.NotNull(result);
        }

    }
}
