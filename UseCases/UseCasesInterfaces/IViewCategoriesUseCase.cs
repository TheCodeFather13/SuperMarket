using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.UseCasesInterfaces
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
    }
}