using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRefundTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CancellationCharges_CancellationRequests_CancellationRequestId",
                table: "CancellationCharges");

            migrationBuilder.DropForeignKey(
                name: "FK_CancellationRequests_Reservations_ReservationID",
                table: "CancellationRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Reservations_ReservationID",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_CancellationRequests_ReservationID",
                table: "CancellationRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CancellationCharges",
                table: "CancellationCharges");

            migrationBuilder.DropIndex(
                name: "IX_CancellationCharges_CancellationRequestId",
                table: "CancellationCharges");

            migrationBuilder.RenameColumn(
                name: "CancellationRequestId",
                table: "CancellationCharges",
                newName: "CancellationRequestID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "States",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RoomTypes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "Reservations",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Payments",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal;(10, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Feedbacks",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestedOn",
                table: "CancellationRequests",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "CancellationRequests",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CancellationRequests",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "CancellationRequests",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CancellationType",
                table: "CancellationRequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CancellationReason",
                table: "CancellationRequests",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "CancellationCharges",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PolicyDescription",
                table: "CancellationCharges",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MinimumCharge",
                table: "CancellationCharges",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CancellationPercentage",
                table: "CancellationCharges",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CancellationChargeAmount",
                table: "CancellationCharges",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            // FIXED: Removed the problematic AlterColumn that tried to remove IDENTITY
            // Instead, we keep the Id column as is (with IDENTITY) and just change the primary key

            migrationBuilder.AddPrimaryKey(
                name: "PK_CancellationCharges",
                table: "CancellationCharges",
                column: "CancellationRequestID");

            migrationBuilder.CreateTable(
                name: "Refunds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefundAmount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    RefundReason = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RefundStatus = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    RefundDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CancellationCharge = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    NetRefundAmount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    ProcessedByUserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefundMethodID = table.Column<int>(type: "int", nullable: false),
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    CancellationRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refunds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refunds_CancellationRequests_CancellationRequestId",
                        column: x => x.CancellationRequestId,
                        principalTable: "CancellationRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Refunds_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Refunds_RefundMethods_RefundMethodID",
                        column: x => x.RefundMethodID,
                        principalTable: "RefundMethods",
                        principalColumn: "Id");
                });

            migrationBuilder.AddCheckConstraint(
                name: "CHK_ResRoomDates",
                table: "ReservationRooms",
                sql: "[CheckOutDate] > [CheckInDate]");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_Rating_Between_1_5",
                table: "Feedbacks",
                sql: "Rating BETWEEN 1 AND 5");

            migrationBuilder.CreateIndex(
                name: "IX_CancellationRequests_ReservationID",
                table: "CancellationRequests",
                column: "ReservationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_CancellationRequestId",
                table: "Refunds",
                column: "CancellationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_PaymentID",
                table: "Refunds",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_RefundMethodID",
                table: "Refunds",
                column: "RefundMethodID");

            migrationBuilder.AddForeignKey(
                name: "FK_CancellationCharges_CancellationRequests_CancellationRequestID",
                table: "CancellationCharges",
                column: "CancellationRequestID",
                principalTable: "CancellationRequests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CancellationRequests_Reservations_ReservationID",
                table: "CancellationRequests",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Reservations_ReservationID",
                table: "Feedbacks",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CancellationCharges_CancellationRequests_CancellationRequestID",
                table: "CancellationCharges");

            migrationBuilder.DropForeignKey(
                name: "FK_CancellationRequests_Reservations_ReservationID",
                table: "CancellationRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Reservations_ReservationID",
                table: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Refunds");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_ResRoomDates",
                table: "ReservationRooms");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_Rating_Between_1_5",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_CancellationRequests_ReservationID",
                table: "CancellationRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CancellationCharges",
                table: "CancellationCharges");

            // Recreate the original primary key on Id
            migrationBuilder.AddPrimaryKey(
                name: "PK_CancellationCharges",
                table: "CancellationCharges",
                column: "Id");

            migrationBuilder.RenameColumn(
                name: "CancellationRequestID",
                table: "CancellationCharges",
                newName: "CancellationRequestId");

            // Restore original column values
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "States",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "RoomTypes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "Reservations",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Payments",
                type: "decimal;(10, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RequestedOn",
                table: "CancellationRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "CancellationRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CancellationRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "CancellationRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CancellationType",
                table: "CancellationRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CancellationReason",
                table: "CancellationRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            // Restore original CancellationCharges columns
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalCost",
                table: "CancellationCharges",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PolicyDescription",
                table: "CancellationCharges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MinimumCharge",
                table: "CancellationCharges",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CancellationPercentage",
                table: "CancellationCharges",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CancellationChargeAmount",
                table: "CancellationCharges",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);

            // Restore the IDENTITY property on Id column
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CancellationCharges",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_CancellationRequests_ReservationID",
                table: "CancellationRequests",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_CancellationCharges_CancellationRequestId",
                table: "CancellationCharges",
                column: "CancellationRequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CancellationCharges_CancellationRequests_CancellationRequestId",
                table: "CancellationCharges",
                column: "CancellationRequestId",
                principalTable: "CancellationRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CancellationRequests_Reservations_ReservationID",
                table: "CancellationRequests",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Reservations_ReservationID",
                table: "Feedbacks",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}