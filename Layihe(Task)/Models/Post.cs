using Layihe_Task_.Models.Base;

namespace Layihe_Task_.Models
{
    public class Post:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
