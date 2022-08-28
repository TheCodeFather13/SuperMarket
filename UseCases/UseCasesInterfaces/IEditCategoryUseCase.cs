using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.UseCasesInterfaces
{
    public interface IEditCategoryUseCase
    {
        void Execute(Category category);     
    }
}
