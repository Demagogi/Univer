using AutoMapper;
using MediatR;
using Univer.Application.Dtos;
using Univer.Domain.Interfaces;

namespace Univer.Application.Lecturers.Queries
{
    public record GetLecturersQuery : IRequest<IEnumerable<LecturerDto>>;

    public class GetLecturersQueryHandler : IRequestHandler<GetLecturersQuery, IEnumerable<LecturerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLecturersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LecturerDto>> Handle(GetLecturersQuery request, CancellationToken cancellationToken)
        {
            var lecturers = await _unitOfWork.LecturerRepository.GetAllAsync();

            var lecturersDtos = lecturers.Select(u => _mapper.Map<LecturerDto>(u));

            return lecturersDtos;
        }
    }
}
