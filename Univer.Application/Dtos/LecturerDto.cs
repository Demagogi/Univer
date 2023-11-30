namespace Univer.Application.Dtos
{
    public record LecturerDto(Guid Id, string Name, string Subject);

    public record CreateLecturerDto(string Name, string Subject);

    public record UpdateLecturerDto(Guid Id, string Name, string Subject);
}
