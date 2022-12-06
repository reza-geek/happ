using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catheter",
                columns: table => new
                {
                    Catheter_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Catheter_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catheter", x => x.Catheter_ID);
                });

            migrationBuilder.CreateTable(
                name: "CatheterEject",
                columns: table => new
                {
                    CatheterEject_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EjectReason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatheterEject", x => x.CatheterEject_ID);
                });

            migrationBuilder.CreateTable(
                name: "Clearance",
                columns: table => new
                {
                    Clearance_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clearance_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clearance", x => x.Clearance_ID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Event_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Event_ID);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    Part_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Part_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.Part_ID);
                });

            migrationBuilder.CreateTable(
                name: "user_tbl",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    National_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Create_DateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: true),
                    LoginFailedCount = table.Column<int>(type: "int", nullable: true),
                    LastLoginDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_tbl", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Dr_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dr_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dr_Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dr_NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dr_Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insert_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Other_Center = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Dr_ID);
                    table.ForeignKey(
                        name: "FK_Doctor_user_tbl_User_ID",
                        column: x => x.User_ID,
                        principalTable: "user_tbl",
                        principalColumn: "User_ID");
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Patient_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    National_Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insert_Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Patient_ID);
                    table.ForeignKey(
                        name: "FK_Patient_user_tbl_User_ID",
                        column: x => x.User_ID,
                        principalTable: "user_tbl",
                        principalColumn: "User_ID");
                });

            migrationBuilder.CreateTable(
                name: "Reception",
                columns: table => new
                {
                    Reception_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rec_DateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recognization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clearance_DESC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clearance_DateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Part_ID = table.Column<int>(type: "int", nullable: false),
                    Clearance_ID = table.Column<int>(type: "int", nullable: true),
                    Patient_ID = table.Column<long>(type: "bigint", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reception", x => x.Reception_ID);
                    table.ForeignKey(
                        name: "FK_Reception_Clearance_Clearance_ID",
                        column: x => x.Clearance_ID,
                        principalTable: "Clearance",
                        principalColumn: "Clearance_ID");
                    table.ForeignKey(
                        name: "FK_Reception_Part_Part_ID",
                        column: x => x.Part_ID,
                        principalTable: "Part",
                        principalColumn: "Part_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reception_Patient_Patient_ID",
                        column: x => x.Patient_ID,
                        principalTable: "Patient",
                        principalColumn: "Patient_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reception_user_tbl_User_ID",
                        column: x => x.User_ID,
                        principalTable: "user_tbl",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catheterisation",
                columns: table => new
                {
                    Catheterisation_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Has_Event = table.Column<bool>(type: "bit", nullable: true),
                    Event_Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Catheterisation_Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    Catheterisation_EjectDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Catheterisation_DateEn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Catheterisation_EjectDateEn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CatheterEject_ID = table.Column<int>(type: "int", nullable: true),
                    DoctorDr_ID = table.Column<int>(type: "int", nullable: false),
                    Reception_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catheterisation", x => x.Catheterisation_ID);
                    table.ForeignKey(
                        name: "FK_Catheterisation_CatheterEject_CatheterEject_ID",
                        column: x => x.CatheterEject_ID,
                        principalTable: "CatheterEject",
                        principalColumn: "CatheterEject_ID");
                    table.ForeignKey(
                        name: "FK_Catheterisation_Doctor_DoctorDr_ID",
                        column: x => x.DoctorDr_ID,
                        principalTable: "Doctor",
                        principalColumn: "Dr_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catheterisation_Reception_Reception_ID",
                        column: x => x.Reception_ID,
                        principalTable: "Reception",
                        principalColumn: "Reception_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catheter_event",
                columns: table => new
                {
                    CatheterisationEvent_ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event_Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Event_Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Catheterisation_ID = table.Column<long>(type: "bigint", nullable: false),
                    Event_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catheter_event", x => x.CatheterisationEvent_ID);
                    table.ForeignKey(
                        name: "FK_Catheter_event_Catheterisation_Catheterisation_ID",
                        column: x => x.Catheterisation_ID,
                        principalTable: "Catheterisation",
                        principalColumn: "Catheterisation_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catheter_event_Event_Event_ID",
                        column: x => x.Event_ID,
                        principalTable: "Event",
                        principalColumn: "Event_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catheter_event_Catheterisation_ID",
                table: "Catheter_event",
                column: "Catheterisation_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Catheter_event_Event_ID",
                table: "Catheter_event",
                column: "Event_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Catheterisation_CatheterEject_ID",
                table: "Catheterisation",
                column: "CatheterEject_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Catheterisation_DoctorDr_ID",
                table: "Catheterisation",
                column: "DoctorDr_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Catheterisation_Reception_ID",
                table: "Catheterisation",
                column: "Reception_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_User_ID",
                table: "Doctor",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_National_Code",
                table: "Patient",
                column: "National_Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_User_ID",
                table: "Patient",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_Clearance_ID",
                table: "Reception",
                column: "Clearance_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_Part_ID",
                table: "Reception",
                column: "Part_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_Patient_ID",
                table: "Reception",
                column: "Patient_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_User_ID",
                table: "Reception",
                column: "User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catheter");

            migrationBuilder.DropTable(
                name: "Catheter_event");

            migrationBuilder.DropTable(
                name: "Catheterisation");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "CatheterEject");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Reception");

            migrationBuilder.DropTable(
                name: "Clearance");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "user_tbl");
        }
    }
}
