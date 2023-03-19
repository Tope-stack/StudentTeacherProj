using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentTeacher.Service.Interfaces;

namespace StudentTeacher.API.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected readonly IRepositoryManager _repository;
        protected readonly ILoggerManager _logger;
        protected readonly IMapper _mappeer;

        public BaseApiController(IRepositoryManager repository, ILoggerManager logger, IMapper mappeer)
        {
            _repository = repository;
            _logger = logger;
            _mappeer = mappeer; 
        }
    }
}
