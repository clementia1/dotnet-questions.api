using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using dotnet_questions.api.Models;
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
        
        [HttpGet]
        public async Task<IActionResult> ShowLast(int showLast = 10)
        {
            _logger.LogInformation($"{DateTime.UtcNow}: {Request.Path.Value} {Request.Method} request received");
            var data = await _questionService.GetLast(showLast);
            return data is null ? NotFound() : new JsonResult(data);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Show(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow}: {Request.Path.Value} {Request.Method} request received");
            var data = await _questionService.Find(id);
            return data is null ? NotFound() : new JsonResult(data);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Question question)
        {
            _logger.LogInformation($"{DateTime.UtcNow}: {Request.Path.Value} {Request.Method} request received");
            var newQuestionId = await _questionService.Create(question);
            
            return CreatedAtAction(nameof(Create), new { id = newQuestionId });
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow}: {Request.Path.Value} {Request.Method} request received");
            return Ok("Запрос успешно выполнен");
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Question question)
        {
            _logger.LogInformation($"{DateTime.UtcNow}: {Request.Path.Value} {Request.Method} request received");
            var result = await _questionService.Update(id, question);
            return result ? NotFound() : CreatedAtAction(nameof(Edit), new { id = question.Id });;
        }
    }
}