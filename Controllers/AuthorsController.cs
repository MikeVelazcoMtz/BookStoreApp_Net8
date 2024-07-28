using AutoMapper;
using BookStoreApp.Data;
using BookStoreApp.Models;
using BookStoreApp.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AuthorsController : ControllerBase
{
    private readonly BookStoreContext _context;

    private readonly IMapper _mapper;

    private readonly ILogger<AuthorsController> _logger;



    public AuthorsController(BookStoreContext bookStoreContext, IMapper mapper, ILogger<AuthorsController> logger)
    {
        _context = bookStoreContext;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorReadOnlyDTO>>> GetAuthors()
    {
        try
        {
            var authors = _mapper.Map<IEnumerable<AuthorReadOnlyDTO>>(await _context.Authors.ToListAsync());

            return Ok(authors);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Error Performing GET in {nameof(GetAuthors)}");
            return StatusCode(500, Messages.Error500Msg);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorReadOnlyDTO>> GetAuthor(int id)
    {
        try
        {
            Author? author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                _logger.LogWarning($"Record not found: {nameof(GetAuthor)} - ID: {id}");
                return NotFound();
            }

            return Ok(
                _mapper.Map<AuthorReadOnlyDTO>(author)
            );
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Error Performing GET in {nameof(GetAuthors)}");
            return StatusCode(500, Messages.Error500Msg);
        }
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> PutAuthor(int id, AuthorUpdateDTO authorDto)
    {
        if (id != authorDto.Id)
        {
            _logger.LogWarning($"Update ID invalid in {nameof(PutAuthor)} - ID: {id}");
            return BadRequest();
        }

        var author = await _context.Authors.FindAsync(id);

        if (author == null)
        {
            _logger.LogWarning($"{nameof(Author)} record not found in {nameof(PutAuthor)} - ID: {id}");
            return NotFound();
        }

        _mapper.Map(authorDto, author);
        _context.Entry(author).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException exception)
        {
            if (!await AuthorExists(id))
            {
                return NotFound();
            } else {
                _logger.LogError(exception, $"Error Performing PUT in {nameof(PutAuthor)}");
                return StatusCode(500, Messages.Error500Msg);
            }

        }

        return NoContent();
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<AuthorCreateDTO>> PostAuthor(AuthorCreateDTO authorDTO)
    {
        try
        {
            var author = _mapper.Map<Author>(authorDTO);
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new { id = author.Id }, authorDTO);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, $"Error Performing POST in {nameof(PostAuthor)}");
            return StatusCode(500, Messages.Error500Msg);
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        try
        {
            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                _logger.LogWarning($"{nameof(Author)} record not found in {nameof(DeleteAuthor)} - ID: {id}");
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception exception)
        {
             _logger.LogError(exception, $"Error Performing DELETE in {nameof(DeleteAuthor)}");
            return StatusCode(500, Messages.Error500Msg);
        }
    }

    private async Task<bool> AuthorExists(int id)
    {
        return await _context.Authors.AnyAsync(e => e.Id == id);
    }
}