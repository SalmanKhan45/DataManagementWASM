namespace GameDatabase.Models
{
    public class ColumnEditDTO
    {
        public IEnumerable<int> ids { get; set; }

        public string property { get; set; }

        public bool forAll { get; set; } = false;

        public Player playerData { get; set; }
    }
}
