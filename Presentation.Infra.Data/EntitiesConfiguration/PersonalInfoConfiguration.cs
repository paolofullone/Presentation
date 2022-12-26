using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Presentation.Domain.Entities;
using Presentation.Domain.Enums;

namespace Presentation.Infra.Data.EntitiesConfiguration
{
    public class PersonalInfoConfiguration : IEntityTypeConfiguration<PersonalInfo>
    {
        public void Configure(EntityTypeBuilder<PersonalInfo> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.FullName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.City).IsRequired();
            builder.Property(p => p.State).IsRequired();
            builder.Property(p => p.LinkedinUrl).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.MaritalStatus).IsRequired();
            builder.Property(p => p.Animals).IsRequired();
            builder.Property(p => p.FavoriteFood).IsRequired();
            builder.Property(p => p.FavoriteMusic).IsRequired();
            builder.Property(p => p.FavoriteMovie).IsRequired();
            builder.Property(p => p.FavoriteTVShow).IsRequired();
            builder.Property(p => p.FavoriteBook).IsRequired();
            builder.Property(p => p.FavoriteSport).IsRequired();

            builder.HasOne(p => p.Person)
                .WithOne(p => p.PersonalInfo)
                .HasForeignKey<Person>(p => p.Id);

            builder.HasData(
                            new PersonalInfo(
                                id: 1, fullName: "Paolo Enrico Iacono Fullone", city: "Coronel Fabriciano", state: "MG", birthDate: new DateTime(1978, 08, 10), maritalStatus: MaritalStatus.Married,
                                animals: "2 cachorros, 2(n) coelhos", favoriteFood: "Churrasco", favoriteMusic: "Depende", favoriteMovie: "Interstellar", favoriteTVShow: "Dark", favoriteBook: "Ponto de Inflexão", favoriteSport: "Tenis", linkedinUrl: "https://www.linkedin.com/in/paolofullone/", personId: 1)
                            );
        }
    }
}