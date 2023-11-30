using AutoMapper;
using MediatR;
using Univer.Application.Dtos;
using Univer.Domain.Entities;
using Univer.Domain.Interfaces;

namespace Univer.Application.Lecturers.Commands
{
    public record CreateLecturerCommand(CreateLecturerDto Dto) : IRequest<Guid>;

    public class CreateLecturerCommandHandler : IRequestHandler<CreateLecturerCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLecturerCommandHandler(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateLecturerCommand request, CancellationToken cancellationToken)
        {
            var lecturer = _mapper.Map<Lecturer>(request);

            _unitOfWork.LecturerRepository.Create(lecturer);

            await _unitOfWork.CompleteAsync();

            return lecturer.Id;
        }
    }
}
