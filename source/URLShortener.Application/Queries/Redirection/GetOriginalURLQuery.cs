using URLShortener.Application.Interfaces;
using URLShortener.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using URLShortener.WebApi.Models;
using URLShortener.Application.Models;

namespace URLShortener.Application.Queries
{
    public class GetOriginalURLQuery :  IRequest<string>
    {
        public GetOriginalURLQuery(GetRedirectionBySlugModel getRedirectionBySlugModel)
        {
            GetRedirectionBySlugModel = getRedirectionBySlugModel;
        }

        public GetRedirectionBySlugModel GetRedirectionBySlugModel { get; set; }
        public class GetOriginalURLQueryHandler : IRequestHandler<GetOriginalURLQuery, string>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetOriginalURLQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<string> Handle(GetOriginalURLQuery request, CancellationToken cancellationToken)
            {
                return await _applicationDbContext.Redirections.Where(q=> q.Slug == request.GetRedirectionBySlugModel.Slug).Select(q=> q.OriginalURL).SingleOrDefaultAsync(cancellationToken);
            }
        }
    }
}
