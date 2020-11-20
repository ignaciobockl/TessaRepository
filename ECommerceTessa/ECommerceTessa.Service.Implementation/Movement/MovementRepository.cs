using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Movement;
using ECommerceTessa.Service.Interface.Movement.DTOs;

namespace ECommerceTessa.Service.Implementation.Movement
{
    public class MovementRepository : IMovementRepository
    {
        private readonly IRepository<Domain.Entities.Movement> _movementRepository;

        public MovementRepository(IRepository<Domain.Entities.Movement> movementRepository)
        {
            _movementRepository = movementRepository;
        }

        public async Task Create(MovementDto dto)
        {
            var movement = new Domain.Entities.Movement
            {
                Amount = dto.Amount,
                Date = dto.Date,
                Description = dto.Description,
                VoucherId = dto.VoucherId,
                ErasedState = false
            };

            await _movementRepository.Create(movement);
        }

        public async Task Delete(MovementDto dto)
        {
            var movement = await _movementRepository.GetById(dto.Id);

            if (movement != null)
            {
                var delete = await _movementRepository.GetById(movement.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;

                    await _movementRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;

                    await _movementRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Movement not exist");
            }
        }

        public async Task<IEnumerable<MovementDto>> GetAll()
        {
            var allMovement = await _movementRepository.GetAll();

            return allMovement.Select(x => new MovementDto
            {
                Id = x.Id,
                Amount = x.Amount,
                Date = x.Date,
                Description = x.Description,
                VoucherId = x.VoucherId,
                ErasedState = x.ErasedState
            }).Where(x => x.ErasedState == false);
        }

        public async Task<MovementDto> GetById(long movementId)
        {
            var movement = await _movementRepository.GetById(movementId);

            if (movement==null)
            {
                return null;
            }
            else
            {
                return new MovementDto
                {
                    Id = movement.Id,
                    Amount = movement.Amount,
                    Date = movement.Date,
                    Description = movement.Description,
                    VoucherId = movement.VoucherId,
                    ErasedState = movement.ErasedState
                };
            }
        }

        public async Task Update(MovementDto dto)
        {
            using (var context = new DataContext())
            {
                var updateMovement = context.Movements.FirstOrDefault(x => x.Id == dto.Id);

                if (updateMovement == null)
                {
                    throw new Exception("The Movement to modify was not found");
                }
                else
                {
                    if (updateMovement.ErasedState)
                    {
                        throw new Exception("The Movement is eliminated");
                    }

                    updateMovement.Amount = dto.Amount;
                    updateMovement.Date = dto.Date;
                    updateMovement.Description = dto.Description;
                    updateMovement.VoucherId = dto.VoucherId;

                    await _movementRepository.Update(updateMovement);
                }
            }
        }
    }
}
