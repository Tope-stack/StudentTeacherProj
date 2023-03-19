using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentTeacher.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Repo.Data
{
    public class StudentData : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
                new Student
                {
                    Id = 1,
                    Name = "Ayomide",
                    Class = "Science",
                    TeacherId = 1
                },
                new Student
                {
                    Id = 2,
                    Name = "Chidinma",
                    Class = "Management",
                    TeacherId = 2
                },
                new Student
                {
                    Id = 3,
                    Name = "Quadri",
                    Class = "Science",
                    TeacherId = 1
                });
        }
    }
}
