using Application.Features.UnitMaterialFeatures.Dtos;
using Application.Features.UnitMaterialFeatures.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.UnitMaterialFeatures.Queries;
using Application.Common.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitMaterialController : BaseApiController
    {
        /// <summary>
        /// </summary>
        /// <param name="CreateUnitMaterialDto"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public async Task<ActionResult<UnitMaterialDto>> CreateAsync(CreateUnitMaterialDto dto)
        {
            return Ok(await Mediator.Send(new CreateUnitMaterialCommand(dto)));
        }
        /// <summary>
        /// </summary>
        /// <param name="CreateUnitMaterialDto"></param>
        /// <returns></returns>
        /// 
        [HttpPut]
        public async Task<ActionResult<UnitMaterialDto>> UpdateAsync(UpdateUnitMaterialDto dto)
        {
            return Ok(await Mediator.Send(new UpdateUnitMaterialCommand(dto)));
        }

        /// <summary>
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<PagingResultDto<UnitMaterialDto>>> GatAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllUnitMaterialQuery()));
        }

        /// <summary>
        /// </summary>
        /// <param name="PagingDto"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("get-all-paging")]
        public async Task<ActionResult<PagingResultDto<UnitMaterialDto>>> GetPagingAsync([FromQuery] PagingDto pagingDto)
        {
            return Ok(await Mediator.Send(new GetPagingUnitMaterialAsyncQuery(pagingDto)));
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("get-By-Id")]
        public async Task<ActionResult<PagingResultDto<UnitMaterialDto>>> GetByIdAsync([FromQuery] int id)
        {
            return Ok(await Mediator.Send(new GetUnitMaterialByIdQuery(id)));
        }


    }
}
