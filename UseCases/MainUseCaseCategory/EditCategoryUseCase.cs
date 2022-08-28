﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCasesInterfaces;

namespace UseCases.MainUseCaseCategory
{
    public class EditCategoryUseCase : IEditCategoryUseCase
    {
        private ICategoryRepository _categoryRepository;
        public EditCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Execute(Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }
    }
}