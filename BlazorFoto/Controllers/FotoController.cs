using Azure;
using BlazorFoto.Models;
using BlazorFoto.Utility;
using Microsoft.AspNetCore.Mvc;

[Route("api/foto/[action]")]
[ApiController]
public class FotoController : ControllerBase
{
    private readonly IRepositoryFoto _repository;

    public FotoController(IRepositoryFoto repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<FotoResponse>> GetFotos([FromQuery] int page = 1, [FromQuery] string search = "")
    {
        try
        {
            FotoResponse? result = await _repository.GetFotos(page, search);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"Errore: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Foto>> GetFoto(int id)
    {
        try
        {
            Foto? foto = await _repository.GetFoto(id);
            return Ok(foto);

        }
        catch (Exception ex)
        {
            return BadRequest($"Errore: {ex.Message}");

        }
    }

    [HttpPost]
    public async Task<FotoCreateResponse> CreateFoto([FromBody] Foto foto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _repository.CreateFoto(foto);
                FotoCreateResponse response = new FotoCreateResponse()
                {
                    Foto = foto,
                    Message = $"Foto {foto.Name} creata con successo"
                };
                    return response;
            }else
            {
                return new FotoCreateResponse()
                {
                    Message = "Dati non validi"
                };
            }
        }
        catch (Exception ex)
        {
            return new FotoCreateResponse { Message = $"Errore durante la creazione della foto. Dettagli: {ex.Message}" };

        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<FotoCreateResponse>> EditFoto(int id, [FromBody] Foto foto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                bool success = _repository.EditFoto(id, foto);

                if (success)
                {
                    FotoCreateResponse response = new FotoCreateResponse()
                    {
                        Foto = foto,
                        Message = $"Foto {foto.Name} modificata con successo"
                    };
                    return Ok(response);
                }
                else
                {
                    return NotFound($"Foto con ID {id} non trovata");
                }
            }
            else
            {
                return new BadRequestObjectResult(new FotoCreateResponse()
                {
                    Message = "Dati non validi"
                });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}");
        }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteFoto(int id)
    {
        bool success = _repository.DeleteFoto(id);

        if (success) return Ok($"Foto con id {id} cancellata");

        else return NotFound($"Foto con id {id} non trovata");
    }



}
