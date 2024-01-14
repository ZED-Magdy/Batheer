using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AuthenticationUsers;
using System;
using static Batheer.Domain.AuthenticationUsers.User;

namespace Batheer.Application.Users.Queries.GetUsersByRole
{
    public class UserDto : IMapFrom<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string FullName { get; set; }
        public string Mobile { get; set; }
        public int PhotoId { get; set; }
        public Guid PhotoObjectkey { get; set; }
        public bool IsActive { get; set; }

        public UserRoles UserRole { get; set; }
        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<User, UserDto>();
        //}
    }
}
