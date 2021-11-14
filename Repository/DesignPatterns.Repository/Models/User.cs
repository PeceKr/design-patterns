using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesignPatterns.Repository.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}