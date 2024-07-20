using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreApp.Data;
using BookStoreApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using BookStoreApp.API.Data;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BooksController(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReadonlyDTO>>> GetBooks()
        {
            var books = await _context.Books.Include(q =>  q.Author).ProjectTo<BookReadonlyDTO>(_mapper.ConfigurationProvider).ToListAsync();
            // var booDTOs = _mapper.Map<IEnumerable<BookReadonlyDTO>>(books);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailsDTO>> GetBook(int id)
        {
            var book = await _context.Books.Include(q => q.Author).ProjectTo<BookDetailsDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(r => r.Id == id);

            if (book == null) {
                return NotFound();
            }

            return book;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookUpdateDTO bookDTO)
        {
            if (id != bookDTO.Id) {
                return BadRequest();
            }

            var book = await _context.Books.FindAsync(id);

            if (book == null) {
                return NotFound();
            }

            _mapper.Map(bookDTO, book);
            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await BookExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<BookDetailsDTO>> PostBook(BookCreateDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);

            if ((await _context.Authors.AnyAsync(e => e.Id == bookDTO.AuthorId)) == false) {
                return ValidationProblem("Author ID is invalid");
            }

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null) {
                return NotFound();
            }

             _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> BookExists(int id)
    {
        return await _context.Books.AnyAsync(e => e.Id == id);
    }
    }
}