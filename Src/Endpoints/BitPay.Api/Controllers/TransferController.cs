using BitPay.Application.Memeber.Commands.RegisterMember;
using BitPay.Application.Transfer.Commands.SettlementMerchant;
using BitPay.Application.Transfer.Commands.Transfer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitPay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ISender _sender;

        public TransferController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("Transfer")]
        public async Task<IActionResult> Transfer(TransferCommand command)
        {
            var result = await _sender.Send(command);

            if (!result.IsSuccess)
            {
                Response.StatusCode = int.Parse(result.ResponseCode);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("SettlementMerchant")]
        public async Task<IActionResult> SettlementMerchant(SettlementMerchantCommand command)
        {
            var result = await _sender.Send(command);

            if (!result.IsSuccess)
            {
                Response.StatusCode = int.Parse(result.ResponseCode);
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
