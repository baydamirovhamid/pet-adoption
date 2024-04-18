using Microsoft.AspNetCore.Mvc;
using animal.adoption.api.DTO.HelperModels.Const;
using animal.adoption.api.DTO.HelperModels;
using animal.adoption.api.DTO.ResponseModels.Main;
using System.Diagnostics;
using animal.adoption.api.Services.Interface;
using animal.adoption.api.DTO.ResponseModels.Inner;
using animal.adoption.api.Enums;
using animal.adoption.api.Models;


namespace animal.adoption.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IValidationCommon _validation;
        private readonly ILoggerManager _logger;
        public PetController(
            IPetService petService,
            IValidationCommon validation,
            ILoggerManager logger
            )
        {
            _petService = petService;
            _validation = validation;
            _logger = logger;
        }


        //[HttpGet]
        //[Route("get-by-id")]
        //public async Task<IActionResult> GetById(PetType type)
        //{
        //    ResponseObject<PetVM> response = new ResponseObject<PetVM>();
        //    response.Status = new StatusModel();
        //    response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
        //    try
        //    {
        //        List<PET> pets = await _petService.GetAll();
        //        List<PET> filteredPets = pets.Where(x => x.Type == type).ToList();
        //        response.Response = filteredPets;
        //        if (response.Response == null)
        //        {
        //            response.Status.Message = "Məlumat tapılmadı!";
        //            response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
        //            StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
        //        }
        //        return Ok(response);
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetById)}: " + $"{e}");
        //        response.Status.ErrorCode = ErrorCodes.SYSTEM;
        //        response.Status.Message = "Sistemdə xəta baş verdi.";
        //        return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
        //    }
        //}

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll(int page, int pageSize)
        {
            ResponseListTotal<PetVM> response = new ResponseListTotal<PetVM>();
            response.Response = new ResponseTotal<PetVM>();
            response.Status = new StatusModel();
            response.TraceID = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            try
            {
                response = await _petService.GetAll(response, page, pageSize);
                if (response.Response.Data == null)
                {
                    response.Status.Message = "Məlumat tapılmadı!";
                    response.Status.ErrorCode = ErrorCodes.NOT_FOUND;
                    StatusCode(_validation.CheckErrorCode(response.Status.ErrorCode), response);
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("TraceId: " + response.TraceID + $", {nameof(GetAll)}: " + $"{e}");
                response.Status.ErrorCode = ErrorCodes.SYSTEM;
                response.Status.Message = "Sistemdə xəta baş verdi.";
                return StatusCode(StatusCodeModel.INTERNEL_SERVER, response);
            }
        }
    }
}
