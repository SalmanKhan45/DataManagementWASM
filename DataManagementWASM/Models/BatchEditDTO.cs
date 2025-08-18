using System.Reflection;

namespace DataManagementWASM.Models
{
    public class BatchEditDTO
    {
        public List<int> ids { get; set; }

        public PropertyInfo property { get; set; }
    }
}
