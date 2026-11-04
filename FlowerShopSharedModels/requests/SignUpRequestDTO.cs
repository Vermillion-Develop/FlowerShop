using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShopSharedModels.requests
{
    public class SignUpRequestDTO
    {
        public string? Family { get; set; }
        public string? Name { get; set; }
        public string? Father { get; set; }
        public string? Phone { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
