using IlustraApp.Core.Bussiness.BDimension.Request;
using IlustraApp.Core.Bussiness.BDimension.Response;
using IlustraApp.Core.Bussiness.BDimension.Validate;
using IlustraApp.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace IlustrApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DimensionController : BaseController
    {
        private readonly IDimensionRepository DimensionRepository;
        private readonly IBaseRepository BaseRepository;
        public DimensionController(IDimensionRepository dimensionRepository, IBaseRepository baseRepository)
        {
            DimensionRepository = dimensionRepository;
            BaseRepository = baseRepository;
        }

        [HttpGet]
        [Route("dimensions")]
        public async Task<IActionResult> GetDimensions()
        {
            var dimensions = await DimensionRepository.GetAllDimension();
            return Ok(new DimensionsResponse(dimensions));
        }

        [HttpGet]
        [Route("dimension/{idDimension}")]
        public async Task<IActionResult> GetDimensionById(int idDimension)
        {
            var dimension = await DimensionRepository.GetDimensionById(idDimension);
            return Ok(new DimensionResponse(dimension));
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateDimension([FromBody] CreateDimensionRequest request)
        {
            var validate = new CreateDimensionValidate(request);
            var result = validate.ExecuteValidations();

            if (result.Code != Result.OK) return ResultResponse(result);

            await DimensionRepository.CreateDimension(validate.newDimension);
            await BaseRepository.SaveChangesAsync();
            return ResultResponse(result);
        }

        [HttpPut]
        [Route("update/{idDimension}")]
        public async Task<IActionResult> UpdateDimension(int idDimension, [FromBody] UpdateDimensionRequest request)
        {
            var dimension = await DimensionRepository.GetDimensionById(idDimension);

            var validate = new UpdateDimensionValidate(dimension, request);
            var result = validate.ExecuteValidations();

            if (result.Code != Result.OK) return ResultResponse(result);
            await BaseRepository.SaveChangesAsync();
            return ResultResponse(result);
        }

        [HttpPut]
        [Route("togleAvailable/{idDimension}")]
        public async Task<IActionResult> ToogleAvailable(int idDimension)
        {
            var dimension = await DimensionRepository.GetDimensionById(idDimension);
            if (dimension == null) return ResultResponse(new Result { Code = Result.NOT_FOUND, Type = "dimension_not_found", Message = "Dimension not found" });

            dimension.IsAvailable = !dimension.IsAvailable;
            await BaseRepository.SaveChangesAsync();
            return ResultResponse(new Result());
        }

        [HttpDelete]
        [Route("{idDimension}")]
        public async Task<IActionResult> DeleteDimension(int idDimension)
        {
            var dimension = await DimensionRepository.GetDimensionById(idDimension);
            if (dimension == null) return ResultResponse(new Result { Code = Result.NOT_FOUND, Type = "dimension_not_found", Message = "Dimension not found" });

            dimension.Deleted = true;
            await BaseRepository.SaveChangesAsync();
            return ResultResponse(new Result());
        }
    }
}
