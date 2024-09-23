using BitPay.Application.Memeber.Commands.RegisterMember;
using BitPay.Application.Payment.Commands.Pay;
using BitPay.Application.Payment.Commands.VerifyPayment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitPay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ISender _sender;

        public PaymentController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("Pay")]
        public async Task<IActionResult> Pay(PayCommand command)
        {
            var result = await _sender.Send(command);

            if (!result.IsSuccess)
            {
                Response.StatusCode = int.Parse(result.ResponseCode);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("VerifyPayment")]
        public async Task<IActionResult> VerifyPayment(VerifyPaymentCommand command)
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
