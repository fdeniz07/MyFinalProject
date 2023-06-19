using Entities.Abstract;

namespace Entities.Concrete
{
    //Ciplak Class Kalmasin 
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
