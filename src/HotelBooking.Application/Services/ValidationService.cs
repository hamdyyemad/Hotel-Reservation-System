using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using HotelBooking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelBooking.Application.Services
{
    public class ValidationService
    {
        public async Task<bool> IsExist<T>(GeneralRepository<T> repository, int id, ErrorCode errorCode) where T : BaseModel
        {
            var doesEntityExist = await repository.ExistById(id);
            if (!doesEntityExist)
            {
                throw new Exception($"Entity with ID {id} not found")
                {
                    Data = { { "ErrorCode", errorCode } }
                };  
            }
            return doesEntityExist;
        }

        public async Task<T> IsExist<T>(GeneralRepository<T> repository, Expression<Func<T, bool>> predicate, ErrorCode errorCode, string errorMessage) where T : BaseModel
        {
            var entity = await repository.GetAll().FirstOrDefaultAsync(predicate);
            if (entity == null)
            {
                throw new Exception(errorMessage)
                {
                    Data = { { "ErrorCode", errorCode } }
                };
            }
            return entity;
        }
        public async Task IsNotExist<T>(GeneralRepository<T> repository, Expression<Func<T, bool>> predicate, ErrorCode errorCode, string errorMessage) where T : BaseModel
        {
            var entity = await repository.GetAll().FirstOrDefaultAsync(predicate);
            if (entity != null)
            {
                throw new Exception(errorMessage)
                {
                    Data = { { "ErrorCode", errorCode } }
                };
            }
        }

        public async Task<IEnumerable<T>> DoTheyExist<T>(
            GeneralRepository<T> repository,
            Expression<Func<T, bool>> predicate,
            ErrorCode errorCode,
            string errorMessage) where T : BaseModel
        {
            var entities = await repository.GetAll().Where(predicate).ToListAsync();
            if (!entities.Any())
            {
                throw new Exception(errorMessage)
                {
                    Data = { { "ErrorCode", errorCode } }
                };
            }
            return entities;
        }

    }
} 