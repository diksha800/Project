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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class HomeHealthCareEntities : DbContext
    {
        public HomeHealthCareEntities()
            : base("name=HomeHealthCareEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Audit> Audits { get; set; }
        public virtual DbSet<doctorName> doctorNames { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<patient> patients { get; set; }
        public virtual DbSet<Specialist> Specialists { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int AddUser(string pLogin, string pPassword, string pFirstName, string pLastName)
        {
            var pLoginParameter = pLogin != null ?
                new ObjectParameter("pLogin", pLogin) :
                new ObjectParameter("pLogin", typeof(string));
    
            var pPasswordParameter = pPassword != null ?
                new ObjectParameter("pPassword", pPassword) :
                new ObjectParameter("pPassword", typeof(string));
    
            var pFirstNameParameter = pFirstName != null ?
                new ObjectParameter("pFirstName", pFirstName) :
                new ObjectParameter("pFirstName", typeof(string));
    
            var pLastNameParameter = pLastName != null ?
                new ObjectParameter("pLastName", pLastName) :
                new ObjectParameter("pLastName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddUser", pLoginParameter, pPasswordParameter, pFirstNameParameter, pLastNameParameter);
        }
    
        public virtual int DeletePatientsDetails(Nullable<int> paientId)
        {
            var paientIdParameter = paientId.HasValue ?
                new ObjectParameter("paientId", paientId) :
                new ObjectParameter("paientId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeletePatientsDetails", paientIdParameter);
        }
    
        public virtual ObjectResult<Getappointments_Result> Getappointments(Nullable<int> aID, string doctorName, string specialist, Nullable<System.DateTime> appointmentDime)
        {
            var aIDParameter = aID.HasValue ?
                new ObjectParameter("AID", aID) :
                new ObjectParameter("AID", typeof(int));
    
            var doctorNameParameter = doctorName != null ?
                new ObjectParameter("DoctorName", doctorName) :
                new ObjectParameter("DoctorName", typeof(string));
    
            var specialistParameter = specialist != null ?
                new ObjectParameter("Specialist", specialist) :
                new ObjectParameter("Specialist", typeof(string));
    
            var appointmentDimeParameter = appointmentDime.HasValue ?
                new ObjectParameter("AppointmentDime", appointmentDime) :
                new ObjectParameter("AppointmentDime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Getappointments_Result>("Getappointments", aIDParameter, doctorNameParameter, specialistParameter, appointmentDimeParameter);
        }
    
        public virtual ObjectResult<PatientRecords_Result> PatientRecords()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PatientRecords_Result>("PatientRecords");
        }
    
        public virtual ObjectResult<AppointmentRecords_Result> AppointmentRecords()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AppointmentRecords_Result>("AppointmentRecords");
        }
    
        public virtual ObjectResult<AppointmentRecords_Result> appointmentrecord()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AppointmentRecords_Result>("appointmentrecord");
        }
    
        public virtual ObjectResult<Getaudit_Result> Getaudit()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Getaudit_Result>("Getaudit");
        }
    
        public virtual ObjectResult<Getaudit_Result> GetAuditInfo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Getaudit_Result>("GetAuditInfo");
        }
    
        public virtual ObjectResult<DoctorNameList_Result> DoctorNameList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DoctorNameList_Result>("DoctorNameList");
        }
    
        public virtual ObjectResult<SpecialistList_Result> SpecialistList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpecialistList_Result>("SpecialistList");
        }
    }
}
