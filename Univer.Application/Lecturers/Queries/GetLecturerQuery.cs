using AutoMapper;
using MediatR;
using Univer.Application.Dtos;
using Univer.Domain.Interfaces;

namespace Univer.Application.Lecturers.Queries
{
    public record GetLecturerQuery(Guid Id) : IRequest<LecturerDto>;

    public class GetLecturerQueryHandler : IRequestHandler<GetLecturerQuery, LecturerDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetLecturerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<LecturerDto> Handle(GetLecturerQuery request, CancellationToken cancellationToken)
        {
            var lector = await _unitOfWork.LecturerRepository.GetFirstOrDefaultAsync(l=>l.Id == request.Id);

            return _mapper.Map<LecturerDto>(lector);
        }
    }
}
