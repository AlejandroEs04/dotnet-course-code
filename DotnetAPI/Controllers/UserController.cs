using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    DataContextDapper _dapper;
    public UserController(IConfiguration config)
    {   
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers()
    {
        string sql = @"
            SELECT 
                [UserId],
                [FirstName],
                [LastName],
                [Email],
                [Gender],
                [Active] 
            FROM TutorialAppSchema.Users
        ";
        IEnumerable<User> users = _dapper.LoadData<User>(sql);

        return users;
    }

    [HttpGet("GetUsers/{userId}")]
    public User GetSingleUser(int userId)
    {
        string sql = @"
            SELECT 
                [UserId],
                [FirstName],
                [LastName],
                [Email],
                [Gender],
                [Active] 
            FROM TutorialAppSchema.Users
            WHERE userId = " + userId.ToString();

        return _dapper.LoadDataSingle<User>(sql);
    }

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user) 
    {
        string sql = @"
            UPDATE TutorialAppSchema.Users
                SET [FirstName] = '" + user.FirstName + @"',
                [LastName] = '" + user.LastName + @"', 
                [Email] = '" + user.Email + @"', 
                [Gender] = '" + user.Gender + @"', 
                [Active] = '" + user.Active + @"'
            WHERE userId = " +user.UserId.ToString();
            
        if(_dapper.ExecuteSql(sql)) {
            return Ok();
        }

        throw new Exception("Failed to update user");
    }

    [HttpPost("AddUser")]
    public IActionResult AddUser(UserDto user) 
    {
        string sql = @"
            INSERT INTO TutorialAppSchema.Users (
                [FirstName],
                [LastName],
                [Email],
                [Gender]
                [Active]
            ) VALUES ( 
                '" + user.FirstName + @"',
                '" + user.LastName + @"',
                '" + user.Email + @"',
                '" + user.Gender + @"',
                '" + user.Active + @"'
            )";

        if(_dapper.ExecuteSql(sql)) {
            return Ok();
        }

        throw new Exception("Failed to create user");
    }

    [HttpDelete("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        string sql = @"
            DELETE TutorialAppSchema.Users
            WHERE UserId = " + userId.ToString();

        if(_dapper.ExecuteSql(sql)) {
            return Ok();
        }

        throw new Exception("Failed to delete user");
    }

    [HttpGet("UserSalary/{userId}")]
    public IEnumerable<UserSalary> GetUserSalary(int userId)
    {
        string sql = @"
            SELECT 
                US.UserId, 
                US.Salary
            FROM TutorialAppSchema.UserSalary AS US
            INNER JOIN TutorialAppSchema.Users AS U on US.UserId = U.UserId
            WHERE US.UserId = " + userId;
        return _dapper.LoadData<UserSalary>(sql);
    }

    [HttpPost("UserSalary")]
    public IActionResult PostUserSalary(UserSalary userSalaryForInsert) 
    {
        string sql = @"
            INSERT INTO TutorialAppSchema.UserSalary (
                [UserId],
                [Salary]
            ) VALUES ( 
                " + userSalaryForInsert.UserId + @",
                " + userSalaryForInsert.Salary + @"
            )";

        if(_dapper.ExecuteSql(sql)) {
            return Ok();
        }

        throw new Exception("Failed to create userSalary");
    }

    [HttpPut("UserSalary")]
    public IActionResult EditUserSalary(UserSalary userSalaryForUpdate) 
    {
        string sql = @"
            UPDATE TutorialAppSchema.UserSalary SET
                Salary = " + userSalaryForUpdate.Salary + @"
            WHERE userId = " +userSalaryForUpdate.UserId;

        if(_dapper.ExecuteSqlWithRowCount(sql) > 0) {
            return Ok();
        }
        
        throw new Exception("Failed to update user");
    }

    [HttpGet("UserJobInfo/{userId}")]
    public IEnumerable<UserJobInfo> GetUserJobInfo(int userId)
    {
        string sql = @"
            SELECT 
                UserId, 
                JobTitle, 
                Department
            FROM TutorialAppSchema.UserJobInfo
            WHERE UserId = " + userId;
        return _dapper.LoadData<UserJobInfo>(sql);
    }

    [HttpPost("UserJobInfo")]
    public IActionResult PostUserJobInfo(UserJobInfo userJobInfoForInsert) 
    {
        string sql = @"
            INSERT INTO TutorialAppSchema.UserJobInfo (
                [UserId],
                [JobTitle], 
                [Department]
            ) VALUES ( 
                " + userJobInfoForInsert.UserId + @",
                '" + userJobInfoForInsert.JobTitle + @"',
                '" + userJobInfoForInsert.Department + @"'
            )";

        if(_dapper.ExecuteSql(sql)) {
            return Ok();
        }

        throw new Exception("Failed to create userSalary");
    }

    [HttpPut("UserJobInfo")]
    public IActionResult EditUserJobInfo(UserJobInfo userJobInfoForUpdate) 
    {
        string sql = @"
            UPDATE TutorialAppSchema.UserJobInfo SET
                JobTitle = '" + userJobInfoForUpdate.JobTitle + @"',
                Department = '" + userJobInfoForUpdate.Department + @"'
            WHERE userId = " +userJobInfoForUpdate.UserId;

        if(_dapper.ExecuteSqlWithRowCount(sql) > 0) {
            return Ok();
        }
        
        throw new Exception("Failed to update user");
    }
}