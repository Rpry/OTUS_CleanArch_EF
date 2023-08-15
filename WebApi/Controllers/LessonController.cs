using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Contracts.Lesson;
using WebApi.Models.Lesson;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonController: ControllerBase
    {
        private ILessonService _service;
        private readonly ILogger<LessonController> _logger;
        private IMapper _mapper;

        public LessonController(ILessonService service, ILogger<LessonController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var lessonDto = await _service.GetById(id);
            return Ok(_mapper.Map<LessonDto, LessonModel>(lessonDto));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatingLessonModel creatingLessonDto)
        {
            return Ok(await _service.Create(_mapper.Map<CreatingLessonModel, CreatingLessonDto>(creatingLessonDto)));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, UpdatingLessonModel creatingLessonDto)
        {
            await _service.Update(id, _mapper.Map<UpdatingLessonModel, UpdatingLessonDto>(creatingLessonDto));
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
        
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetList(int page, int itemsPerPage)
        {
            return Ok(_mapper.Map<List<LessonModel>>(await _service.GetPaged(page, itemsPerPage)));
        }
    }
}