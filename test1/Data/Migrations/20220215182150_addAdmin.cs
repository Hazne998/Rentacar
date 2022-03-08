using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using RentaCar.Entities;
using System.Text;

namespace RentaCar.Data.Migrations
{
    public partial class addAdmin : Migration
    {
        const string ADMIN_USER_GUID = "3e7e02d4-9dad-48a9-8d10-3357f756536c";
        const string ADMIN_ROLE_GUID = "e24bdb6b-80c3-4a8c-8b36-d63fa203ea07";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var passwordHash = hasher.HashPassword(null, "Password100!"); //TODO!!!

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName,Email,EmailConfirmed,PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount,NormalizedEmail, PasswordHash, SecurityStamp, Ime, Prezime, Adresa1, Adresa2, PostCode)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{ADMIN_USER_GUID}'");
            sb.AppendLine(",'admin@rentacar.com'");
            sb.AppendLine(",'ADMIN@RENTACAR.COM'");
            sb.AppendLine(",'admin@rentacar.com'");
            sb.AppendLine(",0");
            sb.AppendLine(",0");
            sb.AppendLine(",0");
            sb.AppendLine(",0");
            sb.AppendLine(",0");
            sb.AppendLine(",'ADMIN@RENTACAR.COM'");
            sb.AppendLine($",'{passwordHash}'");
            sb.AppendLine(",''");
            sb.AppendLine(",'Ado'");
            sb.AppendLine(",'Haznadarevic'"); 
            sb.AppendLine(",'Stipanjici bb'"); 
            sb.AppendLine(",'Stipanjici bb'"); 
            sb.AppendLine(",'80240'"); 
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{ADMIN_ROLE_GUID}','Admin','ADMIN')");

            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{ADMIN_USER_GUID}','{ADMIN_ROLE_GUID}')");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId='{ADMIN_USER_GUID}' AND RoleId='{ADMIN_ROLE_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id='{ADMIN_USER_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id='{ADMIN_ROLE_GUID}'");


        }
    }
}
