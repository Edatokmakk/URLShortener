using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using URLShortener.Application.Commands;
using URLShortener.Application.Models;
using URLShortener.Application.Queries;
using URLShortener.WebApi.Models;

namespace URLShortener.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedirectionController : ControllerBase
    {
        private readonly IMediator _mediator;     

        public RedirectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/{Slug}")]
        public async Task<ActionResult> GetRedirection([FromRoute]GetRedirectionBySlugModel model)
        {
           var originalURL = await _mediator.Send(new GetOriginalURLQuery(model));
            if(originalURL!=null)
            {
                return Redirect(originalURL);
            }
            else
            {
                return NotFound();
            }
         
        }
        [HttpPost]
        public async Task<ActionResult<string>> PostRedirection(CreateRedirectionModel model)
        {
            var redirection = await _mediator.Send(new CreateRedirectionCommand(model));
            if (redirection != null)
            {
                var shortenedURL = $"{Request.Scheme}://{Request.Host}/{redirection.Slug}";
                return shortenedURL;
            }
            else
            {
                return NotFound();
            }
        }
    }
}
