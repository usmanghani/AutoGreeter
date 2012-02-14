using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace AutoGreeter.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [Required]
        [MinLength(6), MaxLength(20)]
        [RegularExpression("^[A-Za-z0-9_][A-Za-z0-9_.]{5,19}$")]
        public string Username { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,4}$")]
        public string Email { get; set; }
        public string TwitterHandle { get; set; }
        public string FacebookHandle { get; set; }
        public string Salt { get; set; }
        public string PasswordHash { get; set; }
    }

    public class UserSession
    {
        public int Id { get; set; }
        public string Token { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string Username { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastLoginTimestamp { get; set; }

        // if there is no expiration timestamp, it means its a non-persistent cookie.
        // RememberMe == false.
        public DateTime? ExpirationTimestamp { get; set; }
    }
}