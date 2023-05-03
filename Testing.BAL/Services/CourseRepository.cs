using System;
using Microsoft.EntityFrameworkCore;
using Testing.BAL.Interfaces;
using Testing.DAL.Entities;
using Testing.Models.DTO;
namespace Testing.BAL.Services
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(MachineTestContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<Course> GetCourse()
        {
            return await GetAll()
                .OrderByDescending(c => c.Name)
                .FirstOrDefaultAsync();
        }
    }

}