﻿using System;
using DAWProject.Models;
using DAWProject.Models.DTOs;
using DAWProject.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace DAWProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        
        [HttpGet("types")]
        public IActionResult GetAllUserTypes()
        {
            var users = _userService.GetAllUserTypes();
            return Ok(users);
        }
        
        [HttpPost("types")]
        public IActionResult CreateUserType(UserType userType)
        {
            _userService.CreateUserType(userType);
            return Ok();
        }
        
        [HttpPut("types")]
        public IActionResult UpdateUserType(UserType userType)
        {
            _userService.UpdateUserType(userType);
            return Ok();
        }
        
        [HttpDelete("types/{id}")]
        public IActionResult DeleteUserType(Guid id)
        {
            _userService.DeleteUserType(id);
            return Ok();
        }
        
        [HttpPost]
        public IActionResult CreateUser(UserDto userDto)
        {
            _userService.CreateUser(userDto);
            return Ok();
        }
    }
}
