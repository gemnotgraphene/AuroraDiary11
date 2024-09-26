using System;
using System.ComponentModel.DataAnnotations;

namespace AuroraDiary.Models
{
    public class User
    {
        public User(string username, string password, string email, string fullName, DateTime dateOfBirth)
        {
            Username = username;
            Password = password;
            Email = email;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
        }

        public User()
        {
        }

        [Key]
        public string Id { get; set; }  // Changed to string

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool ValidatePassword(string password)
        {
            // Implement password validation logic
            return Password == password;
        }

        public override string ToString()
        {
            return $"User: {Username}, Email: {Email}, Full Name: {FullName}";
        }
    }
}
