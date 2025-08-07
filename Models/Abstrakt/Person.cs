using LibrarySystem.Models.Interfaces;

namespace LibrarySystem.Models.Abstract
{
    public abstract class Person : ILibraryMember
    {
        public string Name { get; }

        protected Person(string name)
        {
            Name = name;
        }
    }
}