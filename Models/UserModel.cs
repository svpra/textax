using System;

namespace Tectex.Models {
    public class UserModel {
        [Key]
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public Avatar { get; set; }
        
        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                Name = User.FindFirst(c => c.Type == ClaimTypes.Name)?.Value;
                Nick = User.FindFirst(c => c.Type == "urn:github:login")?.Value;
                Url = User.FindFirst(c => c.Type == "urn:github:url")?.Value;
                Avatar = User.FindFirst(c => c.Type == "urn:github:avatar")?.Value;
            }
        }
    }
}
