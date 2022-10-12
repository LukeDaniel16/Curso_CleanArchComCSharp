using System;

namespace CleanArchMvc.API.Models
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
