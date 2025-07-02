using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

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
        var isTitleEmpty = string.IsNullOrWhiteSpace(request.Title);

        if (isTitleEmpty)
        {
            throw new ArgumentException("Title is required.");
        }

        if(request.Amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        var isExpenseFromToday = DateTime.Compare(request.Date, DateTime.UtcNow);

        if(isExpenseFromToday > 0)
        {
            throw new ArgumentException("Expenses cannot be for the future");
        }

        var isValidPaymentType = Enum.IsDefined(typeof(PaymentType), request.PaymentType);

        if (!isValidPaymentType)
        {
            throw new ArgumentException("Incorrect Payment Type.");
        }
    }
}
