using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class cascade_no_action : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catheter_event_Catheterisation_Catheterisation_ID",
                table: "Catheter_event");

            migrationBuilder.DropForeignKey(
                name: "FK_Catheter_event_Event_Event_ID",
                table: "Catheter_event");

         
            migrationBuilder.DropForeignKey(
                name: "FK_Catheterisation_Reception_Reception_ID",
                table: "Catheterisation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reception_Part_Part_ID",
                table: "Reception");

            migrationBuilder.DropForeignKey(
                name: "FK_Reception_Patient_Patient_ID",
                table: "Reception");

            migrationBuilder.DropForeignKey(
                name: "FK_Reception_user_tbl_User_ID",
                table: "Reception");

            migrationBuilder.AddForeignKey(
                name: "FK_Catheter_event_Catheterisation_Catheterisation_ID",
                table: "Catheter_event",
                column: "Catheterisation_ID",
                principalTable: "Catheterisation",
                principalColumn: "Catheterisation_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Catheter_event_Event_Event_ID",
                table: "Catheter_event",
                column: "Event_ID",
                principalTable: "Event",
                principalColumn: "Event_ID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Catheterisation_Doctor_DoctorDr_ID",
            //    table: "Catheterisation",
            //    column: "Dr_ID",
            //    principalTable: "Doctor",
            //    principalColumn: "DR_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Catheterisation_Reception_Reception_ID",
                table: "Catheterisation",
                column: "Reception_ID",
                principalTable: "Reception",
                principalColumn: "Reception_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reception_Part_Part_ID",
                table: "Reception",
                column: "Part_ID",
                principalTable: "Part",
                principalColumn: "Part_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reception_Patient_Patient_ID",
                table: "Reception",
                column: "Patient_ID",
                principalTable: "Patient",
                principalColumn: "Patient_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reception_user_tbl_User_ID",
                table: "Reception",
                column: "User_ID",
                principalTable: "user_tbl",
                principalColumn: "User_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catheter_event_Catheterisation_Catheterisation_ID",
                table: "Catheter_event");

            migrationBuilder.DropForeignKey(
                name: "FK_Catheter_event_Event_Event_ID",
                table: "Catheter_event");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Catheterisation_Doctor_DoctorDr_ID",
            //    table: "Catheterisation");

            migrationBuilder.DropForeignKey(
                name: "FK_Catheterisation_Reception_Reception_ID",
                table: "Catheterisation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reception_Part_Part_ID",
                table: "Reception");

            migrationBuilder.DropForeignKey(
                name: "FK_Reception_Patient_Patient_ID",
                table: "Reception");

            migrationBuilder.DropForeignKey(
                name: "FK_Reception_user_tbl_User_ID",
                table: "Reception");

            migrationBuilder.AddForeignKey(
                name: "FK_Catheter_event_Catheterisation_Catheterisation_ID",
                table: "Catheter_event",
                column: "Catheterisation_ID",
                principalTable: "Catheterisation",
                principalColumn: "Catheterisation_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catheter_event_Event_Event_ID",
                table: "Catheter_event",
                column: "Event_ID",
                principalTable: "Event",
                principalColumn: "Event_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catheterisation_Doctor_DoctorDr_ID",
                table: "Catheterisation",
                column: "Dr_ID",
                principalTable: "Doctor",
                principalColumn: "DR_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catheterisation_Reception_Reception_ID",
                table: "Catheterisation",
                column: "Reception_ID",
                principalTable: "Reception",
                principalColumn: "Reception_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reception_Part_Part_ID",
                table: "Reception",
                column: "Part_ID",
                principalTable: "Part",
                principalColumn: "Part_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reception_Patient_Patient_ID",
                table: "Reception",
                column: "Patient_ID",
                principalTable: "Patient",
                principalColumn: "Patient_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reception_user_tbl_User_ID",
                table: "Reception",
                column: "User_ID",
                principalTable: "user_tbl",
                principalColumn: "User_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
