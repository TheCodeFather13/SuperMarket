﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.ProductsUseCasesInterfaces
{
    public interface IViewProductsByCategoryIdUseCase
    {
        IEnumerable<Product> Execute(int categoryId); 
    }
}
