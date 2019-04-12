using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
    public class Keep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
        public string Img { get; set; }
        public int Views { get; set; }
        public int Shares { get; set; }
    }
}