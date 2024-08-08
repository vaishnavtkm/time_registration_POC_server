
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TimeApp_Server.Models
{
    public class Posts
    {
        [Key]
        public int Id { get; set; }


        public string From { get; set; } = string.Empty;

        public string To { get; set; } = string.Empty;

        public string Duration { get; set; } = string.Empty;

        public string Clientname { get; set; } = string.Empty;

        public string Casenumber { get; set; } = string.Empty;

        public string Case { get; set; } = string.Empty;

        public string Typeofwork { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;



    }
    
}

