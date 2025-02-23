using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Commands;
using UsersAPI.DataContext;
using UsersAPI.Models;
using UsersAPI.Queries;

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromBody] AddUserCommand command)
        {
            var usr = await _mediator.Send(command);
            return CreatedAtAction("GetUser", new { id = usr.Id }, usr);
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _mediator.Send(new GetUserQuery() { Id = id });
            return user != null ? Ok(user) : NotFound("User not found");
        }        
    }
}
