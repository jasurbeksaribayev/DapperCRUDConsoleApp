// See https://aka.ms/new-console-template for more information
using DapperCRUD.Data.IRepositories;
using DapperCRUD.Data.Repositories;
using DapperCRUD.Domain.Entities;
using DapperCRUD.Domain.Enums;
using DapperCRUD.Service.DTOs.UserCourses;
using DapperCRUD.Service.DTOs.Users;
using DapperCRUD.Service.IServices.IMentors;
using DapperCRUD.Service.IServices.IUserCourses;
using DapperCRUD.Service.IServices.IUsers;
using DapperCRUD.Service.Services.Mentors;
using DapperCRUD.Service.Services.UserCourses;
using DapperCRUD.Service.Services.Users;
using System;

#region

//IUserCourseRepository userCourseRepository = new UserCourseRepository();



//await userCourseRepository.CreateUserToCourseAsync(18, 4);

//var a = await userCourseRepository.GetCourseForUserAsync(18);


//foreach (var item in a)
//{
//    Console.WriteLine(item.Name);
//}


#endregion


IUserService userService = new UserService();

//await userService.CreateAsync(new UserForCreationDTO
//{
//    FirstName = "Muhammad",
//    LastName = "Kasimov",
//    Email = "sc@1gfhg5",
//    Password = "11234657",
//    Level = Level.advanced
//});

//await userService.DeleteAsync(21);

//await userService.UpdateAsync(22,new UserForUpdateDTO {
//    FirstName = "Muhammad",
//    LastName = "Kasimov",
//    Email = "sc@1gfhg5",
//    Level = Level.elementary
//});

//var a = await userService.GetAllAsync();


//foreach (var item in a)
//{
//    Console.WriteLine(item.FirstName);

//    foreach (var i in item.Courses)
//    {
//        Console.WriteLine(i.Name);
//    }
//}

//await userService.ChangePasswordAsync(22,new UserForChangePasswordDTO { OldPassword = "11234657", NewPassword = "111", Email="sc@1gfhg5" });


//IMentorService mentorService = new MentorService();

//var a = await mentorService.GetAsync(4);

//Console.WriteLine(a.FirstName);

//foreach (var item in a.Courses)
//{
//    Console.WriteLine(item.Name);
//}


IUserCourseService userCourseService = new UserCourseService();

//await userCourseService.CreateAsync(new UserCourseForCreationDTO { UserId = 19, CourseId = 6 });

await userCourseService.DeleteAsync(new UserCourseForCreationDTO { UserId = 18, CourseId = 4 });




