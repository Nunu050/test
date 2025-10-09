namespace PutApi.Models
{
    public class Student
    {
        public int Id { get; set; }        // Khóa chính
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }   // Ngày sinh

        public int ClassId { get; set; }   // Khóa ngoại

    }
}
