using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBS2019.Data.Migrations
{
    public partial class ImplementedNBSControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArticleDescription = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessCentre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: true),
                    CentreNumber = table.Column<int>(nullable: true),
                    CentreName = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    NumberOfFloors = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    CentreNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCentre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessCentre_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessCentre_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessCentre_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MeetingTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: true),
                    CompanyId1 = table.Column<int>(nullable: true),
                    Qantity1 = table.Column<int>(nullable: true),
                    ArticleId = table.Column<int>(nullable: true),
                    ArticleId1 = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Article_ArticleId1",
                        column: x => x.ArticleId1,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Company_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderPost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ArticleId = table.Column<int>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPost_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PeriodStartDate = table.Column<DateTime>(nullable: false),
                    PeriodEndDate = table.Column<DateTime>(nullable: false),
                    PersonId = table.Column<int>(nullable: true),
                    ArticleId = table.Column<int>(nullable: true),
                    Hours = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    TotalSalary = table.Column<decimal>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    AmountPaidOut = table.Column<decimal>(nullable: false),
                    DatePaidOut = table.Column<DateTime>(nullable: true),
                    AmountDueToPayOut = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salary_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Salary_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocumentName = table.Column<string>(nullable: true),
                    DocumentDescription = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    BusinessCentreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_BusinessCentre_BusinessCentreId",
                        column: x => x.BusinessCentreId,
                        principalTable: "BusinessCentre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DworkinWiFiSurveyResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessCentreId = table.Column<int>(nullable: true),
                    ReportDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    TimeOnSite = table.Column<decimal>(nullable: true),
                    AccessPoints = table.Column<int>(nullable: true),
                    AccessPointsBrandModel = table.Column<string>(nullable: true),
                    A = table.Column<string>(nullable: true),
                    B = table.Column<string>(nullable: true),
                    C = table.Column<string>(nullable: true),
                    D = table.Column<string>(nullable: true),
                    E = table.Column<string>(nullable: true),
                    F = table.Column<string>(nullable: true),
                    G = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DworkinWiFiSurveyResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DworkinWiFiSurveyResult_BusinessCentre_BusinessCentreId",
                        column: x => x.BusinessCentreId,
                        principalTable: "BusinessCentre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DworkinWiFiSurveyResult_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PurchaseOrderNumber = table.Column<string>(nullable: true),
                    BusinessCentreId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    Descrition = table.Column<string>(nullable: true),
                    TimeOnSite = table.Column<decimal>(nullable: false),
                    KostPerHour = table.Column<decimal>(nullable: false),
                    TotalKost = table.Column<decimal>(nullable: false),
                    JobbScheduled = table.Column<DateTime>(nullable: true),
                    JobbStarted = table.Column<DateTime>(nullable: true),
                    JobbEnded = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_BusinessCentre_BusinessCentreId",
                        column: x => x.BusinessCentreId,
                        principalTable: "BusinessCentre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrder_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupportTicket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeStampCreated = table.Column<DateTime>(nullable: false),
                    TimeStampResolved = table.Column<DateTime>(nullable: true),
                    TimeStampClosed = table.Column<DateTime>(nullable: true),
                    BusinessCentreId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    FaultDescription = table.Column<string>(nullable: true),
                    FaultReport = table.Column<string>(nullable: true),
                    TicketLog = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportTicket_BusinessCentre_BusinessCentreId",
                        column: x => x.BusinessCentreId,
                        principalTable: "BusinessCentre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportTicket_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportTicket_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessCentreId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    WorkStarted = table.Column<DateTime>(nullable: false),
                    WorkEnded = table.Column<DateTime>(nullable: false),
                    TimeWorked = table.Column<decimal>(nullable: false),
                    PaymentPerHour = table.Column<decimal>(nullable: false),
                    TotalPayment = table.Column<decimal>(nullable: false),
                    WorkNote = table.Column<string>(nullable: true),
                    Paid = table.Column<bool>(nullable: false),
                    AmountPaid = table.Column<decimal>(nullable: false),
                    DueToPay = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkReport_BusinessCentre_BusinessCentreId",
                        column: x => x.BusinessCentreId,
                        principalTable: "BusinessCentre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkReport_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meeting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    MeetingNote = table.Column<string>(nullable: true),
                    MeetingTypeId = table.Column<int>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meeting_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_MeetingType_MeetingTypeId",
                        column: x => x.MeetingTypeId,
                        principalTable: "MeetingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meeting_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: true),
                    OrderPostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_OrderPost_PersonId",
                        column: x => x.PersonId,
                        principalTable: "OrderPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PROWorkReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    WorkStarted = table.Column<DateTime>(nullable: false),
                    WorkEnded = table.Column<DateTime>(nullable: false),
                    TimeWorked = table.Column<int>(nullable: false),
                    FeePerHour = table.Column<int>(nullable: false),
                    TotalPayment = table.Column<int>(nullable: false),
                    PurchaseOrderId = table.Column<int>(nullable: false),
                    WorkDescription = table.Column<string>(nullable: true),
                    Paid = table.Column<bool>(nullable: false),
                    AmountPaid = table.Column<int>(nullable: false),
                    DueToPay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROWorkReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PROWorkReport_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROWorkReport_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROWorkReport_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROWorkReport_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupportCase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeReported = table.Column<DateTime>(nullable: true),
                    TimeStarted = table.Column<DateTime>(nullable: true),
                    TimeFEScheduled = table.Column<DateTime>(nullable: true),
                    TimeSolved = table.Column<DateTime>(nullable: true),
                    TotalTimeOnSite = table.Column<decimal>(nullable: true),
                    BusinessCentreId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    Descrition = table.Column<string>(nullable: true),
                    PurchaseOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportCase_BusinessCentre_BusinessCentreId",
                        column: x => x.BusinessCentreId,
                        principalTable: "BusinessCentre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportCase_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportCase_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportCase_PurchaseOrder_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCentre_CompanyId",
                table: "BusinessCentre",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCentre_PersonId",
                table: "BusinessCentre",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessCentre_PersonId1",
                table: "BusinessCentre",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Document_BusinessCentreId",
                table: "Document",
                column: "BusinessCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_PersonId",
                table: "Document",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_DworkinWiFiSurveyResult_BusinessCentreId",
                table: "DworkinWiFiSurveyResult",
                column: "BusinessCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_DworkinWiFiSurveyResult_PersonId",
                table: "DworkinWiFiSurveyResult",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ArticleId",
                table: "Invoice",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ArticleId1",
                table: "Invoice",
                column: "ArticleId1");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CompanyId",
                table: "Invoice",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CompanyId1",
                table: "Invoice",
                column: "CompanyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_CompanyId",
                table: "Meeting",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_MeetingTypeId",
                table: "Meeting",
                column: "MeetingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_PersonId",
                table: "Meeting",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_PersonId1",
                table: "Meeting",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PersonId",
                table: "Order",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPost_ArticleId",
                table: "OrderPost",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_PROWorkReport_CompanyId",
                table: "PROWorkReport",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PROWorkReport_PersonId",
                table: "PROWorkReport",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PROWorkReport_PersonId1",
                table: "PROWorkReport",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_PROWorkReport_PurchaseOrderId",
                table: "PROWorkReport",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_BusinessCentreId",
                table: "PurchaseOrder",
                column: "BusinessCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_PersonId",
                table: "PurchaseOrder",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrder_PersonId1",
                table: "PurchaseOrder",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_ArticleId",
                table: "Salary",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_PersonId",
                table: "Salary",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportCase_BusinessCentreId",
                table: "SupportCase",
                column: "BusinessCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportCase_PersonId",
                table: "SupportCase",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportCase_PersonId1",
                table: "SupportCase",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_SupportCase_PurchaseOrderId",
                table: "SupportCase",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTicket_BusinessCentreId",
                table: "SupportTicket",
                column: "BusinessCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTicket_PersonId",
                table: "SupportTicket",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTicket_PersonId1",
                table: "SupportTicket",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkReport_BusinessCentreId",
                table: "WorkReport",
                column: "BusinessCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkReport_PersonId",
                table: "WorkReport",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "DworkinWiFiSurveyResult");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Meeting");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PROWorkReport");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "SupportCase");

            migrationBuilder.DropTable(
                name: "SupportTicket");

            migrationBuilder.DropTable(
                name: "WorkReport");

            migrationBuilder.DropTable(
                name: "MeetingType");

            migrationBuilder.DropTable(
                name: "OrderPost");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "BusinessCentre");
        }
    }
}
