using OperationDomian.Interface;

namespace OperationDomian.Entities
{
    public class EmployeeInfo : IEmployeeInfo
    {
        public Int32 EmployeeId { get; set; }
        public String EmployeeName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public String EmailId { get; set; }
        public String Department { get; set; }
        public String City { get; set; }

        public EmployeeInfo()
        {
            EmployeeId = 0;
            EmployeeName = String.Empty;
            EmailId = String.Empty;
            Department = String.Empty;
            City = String.Empty;
        }
    }
}
