using Database.Models;

namespace DataBase.Models
{
    public partial class Salary
    {
        public int? Id { get; set; }
        public decimal BasicSalary { get; set; }
        public int NumberOfDays { get; set; }
        public decimal? Allowance { get; set; }
        public DateTime? WorkTime { get; set; }
        public string EmployeeId { get; set; } = null!;
        public ApplicationUser Employee { get; set; } = null!;
    }
}
