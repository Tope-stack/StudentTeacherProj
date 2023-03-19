using StudentTeacher.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Service.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachers(bool trackChanges);
        Task<Teacher> GetTeacher(int teacherId, bool trackChanges);
        Task CreateTeacher(Teacher teacher);
    }
}
