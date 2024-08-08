using System.ComponentModel.DataAnnotations;

namespace TimeApp_Server.Models
{
    public class ClientDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ClientName { get; set; } = string.Empty;
    }
}

