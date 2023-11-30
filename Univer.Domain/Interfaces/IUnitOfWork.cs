namespace Univer.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        ILecturerRepository LecturerRepository { get; }
        Task<int> CompleteAsync();
    }
}
