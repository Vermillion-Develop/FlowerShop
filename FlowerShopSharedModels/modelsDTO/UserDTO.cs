using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopSharedModels.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Family { get; set; }
        public string? Name { get; set; }
        public string? Father { get; set; }
        public string? Phone { get; set; }
        public int? RoleId { get; set; }
        public int? DatalogsId { get; set; }
        public int? StreetId { get; set; }
        public string? Home { get; set; }
        public string? Apartment { get; set; }

        public string? RoleName { get; set; }
        public string? StreetName { get; set; }
        public string? LoginName { get; set; }
    }
}
