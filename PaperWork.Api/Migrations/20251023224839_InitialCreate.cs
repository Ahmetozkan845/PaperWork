using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaperWork.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_Feedback_Process",
                columns: table => new
                {
                    PWId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionDecision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Directorate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CBACodes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackChannel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionOwnerManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionOwnerManagerRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedbackDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionOwnerManagerFeedbackDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GettingStartedGeneralDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Feedback_Process", x => x.PWId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Feedback_Process");
        }
    }
}
