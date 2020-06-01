using System.ComponentModel.DataAnnotations;

namespace alkoholspiele.Models.DTO
{
    public class UpsertGameDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
    }
}