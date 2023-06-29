using Entities.Abstract;

namespace Entities
{
    public class Personel : IEntity
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
    }
}
