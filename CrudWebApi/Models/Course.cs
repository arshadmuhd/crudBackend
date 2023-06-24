namespace CrudWebApi.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string CourseDescription { get; set; }
        public long CourseFee { get; set; }
        public bool CourseIsActive { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
