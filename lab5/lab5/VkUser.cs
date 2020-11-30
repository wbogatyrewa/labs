using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class VkUser
    {
        public string AccessToken { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo { get; set; }

        public VkUser()
        {

        }

        public VkUser(string accessToken, string userId)
        {
            AccessToken = accessToken;
            UserId = userId;
        }
    }

}
