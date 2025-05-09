namespace ExpenseApplication.Server.Infrastructure.Data.Configurations;

/// <summary>
/// UserToken entity fluent api database configuration
/// </summary>
public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.HasKey(userToken => userToken.Id);
        builder.Property(userToken => userToken.Id).HasColumnOrder(0);
        builder.HasOne(userToken => userToken.User).WithMany(user => user.UserTokens).HasForeignKey(ut => ut.UserId);
        builder.Property(userToken => userToken.AccessTokenExpiresDateTime).HasColumnType("datetime2(0)").IsRequired();
        builder.Property(userToken => userToken.RefreshTokenExpiresDateTime).HasColumnType("datetime2(0)").IsRequired();
        builder.Property(userToken => userToken.AccessTokenHash).HasColumnType("varchar").HasMaxLength(450);
        builder.Property(userToken => userToken.RefreshTokenIdHash).HasColumnType("varchar").HasMaxLength(450).IsRequired();
        builder.Property(userToken => userToken.RefreshTokenIdHashSource).HasColumnType("varchar").HasMaxLength(450);
    }
}