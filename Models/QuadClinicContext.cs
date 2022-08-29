using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuadClinicWebApplication2022.Models
{
    public partial class QuadClinicContext : DbContext
    {
        public QuadClinicContext()
        {
        }

        public QuadClinicContext(DbContextOptions<QuadClinicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<AppointmentBill> AppointmentBill { get; set; }
        public virtual DbSet<BloodGroup> BloodGroup { get; set; }
        public virtual DbSet<ClinicInfo> ClinicInfo { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<LabTest> LabTest { get; set; }
        public virtual DbSet<LabTestBill> LabTestBill { get; set; }
        public virtual DbSet<LabTestPrescription> LabTestPrescription { get; set; }
        public virtual DbSet<LabTestReport> LabTestReport { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<MedicineBill> MedicineBill { get; set; }
        public virtual DbSet<MedicinePrescription> MedicinePrescription { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Specialization> Specialization { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<TreatmentHistory> TreatmentHistory { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server = DESKTOP-E40CR46\\SQLEXPRESS;Database=QuadClinic;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Appointme__Docto__4D94879B");

                //entity.HasOne(d => d.Patient)
                //    .WithMany(p => p.Appointment)
                //    .HasForeignKey(d => d.PatientId)
                //    .HasConstraintName("FK__Appointme__Patie__4E88ABD4");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK__Appointme__Speci__4F7CD00D");
            });

            modelBuilder.Entity<AppointmentBill>(entity =>
            {
                entity.Property(e => e.AppointmentBillAmount)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AppointmentBillDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.AppointmentBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__Appointme__Appoi__70DDC3D8");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.AppointmentBill)
                    .HasForeignKey(d => d.ClinicId)
                    .HasConstraintName("FK__Appointme__Clini__71D1E811");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.AppointmentBill)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Appointme__Docto__6FE99F9F");

                //entity.HasOne(d => d.Patient)
                //    .WithMany(p => p.AppointmentBill)
                //    .HasForeignKey(d => d.PatientId)
                //    .HasConstraintName("FK__Appointme__Patie__6EF57B66");
            });

            modelBuilder.Entity<BloodGroup>(entity =>
            {
                entity.Property(e => e.BloodGroup1)
                    .HasColumnName("BloodGroup")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClinicInfo>(entity =>
            {
                entity.HasKey(e => e.ClinicId)
                    .HasName("PK__ClinicIn__3347C2DDB1165267");

                entity.Property(e => e.ClinicName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('RE220'+CONVERT([varchar](20),[ClinicId]))");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.ConsultationFees)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK__Doctor__Speciali__440B1D61");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Doctor__StaffId__4316F928");
            });

            modelBuilder.Entity<LabTest>(entity =>
            {
                entity.Property(e => e.LabTestCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LabTestName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LabTestPrice)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LabTestBill>(entity =>
            {
                entity.Property(e => e.LabTestBillAmount)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LabTestBillDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.LabTestBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__LabTestBi__Appoi__778AC167");

                entity.HasOne(d => d.Clinic)
                    .WithMany(p => p.LabTestBill)
                    .HasForeignKey(d => d.ClinicId)
                    .HasConstraintName("FK__LabTestBi__Clini__787EE5A0");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.LabTestBill)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__LabTestBi__Docto__76969D2E");

                entity.HasOne(d => d.LabTestPresc)
                    .WithMany(p => p.LabTestBill)
                    .HasForeignKey(d => d.LabTestPrescId)
                    .HasConstraintName("FK__LabTestBi__LabTe__797309D9");

                //entity.HasOne(d => d.Patient)
                //    .WithMany(p => p.LabTestBill)
                //    .HasForeignKey(d => d.PatientId)
                //    .HasConstraintName("FK__LabTestBi__Patie__75A278F5");
            });

            modelBuilder.Entity<LabTestPrescription>(entity =>
            {
                entity.HasKey(e => e.LabTestPrescId)
                    .HasName("PK__LabTestP__F8597B79DA496AEB");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.LabTestPrescription)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__LabTestPr__Appoi__5DCAEF64");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.LabTestPrescription)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__LabTestPr__Docto__5EBF139D");

                entity.HasOne(d => d.LabTest)
                    .WithMany(p => p.LabTestPrescription)
                    .HasForeignKey(d => d.LabTestId)
                    .HasConstraintName("FK__LabTestPr__LabTe__5BE2A6F2");

                //entity.HasOne(d => d.Patient)
                //    .WithMany(p => p.LabTestPrescription)
                //    .HasForeignKey(d => d.PatientId)
                //    .HasConstraintName("FK__LabTestPr__Patie__5CD6CB2B");
            });

            modelBuilder.Entity<LabTestReport>(entity =>
            {
                entity.HasKey(e => e.LabTestReport1)
                    .HasName("PK__LabTestR__CFA656F04DFC146F");

                entity.Property(e => e.LabTestReport1).HasColumnName("LabTestReport");

                entity.Property(e => e.HighRange)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LabTestReportPrice)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LabTestReportRemarks)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.LowRange)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.LabTestReport)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__LabTestRe__Docto__6383C8BA");

                entity.HasOne(d => d.LabTestPresc)
                    .WithMany(p => p.LabTestReport)
                    .HasForeignKey(d => d.LabTestPrescId)
                    .HasConstraintName("FK__LabTestRe__LabTe__619B8048");

                //entity.HasOne(d => d.Patient)
                //    .WithMany(p => p.LabTestReport)
                //    .HasForeignKey(d => d.PatientId)
                //    .HasConstraintName("FK__LabTestRe__Patie__628FA481");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GenericName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MedicinePrice)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicineBill>(entity =>
            {
                entity.Property(e => e.MedicineBillAmount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineBillDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.MedicineBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__MedicineB__Appoi__7D439ABD");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.MedicineBill)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__MedicineB__Docto__7F2BE32F");

                entity.HasOne(d => d.MedicinePresc)
                    .WithMany(p => p.MedicineBill)
                    .HasForeignKey(d => d.MedicinePrescId)
                    .HasConstraintName("FK__MedicineB__Medic__00200768");

                //entity.HasOne(d => d.Patient)
                //    .WithMany(p => p.MedicineBill)
                //    .HasForeignKey(d => d.PatientId)
                //    .HasConstraintName("FK__MedicineB__Patie__7E37BEF6");
            });

            modelBuilder.Entity<MedicinePrescription>(entity =>
            {
                entity.HasKey(e => e.MedicinePrescId)
                    .HasName("PK__Medicine__12B0A476CAF7910A");

                entity.Property(e => e.Dosage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfDays)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.MedicinePrescription)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__MedicineP__Appoi__5812160E");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.MedicinePrescription)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__MedicineP__Docto__59063A47");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedicinePrescription)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__MedicineP__Medic__5629CD9C");

                //entity.HasOne(d => d.Patient)
                //    .WithMany(p => p.MedicinePrescription)
                //    .HasForeignKey(d => d.PatientId)
                //    .HasConstraintName("FK__MedicineP__Patie__571DF1D5");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PatientCreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PatientDob)
                    .HasColumnName("PatientDOB")
                    .HasColumnType("date");

                entity.Property(e => e.PatientMobileNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PatientName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PatientRegId)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('QP220'+CONVERT([varchar](20),[PatientId]))");

                entity.Property(e => e.StaffGender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                //entity.HasOne(d => d.BloodGroup)
                //    .WithMany(p => p.Patient)
                //    .HasForeignKey(d => d.BloodGroupId)
                //    .HasConstraintName("FK__Patient__BloodGr__48CFD27E");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.Property(e => e.SpecializationName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.StaffAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StaffCreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StaffDesignation)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.StaffDob)
                    .HasColumnName("StaffDOB")
                    .HasColumnType("date");

                entity.Property(e => e.StaffFullname)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.StaffGender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffMobileNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TreatmentHistory>(entity =>
            {
                entity.Property(e => e.Diagnosis)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TreatmentHistoryCreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.TreatmentHistory)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__Treatment__Appoi__6B24EA82");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TreatmentHistory)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Treatment__Docto__68487DD7");

                entity.HasOne(d => d.LabTestPresc)
                    .WithMany(p => p.TreatmentHistory)
                    .HasForeignKey(d => d.LabTestPrescId)
                    .HasConstraintName("FK__Treatment__LabTe__693CA210");

                entity.HasOne(d => d.MedicinePresc)
                    .WithMany(p => p.TreatmentHistory)
                    .HasForeignKey(d => d.MedicinePrescId)
                    .HasConstraintName("FK__Treatment__Medic__6A30C649");

                //entity.HasOne(d => d.Patient)
                //    .WithMany(p => p.TreatmentHistory)
                //    .HasForeignKey(d => d.PatientId)
                //    .HasConstraintName("FK__Treatment__Patie__6754599E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User__RoleId__3D5E1FD2");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__User__StaffId__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
