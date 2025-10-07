namespace PutApi.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}