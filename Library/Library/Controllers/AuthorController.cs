using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthorsAsync()
        {
            var authors = (await RepsitoryWrapper.Author.GetAllAsync()).OrderBy(author => author.Name);
            var authorDtoList = Mapper.Map<IEnumerable<AuthorDto>>(authors);
            return authorDtoList.ToList();
                
        }



        public ActionResult<List<AuthorDto>> GetAuthors()
        {
            return AuthorReponsitory.GetAuthors().ToList();
        }

        [HttpGet("{authorId}")]
        public ActionResult<AuthorDto> GetAuthor(Guid authorId)
        {
            var author = AuthorReponsitory.GetAuthor(authorId);
            if (author==null)
            {
                return NotFound();
            }
            else
            {
                return author;
            }
        }

    }
}
