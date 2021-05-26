using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SampleWebApplication.Data;
using SampleWebApplication.Data.Entities;

namespace SampleWebApplication2021.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectoryController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<DirectoryController> _logger;

        public DirectoryController(ILogger<DirectoryController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("employees")]
        public IEnumerable<Employee> GetEmployees()
        {
            return _dbContext.Employees.Include(x => x.Position).ToArray();
        }
        
        [HttpGet]
        [Route("positions")]
        public IEnumerable<EmployeePosition> GetPositions()
        {
            return _dbContext.EmployeePositions.ToArray();
        }
        
        [HttpPost]
        [Route("submitEmployee")]
        public ActionResult<IEnumerable<Employee>> SubmitEmployee(Employee data)
        {
            // NOTE: normally there would be a service for this

            if (data.ID != null)
            {
                var target = _dbContext.Employees.FirstOrDefault(x => x.ID == data.ID);
                if (target == null)
                    return BadRequest($"Could not find user with the specified ID: {data.ID}");

                target.FullName = data.FullName;
                target.Address = data.Address;
                target.PhoneNumber = data.PhoneNumber;
                target.PositionID = data.PositionID;
            }
            else
            {
                _dbContext.Employees.Add(data);
            }

            _dbContext.SaveChanges();

            return Ok(GetEmployees());
        }

        [HttpDelete]
        [Route("deleteEmployee")]
        public ActionResult<IEnumerable<Employee>> DeleteEmployee(int id)
        {
            // NOTE: normally there would be a service for this

            var target = _dbContext.Employees.FirstOrDefault(x => x.ID == id);
            if (target == null)
                return BadRequest($"Could not find user with the specified ID: {id}");

            _dbContext.Employees.Remove(target);
            _dbContext.SaveChanges();

            return Ok(GetEmployees());
        }
    }
}
