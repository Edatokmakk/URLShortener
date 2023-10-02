using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.Core.Entities;
using System.Threading;
using URLShortener.Application.Interfaces;
using URLShortener.WebApi.Models;
using URLShortener.Core.Exceptions;

namespace URLShortener.Application.Commands
{
    public class CreateRedirectionCommand : IRequest<Redirection>
    {
        public CreateRedirectionModel CreateRedirectionModel { get; set; }
        public CreateRedirectionCommand(CreateRedirectionModel createRedirectionModel)
        {

            CreateRedirectionModel = createRedirectionModel;
        }
        public class CreateRedirectionCommandHandler : IRequestHandler<CreateRedirectionCommand, Redirection>
        {
            private readonly IApplicationDbContext _applicationDbContext;       
            public CreateRedirectionCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;                
            }
            public async Task<Redirection> Handle(CreateRedirectionCommand request, CancellationToken cancellationToken)
            {
                await using var transaction = await _applicationDbContext.Database.BeginTransactionAsync();
                if (string.IsNullOrEmpty(request.CreateRedirectionModel.Slug) == true)
                {
                    while (true)
                    {
                        var randomSlug = Guid.NewGuid().ToString("n").Substring(0, 8);
                        if (_applicationDbContext.Redirections.Any(q => q.Slug == randomSlug) == false)
                        {
                            request.CreateRedirectionModel.Slug = randomSlug;
                            break;
                        }
                    }
                }
                else
                {
                    if (_applicationDbContext.Redirections.Any(q => q.Slug == request.CreateRedirectionModel.Slug) == true)
                    {
                        new SlugAlreadyExistException(request.CreateRedirectionModel.Slug);
                    }
                }
                var redirection = new Redirection() { OriginalURL = request.CreateRedirectionModel.OriginalURL, Slug = request.CreateRedirectionModel.Slug };
                _applicationDbContext.Redirections.Add(redirection);                    
                var affected = await _applicationDbContext.SaveChangesAsync(cancellationToken);
                if (affected != 0)
                {                 
                    await transaction.CommitAsync();
                    return redirection;
                }               
                return null;
            }
        }
    }
}
