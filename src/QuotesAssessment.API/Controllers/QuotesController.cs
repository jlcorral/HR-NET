using Microsoft.AspNetCore.Mvc;
using QuotesAssessment.Core.DTOs.Quotes.Requests;
using QuotesAssessment.Core.DTOs.Quotes.Responses;
using QuotesAssessment.Core.Services.Quotes;

namespace QuotesAssessment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuotesController : ControllerBase
{
    private readonly IQuoteService _quoteService;
    public QuotesController(IQuoteService quoteService)
    {
        _quoteService = quoteService;
    }




    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateQuoteRequestDto request)
    {

        try
        {
            CreateQuoteResponseDto response = await _quoteService.Create(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            // TODO Log Exception
            string[] response = [ex.Message];
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }


    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateQuoteRequestDto request)
    {
        try
        {
            await _quoteService.Update(request);
            return Ok();
        }
        catch (Exception ex)
        {
            // TODO Log Exception
            // TODO map propper status code
            string[] response = [ex.Message];
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }

    [HttpDelete("quote/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            await _quoteService.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            // TODO Log Exception
            // TODO map propper status code
            string[] response = [ex.Message];
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }

    [HttpGet("quote/{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        try
        {
            QuoteResponseDto response = await _quoteService.Get(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            // TODO Log Exception
            // TODO map propper status code
            string[] response = [ex.Message];
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            IEnumerable<QuoteResponseDto> response = await _quoteService.Get();
            return Ok(response);
        }
        catch (Exception ex)
        {
            // TODO Log Exception
            // TODO map propper status code
            string[] response = [ex.Message];
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }
}
