using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using dotnet_questions.api.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_questions.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManageController : ControllerBase
    {
        private readonly ILogger<ManageController> _logger;
        private readonly IQuestionService _questionService;

        public ManageController(ILogger<ManageController> logger, IQuestionService questionService)
        {
            _logger = logger;
            _questionService = questionService;
        }

        [HttpGet("{id}")]
        public JsonResult Show(int id)
        {
            var data = _questionService.GetAll();
            return new JsonResult(data);
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