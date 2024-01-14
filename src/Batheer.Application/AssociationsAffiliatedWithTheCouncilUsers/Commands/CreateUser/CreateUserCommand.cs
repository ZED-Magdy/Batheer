using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.AssociationsAffiliatedWithTheCouncilUsers.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public int AssociationAffiliatedId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public Batheer.Application.Common.Models.UploadedFile PhotoFile { get; set; }

    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IDateTime _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public CreateUserCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<CreateUserCommand> logger, IDateTime dateTime, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _dateTime = dateTime;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            using var transaction = _context.BeginTransaction();

            try
            {
                var councilUser = new AssociationsAffiliatedWithTheCouncilUser()
                {
                    AssociationsAffiliatedWithTheCouncilId = request.AssociationAffiliatedId,
                    FullName = request.FullName,
                    Mobile = request.Mobile,
                    PhotoUrl = "",
                    UserName = request.UserName
                };

                var user = new Domain.AuthenticationUsers.User()
                {
                    FullName = request.FullName,
                    Mobile = request.Mobile,
                    Password = request.Password,
                    UserName = request.UserName,
                    UserRole = Domain.AuthenticationUsers.User.UserRoles.CouncilRole,
                    Photo = new UploadedFile()
                    {

                        Content = request.PhotoFile.Content,
                        FileName = request.PhotoFile.FileName,
                        ContentType = request.PhotoFile.ContentType,
                    },
                    IsActive = true,
                };

                _context.AssociationsAffiliatedWithTheCouncilUsers.Add(councilUser);
                _context.Users.Add(user);

                await _context.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                return councilUser.Id;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }

            return int.MinValue;

        }


        private int ParseInt(string value, int defaultIntValue = 0)
        {

            if (value is null)
                return defaultIntValue;

            int parsedInt;
            if (int.TryParse(value, out parsedInt))
            {
                return parsedInt;
            }

            return defaultIntValue;
        }

    }

}
