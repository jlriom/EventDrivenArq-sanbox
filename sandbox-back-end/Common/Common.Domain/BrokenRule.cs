namespace Common.Domain
{
    public class BrokenRule
    {
        public BrokenRule(string description)
        {
            Description = description;
        }

        public string Description { get; }
    }
}