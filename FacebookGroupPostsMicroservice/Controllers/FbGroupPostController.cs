using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Base;
using Application.GroupPosts.Commands.CreateGroupPost;
using Application.GroupPosts.Queries.GetGroupPosts;
using Domain.QueryConfiguration;
using FacebookGroupPostsMicroservice.Models;
using FacebookGroupPostsMicroservice.MongoDb;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacebookGroupPostsMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FbGroupPostController : BaseController
    {

 
        public FbGroupPostController()
        {

        }


        // GET: api/values
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<GroupPostDto>>> Get([FromQuery] QueryOptions options)
        {
            var results = await Mediator.Send(new GetGroupPostsQuery
            {
                QueryOptions = options
            });

            return Ok(results);
        }


        // POST api/values
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] IEnumerable<CreateGroupPostDto> createGroupPostDtos)
        {
            var result = await Mediator.Send(new CreateGroupPostCommand
            {
                CreateGroupPostDtos = createGroupPostDtos
            });

            return Ok(result);
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

