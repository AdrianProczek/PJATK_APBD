using Zad_6.Models;

namespace Zad_6.Configuration
{
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder) 
        {
            builder.HaskKey(e => e.IdDoctor).HasName("Doctor_PK");
            builder.Property(e => e.IdDoctor).UseIdentityColumn();

            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();

            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Email).IsUnique();

            var doctors = new List<Doctor>();

            doctors.Add(new Doctor
            {
                IdDoctor = 1,
                FirstName = "Mateusz",
                LastName = "Nowak",
                Email = "mateusz.nowak@gmail.com"
            });
            doctors.Add(new Doctor
            {
                IdDoctor = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jan.kowalsk@gmail.com"
            });

            builder.HasData(doctors);
        }
    }
}
