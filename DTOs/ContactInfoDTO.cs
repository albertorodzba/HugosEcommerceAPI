using System;
using System.Collections.Generic;

namespace hugosEcommerce_api.DTOs
{
    public partial class ContactInfoDTO
    {
        public string Name { get; set; }
        public string? BusinessName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public IFormFile File { get; set; }
        public string? FileURL {get; set;}
        public string? CustomIdObject {get;set;}
    }
}
