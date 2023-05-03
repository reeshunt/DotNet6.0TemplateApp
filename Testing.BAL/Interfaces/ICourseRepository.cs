using System;
using Testing.Models.DTO;
namespace Testing.BAL.Interfaces
{
	
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<Course> GetCourse();
    }
}

