using AutoMapper;
using DapperCRUD.Data.IRepositories;
using DapperCRUD.Data.Repositories;
using DapperCRUD.Domain.Entities;
using DapperCRUD.Service.DTOs.Courses;
using DapperCRUD.Service.DTOs.Mentors;
using DapperCRUD.Service.Exceptions;
using DapperCRUD.Service.IServices.ICourses;
using DapperCRUD.Service.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Service.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CourseService()
        {
            unitOfWork = new UnitOfWork();
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }).CreateMapper();
        }
        public async ValueTask<CourseForViewDTO> CreateAsync(CourseForCreationDTO courseForCreationDTO)
        {
            var existCourse = (unitOfWork.Courses.GetAll()).FirstOrDefault(c => c.Name == courseForCreationDTO.Name); ;

            if (existCourse != null)
                throw new DapperCRUDAppException("Course already exist");

            var createdCourse = await unitOfWork.Courses.CreateAsync(mapper.Map<Course>(courseForCreationDTO));

            return mapper.Map<CourseForViewDTO>(createdCourse);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var deletedCourse = await unitOfWork.Mentors.DeleteAsync(id);

            if (!deletedCourse)
                throw new DapperCRUDAppException("Course not found");

            return true;
        }

        public IEnumerable<CourseForViewDTO> GetAllAsync(Func<Course, bool> expression = null)
        {
            var result = unitOfWork.Courses.GetAll();

            if (expression == null)
                return mapper.Map<IEnumerable<CourseForViewDTO>>(result);

            var mentors = result.Where(expression);

            return mapper.Map<IEnumerable<CourseForViewDTO>>(mentors);
        }

        public async ValueTask<CourseForViewDTO> GetAsync(int id)
        {
            var course = await unitOfWork.Courses.GetAsync(id);

            if (course == null)
                throw new DapperCRUDAppException("Courses not found");

            return mapper.Map<CourseForViewDTO>(course);
        }

        public async ValueTask<CourseForViewDTO> UpdateAsync(int id, CourseForUpdateDTO courseForUpdateDTO)
        {
            var existCourse = unitOfWork.Courses.GetAll();

            var course = existCourse.FirstOrDefault(c => c.Id == id);

            if (course == null)
                throw new DapperCRUDAppException(404, "Course not found");



            if (course.Name == courseForUpdateDTO.Name || course.Id != id)
                throw new DapperCRUDAppException(404, "This course already exist");

            var courses = mapper.Map(courseForUpdateDTO, course);

            var updateCourse = await unitOfWork.Courses.UpdateAsync(course.Id, course);

            return mapper.Map<CourseForViewDTO>(updateCourse);
        }
    }
}
