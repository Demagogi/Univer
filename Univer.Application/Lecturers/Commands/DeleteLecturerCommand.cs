using MediatR;
using Univer.Domain.Interfaces;

namespace Univer.Application.Lecturers.Commands
{
    public record DeleteLecturerCommand(Guid Id): IRequest;

    public class DeleteLecturerCommandHandler : IRequestHandler<DeleteLecturerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLecturerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteLecturerCommand request, CancellationToken cancellationToken)
        {
            var lecturer = await _unitOfWork.LecturerRepository.GetFirstOrDefaultAsync(l => l.Id == request.Id);

            await _unitOfWork.LecturerRepository.DeleteAsync(lecturer.Id);

            await _unitOfWork.CompleteAsync();
        }
    }
}
