namespace Sandbox.Usr.ReadStack.Application.Queries.User.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RoleDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
