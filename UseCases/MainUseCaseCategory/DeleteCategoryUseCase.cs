using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.UseCasesInterfaces;

namespace UseCases.MainUseCaseCategory
{
    public class DeleteCategoryUseCase : IDeleteCategoryUseCase
    {
        private IDeleteCategoryUseCase _deleteCategoryUseCase;

        public DeleteCategoryUseCase(IDeleteCategoryUseCase deleteCategoryUseCase)
        {
            _deleteCategoryUseCase = deleteCategoryUseCase;
        }


        public void Delete(int categoryId)
        {
            _deleteCategoryUseCase.Delete(categoryId);
        }
    }
}
