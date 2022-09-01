using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.ProductsUseCasesInterfaces
{
    public interface IDeleteProductUseCase
    {
       void Delete(int productId);
    }
}
