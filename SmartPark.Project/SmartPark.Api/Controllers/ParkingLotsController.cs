using Microsoft.AspNetCore.Mvc;
using SmartPark.Api.Extensions;
using SmartPark.Borders.Dtos.ParkingLot.Request;
using SmartPark.Borders.Dtos.ParkingLot.Response;
using SmartPark.Borders.Interfaces.UseCases.ParkingLot;
using SmartPark.Borders.Shared;

namespace SmartPark.Api.Controllers
{
    [ApiController]
    [Route("api/parking-lots")]
    public class ParkingLotsController : ControllerBase
    {
        private readonly IGetParkingLotsUseCase _getParkingLotsUseCase;
        private readonly IGetParkingLotByIdUseCase _getParkingLotByIdUseCase;

        public ParkingLotsController(IGetParkingLotsUseCase getParkingLotsUseCase, IGetParkingLotByIdUseCase getParkingLotByIdUseCase)
        {
            _getParkingLotsUseCase = getParkingLotsUseCase;
            _getParkingLotByIdUseCase = getParkingLotByIdUseCase;
        }

        [HttpGet("get-list")]
        [ProducesResponseType(typeof(PagedResult<ParkingLotDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListAsync([FromQuery] GetParkingLotsRequest request)
        {
            return ActionResultConverter.Convert(await _getParkingLotsUseCase.Execute(request));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PagedResult<ParkingLotDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            return ActionResultConverter.Convert(await _getParkingLotByIdUseCase.Execute(id));
        }
    }
}
