using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibManagementApi.Models
{
    public class User
    {
        public Guid UserID { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}