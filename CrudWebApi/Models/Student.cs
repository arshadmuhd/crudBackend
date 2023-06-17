namespace CrudWebApi.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public string StudentName { get; set; }
        public DateTime StudentDob { get; set; }
        public string StudentDistrict { get; set; }
        public string StudentPlace { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public bool StudentStatus { get; set; }
    }
}
