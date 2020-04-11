using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.API.Entities;
using Library.Helper;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api/authors")]
    public class AuthorController : Controller
    {
        public AuthorController(IRepsitoryWrapper repsitoryWrapper,IMapper mapper)
        {
            RepsitoryWrapper = repsitoryWrapper;
            Mapper = mapper;
        }

        public IMapper Mapper { get; }
        public IRepsitoryWrapper RepsitoryWrapper { get; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthorsAsync([FromQuery] AuthorresourceParameters parameters)
        {
            //var authors = (await RepsitoryWrapper.Author.GetAllAsync()).OrderBy(author => author.Name).Skip(parameters.PageSize*(parameters.PageNumber-1)
            //   ).Take(parameters.PageSize);
            //var authorDtoList = Mapper.Map<IEnumerable<AuthorDto>>(authors);
            //return authorDtoList.ToList();
            var pageList = await RepsitoryWrapper.Author.GetAllAsync(parameters);
            var paginationMetadata = new
            {
                totalCount = pageList.TotalCount,
                pageSize = pageList.PageSize,
                currentPage = pageList.CurrentPage,
                totalPage = pageList.TotalPage,
                previousePageLink = pageList.HasPrevious ? Url.Link(nameof(GetAuthors), new
                {
                    pageNumber = pageList.CurrentPage - 1,
                    pageSize = pageList.PageSize
                }) : null,
                nextPageLink = pageList.HasNext ? Url.Link(nameof(GetAuthors), new
                {
                    pageNumber = pageList.CurrentPage + 1,
                    pageSize = pageList.PageSize
                }) : null
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));
            var authorDtoList = Mapper.Map<IEnumerable<AuthorDto>>(pageList);
            return authorDtoList.ToList();
                
        }

        [HttpGet("{authorId}")]
        public ActionResult<AuthorDto> GetAuthors(Guid authorId)
        {
            var author = AuthorRepository.GetAuthor(authorId);
            if (author==null)
            {
                return NotFound();
            }
            else
            {
                return author;
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreataAuthorAsync(AuthorForCreationDto authorForCreationDto)
        {
            var author = Mapper.Map<Author>(authorForCreationDto);

            RepsitoryWrapper.Author.Create(author);
            var result = await RepsitoryWrapper.Author.SaveAsync();

            if (!result)
            {
                throw new Exception("创建资源失败");

            }

            var authorCreated = Mapper.Map<AuthorDto>(author);

            return CreatedAtRoute(nameof(GetAuthorsAsync), new { author = authorCreated.Id }, authorCreated);
        }
    }
}
