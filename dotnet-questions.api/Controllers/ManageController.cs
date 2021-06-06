using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_questions.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManageController : ControllerBase
    {
        private readonly ILogger<ManageController> _logger;

        public ManageController(ILogger<ManageController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            return Ok("Запрос успешно выполнен");
        }
        
        [HttpPost]
        public IActionResult Create(int id)
        {
            return Ok("Запрос успешно выполнен");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("Запрос успешно выполнен");
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return Ok("Запрос успешно выполнен");
        }
    }
}