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
        private ICourseService _service;
        private IMapper _mapper;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ICourseService service, ILogger<CourseController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<CourseModel>(await _service.GetById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatingCourseModel courseModel)
        {
            return Ok(await _service.Create(_mapper.Map<CreatingCourseDto>(courseModel)));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, UpdatingCourseModel courseModel)
        {
            await _service.Update(id, _mapper.Map<UpdatingCourseModel, UpdatingCourseDto>(courseModel));
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
        
        [HttpPost("list")]
        public async Task<IActionResult> GetList(CourseFilterModel filterModel)
        {
            var filterDto = _mapper.Map<CourseFilterModel, CourseFilterDto>(filterModel);
            return Ok(_mapper.Map<List<CourseModel>>(await _service.GetPaged(filterDto)));
        }
    }
}