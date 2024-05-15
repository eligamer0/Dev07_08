using Microsoft.Extensions.DependencyInjection;
using Okane.Application;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Update;

namespace Okane.Tests
{
    public abstract class AbstractHandlerTests
    {
        private readonly ServiceProvider _provider;

        protected AbstractHandlerTests()
        {
            var services = new ServiceCollection();
        
            services.AddOkane();

            _provider = services.BuildServiceProvider();
        }

        protected IEnumerable<SuccessResponse> RetrieveExpenses() => 
            Resolve<Application.Expenses.Retrieve.Handler>().Handle();

        protected IExpenseResponse CreateExpense(Application.Expenses.Create.Request request) =>
            Resolve<Application.Expenses.Create.Handler>().Handle(request);

        protected IExpenseResponse GetExpenseById(int id) => 
            Resolve<Application.Expenses.ById.Handler>().Handle(id);

        private T Resolve<T>() where T : notnull =>
            _provider.GetRequiredService<T>();

        protected IExpenseResponse UpdateExpense(Request request)
        {
            throw new NotImplementedException();
        }
    }
}