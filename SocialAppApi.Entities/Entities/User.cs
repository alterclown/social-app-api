using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SocialAppApi.Entities.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime? RegisteredAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public string? Intro { get; set; }
        public string? Profile { get; set; }
    }
}
