using System;

namespace Tectex.Models {
    public class UserModel {
        [Key]
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
