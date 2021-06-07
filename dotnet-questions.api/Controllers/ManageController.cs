using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
            var data = _questionService.Find(id);
            return new JsonResult(data);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] string jsonString)
        {
            _questionService.Create(jsonString);
            return Ok("Запрос успешно выполнен");
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("Запрос успешно выполнен");
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] string jsonString)
        {
            var json = await new StreamReader(Request.Body).ReadToEndAsync();
            var result = await _questionService.Update(id, jsonString);
            return Ok("Запрос успешно выполнен");
        }
    }
}