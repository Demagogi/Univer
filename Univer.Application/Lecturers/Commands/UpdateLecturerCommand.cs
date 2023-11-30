using AutoMapper;
using MediatR;
using Univer.Application.Dtos;
using Univer.Domain.Interfaces;

namespace Univer.Application.Lecturers.Commands
{
    public record UpdateLecturerCommand(UpdateLecturerDto Dto) : IRequest<Guid>;

    public class UpdateLecturerCommandHandler : IRequestHandler<UpdateLecturerCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateLecturerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateLecturerCommand request, CancellationToken cancellationToken)
        {

            var lector = await _unitOfWork.LecturerRepository.GetFirstOrDefaultAsync(l => l.Id == request.Dto.Id);

            if (lector == null) 
            {
                throw new NullReferenceException(nameof(lector));
            }

            lector.Update(request.Dto.Name, request.Dto.Subject);

            await _unitOfWork.CompleteAsync();

            return lector.Id;
        }
    }
}
