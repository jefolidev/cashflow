using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegisterExpense request)
    {
        try
        {
            var sut = new RegisterExpenseUseCase();

            var response = sut.Execute(request);

            return Created(string.Empty, response);
        }
        catch (ArgumentException ex)
        {
            var error = new ResponseError
            {
                ErrorMessage = ex.Message,
            };

            return BadRequest(error);
        }
        catch
        {
            var error = new ResponseError
            {
                ErrorMessage = "Unkwown Error.",
            };

            return StatusCode(StatusCodes.Status500InternalServerError, error);
        }
    }

}
