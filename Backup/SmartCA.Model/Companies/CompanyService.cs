﻿using System;
using System.Collections.Generic;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.RepositoryFramework;

namespace SmartCA.Model.Companies
{
    public static class CompanyService
    {
        private static ICompanyRepository repository;
        private static IUnitOfWork unitOfWork;

        static CompanyService()
        {
            CompanyService.unitOfWork = new UnitOfWork();
            CompanyService.repository = RepositoryFactory.GetRepository<ICompanyRepository, Company>(CompanyService.unitOfWork);
        }

        public static IList<Company> GetOwners()
        {
            return CompanyService.repository.FindAll();
        }
    }
}
