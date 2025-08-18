using System.Reflection;

namespace GameDatabase.Models
{
    public class BatchEditDTO
    {
        public List<int> ids { get; set; }

        public PropertyInfo property { get; set; }

        public bool forAll { get; set; } = false;

        public Player playerData { get; set; }

    }
}
