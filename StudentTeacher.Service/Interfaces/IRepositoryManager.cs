using StudentTeacher.Repo.GenericRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Service.Interfaces
{
    public interface IRepositoryManager
    {
        ITeacherRepository Teacher { get; }
        IStudentRepository Student { get; }
        IUserAuthenticationRepository UserAuthentication { get; }
        Task SaveAsync();
    }
}
