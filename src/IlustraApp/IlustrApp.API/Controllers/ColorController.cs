using IlustraApp.Core.Bussiness.BColor.Request;
using IlustraApp.Core.Bussiness.BColor.Validate;
using IlustraApp.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace IlustrApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ColorController : BaseController
    {
        private readonly IColorRepository ColorRepository;
        private readonly IBaseRepository BaseRepository;
        public ColorController(IColorRepository colorRepository, IBaseRepository baseRepository)
        {
            ColorRepository = colorRepository;
            BaseRepository = baseRepository;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateColor([FromBody] CreateColorRequest request)
        {
            var validate = new CreateColorValidate(request);
            var result = validate.ExecuteValidations();

            if (result.Code != Result.OK) return ResultResponse(result);

            await ColorRepository.CreateColor(validate.NewColor);
            await BaseRepository.SaveChangesAsync();
            return ResultResponse(result);
        }

        [HttpPut]
        [Route("update/{idColor}")]
        public async Task<IActionResult> UpdateColor(int idColor, [FromBody] UpdateColorRequest request)
        {
            var color = await ColorRepository.GetColorById(idColor);

            var validate = new UpdateColorValidate(request, color);
            var result = validate.ExecuteValidations();

            if (result.Code != Result.OK) return ResultResponse(result);

            await BaseRepository.SaveChangesAsync();
            return ResultResponse(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetColors()
        {
            var colors = await ColorRepository.GetAllColors();
            return Ok(colors);
        }

        [HttpGet]
        [Route("color/{idColor}")]
        public async Task<IActionResult> GetColorById(int idColor)
        {
            var color = await ColorRepository.GetColorById(idColor);
            if (color == null) return ResultResponse(new Result { Code = Result.NOT_FOUND, Type = "color_not_found", Message = "Color not found" });
            return Ok(color);
        }

        [HttpPut]
        [Route("color/{idColor}")]
        public async Task<IActionResult> ToogleAvailableColor(int idColor)
        {
            var color = await ColorRepository.GetColorById(idColor);
            if (color == null) return ResultResponse(new Result { Code = Result.NOT_FOUND, Type = "color_not_found", Message = "Color not found" });

            color.IsAvailable = !color.IsAvailable;
            return Ok(color);
        }

        [HttpDelete]
        [Route("color/{idColor}")]
        public async Task<IActionResult> DeleteColor(int idColor)
        {
            var color = await ColorRepository.GetColorById(idColor);
            if (color == null) return ResultResponse(new Result { Code = Result.NOT_FOUND, Type = "color_not_found", Message = "Color not found" });

            color.Deleted = true;
            return Ok(color);
        }
    }
}
