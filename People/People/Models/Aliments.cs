using SQLite;

namespace People.Models
{
    [Table("aliments")]
    public class Aliments
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public float Glucide { get; set; }
        public float SucreLent { get; set; }
        public float SucreRapide { get; set; }
    }
}
