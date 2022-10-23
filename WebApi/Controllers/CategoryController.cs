using Application.Features.CategoryFeatures.Dtos;
using Application.Features.CategoryFeatures.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.CategoryFeatures.Queries;
using Application.Common.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController
    {
        /// <summary>
        /// </summary>
        /// <param name="CreateCategoryDto"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateAsync(CreateCategoryDto dto)
        {
            return Ok(await Mediator.Send(new CreateCategoryCommand(dto)));
        }
        /// <summary>
        /// </summary>
        /// <param name="CreateCategoryDto"></param>
        /// <returns></returns>
        /// 
        [HttpPut]
        public async Task<ActionResult<CategoryDto>> UpdateAsync(UpdateCategoryDto dto)
        {
            return Ok(await Mediator.Send(new UpdateCategoryCommand(dto)));
        }

        /// <summary>
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<PagingResultDto<CategoryDto>>> GatAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllCategoryQuery()));
        }

        /// <summary>
        /// </summary>
        /// <param name="PagingDto"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("get-all-paging")]
        public async Task<ActionResult<PagingResultDto<CategoryDto>>> GetPagingAsync([FromQuery] PagingDto pagingDto)
        {
            return Ok(await Mediator.Send(new GetPagingAsyncQuery(pagingDto)));
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("get-By-Id")]
        public async Task<ActionResult<CategoryDto>> GetByIdAsync(int id)
        {
            return Ok(await Mediator.Send(new GetCategoryByIdQuery(id)));
        }


        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpPut("delete-id")]
        public async Task<ActionResult> DeleteAsync([FromBody] int id)
        {
            return Ok(await Mediator.Send(new DeleteCategoryCommand(id)));
        }

    }
}
