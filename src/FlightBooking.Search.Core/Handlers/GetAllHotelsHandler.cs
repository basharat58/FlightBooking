﻿using FlightBooking.Search.Core.Mapping;
using FlightBooking.Search.Core.Queries;
using FlightBooking.Search.Core.Repositories;
using FlightBooking.Search.Core.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FlightBooking.Search.Core.Handlers
{
    public class GetAllHotelsHandler : IRequestHandler<GetAllHotelsQuery, List<HotelResponse>>
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;

        public GetAllHotelsHandler(
            IHotelRepository hotelRepository,
            IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<List<HotelResponse>> Handle(GetAllHotelsQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _hotelRepository.GetAllHotels();
            return hotels == null
                ? null
                : _mapper.Map(hotels);
        }
    }
}
