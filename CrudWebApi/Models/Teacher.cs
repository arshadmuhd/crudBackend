using System.ComponentModel.DataAnnotations.Schema;

namespace CrudWebApi.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }

        public Guid UserID { get; set; }
        public User User { get; set; }

        public string TeacherName { get; set; }


        public long TeacherPhoneNumber { get; set; }
        public string TeacherEmail { get; set; }
        public DateTime TeacherDob { get; set; }
        public DateTime TeacherDoj { get; set; }
        public string TeacherPlace { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }  

        public bool IsActive { get; set; }
    }
}

