using System.Reflection;

namespace DataManagementWASM.Models
{
    public class ColumnEditDTO
    {
        public IEnumerable<int> ids { get; set; }

        public string property { get; set; } = string.Empty;

        public bool forAll { get; set; } = false;

        public Player playerData { get; set; } = new();
    }
}
