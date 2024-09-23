using BitPay.Application.Memeber.Commands.RegisterMember;
using BitPay.Application.Merchants.Commands.RegisterMerchant;
using BitPay.Application.Merchants.Queries.GetMerchantTransfers;
using BitPay.Application.Merchants.Queries.GetRemainingCoins;
using BitPay.Application.Merchants.Queries.GetTodayCoins;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitPay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly ISender _sender;

        public MerchantController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("RegisterMerchant")]
        public async Task<IActionResult> RegisterMerchant(RegisterMerchantCommand command)
        {
            var result = await _sender.Send(command);

            if (!result.IsSuccess)
            {
                Response.StatusCode = int.Parse(result.ResponseCode);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("GetMerchantTransfers")]
        public async Task<IActionResult> GetMerchantTransfers(GetMerchantTransfersQuery query)
        {
            var result = await _sender.Send(query);

            if (!result.IsSuccess)
            {
                Response.StatusCode = int.Parse(result.ResponseCode);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("GetRemainingCoins")]
        public async Task<IActionResult> GetRemainingCoins(GetRemainingCoinsQuery query)
        {
            var result = await _sender.Send(query);

            if (!result.IsSuccess)
            {
                Response.StatusCode = int.Parse(result.ResponseCode);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("GetTodayCoins")]
        public async Task<IActionResult> GetTodayCoins(GetTodayCoinsQuery query)
        {
            var result = await _sender.Send(query);

            if (!result.IsSuccess)
            {
                Response.StatusCode = int.Parse(result.ResponseCode);
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
