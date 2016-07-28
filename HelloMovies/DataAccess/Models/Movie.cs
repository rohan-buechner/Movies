using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelloMovies.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public DateTime Released { get; set; }

        [Required]
        public int GenreTypeId { get; set; }

        [ForeignKey("GenreTypeId")]
        public GenreType Genre { get; set; }
    }
}