namespace Univer.Domain.Entities
{
    public class Lecturer : Entity
    {
        public string Name { get; private set; }
        public string Subject {  get; private set; }

        private Lecturer() {}

        public Lecturer(string name, string subject)
        {
            Id = Guid.NewGuid();
            Name = name;
            Subject = subject;
        }

        public void Update(string name, string subject) 
        {
            Name = name;
            Subject = subject;
        }
    }
}
