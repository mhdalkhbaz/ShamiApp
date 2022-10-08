using Application.Features.MaterialFeatures.Dtos;
using Application.Features.MaterialFeatures.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.MaterialFeatures.Queries;
using Application.Common.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : BaseApiController
    {
        /// <summary>
        /// </summary>
        /// <param name="CreateMaterialDto"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public async Task<ActionResult<MaterialDto>> CreateAsync(CreateMaterialDto dto)
        {
            return Ok(await Mediator.Send(new CreateMaterialCommand(dto)));
        }
        /// <summary>
        /// </summary>
        /// <param name="CreateMaterialDto"></param>
        /// <returns></returns>
        /// 
        [HttpPut]
        public async Task<ActionResult<MaterialDto>> UpdateAsync(UpdateMaterialDto dto)
        {
            return Ok(await Mediator.Send(new UpdateMaterialCommand(dto)));
        }

        /// <summary>
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<PagingResultDto<MaterialDto>>> GatAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllMaterialQuery()));
        }

        /// <summary>
        /// </summary>
        /// <param name="PagingDto"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("get-all-paging")]
        public async Task<ActionResult<PagingResultDto<MaterialDto>>> GetPagingAsync([FromQuery] PagingDto pagingDto)
        {
            return Ok(await Mediator.Send(new GetPagingMaterialAsyncQuery(pagingDto)));
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("get-By-Id")]
        public async Task<ActionResult<PagingResultDto<MaterialDto>>> GetByIdAsync([FromQuery] int id)
        {
            return Ok(await Mediator.Send(new GetMaterialByIdQuery(id)));
        }
    }
}
