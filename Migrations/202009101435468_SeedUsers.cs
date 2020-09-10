namespace Vid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'40e2b3fc-9c6c-4e77-9b28-b18ff79d907d', N'lmao@yahoo.com', 0, N'AKvNzrU2L0AnhiEhYTJaJzkaHa1sQkvHi2nn/bCadD23zFFJxiqV5H25o/1he9uLsQ==', N'647aac0f-378c-41a1-9fb0-38235436b896', NULL, 0, 0, NULL, 1, 0, N'lmao@yahoo.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5af166ee-b764-4fd1-ae76-ad7fbbc31183', N'admin@vidly.com', 0, N'AGCKjY0AeBflN2CumG8Kkz8YAFddj7F2pjKMegq9YrkRGXxXibXgO3/fxQ7JDQuamg==', N'eb08662f-82ab-4e1b-85d6-5bae1b1bbb4d', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9c3e51b1-ff5c-4ab9-b13d-e9a3a070ecb7', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5af166ee-b764-4fd1-ae76-ad7fbbc31183', N'9c3e51b1-ff5c-4ab9-b13d-e9a3a070ecb7')

");
        }
        
        public override void Down()
        {
        }
    }
}
