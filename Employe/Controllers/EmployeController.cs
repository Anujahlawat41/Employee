using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employe.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employe.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class EmployeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public EmployeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllEmploye()
        {
            return Ok(_context.employes.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var EmployeeInDb = _context.employes.Find(id);
            if (EmployeeInDb == null) return NotFound();
            return Ok(EmployeeInDb);
        }

        [HttpPost]
        public IActionResult SaveEmploye([FromBody] employe employe)
        {
            if (employe != null && ModelState.IsValid)
            {
                _context.employes.Add(employe);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateEmploye([FromBody] employe employe)
        {
            if (employe != null && ModelState.IsValid)
            {
                _context.employes.Update(employe);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
            [HttpDelete("{id}")]
            public IActionResult DeleteEmploye(int id)
            {
                var EmployeeInDb = _context.employes.Find(id);
                if (EmployeeInDb == null) return NotFound();
                _context.employes.Remove(EmployeeInDb);
                _context.SaveChanges();
                return Ok();
            }

        }
    }

