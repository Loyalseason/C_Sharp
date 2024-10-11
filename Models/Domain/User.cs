using System;
using Microsoft.AspNetCore.Identity;

namespace MyFirstrestFulApi.Models.Domain;

public class User : IdentityUser
{
    public required string FullName { get; set; }

    public UserType Type { get; set; }

    public string Status { get; set; }
}


public enum UserType
{
    SuperAdmin,
    Admin,
    User
}