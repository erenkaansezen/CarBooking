using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.CQRS.Result.ContactResults;
using Application.Features.Mediator.Queries.ReservationQueries;
using Application.Features.Mediator.Results.ReservationResults;
using Application.Interfaces;
using MediatR;
using Web.Domain.Entities;

namespace Application.Features.CQRS.Handlers.ReservationHandlers
{
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, List<GetReservationQueryResult>>
    {
        private readonly  IRepository<Reservation> _repository;

        public GetReservationQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReservationQueryResult>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var values = await  _repository.GetAllAsync();
            return values.Select(x => new GetReservationQueryResult
            {
                ReservationID = x.ReservationID,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Phone = x.Phone,
                PickUpLocationID = x.PickUpLocationID,
                DropOffLocationID = x.DropOffLocationID,
                CarID = x.CarID,
                Age = x.Age,
                DriverLicenseYear = x.DriverLicenseYear,
                Description = x.Description,
                Status = x.Status

            }).ToList();
        }
    }
}