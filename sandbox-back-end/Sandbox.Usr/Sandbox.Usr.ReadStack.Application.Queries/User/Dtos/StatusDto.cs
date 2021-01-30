namespace Sandbox.Usr.ReadStack.Application.Queries.User.Dtos
{
    public class StatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StatusDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
