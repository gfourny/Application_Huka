using SQLite;

namespace People.Models
{
    [Table("Boisson")]
    public class Boisson
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public float Glucide { get; set; }
        public float SucreLent { get; set; }
        public float SucreRapide { get; set; }
    }
}
