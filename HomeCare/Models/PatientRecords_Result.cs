//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeCare.Models
{
    using System;
    
    public partial class PatientRecords_Result
    {
        public int patientId { get; set; }
        public string firsttname { get; set; }
        public string lastname { get; set; }
        public string middlename { get; set; }
        public string gender { get; set; }
        public string phoneNumber { get; set; }
        public System.DateTime dob { get; set; }
        public Nullable<int> age { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
    }
}
