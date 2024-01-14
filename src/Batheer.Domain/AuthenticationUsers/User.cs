using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AuthenticationUsers
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string FullName { get; set; }
        public string Mobile { get; set; }
        //public string PhotoUrl { get; set; }

        public virtual UploadedFile Photo { get; set; }
        public int PhotoId { get; set; }

        public UserRoles UserRole { get; set; }

        public bool IsActive { get; set; }
        public DateTime? LastLoginAtUtc { get; set; }

        public enum UserRoles
        {
            AdminRole = 1,
            CouncilRole = 2,
            Researcher = 3
        }
    }
}
