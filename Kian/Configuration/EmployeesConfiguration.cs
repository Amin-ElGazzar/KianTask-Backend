using Kian.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kian.Configuration;

public class EmployeesConfiguration : IEntityTypeConfiguration<Employees>
{
    public void Configure(EntityTypeBuilder<Employees> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(e => e.Id);


        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Address)
            .HasMaxLength(200);

        builder.Property(e => e.Salary)
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.IsActive)
            .IsRequired();
    }
}
