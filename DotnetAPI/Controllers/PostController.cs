using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]


    public class PostController : ControllerBase
    {
        private readonly DataContextDapper _dapper;

        public PostController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("Posts/{postId}/{userId}/{searchParams}")]
        public IEnumerable<Post> GetSinglePost(int postId = 0, int userId = 0, string searchParams = "None")
        {
            string sql = @"TutorialAppSchema.spPosts_Get";
            string parameters = "";

            if (postId != 0)
            {
                parameters += ", @PostId=" + postId.ToString();
            } 
            if (userId != 0)
            {
                parameters += ", @UserID=" + userId.ToString();
            }
            if (searchParams.ToLower() != "none")
            {
                parameters += ", @SearchValue='" + searchParams + "'";
            }

            if(parameters.Length > 0) 
            {
                sql += parameters.Substring(1);
            }

            return _dapper.LoadData<Post>(sql);
        }

        [HttpGet("MyPosts")]
        public IEnumerable<Post> GetMyPosts()
        {
            string sql = @"TutorialAppSchema.spPosts_Get @UserId=" + this.User.FindFirst("userId")?.Value;
            return _dapper.LoadData<Post>(sql);
        }

        [HttpPut("Post")]
        public IActionResult EditPost(PostDto post) 
        {
            string sql = @"TutorialAppSchema.spPost_Upsert
                @UserId=" + this.User.FindFirst("userId")?.Value + @", 
                @PostTitle='" + post.PostTitle + @"',
                @PostContent='" + post.PostContent + "'";
                

            if(post.PostId > 0)
            {
                sql += ", @PostId=" + post.PostId.ToString();
            }

            if(_dapper.ExecuteSql(sql))
            {
                return Ok();
            }
            
            throw new Exception("Failed to Set Post");
        }

        [HttpDelete("Post/{postId}")]
        public IActionResult DeletePost(int postId)
        {
            string sql = @"TutorialAppSchema.spPost_Delete 
                @PostId=" + postId + @",
                @UserId=" + this.User.FindFirst("userId")?.Value;

            if(_dapper.ExecuteSql(sql))
            {
                return Ok();
            }

            throw new Exception("Failed to Delete Post");
        }
    }
}