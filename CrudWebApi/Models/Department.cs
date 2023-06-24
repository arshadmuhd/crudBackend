namespace CrudWebApi.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public bool DepartmentStatus { get; set; }
/*
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }*/

        public string DepartmentHeadName { get; set;}
    }
}
