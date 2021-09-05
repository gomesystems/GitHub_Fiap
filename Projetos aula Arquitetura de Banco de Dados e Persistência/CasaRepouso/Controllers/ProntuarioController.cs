using AutoMapper;
using AutoMapper.Configuration;
using CasaRepouso.Models;
using CasaRepouso.Repository.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CasaRepouso.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ProntuarioController : Controller
    {
        private readonly ILogger<ProntuarioController> _logger;
        private readonly IMapper _mapper;
        private readonly IProntuarioRepository _prontuario;

        public ProntuarioController(ILogger<ProntuarioController> logger,
                                  IProntuarioRepository prontuario,
                                  IConfiguration configuration,
                                  IMapper mapper)
        {
            _mapper = mapper;
            _prontuario = prontuario;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var result = _prontuario.Get();
            return Json(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            _logger.LogTrace($"Controller: ProntuarioController - Action: GetById - Passo: Inicio - Data: data={id}.");
            _logger.LogInformation(id.ToString());

            var result = _prontuario.GetProntuarioById(id);

            _logger.LogTrace($"Controller: ProntuarioController - GetById: Info={result}.");

            return Json(result);
        }


        [HttpPost("salvarprontuario")]
        public async Task<IActionResult> SaveSingleAsyncProntuario([FromBody] ProntuarioModel ProntuarioModel)
        {
            try
            {
                _logger.LogTrace($"Controller: ProntuarioController - Action: SaveSingleAsyncProntuario - Passo: Inicio - Data: data={ProntuarioModel.DataCriacao} - User: {ProntuarioModel.Usuario}");
                _logger.LogInformation(ProntuarioModel.ToString());

                await _prontuario.SaveProntuarioSingleAsync(ProntuarioModel);

                _logger.LogTrace($"Controller: ProntuarioController - Action: SaveSingleAsyncProntuario - Passo: Salvando Prontuario - DataAlteração: data={ProntuarioModel.DataAlteracao} - UserAlteração: {ProntuarioModel.Usuario}");

                return Json(Get());

            }

            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao salvar Prontuario");
                throw;
            }
        }


        [HttpDelete("remove")]
        public IActionResult Remove([FromQuery] Guid id)
        {
            _logger.LogTrace($"Controller: ProntuarioController - Action: Remove - Passo: Inicio : data={id} .");
            _logger.LogInformation(id.ToString());

            try
            {
                _prontuario.DeleteProntuarioAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] Guid id, ProntuarioModel ProntuarioModel)
        {
            _logger.LogTrace($"Controller: ProntuarioController - Action: Update - Passo: Inicio : data={ProntuarioModel} .");
            _logger.LogInformation(ProntuarioModel.ToString());
            try
            {
                var user = _prontuario.UpdateProntuarioAsync(id, ProntuarioModel);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
