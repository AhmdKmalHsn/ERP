//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AK_HR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ak_Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ak_Users()
        {
            this.AK_logins = new HashSet<AK_logins>();
        }
    
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string Image { get; set; }
        public Nullable<short> All { get; set; }
        public Nullable<short> Departments { get; set; }
        public Nullable<short> Employees { get; set; }
        public Nullable<bool> HaveApprove { get; set; }
        public Nullable<int> ApproveId { get; set; }
        public Nullable<int> UserType { get; set; }
        public Nullable<int> Parent { get; set; }
        public Nullable<int> StageClass { get; set; }
        public string ip_restrict { get; set; }
        public string active { get; set; }
        public Nullable<System.DateTime> login_at { get; set; }
        public Nullable<System.DateTime> login_to { get; set; }
        public Nullable<decimal> login_permit { get; set; }
        public string token { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AK_logins> AK_logins { get; set; }
        public virtual AK_Roles AK_Roles { get; set; }
    }
}
