using BitPay.Application.Memeber.Commands.RegisterMember;
using BitPay.Application.Memeber.Queries.GetMemberMerchant;
using BitPay.Application.Sms.Commands.Inquire;
using BitPay.Application.Sms.Commands.VerifyCode;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitPay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ISender _sender;

        public MemberController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("RegisterMemeber")]
        public async Task<IActionResult> RegisterMemeber(RegisterMemberCommand command)
        {
            var result = await _sender.Send(command);

            if (!result.IsSuccess)
            {
                Response.StatusCode = int.Parse(result.ResponseCode);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("Inquire")]
        public async Task<IActionResult> Inquire(InquireMemeberCommand command)
        {
            var result = await _sender.Send(command);

            if (!result.IsSuccess)
            {
                Response.StatusCode = int.Parse(result.ResponseCode);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("VerifyCode")]
        public async Task<IActionResult> VerifyCode(VerifyCodeCommand command)
        {
            var result = await _sender.Send(command);

            if (!result.IsSuccess)
            {
                Response.StatusCode = int.Parse(result.ResponseCode);
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("GetMemeberMerchant")]
        public async Task<IActionResult> GetMemeberMerchant(GetMemberMerchantQuery query)
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
