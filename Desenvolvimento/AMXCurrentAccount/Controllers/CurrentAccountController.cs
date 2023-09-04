using Microsoft.AspNetCore.Mvc;

namespace AMXCurrentAccount.Controllers
{
    using AMXCurrentAccount.Core.Domain.CurrentAccount.Exceptions;
    using AMXCurrentAccount.Presenters.Interfaces;
    using AMXCurrentAccount.Views.PostCustomerCurrentAccount.Request;

    [Route("v1/currentAccount")]
    [ApiController]
    public class CurrentAccountController : ControllerBase
    {
        private readonly ICurrentAccountPresenter _currentAccountPresenter;


        public CurrentAccountController(ICurrentAccountPresenter currentAccountPresenter)
        {
            _currentAccountPresenter = currentAccountPresenter;
        }


        [HttpPost()]
        public async Task<IActionResult> PostCustomer([FromBody]CustomerCurrentAccountRequestDTO customerCurrentAccountRequest)
        {
            try
            {
                await _currentAccountPresenter.PostCustomerCurrentAccount(customerCurrentAccountRequest);
                return Ok();
            }
            catch (CurrentAccountException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet()]
        public async Task<IActionResult> GetCurrentAccount([FromQuery] int customerId)
        {
            try
            {
                var result = await _currentAccountPresenter.GetCustomerCurrentAccount(customerId);
                return Ok(result);
            }
            catch (CurrentAccountException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
