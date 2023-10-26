﻿using BoletoService.Domain.Entities;
using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Domain.Interfaces.Services;

namespace BoletoService.Domain.Services
{
    public class BancoService : BaseService<Banco>, IBancoService
    {
        public BancoService(IBancoRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {

        }
    }
}
