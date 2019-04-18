using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class VaultKeep
    {
      public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public string UserId { get; set; }
        [Required]

        public string Img { get; set; }
        [Required]
        public int Views { get; set; }
        public int Shares { get; set; }
        public int Keeps { get; set; }
        public bool IsPrivate { get; set; }
    }
}