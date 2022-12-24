using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.Entities;


namespace Presentation.Infra.Data.EntitiesConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FullName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.City).IsRequired();
            builder.Property(p => p.State).IsRequired();
            builder.Property(p => p.LinkedinUrl).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();

            builder.HasData(
                new Person(1, "Paolo Fullone", "paolo.fullone@xpi.com.br", "Coronel Fabriciano", "MG", "https://www.linkedin.com/in/paolofullone/", new DateTime(1978, 08, 10))
                );
        }
    }
}
