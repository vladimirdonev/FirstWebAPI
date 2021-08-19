using System;
using System.ComponentModel.DataAnnotations;

namespace FirstWebAPI.Models
{
    public class Book
    {

        public Book()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
