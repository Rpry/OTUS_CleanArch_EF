using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Contracts.Course;
using WebApi.Models.Course;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController: ControllerBase
    {
        private readonly ICourseService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ICourseService service, ILogger<CourseController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(_mapper.Map<CourseModel>(await _service.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatingCourseModel courseModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingCourseDto>(courseModel)));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, UpdatingCourseModel courseModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingCourseModel, UpdatingCourseDto>(courseModel));
            return Ok();
        }
        
        
        [HttpPut("WithLessons")]
        public async Task<IActionResult> EditWithLessonsAsync(int id, UpdatingCourseWithLessonsModel courseModel)
        {
            await _service.UpdatingWithLessonsAsync(id, _mapper.Map<UpdatingCourseWithLessonsModel, UpdatingCourseWithLessonsDto>(courseModel));
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        
        [HttpPost("list")]
        public async Task<IActionResult> GetListAsync(CourseFilterModel filterModel)
        {
            var filterDto = _mapper.Map<CourseFilterModel, CourseFilterDto>(filterModel);
            return Ok(_mapper.Map<List<CourseModel>>(await _service.GetPagedAsync(filterDto)));
        }
    }
}