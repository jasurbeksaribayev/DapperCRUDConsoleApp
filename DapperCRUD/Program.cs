// See https://aka.ms/new-console-template for more information
using DapperCRUD.Data.IRepositories;
using DapperCRUD.Data.Repositories;
using DapperCRUD.Domain.Entities;
using DapperCRUD.Domain.Enums;
using DapperCRUD.Service.DTOs.Users;
using DapperCRUD.Service.IServices.IUsers;
using DapperCRUD.Service.Services.Users;
using System;

#region

IUserCourseRepository userCourseRepository = new UserCourseRepository();

CourseRepository courseRepository = new CourseRepository();

MentorRepository mentorRepository = new MentorRepository();

UserRepository userRepository = new UserRepository();


//await userRepository.CreateAsync(new User
//{
//    FirstName = "Jamshid",
//    LastName = "Sodiqov",
//    Email = "adsc@1546785",
//    Password = "11234657",
//    Level = Level.elementary
//});

//Console.WriteLine((await userRepository.GetByIdAsync(1)).FirstName);

//await userRepository.DeleteAsync(17);

//await userRepository.UpdateAsync(18, new User
//{
//    FirstName = "Jasur",
//    LastName = "Saribayev",
//    Email = "adsc@154678a",
//    Level = Level.expert

//});

//await mentorRepository.CreateAsync(new Mentor
//{
//    FirstName = "Toxirxon",
//    LastName = "Sodiqov",
//    Email = "adscsa12a@89a",
//    Password = "11234657",
//    BIO = "Expert",
//});


//await courseRepository.CreateAsync(new Course
//{
//    Name = "Phyton1",
//    Description = "odatiy",
//    Section = Section.Programming,
//    MentorId = 4
//});


//await userCourseRepository.CreateUserToCourseAsync(18, 4);

//var a = await userCourseRepository.GetCourseForUserAsync(18);


//foreach (var item in a)
//{
//    Console.WriteLine(item.Name);
//}

//var b= await mentorRepository.GetAllAsync();


//foreach (var item in b)
//{
//	Console.WriteLine(item.FirstName);
//	foreach (var i in item.Courses)
//	{
//		Console.WriteLine(i.Name);
//	}
//}

//var c = await mentorRepository.GetAsync(2);

//Console.WriteLine(c.FirstName);

//foreach (var item in c.Courses)
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