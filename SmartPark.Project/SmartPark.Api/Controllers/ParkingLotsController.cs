using Microsoft.AspNetCore.Mvc;
using SmartPark.Api.Extensions;
using SmartPark.Borders.Dtos.ParkingLot.Request;
using SmartPark.Borders.Dtos.ParkingLot.Response;
using SmartPark.Borders.Interfaces.UseCases.ParkingLot;
using SmartPark.Borders.Shared;
using SmartPark.Borders.Shared.Response;

namespace SmartPark.Api.Controllers
{
    [ApiController]
    [Route("api/parking-lots")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly ActionResultConverter _converter;

        private readonly IGetParkingLotsUseCase _getParkingLotsUseCase;
        private readonly IGetParkingLotByIdUseCase _getParkingLotByIdUseCase;
        private readonly IPostParkingLotUseCase _postParkingLotUseCase;
        private readonly IPatchParkingLotUseCase _patchParkingLotUseCase;
        private readonly IDeleteParkingLotUseCase _deleteParkingLotUseCase;

        public ParkingLotsController(
            ActionResultConverter converter,
            IGetParkingLotsUseCase getParkingLotsUseCase,
            IGetParkingLotByIdUseCase getParkingLotByIdUseCase,
            IPostParkingLotUseCase postParkingLotUseCase,
            IPatchParkingLotUseCase patchParkingLotUseCase,
            IDeleteParkingLotUseCase deleteParkingLotUseCase
            )
        {
            _converter = converter;
            _getParkingLotsUseCase = getParkingLotsUseCase;
            _getParkingLotByIdUseCase = getParkingLotByIdUseCase;
            _postParkingLotUseCase = postParkingLotUseCase;
            _patchParkingLotUseCase = patchParkingLotUseCase;
            _deleteParkingLotUseCase = deleteParkingLotUseCase;
        }

        [HttpGet("get-list")]
        [ProducesResponseType(typeof(PagedResult<ParkingLotDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListAsync([FromQuery] GetParkingLotsRequest request)
        {
            return await _converter.ExecuteActionAsync(_getParkingLotsUseCase.Execute(request), typeof(ParkingLotsController));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseResponse<ParkingLotDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            return await _converter.ExecuteActionAsync(_getParkingLotByIdUseCase.Execute(id), typeof(ParkingLotsController));
        }

        [HttpPost()]
        [ProducesResponseType(typeof(BasePostResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] PostParkingLotRequest request)
        {
            return await _converter.ExecuteActionAsync(_postParkingLotUseCase.Execute(request), typeof(ParkingLotsController));
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(BasePatchResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] PatchParkingLotRequest request)
        {
            return await _converter.ExecuteActionAsync(_patchParkingLotUseCase.Execute((id, request)), typeof(ParkingLotsController));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BaseDeleteResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            return await _converter.ExecuteActionAsync(_deleteParkingLotUseCase.Execute(id), typeof(ParkingLotsController));
        }

    }
}
