using StudentTeacher.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Service.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetStudent(int teacherId, int studentId, bool trackChanges);
        Task CreateStudentForTeacher(int teacherId, Student student);
        Task DeleteStudent(Student student);
    }
}
