using System.Collections.Generic;
using System.Threading;
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
        private readonly ILessonService _service;
        private readonly ILogger<LessonController> _logger;
        private readonly IMapper _mapper;

        public LessonController(ILessonService service, ILogger<LessonController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken)
        {
            var lessonDto = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(_mapper.Map<LessonDto, LessonModel>(lessonDto));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatingLessonModel creatingLessonDto)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingLessonModel, CreatingLessonDto>(creatingLessonDto)));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, UpdatingLessonModel creatingLessonDto)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingLessonModel, UpdatingLessonDto>(creatingLessonDto));
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        
        [HttpGet("list/{page}/{itemsPerPage}")]
        public async Task<IActionResult> GetListAsync(int page, int itemsPerPage)
        {
            return Ok(_mapper.Map<List<LessonModel>>(await _service.GetPagedAsync(page, itemsPerPage)));
        }
    }
}