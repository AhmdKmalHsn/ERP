
namespace AK_HR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Absence
    {
        public int Id { get; set; }
        public System.DateTime DateFrom { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public Nullable<decimal> HoursNo { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> Payment { get; set; }
        public int AbsenceTypeId { get; set; }
        public int EmployeeId { get; set; }
        public Nullable<int> IsCreated { get; set; }
        public Nullable<int> IsUpdated { get; set; }
        public Nullable<double> DayPart { get; set; }
        public Nullable<System.DateTime> Ref1 { get; set; }
        public Nullable<System.DateTime> Ref2 { get; set; }
        public Nullable<byte> isRemoveGap { get; set; }
    }
}
