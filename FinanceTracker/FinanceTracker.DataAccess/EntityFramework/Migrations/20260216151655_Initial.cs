using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceTracker.DataAccess.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AmountParsingDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mode = table.Column<int>(type: "int", nullable: false),
                    SignedConvention = table.Column<int>(type: "int", nullable: false),
                    DebitCreditConvention = table.Column<int>(type: "int", nullable: false),
                    DefaultCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecimalSeparator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThousandSeparator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmountParsingDefinitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColumnSelectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: true),
                    Trim = table.Column<bool>(type: "bit", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnSelectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoredPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColumnMappingDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Strategy = table.Column<int>(type: "int", nullable: false),
                    DateId = table.Column<int>(type: "int", nullable: false),
                    DescriptionId = table.Column<int>(type: "int", nullable: false),
                    CounterpartyId = table.Column<int>(type: "int", nullable: true),
                    ReferenceId = table.Column<int>(type: "int", nullable: true),
                    ExternalIdId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<int>(type: "int", nullable: true),
                    AmountId = table.Column<int>(type: "int", nullable: true),
                    DebitId = table.Column<int>(type: "int", nullable: true),
                    CreditId = table.Column<int>(type: "int", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnMappingDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColumnMappingDefinitions_ColumnSelectors_AccountId",
                        column: x => x.AccountId,
                        principalTable: "ColumnSelectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ColumnMappingDefinitions_ColumnSelectors_AmountId",
                        column: x => x.AmountId,
                        principalTable: "ColumnSelectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ColumnMappingDefinitions_ColumnSelectors_CounterpartyId",
                        column: x => x.CounterpartyId,
                        principalTable: "ColumnSelectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ColumnMappingDefinitions_ColumnSelectors_CreditId",
                        column: x => x.CreditId,
                        principalTable: "ColumnSelectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ColumnMappingDefinitions_ColumnSelectors_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "ColumnSelectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ColumnMappingDefinitions_ColumnSelectors_DateId",
                        column: x => x.DateId,
                        principalTable: "ColumnSelectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ColumnMappingDefinitions_ColumnSelectors_DebitId",
                        column: x => x.DebitId,
                        principalTable: "ColumnSelectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ColumnMappingDefinitions_ColumnSelectors_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "ColumnSelectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ColumnMappingDefinitions_ColumnSelectors_ExternalIdId",
                        column: x => x.ExternalIdId,
                        principalTable: "ColumnSelectors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ColumnMappingDefinitions_ColumnSelectors_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "ColumnSelectors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CsvProfileDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delimiter = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    HasHeader = table.Column<bool>(type: "bit", nullable: false),
                    EncodingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFormat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountParsingId = table.Column<int>(type: "int", nullable: false),
                    MappingId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsvProfileDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CsvProfileDefinitions_AmountParsingDefinitions_AmountParsingId",
                        column: x => x.AmountParsingId,
                        principalTable: "AmountParsingDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CsvProfileDefinitions_ColumnMappingDefinitions_MappingId",
                        column: x => x.MappingId,
                        principalTable: "ColumnMappingDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CsvProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DefinitionId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsvProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CsvProfiles_CsvProfileDefinitions_DefinitionId",
                        column: x => x.DefinitionId,
                        principalTable: "CsvProfileDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextReplaceRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Replacement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UseRegex = table.Column<bool>(type: "bit", nullable: false),
                    CsvProfileDefinitionId = table.Column<int>(type: "int", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextReplaceRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextReplaceRules_CsvProfileDefinitions_CsvProfileDefinitionId",
                        column: x => x.CsvProfileDefinitionId,
                        principalTable: "CsvProfileDefinitions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImportBatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CvsProfileId = table.Column<int>(type: "int", nullable: false),
                    RowCount = table.Column<int>(type: "int", nullable: false),
                    ImportCount = table.Column<int>(type: "int", nullable: false),
                    SkippedCount = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportBatches_CsvProfiles_CvsProfileId",
                        column: x => x.CvsProfileId,
                        principalTable: "CsvProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    ImportBatchId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_ImportBatches_ImportBatchId",
                        column: x => x.ImportBatchId,
                        principalTable: "ImportBatches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionReceipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    ReceiptId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionReceipts_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionReceipts_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionSplits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionSplits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionSplits_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionSplits_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColumnMappingDefinitions_AccountId",
                table: "ColumnMappingDefinitions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnMappingDefinitions_AmountId",
                table: "ColumnMappingDefinitions",
                column: "AmountId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnMappingDefinitions_CounterpartyId",
                table: "ColumnMappingDefinitions",
                column: "CounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnMappingDefinitions_CreditId",
                table: "ColumnMappingDefinitions",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnMappingDefinitions_CurrencyId",
                table: "ColumnMappingDefinitions",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnMappingDefinitions_DateId",
                table: "ColumnMappingDefinitions",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnMappingDefinitions_DebitId",
                table: "ColumnMappingDefinitions",
                column: "DebitId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnMappingDefinitions_DescriptionId",
                table: "ColumnMappingDefinitions",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnMappingDefinitions_ExternalIdId",
                table: "ColumnMappingDefinitions",
                column: "ExternalIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnMappingDefinitions_ReferenceId",
                table: "ColumnMappingDefinitions",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_CsvProfileDefinitions_AmountParsingId",
                table: "CsvProfileDefinitions",
                column: "AmountParsingId");

            migrationBuilder.CreateIndex(
                name: "IX_CsvProfileDefinitions_MappingId",
                table: "CsvProfileDefinitions",
                column: "MappingId");

            migrationBuilder.CreateIndex(
                name: "IX_CsvProfiles_DefinitionId",
                table: "CsvProfiles",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportBatches_CvsProfileId",
                table: "ImportBatches",
                column: "CvsProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_TextReplaceRules_CsvProfileDefinitionId",
                table: "TextReplaceRules",
                column: "CsvProfileDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionReceipts_ReceiptId",
                table: "TransactionReceipts",
                column: "ReceiptId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionReceipts_TransactionId",
                table: "TransactionReceipts",
                column: "TransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ImportBatchId",
                table: "Transactions",
                column: "ImportBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSplits_CategoryId",
                table: "TransactionSplits",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionSplits_TransactionId",
                table: "TransactionSplits",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextReplaceRules");

            migrationBuilder.DropTable(
                name: "TransactionReceipts");

            migrationBuilder.DropTable(
                name: "TransactionSplits");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ImportBatches");

            migrationBuilder.DropTable(
                name: "CsvProfiles");

            migrationBuilder.DropTable(
                name: "CsvProfileDefinitions");

            migrationBuilder.DropTable(
                name: "AmountParsingDefinitions");

            migrationBuilder.DropTable(
                name: "ColumnMappingDefinitions");

            migrationBuilder.DropTable(
                name: "ColumnSelectors");
        }
    }
}
