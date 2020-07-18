namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data.Models;
    public class HospitalContext : DbContext
    {
        public HospitalContext() 
            :base ()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>(pm =>
            {
                pm.HasKey(pm => new { pm.MedicamentId, pm.PatientId });
            });

            modelBuilder.Entity<Diagnose>()
              .Property(t => t.Name)
              .IsRequired(true)
              .IsUnicode(true)
              .HasMaxLength(50);

            modelBuilder.Entity<Diagnose>()
              .Property(t => t.Comments)
              .IsUnicode(true)
              .HasMaxLength(250);

            modelBuilder.Entity<Patient>()
              .Property(t => t.FirstName)
              .IsRequired(true)
              .IsUnicode(true)
              .HasMaxLength(50);

            modelBuilder.Entity<Patient>()
              .Property(t => t.LastName)
              .IsRequired(true)
              .IsUnicode(true)
              .HasMaxLength(50);

            modelBuilder.Entity<Patient>()
              .Property(t => t.Address)
              .IsRequired(true)
              .IsUnicode(true)
              .HasMaxLength(250);

            modelBuilder.Entity<Patient>()
              .Property(t => t.Email)
              .IsRequired(true)
              .IsUnicode(false)
              .HasMaxLength(80);

            modelBuilder.Entity<Visitation>()
              .Property(t => t.Comments)
              .IsRequired(true)
              .IsUnicode(true)
              .HasMaxLength(250);

            modelBuilder.Entity<Medicament>()
              .Property(t => t.Name)
              .IsRequired(true)
              .IsUnicode(true)
              .HasMaxLength(50);

            modelBuilder.Entity<Doctor>()
              .Property(t => t.Name)
              .IsRequired(true)
              .IsUnicode(true)
              .HasMaxLength(100);

            modelBuilder.Entity<Doctor>()
              .Property(t => t.Specialty)
              .IsRequired(true)
              .IsUnicode(true)
              .HasMaxLength(100);
        }
    }
}
