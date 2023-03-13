namespace OperationDomian.Interface
{
    interface IEmployeeInfo
    {
        Int32 EmployeeId { get; set; }
        String EmployeeName { get; set; }
        DateTime? DateOfBirth { get; set; }
        String EmailId { get; set; }
        String Department { get; set; }
        String City { get; set; }
    }
}
