using Microsoft.AspNetCore.Mvc;
using OperationDomian.Entities;
using OperationRepository.Repositories;

namespace ShreeGaneshWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeInfoController : Controller
    {
        EmployeeInfoRepository objemployee = new EmployeeInfoRepository();

        [HttpGet]
        [Route("Get")]
        public IEnumerable<EmployeeInfo> Get()
        {
            return objemployee.GetEntity();
        }

        [HttpPost]
        [Route("Add")]
        public int Add(EmployeeInfo employee)
        {
            return objemployee.AddEntity(employee);
        }

        [HttpPut]
        [Route("Update")]
        public int Update(EmployeeInfo employee)
        {
            return objemployee.UpdateEntity(employee);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public int Delete(int id)
        {
            return objemployee.DeleteEntity(id);
        }
    }
}
