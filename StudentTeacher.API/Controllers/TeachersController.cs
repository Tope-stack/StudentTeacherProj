using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentTeacher.Core.Dtos;
using StudentTeacher.Core.Models;
using StudentTeacher.Service.Filters.ActionFilters;
using StudentTeacher.Service.Interfaces;

namespace StudentTeacher.API.Controllers
{
    [Route("api/teachers")]
    [ApiController]
    public class TeachersController : BaseApiController
    {
        public TeachersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {

        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherCreationDto teacher)
        {
            var teacherdata = _mappeer.Map<Teacher>(teacher);
            await _repository.Teacher.CreateTeacher(teacherdata);
            await _repository.SaveAsync();
            var teacherReturn = _mappeer.Map<TeacherDto>(teacher);

            return CreatedAtRoute("TeacherById",
                new 
                {
                    teacherId = teacherReturn.Id
                },
                teacherReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            try
            {
                var teachers = await _repository.Teacher.GetAllTeachers(trackChanges: false);
                var teachersDto = _mappeer.Map<IEnumerable<TeacherDto>>(teachers);
                return Ok(teachersDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetTeachers)} action {ex}");
                return StatusCode(500, "Internal Server Error");
            }
            finally
            {

            }
        }

        [HttpGet("{teacherId}", Name="TeacherById")]
        public async Task<IActionResult> GetTeacher(int teacherId)
        {
            var teacher = await _repository.Teacher.GetTeacher(teacherId, trackChanges: false);
            if (teacher is null)
            {
                _logger.LogInfo($"Teacher with id; {teacherId} doesn't exist in the database");
                return NotFound();
            }
            else
            {
                var teacherDto = _mappeer.Map<TeacherDto>(teacher);
                return Ok(teacherDto);
            }
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateTeacherExists))]
        public async Task<IActionResult> UpdateTeacher(int teacherId, [FromBody] TeacherCreationDto teacher)
        {
            var teacherData = HttpContext.Items["teacher"] as Teacher;
            _mappeer.Map(teacher, teacherData);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
