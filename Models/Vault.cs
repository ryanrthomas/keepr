using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Vault
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

    }
}