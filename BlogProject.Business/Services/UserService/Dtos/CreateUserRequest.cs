﻿namespace BlogProject.Business.Services.UserService.Dtos;

public class CreateUserRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}