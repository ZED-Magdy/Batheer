using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AuthenticationUsers;
using System;
using static Batheer.Domain.AuthenticationUsers.User;

namespace Batheer.Application.Users.Queries.GetUsersWithLastLoginAt
{
    public class UsersWithLastLoginAtDto : IMapFrom<User>
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public int PhotoId { get; set; }
        public Guid PhotoObjectkey { get; set; }
        public bool IsActive { get; set; }

        public UserRoles UserRole { get; set; }
        public string UserRoleName { get; set; }
        public DateTime? LastLoginAtUtc { get; set; }
        public string CouncilName { get; set; }

        public DateTime? Families_LastModified { get; set; }
        public DateTime? FamilyMembers_LastModified { get; set; }
        public DateTime? AssociationAffiliatedProjects_LastModified { get; set; }
    }
}
