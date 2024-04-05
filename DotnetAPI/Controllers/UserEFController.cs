using AutoMapper;
using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserEFController : ControllerBase
{
    IUserRepository _userRepository;

    IMapper _mapper;

    public UserEFController(IConfiguration config, IUserRepository userRepository)
    {   
        _userRepository = userRepository;

        _mapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<UserDto, User>();
        }));
    }

    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers()
    {
        IEnumerable<User> users = _userRepository.GetUsers();
        return users;
    }

    [HttpGet("GetUsers/{userId}")]
    public User GetSingleUser(int userId)
    {
        return _userRepository.GetSingleUser(userId);
    }

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user) 
    {
        User? userDb = _userRepository.GetSingleUser(user.UserId);

        if(userDb != null) {
            userDb.Active = user.Active;
            userDb.FirstName = user.FirstName;
            userDb.LastName = user.LastName;
            userDb.Email = user.Email;
            userDb.Gender = user.Gender;

            if(_userRepository.SaveChanges())
            {
                return Ok();
            }

            throw new Exception("Failed to Update User");
        }

        throw new Exception("Failed to Get User");
    }

    [HttpPost("AddUser")]
    public IActionResult AddUser(UserDto user) 
    {
        User userDb = _mapper.Map<User>(user);

        userDb.Active = user.Active;
        userDb.FirstName = user.FirstName;
        userDb.LastName = user.LastName;
        userDb.Email = user.Email;
        userDb.Gender = user.Gender;

        _userRepository.AddEntity<User>(userDb);

        if(_userRepository.SaveChanges())
        {
            return Ok();
        }

        throw new Exception("Failed to Create User");
    }

    [HttpDelete("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        User? userDb = _userRepository.GetSingleUser(userId);

        if(userDb != null) {
            _userRepository.RemoveEntity<User>(userDb);

            if(_userRepository.SaveChanges())
            {
                return Ok();
            }

            throw new Exception("Failed to Delete User");
        }

        throw new Exception("Failed to Get User");
    }

    [HttpGet("UserSalary/{userId}")]
    public UserSalary GetUserSalary(int userId)
    {
        UserSalary userSalary = _userRepository.GetSingleUserSalary(userId);
        return userSalary;
    }

    [HttpPut("EditUserSalary")]
    public IActionResult EditUserSalary(UserSalary userSalary) 
    {
        UserSalary? userDb = _userRepository.GetSingleUserSalary(userSalary.UserId);

        if(userDb != null) {
            userDb.Salary = userSalary.Salary;

            if(_userRepository.SaveChanges())
            {
                return Ok();
            }

            throw new Exception("Failed to Update User");
        }

        throw new Exception("Failed to Get User Salary");
    }

    [HttpPost("AddUseralary")]
    public IActionResult AddUserSalary(UserSalary userSalary) 
    {
        UserSalary userDb = _mapper.Map<UserSalary>(userSalary);

        userDb.UserId = userSalary.UserId;
        userDb.Salary = userSalary.Salary;

        _userRepository.AddEntity<UserSalary>(userDb);

        if(_userRepository.SaveChanges())
        {
            return Ok();
        }

        throw new Exception("Failed to Create User Salary");
    }

    [HttpDelete("DeleteUserSalary/{userId}")]
    public IActionResult DeleteUserSalary(int userId)
    {
        UserSalary? userDb = _userRepository.GetSingleUserSalary(userId);
        if(userDb != null) {
            _userRepository.RemoveEntity<UserSalary>(userDb);

            if(_userRepository.SaveChanges())
            {
                return Ok();
            }

            throw new Exception("Failed to Delete User Salary");
        }

        throw new Exception("Failed to Get User Salary");
    }

    [HttpGet("UserJobInfo/{userId}")]
    public UserJobInfo GetUserJobInfo(int userId)
    {
        return _userRepository.GetSingleUserJobInfo(userId);
    }

    [HttpPut("EditUserJobInfo")]
    public IActionResult EditUserJobInfo(UserJobInfo userJobInfo) 
    {
        UserJobInfo? userDb = _userRepository.GetSingleUserJobInfo(userJobInfo.UserId);

        if(userDb != null) {
            userDb.JobTitle = userJobInfo.JobTitle;
            userDb.Department = userJobInfo.Department;

            if(_userRepository.SaveChanges())
            {
                return Ok();
            }

            throw new Exception("Failed to Update User");
        }

        throw new Exception("Failed to Get User Salary");
    }

    [HttpPost("AddUserJobInfo")]
    public IActionResult AddUserJobInfo(UserJobInfo userJobInfo) 
    {
        UserJobInfo userDb = _mapper.Map<UserJobInfo>(userJobInfo);

        userDb.UserId = userJobInfo.UserId;
        userDb.JobTitle = userJobInfo.JobTitle;
        userDb.Department = userJobInfo.Department;

        _userRepository.AddEntity<UserJobInfo>(userDb);

        if(_userRepository.SaveChanges())
        {
            return Ok();
        }

        throw new Exception("Failed to Create User Job Info");
    }

    [HttpDelete("DeleteUserJobInfo/{userId}")]
    public IActionResult DeleteUserJobInfo(int userId)
    {
        UserJobInfo? userDb = _userRepository.GetSingleUserJobInfo(userId);

        if(userDb != null) {
            _userRepository.RemoveEntity<UserJobInfo>(userDb);

            if(_userRepository.SaveChanges())
            {
                return Ok();
            }

            throw new Exception("Failed to Delete User Job Info");
        }

        throw new Exception("Failed to Get User Job Info");
    }
}