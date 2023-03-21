using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentTeacher.Core.Dtos;
using StudentTeacher.Service.Filters.ActionFilters;
using StudentTeacher.Service.Interfaces;

namespace StudentTeacher.API.Controllers
{
    [ApiController]
    [Route("api/userauthentication")]
    public class AuthController : BaseApiController
    {
        public AuthController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {

        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userRegistration)
        {
            var userResult = await _repository.UserAuthentication.RegisterUserAsync(userRegistration);
            return !userResult.Succeeded ? new BadRequestObjectResult(userResult) : StatusCode(201);
        }
    }
}
