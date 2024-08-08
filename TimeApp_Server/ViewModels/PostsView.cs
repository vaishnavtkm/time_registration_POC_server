using System.ComponentModel.DataAnnotations;

namespace TimeApp_Server.ViewModels
{
    public class PostsView
    {
        [Required]
        public string From { get; set; } = string.Empty;

        [Required]
        public string To { get; set; } = string.Empty;

        [Required]
        public string Duration { get; set; } = string.Empty;

        [Required]
        public string Clientname { get; set; } = string.Empty;

        [Required]
        public string Casenumber { get; set; } = string.Empty;

        
        public string Case { get; set; } = string.Empty;

        
        public string Typeofwork {  get; set; } = string.Empty;

        
        public string Description { get; set; } = string.Empty;
    }
    public class ReadPostsView
    {
        public int Id { get; set; }
        [Required]
        public string From { get; set; } = string.Empty;

        [Required]
        public string To { get; set; } = string.Empty;

        [Required]
        public string Duration { get; set; } = string.Empty;

        [Required]
        public string Clientname { get; set; } = string.Empty;

        [Required]
        public string Casenumber { get; set; } = string.Empty;

        
        public string Case { get; set; } = string.Empty;

        
        public string Typeofwork {  get; set; } = string.Empty;

        
        public string Description { get; set; } = string.Empty;
    }
}
