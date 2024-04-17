using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserDataController : ControllerBase
{
    DataContextDapper _dapper;
    public UserDataController(IConfiguration config)
    {   
        _dapper = new DataContextDapper(config);
    }

    [HttpPost("")]
    public IActionResult AddUser(UserCompleteDataDto user) 
    {
        string sql = @"
            EXEC TutorialAppSchema.spUser_Upsert
                @FirstName ='" + user.FirstName + @"',
                @LastName ='" + user.LastName + @"',
                @Email ='" + user.Email + @"',
                @Gender ='" + user.Gender + @"',
                @Active ='" + user.Active + @"',
                @JobTitle ='" + user.JobTitle + @"',
                @Department ='" + user.Department + @"',
                @Salary ='" + user.Salary + @"'";

        if(_dapper.ExecuteSql(sql)) {
            return Ok();
        }

        throw new Exception("Failed to create user");
    }

    [HttpGet("")]
    public IEnumerable<UserCompleteData> GetUsers()
    {
        string sql = @"EXEC TutorialAppSchema.spUsers_Get";
        IEnumerable<UserCompleteData> users = _dapper.LoadData<UserCompleteData>(sql);
        return users;
    }

    [HttpGet("{userId}")]
    public UserCompleteData GetSingleUser(int userId)
    {
        string sql = @"EXEC TutorialAppSchema.spUsers_Get @UserId = " + userId.ToString();
        return _dapper.LoadDataSingle<UserCompleteData>(sql);
    }

    [HttpGet("/Active/{isActive}")]
    public IEnumerable<UserCompleteData> GetSingleUserActive(bool isActive)
    {
        string sql = @"EXEC TutorialAppSchema.spUsers_Get @Active = " + isActive.ToString();
        IEnumerable<UserCompleteData> users = _dapper.LoadData<UserCompleteData>(sql);
        return users;
    }

    [HttpPut("{userId}")]
    public IActionResult EditUser(UserCompleteData user, int userId) 
    {
        string sql = @"
            EXEC TutorialAppSchema.spUser_Upsert
                @FirstName ='" + user.FirstName + @"',
                @LastName ='" + user.LastName + @"',
                @Email ='" + user.Email + @"',
                @Gender ='" + user.Gender + @"',
                @Active ='" + user.Active + @"',
                @JobTitle ='" + user.JobTitle + @"',
                @Department ='" + user.Department + @"',
                @Salary ='" + user.Salary + @"',
                @UserId ='" + user.UserId.ToString() + @"'";

        if(_dapper.ExecuteSql(sql)) {
            return Ok();
        }

        throw new Exception("Failed to update user");
    }

    [HttpDelete("{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        string sql = "TutorialAppSchema.spUser_Delete @UserId = " + userId.ToString();

        if(_dapper.ExecuteSql(sql)) {
            return Ok();
        }

        throw new Exception("Failed to delete user");
    }
}