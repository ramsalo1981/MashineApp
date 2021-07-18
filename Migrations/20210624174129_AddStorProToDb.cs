using Microsoft.EntityFrameworkCore.Migrations;

namespace MachineApp.Migrations
{
    public partial class AddStorProToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC usp_GetApplicationTypes 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.ApplicationTypes 
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_GetApplicationType 
                                    @Id int 
                                    AS 
                                    BEGIN 
                                     SELECT * FROM   dbo.ApplicationTypes  WHERE  (Id = @Id) 
                                    END ");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateApplicationType
	                                @Id int,
	                                @Name varchar(100)
                                    AS 
                                    BEGIN 
                                     UPDATE dbo.ApplicationTypes
                                     SET  Name = @Name
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_DeleteApplicationType
	                                @Id int
                                    AS 
                                    BEGIN 
                                     DELETE FROM dbo.ApplicationTypes
                                     WHERE  Id = @Id
                                    END");

            migrationBuilder.Sql(@"CREATE PROC usp_CreateApplicationType
                                   @Name varchar(100)
                                   AS 
                                   BEGIN 
                                    INSERT INTO dbo.ApplicationTypes(Name)
                                    VALUES (@Name)
                                   END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetApplicationTypes");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetApplicationType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateApplicationType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteApplicationType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateApplicationType");
        }
    }
}
