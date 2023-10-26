﻿using BoletoService.Application.Dtos.Request;
using BoletoService.Application.Dtos.Response;
using BoletoService.Domain.Entities;

namespace BoletoService.Application.Interfaces
{
    public interface IBoletoServiceApp : IBaseServiceApp<Boleto, BoletoRequest, BoletoResponse>
    {
    }
}