using AutoMapper;
using Batheer.Application.Common.Interfaces;
using Batheer.Domain;
using Batheer.Domain.AuthenticationUsers;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using static Batheer.Domain.AuthenticationUsers.User;

namespace Batheer.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public Common.Models.UploadedFile? PhotoFile { get; set; }
        public bool IsActive { get; set; }

        public UserRoles UserRole { get; set; }
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

            var user = new Domain.AuthenticationUsers.User()
            {
                FullName = request.FullName,
                Mobile = request.Mobile,
                Password = request.Password,
                UserName = request.UserName,
                UserRole = request.UserRole,
                //IsActive = request.IsActive,
                IsActive = true,
            };

            if (request.PhotoFile is not null)
            {
                user.Photo = new UploadedFile()
                {
                    Content = request.PhotoFile.Content,
                    FileName = request.PhotoFile.FileName,
                    ContentType = request.PhotoFile.ContentType,
                };
            }
            else
            {
                SetDefaultPhoto(user);
            }

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            return int.MinValue;



        }


        private void SetDefaultPhoto(User user)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            var file = File.OpenRead(@$"{currentDirectory}\wwwroot\ngos_logo.png");
            byte[] bytes = null;


            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                bytes = ms.ToArray();
            }

            string contentType = "image/png";

            //new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider()
            //   .TryGetContentType(file.Name, out contentType);


            user.Photo = new UploadedFile()
            {
                ContentType = contentType,
                FileName = file.Name,
                Content = bytes,
                ObjectKey = Guid.NewGuid(),
            };

        }
    }

}
