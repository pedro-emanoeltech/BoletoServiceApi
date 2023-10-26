using AutoMapper;
using BoletoService.Application.Interfaces;
using BoletoService.Domain.Interfaces.Repositories;
using BoletoService.Domain.Interfaces.Services;
using BoletoService.Shared.Abstractions;
using BoletoService.Shared.Messages;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace BoletoService.Application.Services
{
    public abstract class BaseServiceApp<TEntity, TEntityRequest, TEntityResponse> : IBaseServiceApp<TEntity, TEntityRequest, TEntityResponse>
        where TEntity : BaseEntity, IEntity
        where TEntityRequest : IDtoRequest
        where TEntityResponse : IDtoResponse
    {
        private readonly IBaseService<TEntity> _service;
        private readonly IValidator<TEntityRequest> _validator;
        private readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseServiceApp(IBaseService<TEntity> service, IMapper mapper, IUnitOfWork unitOfWork, IValidator<TEntityRequest> validator)
        {
            _service = service;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        public virtual async Task<IResult> Add(TEntityRequest entityRequest)
        {
            try
            {
                var validationResult = _validator.Validate(entityRequest);

                if (!validationResult.IsValid)
                {
                    return ResultFailed.New(validationResult.ToString());
                }

                TEntity entity = _mapper.Map<TEntity>(entityRequest);
                await _service.Add(entity);
                return ResultSucess<TEntityResponse>.New(_mapper.Map<TEntityResponse>(entity));
            }
            catch (Exception ex)
            {
                return ResultFailed.New(ex.InnerException?.Message ?? ex.Message);
            }
        }
        public virtual async Task<IResult> Get(Guid id)
        {
            TEntity val = await _service.Get(id);
            if (val == null)
            {
                return ResultFailed.New("Not Found");
            }

            return ResultSucess<TEntityResponse>.New(_mapper.Map<TEntityResponse>(val));
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(TEntity TEntity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }


    }

}

