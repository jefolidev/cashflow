using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpense Execute(RequestRegisterExpense request)
    {
        Validate(request);
        return new ResponseRegisteredExpense();
    }

    public void Validate(RequestRegisterExpense request)
    {
        RegisterExpenseValidator validator = new();

        var result = validator.Validate(request);

        if(!result.IsValid)
        {
            List<string> errorMessages = result
                .Errors
                .Select(error => error.ErrorMessage)
                .ToList();

            throw new ErrorOnValidationException(errorMessages);
        }

    }
}
