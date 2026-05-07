using Microsoft.AspNetCore.Mvc;
using echo_mate_backend.Services;
using echo_mate_backend.Models.Requests;
using echo_mate_backend.Models.Responses;

namespace echo_mate_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranslationController : ControllerBase
    {
        private readonly TranslationService _translationService;

        public TranslationController(TranslationService translationService)
        {
            _translationService = translationService;
        }

        [HttpPost("text-to-pics")]
        public async Task<ActionResult<TextToPicsResponse>> TextToPics([FromBody] TextToPicsRequest request)
        {
            var result = await _translationService.TranslateTextAsync(request.InputText);

            if (result == null)
                return StatusCode(500);

            return Ok(result);
        }

        [HttpPost("pics-to-text")]
        public async Task<ActionResult<PicsToTextResponse>> PicsToText([FromBody] PicsToTextRequest request)
        {
            var result = await _translationService.TranslatePicsAsync(request.Keywords);

            if (result == null)
                return StatusCode(500);

            return Ok(result);
        }

        [HttpGet("pics-catalog")]
        public async Task<ActionResult<PicsCatalog>> GetPicsCatalog()
        {
            var result = await _translationService.GetPicsCatalogAsync();

            if (result == null)
                return StatusCode(500);

            return Ok(result);
        }

    }
}
