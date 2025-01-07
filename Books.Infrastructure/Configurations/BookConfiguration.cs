using System.Reflection.Emit;
using System.Reflection.Metadata;
using Books.Domain.Models;
using Books.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Books.Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasConversion(
                    bookId => bookId.Value,
                    dbId => BookId.Of(dbId)
                 )
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Title).HasMaxLength(200).IsRequired();
            builder.Property(b => b.Author).HasMaxLength(150).IsRequired();
            builder.Property(b => b.Genre).HasMaxLength(50).IsRequired();

            builder.HasIndex(b => new { b.Title}, "IX_Books_Title");

            builder.HasIndex(b => new { b.Author, b.Id }, "IX_Books_Author_Id");

            builder.HasIndex(b => new { b.Genre, b.Id }, "IX_Books_Genre_Id");
        }
    }
}