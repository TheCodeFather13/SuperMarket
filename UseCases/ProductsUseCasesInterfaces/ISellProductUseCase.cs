using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.ProductsUseCasesInterfaces
{
    public interface ISellProductUseCase
    {
        void Execute(string cashierName, int productId, int quatityToSell);
    }
}
