using System;
namespace Movies.DTOs
{
    public class LogDTO
    {
        public string Action { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
