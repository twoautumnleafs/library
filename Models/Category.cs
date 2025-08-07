namespace LibrarySystem.Models
{
    public class Category
    {
        public string Name { get; }

        public Category(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;
    }
}