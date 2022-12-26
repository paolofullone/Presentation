using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.Entities;


namespace Presentation.Infra.Data.EntitiesConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Password).IsRequired();

            builder.HasOne(p => p.PersonalInfo)
                .WithOne(p => p.Person)
                .HasForeignKey<PersonalInfo>(p => p.Id);

            // TODO: passar o personId aqui também, por enquanto está gerando a migration com null e estou inserindo manualmente.
            builder.HasData(new Person(1, "paolo.fullone@xpi.com.br", "Password123"));
        }
    }
}
