using CoreBusiness;

namespace UseCases.UseCasesInterfaces
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
    }
}