using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndustrialServicesSystem.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    MinVersionCode = table.Column<string>(maxLength: 128, nullable: true),
                    LatestVersionCode = table.Column<string>(maxLength: 128, nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.ApplicationID);
                });

            migrationBuilder.CreateTable(
                name: "CodeGroup",
                columns: table => new
                {
                    CodeGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeGroupGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeGroup", x => x.CodeGroupID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentProvider",
                columns: table => new
                {
                    PaymentProviderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentProviderGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentProvider", x => x.PaymentProviderID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroup",
                columns: table => new
                {
                    PermissionGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionGroupGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroup", x => x.PermissionGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    SettingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettingGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserInitialCredit = table.Column<int>(nullable: false),
                    OrderRequestPrice = table.Column<int>(nullable: false),
                    IntroductionCodePrice = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.SettingID);
                });

            migrationBuilder.CreateTable(
                name: "SMSProvider",
                columns: table => new
                {
                    SMSProviderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMSProviderGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSProvider", x => x.SMSProviderID);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Usage = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "Code",
                columns: table => new
                {
                    CodeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    CodeGroupID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Code", x => x.CodeID);
                    table.ForeignKey(
                        name: "FK_Code_CodeGroup",
                        column: x => x.CodeGroupID,
                        principalTable: "CodeGroup",
                        principalColumn: "CodeGroupID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentProviderSetting",
                columns: table => new
                {
                    PaymentProviderSettingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentProviderSettingGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    PaymentProviderID = table.Column<int>(nullable: false),
                    Username = table.Column<string>(maxLength: 128, nullable: true),
                    Password = table.Column<string>(maxLength: 128, nullable: true),
                    APIKey = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentProviderSetting", x => x.PaymentProviderSettingID);
                    table.ForeignKey(
                        name: "FK_PaymentProviderSetting_PaymentProvider",
                        column: x => x.PaymentProviderID,
                        principalTable: "PaymentProvider",
                        principalColumn: "PaymentProviderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    PermissionGroupID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionID);
                    table.ForeignKey(
                        name: "FK_Permission_PermissionGroup",
                        column: x => x.PermissionGroupID,
                        principalTable: "PermissionGroup",
                        principalColumn: "PermissionGroupID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ProvinceID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_City_Province",
                        column: x => x.ProvinceID,
                        principalTable: "Province",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMSProviderSetting",
                columns: table => new
                {
                    SMSProviderSettingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMSProviderSettingGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    SMSProviderID = table.Column<int>(nullable: false),
                    Username = table.Column<string>(maxLength: 128, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    APIKey = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSProviderSetting", x => x.SMSProviderSettingID);
                    table.ForeignKey(
                        name: "FK_SMSProviderSetting_SMSProvider",
                        column: x => x.SMSProviderID,
                        principalTable: "SMSProvider",
                        principalColumn: "SMSProviderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    ContactUsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactUsGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ContactUsBusinessTypeCodeID = table.Column<int>(nullable: false),
                    StateCodeID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 128, nullable: false),
                    Message = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.ContactUsID);
                    table.ForeignKey(
                        name: "FK_ContactUs_ContactUsBusinessTypeCode",
                        column: x => x.ContactUsBusinessTypeCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactUs_StateCode",
                        column: x => x.StateCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    TypeCodeID = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Size = table.Column<long>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocumentID);
                    table.ForeignKey(
                        name: "FK_Document_Code",
                        column: x => x.TypeCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicDiscount",
                columns: table => new
                {
                    PublicDiscountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicDiscountGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    TypeCodeID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 128, nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicDiscount", x => x.PublicDiscountID);
                    table.ForeignKey(
                        name: "FK_PublicDiscount_Code",
                        column: x => x.TypeCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    TypeCodeID = table.Column<int>(nullable: false),
                    Cost = table.Column<long>(nullable: false),
                    Serial = table.Column<string>(maxLength: 128, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transaction_Code",
                        column: x => x.TypeCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    RolePermissionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolePermissionGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    PermissionID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.RolePermissionID);
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission",
                        column: x => x.PermissionID,
                        principalTable: "Permission",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMSProviderSettingNumber",
                columns: table => new
                {
                    SMSProviderSettingNumberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMSProviderSettingNumberGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    SMSProviderSettingID = table.Column<int>(nullable: false),
                    Value = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSProviderSettingNumber", x => x.SMSProviderSettingNumberID);
                    table.ForeignKey(
                        name: "FK_SMSProviderSettingNumber_SMSProviderSetting",
                        column: x => x.SMSProviderSettingID,
                        principalTable: "SMSProviderSetting",
                        principalColumn: "SMSProviderSettingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMSTemplate",
                columns: table => new
                {
                    SMSTemplateID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMSTemplateGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    SMSProviderSettingID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSTemplate", x => x.SMSTemplateID);
                    table.ForeignKey(
                        name: "FK_SMSTemplate_SMSProviderSetting",
                        column: x => x.SMSProviderSettingID,
                        principalTable: "SMSProviderSetting",
                        principalColumn: "SMSProviderSettingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Advertisement",
                columns: table => new
                {
                    AdvertisementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    DocumentID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    IsShow = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisement", x => x.AdvertisementID);
                    table.ForeignKey(
                        name: "FK_Advertisement_Document",
                        column: x => x.DocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ParentCategoryID = table.Column<int>(nullable: true),
                    CoverDocumentID = table.Column<int>(nullable: true),
                    SecondPageCoverDocumentID = table.Column<int>(nullable: true),
                    ActiveIconDocumentID = table.Column<int>(nullable: true),
                    InactiveIconDocumentID = table.Column<int>(nullable: true),
                    QuadMenuDocumentID = table.Column<int>(nullable: true),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false),
                    Abstract = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Category_ActiveIconDocument",
                        column: x => x.ActiveIconDocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_CoverDocument",
                        column: x => x.CoverDocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_InactiveIconDocument",
                        column: x => x.InactiveIconDocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_ParentCategory",
                        column: x => x.ParentCategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_QuadMenuDocument",
                        column: x => x.QuadMenuDocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_SecondPageCoverDocument",
                        column: x => x.SecondPageCoverDocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    RoleID = table.Column<int>(nullable: false),
                    GenderCodeID = table.Column<int>(nullable: true),
                    ProfileDocumentID = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    LastName = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsRegister = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    RegisteredDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Code",
                        column: x => x.GenderCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Document_ProfileDocumentID",
                        column: x => x.ProfileDocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTag",
                columns: table => new
                {
                    CategoryTagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryTagGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    CategoryID = table.Column<int>(nullable: false),
                    TagID = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTag", x => x.CategoryTagID);
                    table.ForeignKey(
                        name: "FK_CategoryTag_Category",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryTag_Tag",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Admin_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Client_City",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comment_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    ComplaintID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    StateCodeID = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(maxLength: 512, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.ComplaintID);
                    table.ForeignKey(
                        name: "FK_Complaint_Code",
                        column: x => x.StateCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complaint_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contractor",
                columns: table => new
                {
                    ContractorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    BusinessTypeCodeID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    IntroductionCode = table.Column<string>(maxLength: 128, nullable: false),
                    Latitude = table.Column<string>(maxLength: 128, nullable: false),
                    Longitude = table.Column<string>(maxLength: 128, nullable: false),
                    Credit = table.Column<int>(nullable: false),
                    AverageRate = table.Column<double>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AboutMe = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(maxLength: 128, nullable: true),
                    Website = table.Column<string>(maxLength: 128, nullable: true),
                    Instagram = table.Column<string>(maxLength: 128, nullable: true),
                    Telegram = table.Column<string>(maxLength: 128, nullable: true),
                    Linkedin = table.Column<string>(maxLength: 128, nullable: true),
                    Whatsapp = table.Column<string>(maxLength: 128, nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.ContractorID);
                    table.ForeignKey(
                        name: "FK_Contractor_Code",
                        column: x => x.BusinessTypeCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contractor_City",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contractor_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    DocumentID = table.Column<int>(nullable: false),
                    SliderCodeId = table.Column<int>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false),
                    LikeCount = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Abstract = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsShow = table.Column<bool>(nullable: false),
                    IsSuggested = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Post_Document",
                        column: x => x.DocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_Code",
                        column: x => x.SliderCodeId,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SMSResponse",
                columns: table => new
                {
                    SMSResponseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMSResponseGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    SMSTemplateID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusText = table.Column<string>(nullable: false),
                    Sender = table.Column<string>(maxLength: 128, nullable: false),
                    Receptor = table.Column<string>(maxLength: 128, nullable: false),
                    Token = table.Column<string>(maxLength: 128, nullable: true),
                    Token1 = table.Column<string>(maxLength: 128, nullable: true),
                    Token2 = table.Column<string>(maxLength: 128, nullable: true),
                    Message = table.Column<string>(nullable: false),
                    Cost = table.Column<long>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    SentDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSResponse", x => x.SMSResponseID);
                    table.ForeignKey(
                        name: "FK_SMSResponse_SMSTemplate",
                        column: x => x.SMSTemplateID,
                        principalTable: "SMSTemplate",
                        principalColumn: "SMSTemplateID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SMSResponse_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suggestion",
                columns: table => new
                {
                    SuggestionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuggestionGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(maxLength: 512, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggestion", x => x.SuggestionID);
                    table.ForeignKey(
                        name: "FK_Suggestion_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    TokenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    UserID = table.Column<int>(nullable: false),
                    RoleCodeID = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.TokenID);
                    table.ForeignKey(
                        name: "FK_Token_Code",
                        column: x => x.RoleCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Token_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                columns: table => new
                {
                    UserPermissionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPermissionGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    PermissionID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => x.UserPermissionID);
                    table.ForeignKey(
                        name: "FK_UserPermission_Permission",
                        column: x => x.PermissionID,
                        principalTable: "Permission",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPermission_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractorCategory",
                columns: table => new
                {
                    ContractorCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorCategoryGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ContractorID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorCategory", x => x.ContractorCategoryID);
                    table.ForeignKey(
                        name: "FK_ContractorCategory_Category",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractorCategory_Contractor",
                        column: x => x.ContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ContractorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractorDiscount",
                columns: table => new
                {
                    ContractorDiscountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorDiscountGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ContractorID = table.Column<int>(nullable: false),
                    PublicDiscountID = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorDiscount", x => x.ContractorDiscountID);
                    table.ForeignKey(
                        name: "FK_ContractorDiscount_Contractor",
                        column: x => x.ContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ContractorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractorDiscount_PublicDiscount",
                        column: x => x.PublicDiscountID,
                        principalTable: "PublicDiscount",
                        principalColumn: "PublicDiscountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractorDocument",
                columns: table => new
                {
                    ContractorDocumentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorDocumentGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ContractorID = table.Column<int>(nullable: false),
                    TitleCodeID = table.Column<int>(nullable: false),
                    DocumentID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsAccept = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorDocument", x => x.ContractorDocumentID);
                    table.ForeignKey(
                        name: "FK_ContractorDocument_Contractor",
                        column: x => x.ContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ContractorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractorDocument_Document",
                        column: x => x.DocumentID,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractorDocument_Code",
                        column: x => x.TitleCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractorIntroductionCode",
                columns: table => new
                {
                    ContractorIntroductionCodeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractorIntroductionCodeGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    NewContractorID = table.Column<int>(nullable: false),
                    ContractorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorIntroductionCode", x => x.ContractorIntroductionCodeID);
                    table.ForeignKey(
                        name: "FK_ContractorIntroductionCode_Contractor",
                        column: x => x.ContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ContractorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractorIntroductionCode_NewContractor",
                        column: x => x.NewContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ContractorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ClientID = table.Column<int>(nullable: false),
                    ContractorID = table.Column<int>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false),
                    StateCodeID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Rate = table.Column<double>(nullable: true),
                    Cost = table.Column<int>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    DeadlineDate = table.Column<DateTime>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Category",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Client",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Contractor",
                        column: x => x.ContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ContractorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Code",
                        column: x => x.StateCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    PaymentProviderSettingID = table.Column<int>(nullable: false),
                    ContractorID = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    TrackingToken = table.Column<long>(nullable: true),
                    IsSuccessful = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_Contractor",
                        column: x => x.ContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ContractorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_PaymentProviderSetting_PaymentProviderSettingID",
                        column: x => x.PaymentProviderSettingID,
                        principalTable: "PaymentProviderSetting",
                        principalColumn: "PaymentProviderSettingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateDiscount",
                columns: table => new
                {
                    PrivateDiscountID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrivateDiscountGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ContractorID = table.Column<int>(nullable: false),
                    TypeCodeID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 128, nullable: false),
                    MaximumUsesNumber = table.Column<int>(nullable: false),
                    NumberUsed = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateDiscount", x => x.PrivateDiscountID);
                    table.ForeignKey(
                        name: "FK_PrivateDiscount_Contractor",
                        column: x => x.ContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ContractorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrivateDiscount_Code",
                        column: x => x.TypeCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostCategory",
                columns: table => new
                {
                    PostCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostCategoryGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    CategoryID = table.Column<int>(nullable: false),
                    PostID = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategory", x => x.PostCategoryID);
                    table.ForeignKey(
                        name: "FK_PostCategory_Category",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategory_Post",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostComment",
                columns: table => new
                {
                    PostCommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostCommentGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    CommentID = table.Column<int>(nullable: false),
                    PostID = table.Column<int>(nullable: false),
                    IsAccept = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComment", x => x.PostCommentID);
                    table.ForeignKey(
                        name: "FK_PostComment_Comment",
                        column: x => x.CommentID,
                        principalTable: "Comment",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostComment_Post",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostTagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTagGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    PostID = table.Column<int>(nullable: false),
                    TagID = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => x.PostTagID);
                    table.ForeignKey(
                        name: "FK_PostTag_Post",
                        column: x => x.PostID,
                        principalTable: "Post",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostTag_Tag",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderRequest",
                columns: table => new
                {
                    OrderRequestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderRequestGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    ContractorID = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: false),
                    StateCodeID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    OfferedPrice = table.Column<long>(nullable: false),
                    Price = table.Column<long>(nullable: false),
                    IsAllow = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    IsDelete = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRequest", x => x.OrderRequestID);
                    table.ForeignKey(
                        name: "FK_OrderRequest_Contractor",
                        column: x => x.ContractorID,
                        principalTable: "Contractor",
                        principalColumn: "ContractorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderRequest_Order",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderRequest_StateCode",
                        column: x => x.StateCodeID,
                        principalTable: "Code",
                        principalColumn: "CodeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessage",
                columns: table => new
                {
                    ChatMessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatMessageGUID = table.Column<Guid>(type: "UNIQUEIDENTIFIER ROWGUIDCOL", nullable: false, defaultValueSql: "(newid())"),
                    OrderRequestID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    DocumentId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(nullable: false),
                    SentAt = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => x.ChatMessageID);
                    table.ForeignKey(
                        name: "FK_ChatMessage_Document",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "DocumentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatMessage_OrderRequest",
                        column: x => x.OrderRequestID,
                        principalTable: "OrderRequest",
                        principalColumn: "OrderRequestID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatMessage_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Application",
                columns: new[] { "ApplicationID", "ApplicationGUID", "LatestVersionCode", "MinVersionCode", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("9077fea5-5c35-440a-9ad2-c2bad2730ca1"), null, null, "پیشیار پلاس" },
                    { 2, new Guid("831cf295-25bf-4b52-bfce-cfce432c1a1e"), null, null, "متخصص" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "SecondPageCoverDocumentID", "Sort" },
                values: new object[,]
                {
                    { 1, null, null, new Guid("c265fd02-0194-4d38-83e8-a93bc3698fcc"), null, null, "سایت اصلی", null, true, new DateTime(2020, 12, 10, 18, 37, 59, 974, DateTimeKind.Local).AddTicks(6133), null, null, null, 1 },
                    { 2, null, null, new Guid("dec37f17-0ab2-4208-8ba7-11cc1120369b"), null, null, "وبلاگ", null, true, new DateTime(2020, 12, 10, 18, 37, 59, 974, DateTimeKind.Local).AddTicks(9462), null, null, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "CodeGroup",
                columns: new[] { "CodeGroupID", "CodeGroupGUID", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 12, new Guid("43f6d743-3e89-4c5a-9971-625d7648ebdb"), "نوع کد تخفیف", "Discount Value Type" },
                    { 11, new Guid("7d7887ec-0f29-46f1-ba94-98a9dbb5210e"), "وضعیت پیام شکایت", "Complaint Message State" },
                    { 10, new Guid("822f6fad-a7c0-45e8-93d9-9ceabe74e8bb"), "وضعیت پیام ارتباط با ما", "Contact Us Message State" },
                    { 9, new Guid("51dd8550-d2bd-4a78-b929-2ee7886e6331"), "نام مدرک", "Document Title" },
                    { 8, new Guid("261adec9-7907-4945-b217-c0ed78c363bd"), "اسلایدر", "Slider" },
                    { 7, new Guid("99410d8b-87d5-4aa5-bcc5-552191085d0f"), "وضعیت درخواست سفارش", "Order Request State" },
                    { 13, new Guid("1f8cccf4-9437-4723-9655-0bcadd8e98cd"), "سکو", "Platform" },
                    { 5, new Guid("7e9db57a-0c09-47ff-98b5-f49363beff67"), "نقش", "Role" },
                    { 4, new Guid("39c56245-8e42-4cef-8ddd-5e4c17782e8b"), "وضعیت سفارش", "Order State" },
                    { 3, new Guid("a76da3ba-d12a-42c4-b7e1-732d0990af70"), "جنسیت", "Gender" },
                    { 2, new Guid("2d9c9e83-39eb-42d7-b71f-ef26002c8470"), "نوع کسب و کار", "Business Type" },
                    { 1, new Guid("5b739a57-164e-4b39-8b1c-1129bc9d8991"), "نوع فایل", "Filepond Type" },
                    { 6, new Guid("107a7244-6e66-4369-8ba6-dfb0636642c4"), "نوع کسب و کار بخش ارتباط با ما", "Contact Us Business Type" }
                });

            migrationBuilder.InsertData(
                table: "PaymentProvider",
                columns: new[] { "PaymentProviderID", "Name", "PaymentProviderGUID" },
                values: new object[] { 1, "Zarinpal", new Guid("a129b72e-aca3-4f33-899a-9961f71f352a") });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceID", "Name", "ProvinceGUID" },
                values: new object[,]
                {
                    { 19, "اصفهان", new Guid("3ec70a36-09dd-4019-b2c9-d23b96062e99") },
                    { 20, "ايلام", new Guid("53fa9d29-f537-4eae-9397-3e9018c9b8c9") },
                    { 21, "تهران", new Guid("46e4b223-fed0-4244-af91-8ff3821881ae") },
                    { 22, "آذربايجان شرقي", new Guid("b72bad26-a859-413c-b938-ab0b14f1ff42") },
                    { 23, "فارس", new Guid("92442933-3418-4b9b-8e52-7ab0e3390277") },
                    { 24, "کرمانشاه", new Guid("38f59457-b2f6-4235-b2e4-964ef38c2709") },
                    { 28, "همدان", new Guid("26669bb0-6da9-421e-b77d-9b3a6f18437b") },
                    { 26, "مرکزي", new Guid("314a2d80-fe02-4f65-ac23-8787b5c65a85") },
                    { 27, "گيلان", new Guid("1fee1b12-1bc2-4b70-b619-bd993dc9e03e") },
                    { 29, "کرمان", new Guid("98024ac8-abf3-4682-938b-eecca3d6ec18") },
                    { 30, "سمنان", new Guid("720afbb0-89c2-4a14-a5d6-8b6de090e97a") },
                    { 31, "کهگيلويه و بويراحمد", new Guid("55f2308d-7ed3-4475-b458-e55974b69105") },
                    { 18, "اردبيل", new Guid("cd6c2c28-e571-4f4a-acd2-5220c945bf03") },
                    { 25, "هرمزگان", new Guid("260b6a95-b50b-45f7-87f1-f76f81fdc421") },
                    { 17, "لرستان", new Guid("7132ee81-1274-4a68-9c32-f4a8ec5d48ba") },
                    { 9, "سيستان و بلوچستان", new Guid("99e8e9ed-18e0-4cce-876e-557099facf45") },
                    { 15, "مازندران", new Guid("c84cf0d6-3651-44ca-b285-7de8da4d1b03") },
                    { 1, "يزد", new Guid("2dda5ab0-aedf-427d-bec9-05e0d5317a0c") },
                    { 2, "چهار محال و بختياري", new Guid("3b033ec0-4406-47bc-9a17-29dec1cfe211") },
                    { 3, "خراسان شمالي", new Guid("b90f137a-4aa9-4474-836d-f0f33ff8b66c") },
                    { 4, "البرز", new Guid("c9c30a02-5eb1-4783-a79b-a3574dfc71ba") },
                    { 5, "قم", new Guid("97cf7888-120f-4df6-a4a8-affb81491176") },
                    { 16, "قزوين", new Guid("bdfdf08f-62b8-40d4-a2b0-be462ae2a3dc") },
                    { 7, "آذربايجان غربي", new Guid("73aed877-c018-4205-be19-d5a0ef982911") },
                    { 6, "کردستان", new Guid("ddaa46ae-8317-4019-934f-e5c538924996") },
                    { 10, "خراسان جنوبي", new Guid("d19d972c-a6d2-44c3-a47f-b624d2c5b34a") },
                    { 11, "خوزستان", new Guid("5565555d-63d7-459e-8e66-dd9e6c0245e4") },
                    { 12, "بوشهر", new Guid("f259b545-2088-454c-bdb3-fe25df2452e7") },
                    { 13, "زنجان", new Guid("413e8ecf-2d57-47b8-92a4-e03c355bbe2a") },
                    { 14, "گلستان", new Guid("5f66e3fa-04a8-4688-b9b0-cd98c84d607e") },
                    { 8, "خراسان رضوي", new Guid("80ef998e-310f-4e3b-aa38-ad929bf6208a") }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleID", "DisplayName", "ModifiedDate", "Name", "RoleGUID" },
                values: new object[,]
                {
                    { 1, "ادمین", new DateTime(2020, 12, 10, 18, 37, 59, 963, DateTimeKind.Local).AddTicks(6269), "Admin", new Guid("58796c8a-0c9a-4854-b9a1-567cca21e135") },
                    { 2, "سرویس دهنده", new DateTime(2020, 12, 10, 18, 37, 59, 968, DateTimeKind.Local).AddTicks(7442), "Contractor", new Guid("c54cb218-48ec-4c2a-bb56-2a7a093c86a1") },
                    { 3, "سرویس گیرنده", new DateTime(2020, 12, 10, 18, 37, 59, 968, DateTimeKind.Local).AddTicks(7556), "Client", new Guid("bc8a2bfb-525d-45a0-9490-2a6b8fbe4b21") }
                });

            migrationBuilder.InsertData(
                table: "SMSProvider",
                columns: new[] { "SMSProviderID", "Name" },
                values: new object[] { 1, "Kavenegar" });

            migrationBuilder.InsertData(
                table: "Setting",
                columns: new[] { "SettingID", "IntroductionCodePrice", "OrderRequestPrice", "SettingGUID", "UserInitialCredit" },
                values: new object[] { 1, 250, 500, new Guid("c42e939e-2657-4dfb-b82d-d5341d3b64e5"), 10000 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Abstract", "ActiveIconDocumentID", "CategoryGUID", "CoverDocumentID", "Description", "DisplayName", "InactiveIconDocumentID", "IsActive", "ModifiedDate", "ParentCategoryID", "QuadMenuDocumentID", "SecondPageCoverDocumentID", "Sort" },
                values: new object[,]
                {
                    { 3, null, null, new Guid("e3b1e3a1-4d79-454d-8b1f-6c9e24e290b2"), null, null, "تاسیسات", null, true, new DateTime(2020, 12, 10, 18, 37, 59, 974, DateTimeKind.Local).AddTicks(9531), 1, null, null, 1 },
                    { 4, null, null, new Guid("587f4bc2-2b77-4dd3-9cc7-cbf23b7a677e"), null, null, "ماشین آلات صنعتی", null, true, new DateTime(2020, 12, 10, 18, 37, 59, 974, DateTimeKind.Local).AddTicks(9553), 1, null, null, 2 },
                    { 5, null, null, new Guid("83d56899-6f92-41df-b960-f58f1de9dd4b"), null, null, "تامین کالا", null, true, new DateTime(2020, 12, 10, 18, 37, 59, 974, DateTimeKind.Local).AddTicks(9563), 1, null, null, 3 },
                    { 6, null, null, new Guid("09cc4f35-644d-414b-8663-d386d09e828e"), null, null, "ساخت و ساز", null, true, new DateTime(2020, 12, 10, 18, 37, 59, 974, DateTimeKind.Local).AddTicks(9572), 1, null, null, 4 },
                    { 7, null, null, new Guid("e05f8278-e6dd-4167-b6d3-cca47bb0370c"), null, null, "تعمیرات", null, true, new DateTime(2020, 12, 10, 18, 37, 59, 974, DateTimeKind.Local).AddTicks(9581), 1, null, null, 5 },
                    { 8, null, null, new Guid("3a084152-86c5-4ac2-b033-c0779d8b8340"), null, null, "خدمات", null, true, new DateTime(2020, 12, 10, 18, 37, 59, 974, DateTimeKind.Local).AddTicks(9591), 1, null, null, 6 },
                    { 9, null, null, new Guid("a153fab9-37f2-4c2a-88b7-42171de1dd23"), null, null, "زیرساخت", null, true, new DateTime(2020, 12, 10, 18, 37, 59, 974, DateTimeKind.Local).AddTicks(9600), 1, null, null, 7 },
                    { 10, null, null, new Guid("0c154bf9-93e5-453b-8821-551eaac27567"), null, null, "حمل و نقل", null, true, new DateTime(2020, 12, 10, 18, 37, 59, 974, DateTimeKind.Local).AddTicks(9609), 1, null, null, 8 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 819, new Guid("702a88b2-90b2-4885-8945-a6c14bcc5c76"), "شربيان", 22 },
                    { 818, new Guid("a511c47e-d0f5-41a0-8159-95de42914e7e"), "شبستر", 22 },
                    { 817, new Guid("b195ffc0-1b20-4991-88cb-14b661b0f17a"), "سيه رود", 22 },
                    { 816, new Guid("fdd2a980-b266-482e-85f7-ac891e8d3041"), "سيس", 22 },
                    { 815, new Guid("3e35364c-d84e-4356-b42a-8a25bdac2070"), "سردرود", 22 },
                    { 814, new Guid("967c4342-77bf-4438-97dd-943851911480"), "سراب", 22 },
                    { 813, new Guid("10bafb18-9960-41e2-b79a-464d277ecb7d"), "زنوز", 22 },
                    { 812, new Guid("cb076b5f-83dc-4daf-b004-f911d92d479f"), "زرنق", 22 },
                    { 808, new Guid("c3910cc2-cb94-443d-ad15-e84c18f9d0c3"), "خسروشاه", 22 },
                    { 810, new Guid("35031c8a-9c91-449a-a73b-05bbaac5b4ad"), "خواجه", 22 },
                    { 809, new Guid("24a099b6-e8de-47f0-bef0-ddda6d02e317"), "خمارلو", 22 },
                    { 820, new Guid("29922771-c958-425a-a17c-d2fc020b212f"), "شرفخانه", 22 },
                    { 807, new Guid("edd10461-1cf8-45b6-8cbe-25f0d3a23063"), "خداجو", 22 },
                    { 806, new Guid("0ec45b56-8228-4791-9283-57b1ae46533f"), "خامنه", 22 },
                    { 805, new Guid("fe0e4abc-2518-4934-a27f-b5a28ef7fc2c"), "خاروانا", 22 },
                    { 804, new Guid("48f007a3-c2a0-49e3-ad40-776e00fd7dde"), "جوان قلعه", 22 },
                    { 811, new Guid("17f8afbf-2784-49ce-b22b-fe7e36d1f389"), "دوزدوزان", 22 },
                    { 821, new Guid("4d381d58-5032-40e4-946d-4b013ca73a8b"), "شند آباد", 22 },
                    { 825, new Guid("37cbf1fb-8d31-4681-b24e-f99c892d6ac8"), "قره آغاج", 22 },
                    { 823, new Guid("e66e2ff0-8587-48b4-a185-897a1ce2c57c"), "صوفيان", 22 },
                    { 839, new Guid("de96689f-5d25-46df-b289-9a72895dccdc"), "وايقان", 22 },
                    { 838, new Guid("34763b94-7175-4310-8eb8-19937a82799f"), "هوراند", 22 },
                    { 837, new Guid("c5123915-3508-4295-8878-39ea0e53ec73"), "هشترود", 22 },
                    { 836, new Guid("2273ce7a-8047-460c-9675-2c39c32ebf74"), "هريس", 22 },
                    { 835, new Guid("5384105e-726d-40d8-a04f-9fa053922332"), "هاديشهر", 22 },
                    { 834, new Guid("b91b4af9-2ca7-4481-9b01-8dbcf786203d"), "نظرکهريزي", 22 },
                    { 833, new Guid("2ce05c42-5cb4-4123-bb3a-ecec6f7ab821"), "ميانه", 22 },
                    { 822, new Guid("352cccbf-40b2-4cba-bb61-dbc8cb696fa7"), "شهر جديد سهند", 22 },
                    { 832, new Guid("e264e142-0fde-450b-bfe6-816f85548211"), "مهربان", 22 },
                    { 830, new Guid("01a68f5c-01e8-4cd0-b292-b66c474c240e"), "ملکان", 22 },
                    { 829, new Guid("f94ec8cf-8748-4a73-b9e8-a553a8d50d45"), "مرند", 22 },
                    { 828, new Guid("a6714574-a035-46a5-9394-d397abaa771a"), "مراغه", 22 },
                    { 827, new Guid("c058d1b0-4a22-429f-9aea-8488cbf2fa08"), "مبارک شهر", 22 },
                    { 826, new Guid("3a14d026-ff6c-461e-941c-edcaeed845d4"), "ليلان", 22 },
                    { 803, new Guid("7001de78-1e43-411b-95b8-f91ca1512525"), "جلفا", 22 },
                    { 824, new Guid("c2f31abe-ed93-4289-8583-479702cdd393"), "عجب شير", 22 },
                    { 831, new Guid("2ee7c783-93fa-4fea-9608-c677edaa5a53"), "ممقان", 22 },
                    { 802, new Guid("b5a32fe0-4388-434d-917a-9b29aa4307f5"), "تيکمه داش", 22 },
                    { 798, new Guid("61ca1ac6-2b1f-4cf5-a6af-4be09c1a6852"), "ترک", 22 },
                    { 800, new Guid("69bf23ca-0d44-4902-886a-10d20128670a"), "تسوج", 22 },
                    { 779, new Guid("1ae2ecf9-f0b8-4ab4-b754-910610dbe6eb"), "پرديس", 21 },
                    { 778, new Guid("bfae4bbd-5f83-43bd-bc55-4ddb9e3ebf3c"), "پاکدشت", 21 },
                    { 777, new Guid("bf8246ca-1c9b-4219-880a-c9016d3f605d"), "ورامين", 21 },
                    { 776, new Guid("61b67384-bb3e-49d3-a5d4-0eb100c38e84"), "وحيديه", 21 },
                    { 775, new Guid("290a930b-0c43-4a81-9d1b-395889c3d5fd"), "نصيرشهر", 21 },
                    { 774, new Guid("95c23782-67b6-4c0b-9a56-a0afda7cae3f"), "نسيم شهر", 21 },
                    { 773, new Guid("7d2a3cf0-428b-4362-beb7-4de1b9ce8193"), "ملارد", 21 },
                    { 780, new Guid("2ef16aea-6d86-4c78-a0dc-974b4040043b"), "پيشوا", 21 },
                    { 772, new Guid("3db12005-a0f6-434c-b559-50534e73b599"), "لواسان", 21 },
                    { 770, new Guid("9cf1f1ed-3f4f-463f-8615-35ec6bcdfc83"), "قدس", 21 },
                    { 769, new Guid("cc993077-4117-4518-98ea-c3300c2dc7eb"), "فيروزکوه", 21 },
                    { 768, new Guid("43e15ad4-b4ae-4396-ac39-9895c800d2b3"), "فشم", 21 },
                    { 767, new Guid("e6021517-9915-4bc8-8b06-54866cacc8fb"), "فرون آباد", 21 },
                    { 766, new Guid("b2423ff2-e661-474b-aa3a-a07411c46276"), "فردوسيه", 21 },
                    { 765, new Guid("7ab69b60-ab18-4fdc-987e-6f4f871615a8"), "صفادشت", 21 },
                    { 764, new Guid("51b6b71a-400b-4c9c-9626-869ca4f606cb"), "صبا شهر", 21 },
                    { 771, new Guid("29a51b06-80e6-4f40-a576-747398049c73"), "قرچک", 21 },
                    { 801, new Guid("6ff38b64-0b8a-44e2-a765-4f4da2a4506a"), "تيمورلو", 22 },
                    { 781, new Guid("8e1efb31-b53f-4808-9063-688f122595fa"), "چهاردانگه", 21 },
                    { 783, new Guid("d58504f6-00f5-4b96-b80d-12902da48a89"), "کيلان", 21 },
                    { 799, new Guid("57b3c4b4-e60c-44cb-862f-b1457cde9049"), "ترکمانچاي", 22 },
                    { 840, new Guid("3a52bf3d-bc9d-477d-a84a-910c12b3c95f"), "ورزقان", 22 },
                    { 797, new Guid("c3b39382-2d45-48ad-a5e2-087c77ef999e"), "تبريز", 22 },
                    { 796, new Guid("00986e8c-e0f4-4210-b2ef-da9c8c9a2fd7"), "بناب مرند", 22 },
                    { 795, new Guid("7afb94bf-c499-4260-baba-724104f669c1"), "بناب", 22 },
                    { 794, new Guid("c6fbbbfc-c482-4e82-9218-e0cfb1109be3"), "بستان آباد", 22 },
                    { 793, new Guid("57ac29e4-1dfd-4b00-903f-9a97df2a0f08"), "بخشايش", 22 },
                    { 782, new Guid("7b26f674-03e7-4b5c-80bd-c21bb0fa6c78"), "کهريزک", 21 },
                    { 792, new Guid("7b95f190-407d-4fa3-a6d0-4438f2d0d851"), "باسمنج", 22 },
                    { 790, new Guid("4b7b79fe-6b9b-4ddb-8a35-ee822b039126"), "اهر", 22 },
                    { 789, new Guid("e440989b-11cf-49a6-8196-5c7188e371dc"), "اسکو", 22 },
                    { 788, new Guid("0d011905-c722-4f15-967d-33b221a84a73"), "آچاچي", 22 },
                    { 787, new Guid("7e9f2eac-c44b-4acb-b225-2c5b1d26806f"), "آقکند", 22 },
                    { 786, new Guid("9605a607-e3d8-4443-95db-bd574d050ee4"), "آذرشهر", 22 },
                    { 785, new Guid("722bc313-968b-45b1-acf7-ff1e6448aceb"), "آبش احمد", 22 },
                    { 784, new Guid("fee4ee6e-0edd-46a2-9975-24cd2966259b"), "گلستان", 21 },
                    { 791, new Guid("2693d56e-a88a-4bb7-b0a5-46b6e977061f"), "ايلخچي", 22 },
                    { 841, new Guid("bd9bb862-e6c6-4b14-bddf-b8b1d06bf357"), "يامچي", 22 },
                    { 845, new Guid("bb6dda04-117e-43db-b745-708513f90cf5"), "کوزه کنان", 22 },
                    { 843, new Guid("351ad52d-b06c-4b95-b053-02980f66dff1"), "کلوانق", 22 },
                    { 899, new Guid("7ee3a7d4-05c2-49c0-a82e-c4a5cf54e794"), "سورمق", 23 },
                    { 898, new Guid("6576a401-de7d-404b-aa56-66ae4a1b28bf"), "سلطان شهر", 23 },
                    { 897, new Guid("d8fbd35e-46c4-4880-935d-32ceeda50ed6"), "سعادت شهر", 23 },
                    { 896, new Guid("b07641b0-bb5f-4191-a270-28bb4672dff6"), "سروستان", 23 },
                    { 895, new Guid("eed7576c-1beb-4789-98e1-104e7451f432"), "سده", 23 },
                    { 894, new Guid("538d61a7-e4ab-4d50-953f-2a341681ac60"), "زرقان", 23 },
                    { 893, new Guid("abecf375-7f1e-4829-8210-4282810102fc"), "زاهد شهر", 23 },
                    { 900, new Guid("9578f2ad-d016-4a0a-8876-15efd2e12b2e"), "سيدان", 23 },
                    { 892, new Guid("e35b519b-7a15-4bae-bf92-d5f0904664af"), "رونيز", 23 },
                    { 890, new Guid("9e657703-2f9b-4ec2-84d6-5901e33da88a"), "دژکرد", 23 },
                    { 889, new Guid("cf64d4b6-52ed-4995-adcb-30344d5ca0e4"), "دوزه", 23 },
                    { 888, new Guid("5004449a-0152-4567-b217-c94578c96cbc"), "دوبرجي", 23 },
                    { 887, new Guid("74374bf9-6b7f-43d2-bdb5-4ce8c9de2519"), "دهرم", 23 },
                    { 886, new Guid("9a6b9088-6728-41c0-8a37-d41015393d31"), "دبيران", 23 },
                    { 885, new Guid("f52259e2-52f0-4969-92fb-bba392551ade"), "داريان", 23 },
                    { 884, new Guid("d81015b2-dbd0-4017-8a50-ca678a4ad849"), "داراب", 23 },
                    { 891, new Guid("2e1fe465-6d65-4590-b03e-466ff93f7dda"), "رامجرد", 23 },
                    { 883, new Guid("28c822ba-3722-4db9-bf6a-859d410a75a9"), "خومه زار", 23 },
                    { 901, new Guid("282ef173-6c76-4d1c-b171-c67191f57d4a"), "ششده", 23 },
                    { 903, new Guid("dd9cefa2-27ee-4926-91c6-a700d4b3e28f"), "شهر پير", 23 },
                    { 919, new Guid("30211e14-49e8-42c4-8d06-b210b73eb5d2"), "لار", 23 },
                    { 918, new Guid("642b3c54-fb12-4896-9143-1c67665a0782"), "قير", 23 },
                    { 917, new Guid("c80bd261-6f23-4fc9-bf20-c23b77e2b223"), "قطرويه", 23 },
                    { 916, new Guid("b04a6014-e8e5-4f11-a7dc-6312c5f409cc"), "قطب آباد", 23 },
                    { 915, new Guid("1e3f86a9-7908-4e9d-8dab-c490565749a2"), "قره بلاغ", 23 },
                    { 914, new Guid("f4e3cd38-3260-4cd9-82c1-fee6ab25dcb2"), "قادرآباد", 23 },
                    { 913, new Guid("3c7ba77e-80a7-4c6a-aeba-979fc62b7bfa"), "قائميه", 23 },
                    { 902, new Guid("735d80ac-3e19-4882-a611-9321243b8f64"), "شهر جديد صدرا", 23 },
                    { 912, new Guid("e5361eb8-e5b3-4ea4-b5f0-54c69539ddfd"), "فيروزآباد", 23 },
                    { 910, new Guid("1ecc8d97-62f0-4d11-bb4d-37c6f8565b0f"), "فراشبند", 23 },
                    { 909, new Guid("92c65e26-5cef-42fe-a6cb-aa0974f35536"), "فدامي", 23 },
                    { 908, new Guid("05941644-3838-44ed-bcd5-549d5ed546cb"), "عماد ده", 23 },
                    { 907, new Guid("b0bee652-6b33-419a-a193-e7601aebd288"), "علامرودشت", 23 },
                    { 906, new Guid("0e8c0499-8e37-46f1-9587-caa70e44c1b3"), "صفا شهر", 23 },
                    { 905, new Guid("db8ac007-3c6b-4469-bdad-c7422c28e6b0"), "صغاد", 23 },
                    { 904, new Guid("81115212-e530-4fdc-a995-9d87e2155570"), "شيراز", 23 },
                    { 911, new Guid("7d8f74ab-6c73-44f4-9891-c8dc39eeb4cd"), "فسا", 23 },
                    { 842, new Guid("27fd40d1-7ce4-4568-8f24-4ba209b83bcf"), "کشکسراي", 22 },
                    { 882, new Guid("1c555283-cf8a-414a-a502-2f04dc9b8313"), "خوزي", 23 },
                    { 880, new Guid("c8b9f72a-f5c3-4736-b050-dcdc834155a5"), "خنج", 23 },
                    { 859, new Guid("25a78209-9987-462e-b0fa-84d4ff9dbbb7"), "ايج", 23 },
                    { 858, new Guid("33f259de-ad55-4958-b609-786f7972f88b"), "اوز", 23 },
                    { 857, new Guid("277e7b75-aa0f-4f03-b165-92675b61afc5"), "اهل", 23 },
                    { 856, new Guid("1bb93965-6407-4caf-88ba-f7bcdca2dce6"), "امام شهر", 23 },
                    { 855, new Guid("163751f9-6764-444e-bb04-8177861905e3"), "اقليد", 23 },
                    { 854, new Guid("6f8a4e0e-2bc2-42da-86f0-29763ec40405"), "افزر", 23 },
                    { 853, new Guid("f82af1c5-a122-4da6-b9af-4174f5be8ef0"), "اشکنان", 23 },
                    { 860, new Guid("c6c548ff-b87b-4a0e-8760-a2f62651d1b9"), "ايزد خواست", 23 },
                    { 852, new Guid("f82abae6-8499-44cf-8789-54e89b5eac71"), "اسير", 23 },
                    { 850, new Guid("4f839867-a46e-4067-a726-422505dcce2c"), "ارسنجان", 23 },
                    { 849, new Guid("be1700d7-181a-483c-91e4-f0c40ecbf711"), "اردکان", 23 },
                    { 848, new Guid("d14f0ecc-746d-4c76-8d65-e3dc537edc07"), "آباده طشک", 23 },
                    { 847, new Guid("5cd570c6-3188-4b71-9ef6-6509398bc252"), "آباده", 23 },
                    { 846, new Guid("686c4691-ffa2-4b7e-af7f-c3377b64ea3c"), "گوگان", 22 },
                    { 763, new Guid("0ed0d0f1-4118-490e-bf3e-1a37ce2d71c3"), "صالحيه", 21 },
                    { 844, new Guid("9e9bedf7-3900-4839-b4d7-0befc058830b"), "کليبر", 22 },
                    { 851, new Guid("eff6932b-c89d-4ffc-b38d-60121e72d0a3"), "استهبان", 23 },
                    { 881, new Guid("f6ec9422-4d8a-4471-a346-5e46b2536bfd"), "خور", 23 },
                    { 861, new Guid("47c12973-53fd-4add-a7f8-d837aaddf64d"), "باب انار", 23 },
                    { 863, new Guid("70c510ce-8abc-4ced-8ba4-20c9f2fc1e69"), "بالاده", 23 },
                    { 879, new Guid("d88df4d7-3896-4c88-9f9a-f670aca7f74c"), "خشت", 23 },
                    { 878, new Guid("7b04ced0-65f1-467a-9d25-c9f7224fbf92"), "خرامه", 23 },
                    { 877, new Guid("5a6535ee-4d59-4b82-983f-d6f09e30ed04"), "خاوران", 23 },
                    { 876, new Guid("33723745-71f2-4217-a522-fa64d3df602b"), "خانيمن", 23 },
                    { 875, new Guid("005fdb15-0d67-410d-9224-45851ab4fc43"), "خانه زنيان", 23 },
                    { 874, new Guid("dc1c21ff-38b3-4ec2-b625-d519bb27eebc"), "حسن آباد", 23 },
                    { 873, new Guid("aa8e60c3-8ef5-4fdd-8d43-38e6a1b8b033"), "حسامي", 23 },
                    { 862, new Guid("fb84daf2-6cd3-416a-9189-6bedaf97de66"), "بابامنير", 23 },
                    { 872, new Guid("5375c754-92e6-484a-8049-d214b17fc3b8"), "حاجي آباد", 23 },
                    { 870, new Guid("399a1866-0f23-4521-abe9-c0c49627f673"), "جهرم", 23 },
                    { 869, new Guid("aeb3d0b2-664c-4478-88dd-f71eb999bc78"), "جنت شهر", 23 },
                    { 868, new Guid("9b04ed89-b0bb-43cd-94c8-1dc21c8ac9fc"), "بيضا", 23 },
                    { 867, new Guid("42dcc7e4-310e-46a7-9d8d-d8589389fd9b"), "بيرم", 23 },
                    { 866, new Guid("8cb66596-57d3-4179-b4f9-a76722df0600"), "بوانات", 23 },
                    { 865, new Guid("3788b3e0-8a31-4080-8e53-0ee0b5475ecd"), "بهمن", 23 },
                    { 864, new Guid("757ea931-36b3-4b72-b5c3-a65bbd4a526b"), "بنارويه", 23 },
                    { 871, new Guid("97b829f4-ece2-4fbe-9b7c-093af00f3017"), "جويم", 23 },
                    { 762, new Guid("e84c3aa2-6595-49ba-813d-dd370f626d93"), "شهريار", 21 },
                    { 758, new Guid("114387b2-959f-49da-b777-f6cf370d3e54"), "شاهدشهر", 21 },
                    { 760, new Guid("d118256b-fd71-4144-98cf-1659d31a692f"), "شمشک", 21 },
                    { 658, new Guid("187c81d2-f193-4ba6-9b8f-5255a79dc159"), "زيباشهر", 19 },
                    { 657, new Guid("23a12c30-2ae1-469b-bdda-6de2ea456ba7"), "زيار", 19 },
                    { 656, new Guid("a1bf64ee-5d3e-49d2-9d0d-071b7787fbd7"), "زواره", 19 },
                    { 655, new Guid("92926101-a8af-45a2-aa1d-7b5d9b324781"), "زرين شهر", 19 },
                    { 654, new Guid("b2095604-452c-426d-b2ff-1a163f1d5247"), "زاينده رود", 19 },
                    { 653, new Guid("1ec4193d-9caf-4853-9bff-cdada36b2907"), "زازران", 19 },
                    { 652, new Guid("1faff28a-e608-48cf-8d06-45d3467a7ba4"), "رضوانشهر", 19 },
                    { 659, new Guid("ec351438-4719-4d9c-8c67-7be05eea4929"), "سده لنجان", 19 },
                    { 651, new Guid("3ef7136a-f1a0-444f-a6a2-47fe1ed0ec59"), "رزوه", 19 },
                    { 649, new Guid("e4b9ad8e-2101-4222-922b-e15dc99392c1"), "دولت آباد", 19 },
                    { 648, new Guid("2c6cdb24-b52e-455e-86b1-a202228b61b9"), "دهق", 19 },
                    { 647, new Guid("04861d45-b99c-479e-8a1e-07b19e7fde0c"), "دهاقان", 19 },
                    { 646, new Guid("b7e393b1-566f-4760-845d-e298d4530bd0"), "دستگرد", 19 },
                    { 645, new Guid("84c15103-b184-406b-8edc-e6f088bb37c5"), "درچه پياز", 19 },
                    { 644, new Guid("5fc27426-aa15-4688-9f91-538914b78eb9"), "دامنه", 19 },
                    { 643, new Guid("764492cd-31c5-4e5f-8a00-2c70bf56edf8"), "داران", 19 },
                    { 650, new Guid("2d9e51f5-c656-40fe-807e-510362772a0c"), "ديزيچه", 19 },
                    { 642, new Guid("8a12e3e0-c815-4f52-9e18-100aa3020b01"), "خورزوق", 19 },
                    { 660, new Guid("c078c1a2-9488-4a8d-8ae4-e5bbf40211e3"), "سفيد شهر", 19 },
                    { 662, new Guid("ea3d6c89-a33a-473b-afc8-b148839be57b"), "سين", 19 },
                    { 678, new Guid("997e0684-ec08-458a-81ee-02013e502154"), "لاي بيد", 19 },
                    { 677, new Guid("02a79dc2-e58f-4945-8933-5f039663174b"), "قهدريجان", 19 },
                    { 676, new Guid("5a3a2c87-5346-4d06-8b43-b3692c5742a4"), "قهجاورستان", 19 },
                    { 675, new Guid("57728763-2f53-4504-b608-19d5539d360d"), "قمصر", 19 },
                    { 674, new Guid("7bfb53d7-0db0-46b7-8d6c-426c15ba75c6"), "فولاد شهر", 19 },
                    { 673, new Guid("a4bcfb0d-c6a2-420d-b34c-7f929296a1e7"), "فلاورجان", 19 },
                    { 672, new Guid("48e3b583-4078-4caf-97ea-d83329c3153e"), "فريدونشهر", 19 },
                    { 661, new Guid("3bb3c0e9-7a9d-49f2-8166-4ac286830aaf"), "سميرم", 19 },
                    { 671, new Guid("dae96030-3a2d-4141-a80d-57a5d7eb2c9c"), "فرخي", 19 },
                    { 669, new Guid("85414fd7-8728-44b8-9887-00e9fadc8a15"), "عسگران", 19 },
                    { 668, new Guid("9912a483-2439-44d5-8c32-5b41f0cb9962"), "طرق رود", 19 },
                    { 667, new Guid("e047fd99-ad25-4bea-8480-ca44358f952f"), "طالخونچه", 19 },
                    { 666, new Guid("a51cf1b3-d60e-4db3-ba74-94f237544e2a"), "شهرضا", 19 },
                    { 665, new Guid("458f3ad8-67ff-41da-a899-75e9ad8114b0"), "شاپورآباد", 19 },
                    { 664, new Guid("b3c06c09-2a44-4cc6-910b-44317df896b3"), "شاهين شهر", 19 },
                    { 663, new Guid("99efca76-f25c-4a77-a183-8f908a80c90a"), "سگزي", 19 },
                    { 670, new Guid("f6dd6427-69ff-42f1-a2b7-582a6c53aa2a"), "علويچه", 19 },
                    { 679, new Guid("1eb5d096-caf3-4b91-80a0-f7a4432e4a99"), "مبارکه", 19 },
                    { 641, new Guid("a1b93efc-0c10-4239-afea-4a1961f0e538"), "خور", 19 },
                    { 639, new Guid("678b243b-82ee-4b91-9fa3-02c9d7136372"), "خميني شهر", 19 },
                    { 618, new Guid("64c5f7a5-2cab-47cc-90e8-5b3c4535e872"), "انارک", 19 },
                    { 617, new Guid("77016687-5334-4d70-a99c-e24d35863136"), "افوس", 19 },
                    { 616, new Guid("1f5f8d97-3648-4a72-9d58-096952c166da"), "اصفهان", 19 },
                    { 615, new Guid("cfd77bf3-4d04-416e-9bff-a2c0746c8bf7"), "اصغرآباد", 19 },
                    { 614, new Guid("8d7bedc8-e142-4799-ac86-5b5ab892890f"), "اردستان", 19 },
                    { 613, new Guid("cecdf53b-6ad3-4c1d-914b-0f95e7c28de9"), "ابوزيد آباد", 19 },
                    { 612, new Guid("0b6f3f07-2f80-4ef1-b71d-5d4c0c6f6e58"), "ابريشم", 19 },
                    { 619, new Guid("2a68da72-7a25-464b-8944-a64d4fca3cf1"), "ايمانشهر", 19 },
                    { 611, new Guid("3801a46f-7a3b-4a57-bc34-7380cc23c907"), "آران و بيدگل", 19 },
                    { 609, new Guid("f61d616c-5911-4eb4-922b-85f3141182ca"), "گرمي", 18 },
                    { 608, new Guid("1c652c1e-5dd2-4470-a8e9-1648f0d333dc"), "کورائيم", 18 },
                    { 607, new Guid("7afc6522-16ab-4315-bf55-ba1bd626b086"), "کلور", 18 },
                    { 606, new Guid("a52b5e31-d69a-4d36-bcc8-b9c6618d42c8"), "پارس آباد", 18 },
                    { 605, new Guid("29a8c434-489d-46bc-9bbd-40c001f78746"), "هير", 18 },
                    { 604, new Guid("c632e6d4-703c-44b3-86c1-7929033c8e55"), "هشتجين", 18 },
                    { 603, new Guid("8fdacbfc-d6dd-46a0-9ebd-02529ddc5f81"), "نير", 18 },
                    { 610, new Guid("61f9e4b8-63ce-4d8f-a5df-b4e89df58acd"), "گيوي", 18 },
                    { 640, new Guid("9f554ce4-7f64-475f-8afc-673a542724ae"), "خوانسار", 19 },
                    { 620, new Guid("f753d851-dfe8-489b-8993-50239cb4733c"), "اژيه", 19 },
                    { 622, new Guid("7670d6a3-fce9-47de-a304-65722fca0fab"), "باغ بهادران", 19 },
                    { 638, new Guid("db9147ce-519e-47de-83fb-f123f2ec26bd"), "خالد آباد", 19 },
                    { 637, new Guid("f5f9fd09-913a-4ae2-98a8-628c175179e7"), "حنا", 19 },
                    { 636, new Guid("01686359-9313-4a31-af64-1d7441a7a1df"), "حسن آباد", 19 },
                    { 635, new Guid("4d230712-2506-43ec-8c65-03499f53cfa3"), "حبيب آباد", 19 },
                    { 634, new Guid("36e098a1-73f1-4b28-896e-c0a716e71801"), "جوشقان قالي", 19 },
                    { 633, new Guid("77c981b6-03c8-401b-ab61-42f0eaebbef1"), "جوزدان", 19 },
                    { 632, new Guid("8356dd76-230b-417f-801d-d01fa5a1dfea"), "جندق", 19 },
                    { 621, new Guid("76b6889c-2d11-451d-80d8-19edd0cc3d03"), "بادرود", 19 },
                    { 631, new Guid("323589e7-bf72-4d4e-983f-56846bdd8293"), "تيران", 19 },
                    { 629, new Guid("13e0aa64-cc55-4de9-85c5-fea9b4e979ff"), "بوئين مياندشت", 19 },
                    { 628, new Guid("ce8fca8b-4a06-41e7-ad7c-8ecb106eea91"), "بهارستان", 19 },
                    { 627, new Guid("fbc3bd32-0637-4961-9c1c-ac070d63bb2f"), "بهاران شهر", 19 },
                    { 626, new Guid("d123f031-fced-4ae9-a990-f818ae78595b"), "برف انبار", 19 },
                    { 625, new Guid("bcfce4f1-5139-4291-a91e-b094659db79b"), "برزک", 19 },
                    { 624, new Guid("1075d55b-a78b-456b-9524-15bd864dcc30"), "بافران", 19 },
                    { 623, new Guid("edbb76ab-418f-4dc3-95d7-c9cb10eb0406"), "باغشاد", 19 },
                    { 630, new Guid("c6a77534-eccc-4763-a3b9-3483aaa96db9"), "تودشک", 19 },
                    { 680, new Guid("5a9d35ca-c792-414b-9a47-8d88968cd5a2"), "محمد آباد", 19 },
                    { 681, new Guid("a9a566f9-f352-472f-bce4-c02aef9259af"), "مشکات", 19 },
                    { 682, new Guid("38c875af-9ad2-4de5-b82d-f65ef8ffeaa6"), "منظريه", 19 },
                    { 739, new Guid("9bb14a67-1288-4b5e-b55f-7a12e1cc4017"), "ميمه", 20 },
                    { 738, new Guid("f6e65af2-d458-437e-80ad-121ca06be5ff"), "موسيان", 20 },
                    { 737, new Guid("ddfd09bf-63f4-4470-9be8-902b9d507044"), "مورموري", 20 },
                    { 736, new Guid("9379afae-4d4b-42e2-a469-c5c95bc5c5e3"), "مهران", 20 },
                    { 735, new Guid("63e1f7ef-20d7-4283-9e54-11fa8e042fdc"), "مهر", 20 },
                    { 734, new Guid("9b14b08b-614f-47e0-9509-1d664e97dc53"), "ماژين", 20 },
                    { 733, new Guid("dce32e9e-555b-4c9c-b1cf-c2d13800cd51"), "لومار", 20 },
                    { 740, new Guid("33a8d541-cf37-49a8-a075-aaeba2e8d18b"), "پهله", 20 },
                    { 732, new Guid("e229e3ae-121c-4903-93ce-48d6a2d742e3"), "صالح آباد", 20 },
                    { 730, new Guid("a4312313-fe88-4ee4-a665-926e684d185d"), "سرابله", 20 },
                    { 729, new Guid("41070140-7e36-4a8f-8dd8-88b361679950"), "سراب باغ", 20 },
                    { 728, new Guid("e77d3701-217d-4e0d-98de-60825e2da87e"), "زرنه", 20 },
                    { 727, new Guid("b3aaf31d-c8e4-4985-8960-ede33bd47202"), "دهلران", 20 },
                    { 726, new Guid("3ae9a88a-ce95-47a2-a705-5017abb8197c"), "دلگشا", 20 },
                    { 725, new Guid("b544a402-2262-4c5f-a909-84787369c332"), "دره شهر", 20 },
                    { 724, new Guid("fb4411ab-cefc-4a02-a929-8c0e2bff9040"), "توحيد", 20 },
                    { 731, new Guid("28f1cbe9-7f2d-46aa-9124-7741c7ba71dc"), "شباب", 20 },
                    { 723, new Guid("443f8c15-52fd-4607-9c28-89b4b9bf6fdc"), "بلاوه", 20 },
                    { 741, new Guid("1b8e99a9-87f8-42d2-a4f0-c6cf24e940f3"), "چوار", 20 },
                    { 743, new Guid("b44b2a0c-76aa-45d0-9bf5-fbfc053d40ba"), "آبعلي", 21 },
                    { 759, new Guid("55bc6ac0-bdbd-43d3-b2ca-6ed83ce83059"), "شريف آباد", 21 },
                    { 920, new Guid("6626aac2-193d-4514-b1df-a8f9b6fe1ab5"), "لامرد", 23 },
                    { 757, new Guid("e922ce4a-a422-43a6-af53-efb20077ad51"), "ري", 21 },
                    { 756, new Guid("820ad7cc-cef8-4087-b540-e99c23989a2a"), "رودهن", 21 },
                    { 755, new Guid("153fcabf-30e0-4252-b456-edf9fafb3f27"), "رباط کريم", 21 },
                    { 754, new Guid("a0f5d3f4-1290-4b48-a15e-204fd5111eb5"), "دماوند", 21 },
                    { 753, new Guid("3ea8b858-8ae6-40df-9a9e-7f7e93c16db6"), "حسن آباد", 21 },
                    { 742, new Guid("f03abfd3-1b7d-45ee-9be2-144e5274bff9"), "آبسرد", 21 },
                    { 752, new Guid("8a602905-4072-471f-bed6-0104eebb2257"), "جواد آباد", 21 },
                    { 750, new Guid("c97831ef-c3d4-45cc-8634-ae3d1e52c926"), "تجريش", 21 },
                    { 749, new Guid("62e7bd22-0a9d-47df-a36a-5a8708480217"), "بومهن", 21 },
                    { 748, new Guid("55e6c255-ac8c-45c3-809c-b3c6b6bc8900"), "باقرشهر", 21 },
                    { 747, new Guid("5ab344f8-b998-4bcb-9da9-fd9558429f69"), "باغستان", 21 },
                    { 746, new Guid("8e06d725-4619-4884-85a9-5b294398e841"), "انديشه", 21 },
                    { 745, new Guid("c48c9f87-18de-4237-bcc8-9020b093b2ed"), "اسلامشهر", 21 },
                    { 744, new Guid("4ba35b72-a5e7-4647-a661-e1778d010609"), "ارجمند", 21 },
                    { 751, new Guid("ff30665f-1b01-4cee-ad18-4c5a3d39ade2"), "تهران", 21 },
                    { 722, new Guid("69b420b7-8083-41be-a2c2-efc904bbdd18"), "بدره", 20 },
                    { 721, new Guid("f8034d8f-c4b6-429a-a702-2075d2af8363"), "ايوان", 20 },
                    { 720, new Guid("98667865-ce3b-49d5-a47f-4583a8750aeb"), "ايلام", 20 },
                    { 698, new Guid("4c2969da-8636-4e9b-8428-8ece58a02f92"), "چادگان", 19 },
                    { 697, new Guid("ea6bb669-4d81-4815-9fab-67e54091abba"), "پير بکران", 19 },
                    { 696, new Guid("7f41cd0c-0917-418a-a181-db378842bdfe"), "ونک", 19 },
                    { 695, new Guid("8a43dd32-9928-4993-bbfc-8338c4c76fb8"), "وزوان", 19 },
                    { 694, new Guid("966a6497-8b5b-4778-abfb-39267a1c7f0b"), "ورنامخواست", 19 },
                    { 693, new Guid("2a655c13-0584-488f-bfd2-f432dea963b7"), "ورزنه", 19 },
                    { 692, new Guid("2538ef72-cdec-4e31-b297-7b6c6e5f0cd0"), "هرند", 19 },
                    { 699, new Guid("ed257cd0-0f7d-4622-8b9c-2eae598fa6bb"), "چرمهين", 19 },
                    { 691, new Guid("382afa04-c71a-423d-a05e-2f3e884a4fd3"), "نيک آباد", 19 },
                    { 689, new Guid("dfe552f2-4e81-4dba-8f41-16caf77da419"), "نوش آباد", 19 },
                    { 688, new Guid("b6d3229d-eee8-43e9-9f25-4467fa5a07aa"), "نطنز", 19 },
                    { 687, new Guid("ce66ec03-b102-4ebc-8120-2f36bb4f3523"), "نصرآباد", 19 },
                    { 686, new Guid("6ac24e3d-fdbd-4ef3-b0f4-c51b2e80e8ba"), "نجف آباد", 19 },
                    { 685, new Guid("fc80a2aa-f801-4af6-807c-4b4a7a23a9fb"), "نائين", 19 },
                    { 684, new Guid("1196d637-7e80-4c5c-8743-8bd45da087a7"), "ميمه", 19 },
                    { 683, new Guid("28e1a725-ba9c-44c1-9b40-55ba5df86cda"), "مهاباد", 19 },
                    { 690, new Guid("b30bd1fc-678c-4336-9abd-5db2251b1d08"), "نياسر", 19 },
                    { 700, new Guid("67147b76-c349-43f3-a058-bba568fb3dc3"), "چمگردان", 19 },
                    { 701, new Guid("fb7bc3bd-b5d9-4e3c-bf4a-15d1b2872f41"), "کاشان", 19 },
                    { 702, new Guid("1c8df431-e073-4e0f-91f4-80210168bc5e"), "کامو و چوگان", 19 },
                    { 719, new Guid("10a479e4-1df2-40de-8339-ece9f4913c1a"), "ارکواز", 20 },
                    { 718, new Guid("425706ed-c695-4288-ab54-1fc4c52c46d1"), "آسمان آباد", 20 },
                    { 717, new Guid("4187c524-450c-410c-b68a-ed5f6f128e76"), "آبدانان", 20 },
                    { 716, new Guid("e24c5621-e87d-4d08-a1c2-e5b1ccddf797"), "گوگد", 19 },
                    { 715, new Guid("914e5b01-cf6a-477b-9e34-dc25ebc6cb6a"), "گلپايگان", 19 },
                    { 714, new Guid("de1af42e-94b2-4986-980f-353cf44900bb"), "گلشهر", 19 },
                    { 713, new Guid("7195620e-7813-4d80-95fe-20898ceb57cd"), "گلشن", 19 },
                    { 712, new Guid("35c2b6a1-58d0-4370-b548-ffa39504213e"), "گلدشت", 19 },
                    { 711, new Guid("c77f1533-74ae-43a8-b1b5-6aa0aa859f24"), "گز برخوار", 19 },
                    { 710, new Guid("2fbc2b64-b4c0-4bf6-bb1c-002aae748243"), "گرگاب", 19 },
                    { 709, new Guid("80e2b51a-66d3-4684-9a42-dc708456e3b1"), "کوهپايه", 19 },
                    { 708, new Guid("71180547-b23d-484f-a4a0-c7de14d40ceb"), "کوشک", 19 },
                    { 707, new Guid("ca04d05b-5323-46c4-b8ae-0ce20276b330"), "کهريزسنگ", 19 },
                    { 706, new Guid("54b18486-9598-4b68-b444-9b418906dcd1"), "کمه", 19 },
                    { 705, new Guid("350571df-5bea-4ad5-8424-7a8a62a993a2"), "کمشجه", 19 },
                    { 704, new Guid("133239f0-d806-43f1-ac09-44bfb8f97717"), "کليشاد و سودرجان", 19 },
                    { 703, new Guid("8fdf70f2-72ec-499e-ba7c-d9e898e68837"), "کرکوند", 19 },
                    { 761, new Guid("aae1f4e2-a8c7-4c38-82d5-777bedde5107"), "شهر جديد پرند", 21 },
                    { 921, new Guid("23e88397-9d78-431d-89b6-96949541f0f1"), "لطيفي", 23 },
                    { 925, new Guid("b1bd2356-19ca-4a2b-bc6a-2bea7bd375f5"), "مرودشت", 23 },
                    { 923, new Guid("b27382aa-1a42-440b-b1c7-38cf2b521916"), "مادرسليمان", 23 },
                    { 1140, new Guid("ceed89ae-0f34-419f-a737-72f5403f8cc2"), "بافت", 29 },
                    { 1139, new Guid("7368aac9-f174-4dc6-8a52-6af9758902c5"), "باغين", 29 },
                    { 1138, new Guid("46a589c7-f521-446d-a749-d04e96a8e335"), "اندوهجرد", 29 },
                    { 1137, new Guid("d7d3d495-bb8e-4782-b7ed-8c0be564112d"), "انار", 29 },
                    { 1136, new Guid("39828bfd-9fe9-4d7d-91a2-5f9702c0e2df"), "امين شهر", 29 },
                    { 1135, new Guid("47c4d35d-53c9-4a46-b303-3e3f2b16e1df"), "ارزوئيه", 29 },
                    { 1134, new Guid("5dbb8d58-b691-4488-93b9-1af26ec262c2"), "اختيار آباد", 29 },
                    { 1141, new Guid("4a4bd14e-182f-470c-b99f-c4fe10ece15d"), "بردسير", 29 },
                    { 1133, new Guid("40fafec7-83e7-40c9-8c95-4fb3f57d14c0"), "گيان", 28 },
                    { 1131, new Guid("cb599bf8-2091-4ed3-a495-94465cac31d2"), "کبودر آهنگ", 28 },
                    { 1130, new Guid("b9775608-4482-4c70-8faf-6138f15e1739"), "همدان", 28 },
                    { 1129, new Guid("bf5006e5-d697-4007-8016-5d13ff6698d5"), "نهاوند", 28 },
                    { 1128, new Guid("c1314a9a-f3e2-4717-8aa1-e1587af4376e"), "مهاجران", 28 },
                    { 1127, new Guid("e0998a17-5b0f-439a-8610-81711c0b1b71"), "ملاير", 28 },
                    { 1126, new Guid("387ab466-1623-470d-ab6d-1c0f45b6a00f"), "مريانج", 28 },
                    { 1125, new Guid("64da8112-3c8c-4109-9c28-14832bbedbb8"), "لالجين", 28 },
                    { 1132, new Guid("038fdf9f-b00c-4f89-b072-2451e9392b28"), "گل تپه", 28 },
                    { 1124, new Guid("d2ce7fd1-29a9-4a5c-b3e0-3ac4af6eda3d"), "قهاوند", 28 },
                    { 1142, new Guid("059a978d-0a1a-47bd-9a83-9a609440b730"), "بروات", 29 },
                    { 1144, new Guid("c5e17ef1-ab1e-4fe7-a2cc-de30ace72e6d"), "بلورد", 29 },
                    { 1160, new Guid("fe178676-ab4c-4ebb-83d9-6b3310640bd4"), "رابر", 29 },
                    { 1159, new Guid("1a9c5a03-7957-4654-95c0-51d000f555d8"), "دوساري", 29 },
                    { 1158, new Guid("6a232568-3cb1-4021-a981-457f97617ea5"), "دهج", 29 },
                    { 1157, new Guid("b87dee5c-5d68-42af-8b60-5dd71b8243e8"), "دشتکار", 29 },
                    { 1156, new Guid("f247e82d-a3b9-4b47-b476-28877beccac6"), "درب بهشت", 29 },
                    { 1155, new Guid("369a1077-c183-4ba5-87dc-e0d54bd08c82"), "خورسند", 29 },
                    { 1154, new Guid("b0a89ad2-b8aa-463f-baaf-c0f217cca68f"), "خواجوشهر", 29 },
                    { 1143, new Guid("6c76668e-1054-4459-b927-c1a618b4d9e5"), "بزنجان", 29 },
                    { 1153, new Guid("519f9066-b92f-4aa7-bdd8-e57180c0abc8"), "خانوک", 29 },
                    { 1151, new Guid("922be9a9-c556-4f8d-bd9c-f0b4c2e9003b"), "جيرفت", 29 },
                    { 1150, new Guid("8a79337d-9176-4412-adda-740e94e68999"), "جوپار", 29 },
                    { 1149, new Guid("95dfb371-f866-4305-b47a-85351859e3cf"), "جوزم", 29 },
                    { 1148, new Guid("3da4c3ab-3211-43b3-afce-3dc3d77b8246"), "جبالبارز", 29 },
                    { 1147, new Guid("286d773b-4315-4822-81d4-f2487e94c210"), "بهرمان", 29 },
                    { 1146, new Guid("c3072246-5c69-4f15-95e4-2818be0ee9f9"), "بم", 29 },
                    { 1145, new Guid("fb05d00e-d552-42f6-bc14-9bb2e289c207"), "بلوک", 29 },
                    { 1152, new Guid("b859f9d2-f05b-4596-a470-cfd6d6f4b36d"), "خاتون آباد", 29 },
                    { 1161, new Guid("c85b5090-5e80-44c9-a2da-a6368270ece4"), "راور", 29 },
                    { 1123, new Guid("25dc3158-0950-407f-b50a-02abe6dd1321"), "قروه در جزين", 28 },
                    { 1121, new Guid("c2b8f733-912f-4808-876e-35a80aba683b"), "فرسفج", 28 },
                    { 1100, new Guid("d0dab0c9-552d-40d6-be23-dd4ac7af4568"), "کلاچاي", 27 },
                    { 1099, new Guid("06d0c585-e458-4809-aec4-a2c75ea62130"), "چوبر", 27 },
                    { 1098, new Guid("e0610968-0065-405e-b967-45c888595ef6"), "چاف و چمخاله", 27 },
                    { 1097, new Guid("5bcb4c75-1fe0-48fd-90f5-f5b54c40ff56"), "چابکسر", 27 },
                    { 1096, new Guid("a6ac3d0b-54e3-4d36-9868-503e822e2385"), "پره سر", 27 },
                    { 1095, new Guid("7da2d775-a5aa-46ec-9e5a-a2522e6e30e2"), "واجارگاه", 27 },
                    { 1094, new Guid("a1a3c3e5-5e23-434c-a649-ee266c13bed7"), "هشتپر", 27 },
                    { 1101, new Guid("21dc2a20-79dd-46eb-ae00-7e370b643acd"), "کومله", 27 },
                    { 1093, new Guid("f0eaf918-c237-405c-8746-e9e3735c3203"), "منجيل", 27 },
                    { 1091, new Guid("4651acbd-2d5b-40ab-94a2-7d1423251c2e"), "ماکلوان", 27 },
                    { 1090, new Guid("eb6b2a6a-f808-48ef-815a-ae80e5c912c2"), "ماسوله", 27 },
                    { 1089, new Guid("4600f95b-14e7-408b-b972-343cbc948876"), "ماسال", 27 },
                    { 1088, new Guid("03e8a7a2-f369-4cf2-a885-0b7c99b1cebc"), "ليسار", 27 },
                    { 1087, new Guid("3b3ae7cd-281a-46e1-9ee1-2a7c23f89afc"), "لوندويل", 27 },
                    { 1086, new Guid("50f9c612-733e-4b84-9f95-fd8788cf297b"), "لولمان", 27 },
                    { 1085, new Guid("6a4ccc3e-4216-4d1b-9ec5-beccdf42c0a1"), "لوشان", 27 },
                    { 1092, new Guid("10b4dac6-bc21-4906-bad7-cf8c43497fb2"), "مرجقل", 27 },
                    { 1122, new Guid("e655a5c9-60f5-4703-a0c2-6d7572cf1055"), "فيروزان", 28 },
                    { 1102, new Guid("7495cfcc-a8a0-46ab-a5cb-6d5246a17e75"), "کوچصفهان", 27 },
                    { 1104, new Guid("95058dd9-62e9-41fd-b827-8b972dff71f6"), "گوراب زرميخ", 27 },
                    { 1120, new Guid("e0421410-d023-49ef-90b8-7510840977c1"), "فامنين", 28 },
                    { 1119, new Guid("7d3020f6-5e95-476a-9038-caa4381965b7"), "صالح آباد", 28 },
                    { 1118, new Guid("16f80857-3c87-4a64-a4a6-96a34dd982a2"), "شيرين سو", 28 },
                    { 1117, new Guid("12614828-adbb-4cd8-9db7-0cb70d1fc8f7"), "سرکان", 28 },
                    { 1116, new Guid("2a9d488f-52b8-4fb2-9079-b80b405cbc1c"), "سامن", 28 },
                    { 1115, new Guid("eb54b503-0969-416e-bae7-6b7859998019"), "زنگنه", 28 },
                    { 1114, new Guid("21cfa349-bcd3-4dd3-a78c-fd66c3217254"), "رزن", 28 },
                    { 1103, new Guid("b2f248ce-3033-4963-8a30-0f436081609d"), "کياشهر", 27 },
                    { 1113, new Guid("a550ff51-6165-4306-9156-d1d9ccaea068"), "دمق", 28 },
                    { 1111, new Guid("73875521-ba7d-44fc-a890-8b30d8bf4394"), "جورقان", 28 },
                    { 1110, new Guid("ac20d236-0192-4e66-bb69-4cb9172421c9"), "تويسرکان", 28 },
                    { 1109, new Guid("75373ae3-9658-4377-9da5-0d7ff2971ae7"), "بهار", 28 },
                    { 1108, new Guid("132f92f6-1030-4bb2-8a51-e71484662684"), "برزول", 28 },
                    { 1107, new Guid("4c5b63bf-d2c1-4980-97cb-1071e222114f"), "اسد آباد", 28 },
                    { 1106, new Guid("ff16e64a-e4f1-4750-aecb-a2a01fb0166a"), "ازندريان", 28 },
                    { 1105, new Guid("0a8cc976-d475-4063-bb62-46ff483d3bd5"), "آجين", 28 },
                    { 1112, new Guid("0a94f5c1-4e06-4bca-9b15-6c20cd30fcc9"), "جوکار", 28 },
                    { 1084, new Guid("e961100f-6787-4a0d-a4df-e48e9a229c0d"), "لنگرود", 27 },
                    { 1162, new Guid("7c29921a-1481-4dc3-95bc-6be89ca214f2"), "راين", 29 },
                    { 1164, new Guid("3a664e7d-9647-4fcf-a717-760f72e43907"), "رودبار", 29 },
                    { 1220, new Guid("c164e871-ced4-464b-a8f6-82f03af6cd9b"), "ميامي", 30 },
                    { 1219, new Guid("e899d654-bc28-40f4-85e9-8781939a4cc1"), "مهدي شهر", 30 },
                    { 1218, new Guid("8c8d1d3c-55b1-4e83-ab95-10a22dce3382"), "مجن", 30 },
                    { 1217, new Guid("be456189-6740-4066-9709-b9daacc68df8"), "شهميرزاد", 30 },
                    { 1216, new Guid("1323ee99-992d-4c8d-a368-239942320fa3"), "شاهرود", 30 },
                    { 1215, new Guid("36c06f94-2735-4da0-a0ba-e14bb24731ad"), "سمنان", 30 },
                    { 1214, new Guid("b43149cc-6198-4a92-bc3b-14c5fd342411"), "سرخه", 30 },
                    { 1221, new Guid("0d080aff-7e3a-4547-9e38-351cf8481630"), "کلاته", 30 },
                    { 1213, new Guid("7e9d19ca-4200-423f-8748-410bd6de80a8"), "روديان", 30 },
                    { 1211, new Guid("f7db91fe-f7e0-49aa-8696-7002d4cf31d1"), "درجزين", 30 },
                    { 1210, new Guid("4e4154ef-188a-4d72-a47e-07535e52272f"), "دامغان", 30 },
                    { 1209, new Guid("2798045a-cabd-495f-9cd8-f1d6da199304"), "بيارجمند", 30 },
                    { 1208, new Guid("ed660ff4-2a46-4c5f-a88a-f52eca23b3a9"), "بسطام", 30 },
                    { 1207, new Guid("2362fbd4-fa95-40bb-9324-aaad523777da"), "ايوانکي", 30 },
                    { 1206, new Guid("7dde70ac-b020-4904-a0f4-e5bec0e13f10"), "اميريه", 30 },
                    { 1205, new Guid("195109d4-ff35-4254-9fd8-6d7f7996dbb6"), "آرادان", 30 },
                    { 1212, new Guid("9dcc39f8-c9c5-4bfd-a122-cbaf6e8122dd"), "ديباج", 30 },
                    { 1204, new Guid("1140bd8b-3b70-4266-9beb-c3bf4a5fbdfa"), "گنبکي", 29 },
                    { 1222, new Guid("a54a88de-09bd-4b51-a291-def5c9d312e7"), "کلاته خيج", 30 },
                    { 1224, new Guid("a8bb1005-943f-4872-a5eb-65b43d57577e"), "گرمسار", 30 },
                    { 1240, new Guid("196f5657-0bea-4ed3-9bf4-192437a188b4"), "چيتاب", 31 },
                    { 1239, new Guid("3a831d81-31cd-4964-b29f-a7850a2ac61d"), "چرام", 31 },
                    { 1238, new Guid("71c2e4dd-b342-4b97-b296-15a962b0bcfc"), "پاتاوه", 31 },
                    { 1237, new Guid("0db6e601-70f4-473b-a954-3d355f56ea59"), "ياسوج", 31 },
                    { 1236, new Guid("8180d053-4cb9-4ed4-b117-24dac90fb0f7"), "مارگون", 31 },
                    { 1235, new Guid("12ef04d9-ec5b-48c6-a32a-d7311f977d61"), "مادوان", 31 },
                    { 1234, new Guid("040b1204-a9be-41d5-adc6-f22907913838"), "ليکک", 31 },
                    { 1223, new Guid("cced1aa2-8a3f-41ca-a586-fd8c5e186cd8"), "کهن آباد", 30 },
                    { 1233, new Guid("4ac29ee7-58ca-429c-8e8d-b4e410ddb4e1"), "لنده", 31 },
                    { 1231, new Guid("bdb11c3e-c76d-4aa1-91a0-c1dc5c40fcee"), "سي سخت", 31 },
                    { 1230, new Guid("33dc1a13-01be-4f13-a51d-a1ad416fffdd"), "سوق", 31 },
                    { 1229, new Guid("c156c1a9-31b1-43f8-b0ee-056badbebd72"), "سرفارياب", 31 },
                    { 1228, new Guid("a051be6c-8817-453f-a9e9-6a3e07a1e32c"), "ديشموک", 31 },
                    { 1227, new Guid("af8599d9-7573-43d5-aad1-2168f995c2e6"), "دوگنبدان", 31 },
                    { 1226, new Guid("52536430-f58d-4e2c-ad3d-e397bbb3602b"), "دهدشت", 31 },
                    { 1225, new Guid("4095ee41-be49-463f-99c4-9f911a6bbc2a"), "باشت", 31 },
                    { 1232, new Guid("8e7f4a68-6b18-4efc-abb4-7266333c05e0"), "قلعه رئيسي", 31 },
                    { 1163, new Guid("398da732-107d-4ecb-86f1-712a37a8b791"), "رفسنجان", 29 },
                    { 1203, new Guid("10f8e3b1-7f57-4fbe-b0ae-1f060caba4f5"), "گلزار", 29 },
                    { 1201, new Guid("5929792e-d525-4df0-bbed-6aec4119ad0b"), "کيانشهر", 29 },
                    { 1180, new Guid("31925dca-6f75-4cb6-aa59-1de81527bf07"), "محمد آباد", 29 },
                    { 1179, new Guid("5a897efe-7e03-40a4-b343-aaecd1432934"), "ماهان", 29 },
                    { 1178, new Guid("a3b8f94d-1cea-40b9-8890-9ae90e759791"), "لاله زار", 29 },
                    { 1177, new Guid("8d48811f-13db-452b-9073-7c9db1516399"), "قلعه گنج", 29 },
                    { 1176, new Guid("f7c807c2-5b5c-4a22-bbb7-127ae3dc8ea4"), "فهرج", 29 },
                    { 1175, new Guid("ef85db42-239a-4f9c-80e4-99ca5c76b022"), "فارياب", 29 },
                    { 1174, new Guid("d7a2fff1-6367-4fc7-8c01-8a845296117c"), "عنبر آباد", 29 },
                    { 1181, new Guid("07be6f41-ee0b-41a9-8361-a8f5f4cb7e0d"), "محي آباد", 29 },
                    { 1173, new Guid("8a3f8a53-a6a4-4658-a038-9a5396756fa3"), "صفائيه", 29 },
                    { 1171, new Guid("58dff00f-f81d-4e37-9330-762450e75df0"), "شهداد", 29 },
                    { 1170, new Guid("32cd3077-fc6d-483e-ba13-fd82a459b73d"), "سيرجان", 29 },
                    { 1169, new Guid("1307ce78-49c8-4651-b93c-602b20f0e29d"), "زيد آباد", 29 },
                    { 1168, new Guid("5253f9cb-c9fc-47ab-9ad0-490e40b940d6"), "زهکلوت", 29 },
                    { 1167, new Guid("110e3701-6213-46d2-8504-2672d762f0c1"), "زنگي آباد", 29 },
                    { 1166, new Guid("1587da58-4dc2-4461-88d5-e9a3b7807572"), "زرند", 29 },
                    { 1165, new Guid("89fd35ab-b03f-49a6-89c6-4ced8239a178"), "ريحان", 29 },
                    { 1172, new Guid("9087551e-8420-4959-ae05-4b4d6fa9620b"), "شهر بابک", 29 },
                    { 1202, new Guid("e94bd0f1-c7d2-44b9-8c2d-148cb6578f78"), "گلباف", 29 },
                    { 1182, new Guid("c665957e-b111-400d-9901-cb3d73ed9f21"), "مردهک", 29 },
                    { 1184, new Guid("4cb15c2d-91d5-4990-9d97-fa09fc4fcc0d"), "منوجان", 29 },
                    { 1200, new Guid("73707da7-2039-4969-9549-564610ae4903"), "کوهبنان", 29 },
                    { 1199, new Guid("8c8e2e7f-27ef-45f6-a101-8dfa440d9cde"), "کهنوج", 29 },
                    { 1198, new Guid("b2b227ab-17b2-4d43-b722-9610e8fc6fc9"), "کشکوئيه", 29 },
                    { 1197, new Guid("bddd9a21-2e38-4f6a-bede-dab847ff32ab"), "کرمان", 29 },
                    { 1196, new Guid("2072d7ac-c29b-4d28-9f0a-2f11b21b9464"), "کاظم آباد", 29 },
                    { 1195, new Guid("f84d1e08-834e-46d9-878d-e9dd28e0ae39"), "چترود", 29 },
                    { 1194, new Guid("167c7db9-5637-494d-a285-6399847332ba"), "پاريز", 29 },
                    { 1183, new Guid("f1126fd3-2646-46b7-b9e8-075b50d96fe5"), "مس سرچشمه", 29 },
                    { 1193, new Guid("0e1f20c6-d069-4fa2-a999-d4e433f0888f"), "يزدان شهر", 29 },
                    { 1191, new Guid("5b65ac5c-6cc5-4135-875a-30ea52c069ad"), "هماشهر", 29 },
                    { 1190, new Guid("53803960-882d-42dc-a225-e6dbf8c5d03d"), "هجدک", 29 },
                    { 1189, new Guid("75e0410b-e280-4b24-a121-e5a4bac0d922"), "نگار", 29 },
                    { 1188, new Guid("12ffed11-56af-4fd4-a1fc-9070f6bc0599"), "نودژ", 29 },
                    { 1187, new Guid("e9409bc9-06ef-4d57-8b22-536d3c64d868"), "نظام شهر", 29 },
                    { 1186, new Guid("4f7cd9ac-1445-4e33-9169-4e7378826162"), "نرماشير", 29 },
                    { 1185, new Guid("1f7c1cce-b159-4535-aabc-b9cab4f16db1"), "نجف شهر", 29 },
                    { 1192, new Guid("8ffb8d1b-5e7d-4d15-9a2d-e0732c429231"), "هنزا", 29 },
                    { 1083, new Guid("3e228ae7-070c-4dea-89c3-1d9ee7691a3a"), "لشت نشاء", 27 },
                    { 1082, new Guid("611a256f-a1cb-47e6-8d3e-17d7ad0450fe"), "لاهيجان", 27 },
                    { 1081, new Guid("61a29558-5977-40a2-8bac-3740edd64e2d"), "فومن", 27 },
                    { 979, new Guid("9ad18f09-7875-4bd5-8fa3-722553a71e3a"), "گودين", 24 },
                    { 978, new Guid("6f92f9b3-e3f2-423f-af7e-abb3140df754"), "گهواره", 24 },
                    { 977, new Guid("b9245bb0-6328-4cea-bb7d-6a9f84799ec6"), "کوزران", 24 },
                    { 976, new Guid("44fc4429-54a8-4c01-ae24-741218e06db0"), "کنگاور", 24 },
                    { 975, new Guid("7c0c1413-6fe6-4083-ac22-4e7dbaa3a752"), "کرند غرب", 24 },
                    { 974, new Guid("b9ef5e4c-3636-486c-9c64-ff1836967115"), "کرمانشاه", 24 },
                    { 973, new Guid("895bb571-7626-43a5-b986-52c30bc66d6d"), "پاوه", 24 },
                    { 980, new Guid("f34955ac-a9e4-443b-8206-0fdbbca2ead6"), "گيلانغرب", 24 },
                    { 972, new Guid("ce55d582-73eb-4827-a71f-8af923af6b98"), "هلشي", 24 },
                    { 970, new Guid("02186746-873f-41f0-b6ae-b25ec87e84d6"), "نوسود", 24 },
                    { 969, new Guid("b7baacec-3abc-4fed-bb74-01f1128c42d4"), "نودشه", 24 },
                    { 968, new Guid("f6d83907-09e2-404b-9058-a128cd7d9510"), "ميان راهان", 24 },
                    { 967, new Guid("70cef1e8-280b-4d71-8ed9-87847cace028"), "قصر شيرين", 24 },
                    { 966, new Guid("aeb84417-be1f-456c-a728-7fc530cdfafb"), "صحنه", 24 },
                    { 965, new Guid("1689ef97-02eb-4005-956a-30eb1c8e762b"), "شاهو", 24 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 964, new Guid("76eaf2f2-a576-48d4-a98d-7a20bbb8b4c2"), "سومار", 24 },
                    { 971, new Guid("4a377ce7-6aa7-4183-b8c0-d7e1351f9077"), "هرسين", 24 },
                    { 963, new Guid("840f0098-026d-4ddf-a6b1-d41785600469"), "سنقر", 24 },
                    { 981, new Guid("a2c63821-3a59-40ae-b13f-4c925264db2f"), "ابوموسي", 25 },
                    { 983, new Guid("a02d1dd6-35b2-4cd8-a9f8-662f94c9e665"), "بندر جاسک", 25 },
                    { 999, new Guid("63cd93c1-8821-4936-aa7f-2de659fd5969"), "سرگز", 25 },
                    { 998, new Guid("c8efe964-1f66-413b-ae33-b39ebb6e6c84"), "سردشت", 25 },
                    { 997, new Guid("51e2ce36-83c4-4f8c-903b-1ecbbb6c5c7d"), "زيارتعلي", 25 },
                    { 996, new Guid("388636bd-6fa1-4360-a7e7-42f3ca083688"), "رويدر", 25 },
                    { 995, new Guid("78967dbb-3f33-406c-8f51-758efaefda0a"), "دهبارز", 25 },
                    { 994, new Guid("90b08ed2-d52b-45f5-8db0-241b898fd3fe"), "دشتي", 25 },
                    { 993, new Guid("583c1075-1a6e-482c-9b4f-fd456ffb565f"), "درگهان", 25 },
                    { 982, new Guid("73397f0f-bfe6-42f4-ad7c-4595f0b94c1e"), "بستک", 25 },
                    { 992, new Guid("61ba1187-07fb-4216-93d5-d6898a344c8f"), "خمير", 25 },
                    { 990, new Guid("9c162623-e6b9-44f4-82a8-c7ae475d54e5"), "جناح", 25 },
                    { 989, new Guid("5d3146d0-3841-44af-83cd-818e259e3b9e"), "تيرور", 25 },
                    { 988, new Guid("6f44c6ad-c692-496d-a173-252b853cd7d7"), "تخت", 25 },
                    { 987, new Guid("af52b01e-8be7-4d6c-80b6-cfa46cce28e2"), "تازيان پائين", 25 },
                    { 986, new Guid("e6430a7f-e290-4675-b9ba-e4c7388b8bd9"), "بيکاه", 25 },
                    { 985, new Guid("51c1543b-63ea-4ffd-9409-c309f1582597"), "بندر لنگه", 25 },
                    { 984, new Guid("db195efd-2eb3-4377-972b-2b3d7dd96a96"), "بندر عباس", 25 },
                    { 991, new Guid("01368201-c836-4216-9efe-de00fe34cfce"), "حاجي آباد", 25 },
                    { 1000, new Guid("1ccdb79b-daa3-4c24-a4fc-0430f672a564"), "سندرک", 25 },
                    { 962, new Guid("24a72b58-f010-4e89-83b5-d4c5a8a7895e"), "سطر", 24 },
                    { 960, new Guid("1fdf4c69-9064-4728-b31b-57d9d6694b23"), "سر پل ذهاب", 24 },
                    { 939, new Guid("1517257c-025e-4a06-bc00-8857967a12b3"), "کارزين", 23 },
                    { 938, new Guid("3f1a75d9-f839-4e44-8885-0581f10b206e"), "وراوي", 23 },
                    { 937, new Guid("729489f8-612b-4eb2-8d19-721110fee928"), "هماشهر", 23 },
                    { 936, new Guid("768bb1f4-dc65-4fc9-aa6e-aa72bda3c7d3"), "ني ريز", 23 },
                    { 935, new Guid("4da62ba6-0bb3-4a0f-85c6-26deb6f0a4ce"), "نورآباد", 23 },
                    { 934, new Guid("1111b9fe-121c-456d-b1eb-835d14200833"), "نودان", 23 },
                    { 933, new Guid("e7a84150-4700-41f1-8fba-0a884928f35a"), "نوجين", 23 },
                    { 940, new Guid("a3c48635-a2a2-4424-9869-78f75808de5d"), "کازرون", 23 },
                    { 932, new Guid("6ea6a2c8-061e-44e6-9479-827276361b4c"), "نوبندگان", 23 },
                    { 930, new Guid("986b1a70-3f5b-4002-8d52-75d88aa1ae8b"), "ميانشهر", 23 },
                    { 929, new Guid("a5e315ad-d1d1-4cf9-8db9-bc8353dc2029"), "مهر", 23 },
                    { 928, new Guid("e2b6fd0f-99b9-42e0-a795-995fd4d3db99"), "مصيري", 23 },
                    { 927, new Guid("bddd851f-f293-41bc-8387-7f326a81e2bd"), "مشکان", 23 },
                    { 926, new Guid("b36a80d4-0d0b-4b39-a8b7-6ef5ccc9c43a"), "مزايجان", 23 },
                    { 602, new Guid("cba25618-cb52-4c20-9069-3c54bef11f17"), "نمين", 18 },
                    { 924, new Guid("68af36c1-890a-4c9d-9b56-86d6d66c9bcf"), "مبارک آباد", 23 },
                    { 931, new Guid("9696412e-056b-491a-89db-f28f2a1b9e4c"), "ميمند", 23 },
                    { 961, new Guid("c1ce4471-2967-4746-898c-f3ebba838364"), "سرمست", 24 },
                    { 941, new Guid("78868a84-99bd-4568-975c-adba3a5a3e58"), "کامفيروز", 23 },
                    { 943, new Guid("5d7273af-2457-4bc4-9d05-d857986b9b22"), "کنار تخته", 23 },
                    { 959, new Guid("a4cc64ff-5749-4db2-aec8-b23704f3b560"), "ريجاب", 24 },
                    { 958, new Guid("93915388-4391-4043-b887-de51a268e1db"), "روانسر", 24 },
                    { 957, new Guid("ea264c4f-e50a-49ff-aa8e-4e5baccc6102"), "رباط", 24 },
                    { 956, new Guid("eeba660f-52a0-4f32-9135-423f279e312c"), "حميل", 24 },
                    { 955, new Guid("d11872bc-6fd9-4452-9fb8-365c77ee161b"), "جوانرود", 24 },
                    { 954, new Guid("f98d64ef-4125-46b2-95ec-0da63a27bc2b"), "تازه آباد", 24 },
                    { 953, new Guid("387da6ed-8710-4034-8663-f9cc0856058d"), "بيستون", 24 },
                    { 942, new Guid("6477ba41-68b3-41bb-9663-1e61120b566e"), "کره اي", 23 },
                    { 952, new Guid("c0f2e341-ca88-4067-895f-cb37acc5f998"), "باينگان", 24 },
                    { 950, new Guid("e8872025-815e-4c91-9bc1-59e21593a59b"), "اسلام آباد غرب", 24 },
                    { 949, new Guid("f7d7709c-709c-47f5-a007-64416f9a9f19"), "ازگله", 24 },
                    { 948, new Guid("1374e49a-6bea-45a0-bcc5-d32ebb843637"), "گله دار", 23 },
                    { 947, new Guid("761ec931-f4b9-4018-bc18-e389443455f8"), "گراش", 23 },
                    { 946, new Guid("3a2b44da-d375-4edd-8fa2-16d98ce5130b"), "کوپن", 23 },
                    { 945, new Guid("852d61b2-4596-490b-9a65-44e2400bbc84"), "کوهنجان", 23 },
                    { 944, new Guid("5a8bc43b-8c2c-4b4e-b585-aa18e478f211"), "کوار", 23 },
                    { 951, new Guid("c3316d92-2e68-4f88-80b4-d484b47a3032"), "بانوره", 24 },
                    { 1001, new Guid("d58d260b-d897-44ab-8aa4-f2c70fb5b96e"), "سوزا", 25 },
                    { 1002, new Guid("57c627ae-626b-41b9-b7aa-966ac2b33e09"), "سيريک", 25 },
                    { 1003, new Guid("7bbfd8eb-b6e7-46e7-8f06-08d9523bdc70"), "فارغان", 25 },
                    { 1060, new Guid("d87697d0-06d7-483e-9d3f-13c590272732"), "بره سر", 27 },
                    { 1059, new Guid("bbb44fce-9ba9-4c4d-89ac-fb4bda4fe79a"), "بازار جمعه", 27 },
                    { 1058, new Guid("cd069c13-a87a-4308-b7a7-1122ede566c7"), "املش", 27 },
                    { 1057, new Guid("baf6500b-51d8-4f91-8215-1b18317899ef"), "اطاقور", 27 },
                    { 1056, new Guid("ba3ab0ff-2ec0-4af4-b847-168859d15194"), "اسالم", 27 },
                    { 1055, new Guid("06da1724-f185-4931-be03-c98bc0fbede0"), "احمد سرگوراب", 27 },
                    { 1054, new Guid("54bd833c-a038-42ed-86af-a10c62ded0c1"), "آستانه اشرفيه", 27 },
                    { 1061, new Guid("16eec475-eeb9-40e6-89f9-9ea3ba35c2ad"), "بندر انزلي", 27 },
                    { 1053, new Guid("ef0e1d4a-81c8-424d-9b04-287cbc5bed55"), "آستارا", 27 },
                    { 1051, new Guid("4102aa4e-eefa-4afb-94d5-3f3bb90407c3"), "کارچان", 26 },
                    { 1050, new Guid("909dac82-3b1d-4a8d-8ed8-4c9c96653d7d"), "پرندک", 26 },
                    { 1049, new Guid("e3c12742-7924-488c-a3d7-c1f13c650b35"), "هندودر", 26 },
                    { 1048, new Guid("2e51b76b-b3dc-45b2-976c-937ec5689d64"), "نيمور", 26 },
                    { 1047, new Guid("c24e58cf-54ab-47e1-acb1-c502553cb2e4"), "نوبران", 26 },
                    { 1046, new Guid("40652eea-a675-4db7-ae21-eb365550c98e"), "نراق", 26 },
                    { 1045, new Guid("d8245b6f-eff1-40eb-ae48-29ec3fc33290"), "ميلاجرد", 26 },
                    { 1052, new Guid("f5023587-5173-4bb3-a3f2-d85265963a7c"), "کميجان", 26 },
                    { 1044, new Guid("c3b7edae-7a20-460d-a6b9-6a60b832a543"), "محلات", 26 },
                    { 1062, new Guid("d65a3ac0-b7f9-4fdb-98fd-e04901c325bd"), "توتکابن", 27 },
                    { 1064, new Guid("5f80d131-d652-4856-bd55-73c12067129f"), "حويق", 27 },
                    { 1080, new Guid("e69dbae5-554f-4eeb-8d71-7f676e26b129"), "صومعه سرا", 27 },
                    { 1079, new Guid("27cb791b-447c-4b41-af1b-fc64741d3cf8"), "شلمان", 27 },
                    { 1078, new Guid("77a129f1-d192-4673-bd96-5bac9c80a29d"), "شفت", 27 },
                    { 1077, new Guid("070ae132-b73c-4a0b-b599-b1524b8e2104"), "سياهکل", 27 },
                    { 1076, new Guid("d883a257-3a22-44b7-81e4-3298a0a28dc2"), "سنگر", 27 },
                    { 1075, new Guid("84f6ca16-2e45-4b20-b363-400873e616e5"), "رودسر", 27 },
                    { 1074, new Guid("2dc2e6fc-651d-4ceb-bc69-c6a73d22accb"), "رودبنه", 27 },
                    { 1063, new Guid("8f75a98c-3890-47f2-8cf2-e3a9c3686fed"), "جيرنده", 27 },
                    { 1073, new Guid("3de06b5f-fdde-4895-a481-a632b80c7cd8"), "رودبار", 27 },
                    { 1071, new Guid("edf7323e-f2e6-4ced-8d6f-7894f5ab488e"), "رشت", 27 },
                    { 1070, new Guid("3bfc00cd-8e6c-434f-86fd-8332c3c13f16"), "رستم آباد", 27 },
                    { 1069, new Guid("3e01893a-e4a5-4bc8-96aa-f498437806cb"), "رحيم آباد", 27 },
                    { 1068, new Guid("d1aa708c-fa42-405a-afc8-06a3c329d6b4"), "رانکوه", 27 },
                    { 1067, new Guid("7b459f97-cd41-44b6-905d-86475bcfbce3"), "ديلمان", 27 },
                    { 1066, new Guid("f55dd0fa-6d95-4951-8e92-4e8b6af7b926"), "خمام", 27 },
                    { 1065, new Guid("bce470d4-4cf5-4688-8b73-de28ec4c4e5c"), "خشکبيجار", 27 },
                    { 1072, new Guid("f08df841-fbae-49bc-a55b-b1c2e595c009"), "رضوانشهر", 27 },
                    { 1043, new Guid("31db9d01-3314-4284-8375-9f02f4fea239"), "مامونيه", 26 },
                    { 1042, new Guid("42a7c44d-4120-4996-be24-b1a037cb4a51"), "قورچي باشي", 26 },
                    { 1041, new Guid("809b68b3-dd4d-46cc-b342-b6b1530087aa"), "فرمهين", 26 },
                    { 1019, new Guid("25960816-e2cb-4d22-8e1d-341a8a23875b"), "گوهران", 25 },
                    { 1018, new Guid("82f40e60-2900-4e2a-babc-5c5cd2fe64c7"), "گروک", 25 },
                    { 1017, new Guid("d986079f-e471-4c71-be31-f106de146930"), "کيش", 25 },
                    { 1016, new Guid("72b68b86-4878-4709-a2fb-e9817a5d08aa"), "کوهستک", 25 },
                    { 1015, new Guid("8e41264f-0bab-43e9-88d6-0c0569d1de99"), "کوشکنار", 25 },
                    { 1014, new Guid("78c08eec-2bee-4834-b7df-561cdbc33d03"), "کوخردهرنگ", 25 },
                    { 1013, new Guid("58e641d3-179c-4a52-bdee-54fbb9fc6587"), "کنگ", 25 },
                    { 1020, new Guid("a8eb3902-4325-41b4-a422-40f1b8f88974"), "آستانه", 26 },
                    { 1012, new Guid("3d99e2d9-df25-4440-8be7-ccbf207d6b43"), "چارک", 25 },
                    { 1010, new Guid("6e2afdcf-666f-4f87-8a49-975e9109c91b"), "هشتبندي", 25 },
                    { 1009, new Guid("250d6f6a-e622-4968-a2f2-f49f851bb3db"), "هرمز", 25 },
                    { 1008, new Guid("29beb9fa-0f21-4888-b2a3-a7ff4c1b6624"), "ميناب", 25 },
                    { 1007, new Guid("25c76f36-ca89-409f-81d0-324a817f0b92"), "لمزان", 25 },
                    { 1006, new Guid("42d417c4-f6de-48bd-9ed4-576fabdf372e"), "قلعه قاضي", 25 },
                    { 1005, new Guid("d0aaf2e3-50bd-4736-8386-0db3c0ef7e6e"), "قشم", 25 },
                    { 1004, new Guid("b7a269f9-88c3-418f-8cb6-89b0f65cc075"), "فين", 25 },
                    { 1011, new Guid("4bb94110-a896-4418-855e-c060d91b3da0"), "پارسيان", 25 },
                    { 1021, new Guid("ee94103c-bb91-4ecb-bc94-965ab17e4b3f"), "آشتيان", 26 },
                    { 1022, new Guid("72125da1-cc3d-402e-a586-87597a13e936"), "آوه", 26 },
                    { 1023, new Guid("302b9c4f-5e09-4d5e-9fd9-00a8c401dc7a"), "اراک", 26 },
                    { 1040, new Guid("1595d360-c759-4aa6-a0e3-a0102a9777e9"), "غرق آباد", 26 },
                    { 1039, new Guid("157ab1bb-d57e-4667-bd08-327d616eb7ff"), "شهر جديد مهاجران", 26 },
                    { 1038, new Guid("57f2477b-4b69-48d9-9ca7-58642cf9a8ad"), "شهباز", 26 },
                    { 1037, new Guid("0f395527-3257-4514-9fb0-e3e53eb25b51"), "شازند", 26 },
                    { 1036, new Guid("73b23f3e-98e9-4153-bba7-88c6f038bc36"), "ساوه", 26 },
                    { 1035, new Guid("710794de-deb2-4c58-bc93-c73e341a2269"), "ساروق", 26 },
                    { 1034, new Guid("7f68dce5-cf90-4c50-b5b8-ce5548459e5d"), "زاويه", 26 },
                    { 1033, new Guid("8a80e68d-bd3a-4dcb-80fb-65db8e0ff11b"), "رازقان", 26 },
                    { 1032, new Guid("07340a22-93ae-4468-930e-29d5665283b2"), "دليجان", 26 },
                    { 1031, new Guid("3790c1c7-dd82-4444-85f4-b62a9d5368e2"), "داود آباد", 26 },
                    { 1030, new Guid("1d8d2d6d-b562-4e41-9015-ca14ae28581c"), "خنداب", 26 },
                    { 1029, new Guid("5bd14875-2b24-4efd-bf85-78d4081df3a0"), "خنجين", 26 },
                    { 1028, new Guid("498d3298-c211-43b7-88d3-cff0de9d0c47"), "خمين", 26 },
                    { 1027, new Guid("290e3e7d-2be9-40ec-a4d6-4a1519d51122"), "خشکرود", 26 },
                    { 1026, new Guid("37f681e4-02bd-4483-8e56-bb95058c4bfc"), "جاورسيان", 26 },
                    { 1025, new Guid("a99b7dc4-8fe7-436b-8dbe-a269a3e88605"), "توره", 26 },
                    { 1024, new Guid("5d92e84f-ff96-41a2-b2da-70a6a1cbf546"), "تفرش", 26 },
                    { 922, new Guid("87c42e90-9c10-4323-8d2a-cacc08c39a78"), "لپوئي", 23 },
                    { 601, new Guid("c864143c-0dbd-4b22-bacc-f4b924abba6a"), "مشگين شهر", 18 },
                    { 597, new Guid("d5821285-9e80-4f90-974f-b1c9852fb29b"), "فخرآباد", 18 },
                    { 599, new Guid("58c1325a-ee6d-4340-ab63-79d18c87b1a6"), "لاهرود", 18 },
                    { 203, new Guid("5ca0122e-12cb-4b78-87cf-871ca879d1f7"), "ريوش", 8 },
                    { 202, new Guid("47eeb92e-754a-4ef9-a51e-5ce0d379e430"), "روداب", 8 },
                    { 201, new Guid("1ae0f8bf-6be3-44ac-a71a-8007cd6c1b7b"), "رضويه", 8 },
                    { 200, new Guid("6c70d914-e995-4c9e-b107-04e06c193950"), "رشتخوار", 8 },
                    { 199, new Guid("25becfee-e84e-4bac-ad91-230797cf53ea"), "رباط سنگ", 8 },
                    { 198, new Guid("12a73326-61e8-41ab-8a29-a91cb0a47b15"), "دولت آباد", 8 },
                    { 204, new Guid("cf94139a-5402-4af9-9154-b442f3092b58"), "سبزوار", 8 },
                    { 197, new Guid("a7253545-6003-4616-bc3d-ede32454b33a"), "درگز", 8 },
                    { 195, new Guid("eacc8350-199d-420b-ae14-7364b4f0c8c2"), "داورزن", 8 },
                    { 194, new Guid("b337c534-7b37-4b41-a84f-014d7d0234c6"), "خواف", 8 },
                    { 193, new Guid("1e68b004-a409-41c3-ab70-d1b7c0ad5c0c"), "خليل آباد", 8 },
                    { 192, new Guid("b428596f-37ed-4982-842b-758ccff6503b"), "خرو", 8 },
                    { 191, new Guid("8eab5629-dfa3-493a-956a-7a67e09b077d"), "جنگل", 8 },
                    { 190, new Guid("da5aa323-bcdb-480c-aa0b-d37061907ad8"), "جغتاي", 8 },
                    { 196, new Guid("e63afa64-1738-4ab8-83dc-de5e7a091940"), "درود", 8 },
                    { 205, new Guid("b87ead60-efa6-4b50-bcd6-67d1a1beace9"), "سرخس", 8 },
                    { 206, new Guid("66133164-1062-4f10-a3d0-d97f157a2cf7"), "سفيد سنگ", 8 },
                    { 207, new Guid("0e6aff00-e994-445c-b35a-d16971dc6e50"), "سلامي", 8 },
                    { 222, new Guid("3f5c5abc-cfd2-4e9d-b110-6633ed7b5e8d"), "قاسم آباد", 8 },
                    { 221, new Guid("720edd9b-a22f-45e3-9155-2c4b42ef57a8"), "فيض آباد", 8 },
                    { 220, new Guid("2ed2dc20-c871-4ef7-bb79-b41e3a356405"), "فيروزه", 8 },
                    { 219, new Guid("bbec95de-bddb-4b1a-8809-68519d47bf63"), "فريمان", 8 },
                    { 218, new Guid("9a7db6a5-c38f-4d44-9026-cf79c9c4f2f6"), "فرهاد گرد", 8 },
                    { 217, new Guid("e48f6b31-d2f4-462a-b9c5-3e85359c1a71"), "عشق آباد", 8 },
                    { 216, new Guid("be847de9-990b-4556-8212-ae83ecc5b169"), "طرقبه", 8 },
                    { 215, new Guid("85aa4fe9-7dea-4712-8595-1a68eb87812e"), "صالح آباد", 8 },
                    { 214, new Guid("61815e90-21f1-4863-96ed-634494e62892"), "شهرآباد", 8 },
                    { 213, new Guid("0ff979c7-e354-4164-b426-29004116f9fd"), "شهر زو", 8 },
                    { 212, new Guid("c5ff0075-9e7b-46f5-aebf-ac064dbfbe87"), "ششتمد", 8 },
                    { 211, new Guid("ec026b64-5ac7-4f7f-95a4-2dae0459d37a"), "شانديز", 8 },
                    { 210, new Guid("d3628960-980b-4054-b879-2717d37dbe21"), "شادمهر", 8 },
                    { 209, new Guid("8ba04b60-bf08-45df-8801-70d107a1b983"), "سنگان", 8 },
                    { 208, new Guid("be721cf4-ad24-43ff-8249-80a836f2ec14"), "سلطان آباد", 8 },
                    { 189, new Guid("606bf4b5-bca9-4ab1-8a5c-9ce7c69fbbc6"), "تربت حيدريه", 8 },
                    { 188, new Guid("19a39c0a-8106-4436-9777-479182dee181"), "تربت جام", 8 },
                    { 187, new Guid("899bce88-2f01-4b5c-8ebe-7459a7dca1de"), "تايباد", 8 },
                    { 186, new Guid("a407673b-5d5e-4fb6-b9c7-7b99c062bfe1"), "بيدخت", 8 },
                    { 166, new Guid("e216419b-2ce9-4b55-a2b9-3d19e617b413"), "مهاباد", 7 },
                    { 165, new Guid("cd836e72-b107-4ac0-ba0c-4f5309aeaaa9"), "مرگنلر", 7 },
                    { 164, new Guid("34ac8e00-89ef-47c4-a833-843d74ea85fa"), "محمود آباد", 7 },
                    { 163, new Guid("5d74f3cd-6800-4232-b48a-ee26f4d6c18c"), "محمد يار", 7 },
                    { 162, new Guid("d32fbd09-8c70-4422-8474-a7e1014158ff"), "ماکو", 7 },
                    { 161, new Guid("9cdf43f8-fd22-4032-b55d-e4aa8e26f369"), "قوشچي", 7 },
                    { 160, new Guid("cd358566-f028-4527-a3f4-95aeeae7a906"), "قطور", 7 },
                    { 159, new Guid("ba4dbb34-78cb-43bc-a0d4-ff70a4b45a79"), "قره ضياء الدين", 7 },
                    { 158, new Guid("437d2c8a-9c09-4098-9dd0-9836479245d8"), "فيرورق", 7 },
                    { 157, new Guid("4315d31e-e11e-47ee-aafa-0dac775473f1"), "شوط", 7 },
                    { 156, new Guid("da14ed89-8589-49f5-8e0b-cdae0924ee90"), "شاهين دژ", 7 },
                    { 155, new Guid("8b8fc22b-496a-42eb-9c63-977080b69284"), "سيه چشمه", 7 },
                    { 154, new Guid("a055a476-a1ac-472f-b374-0ac57a1aecb7"), "سيمينه", 7 },
                    { 153, new Guid("591529f2-0267-4827-9305-ffaf02887dcc"), "سيلوانه", 7 },
                    { 152, new Guid("d78fff8a-3d02-44a0-ad2c-5cf55f2900dc"), "سلماس", 7 },
                    { 167, new Guid("45737497-d116-467c-9f65-2b13ae97890e"), "مياندوآب", 7 },
                    { 223, new Guid("e69185f7-917a-4c55-99e3-fbb000815c7f"), "قدمگاه", 8 },
                    { 168, new Guid("5f65d81b-1b3b-4211-98ca-10a736cceb80"), "ميرآباد", 7 },
                    { 170, new Guid("6a52ac29-0848-4fa1-abaf-9fc9463529b9"), "نالوس", 7 },
                    { 185, new Guid("c45b8112-0984-4453-a87c-86d599c96006"), "بردسکن", 8 },
                    { 184, new Guid("b40d4a7f-cdf5-4526-99f0-058845f4e866"), "بجستان", 8 },
                    { 183, new Guid("28697ffa-04c6-4150-9f34-ace7cf61867e"), "بايک", 8 },
                    { 182, new Guid("523e1672-f142-4e12-970a-cfda772d9915"), "بار", 8 },
                    { 181, new Guid("6ed3a361-393f-4be3-a9cc-b1be975020fc"), "باخرز", 8 },
                    { 180, new Guid("a8e4767c-916b-4048-a252-62bd35b48d19"), "باجگيران", 8 },
                    { 179, new Guid("7f28276b-811a-46a0-a400-20bc03cd5e9e"), "انابد", 8 },
                    { 178, new Guid("0e9024ef-7fe2-490e-a9f0-42c78d0badb1"), "احمدآباد صولت", 8 },
                    { 177, new Guid("9872fa8f-7e34-4ae3-aa28-a21127905988"), "گردکشانه", 7 },
                    { 176, new Guid("dc3b5fcc-4c31-49e6-921e-26740f9f4649"), "کشاورز", 7 },
                    { 175, new Guid("ef62a9c6-bad9-4df7-af6a-a4ebcba08422"), "چهار برج", 7 },
                    { 174, new Guid("75d88137-c510-4c7b-9d79-68340cbd9727"), "پيرانشهر", 7 },
                    { 173, new Guid("340063a8-d328-4c09-a10c-bb320f90a6c9"), "پلدشت", 7 },
                    { 172, new Guid("f6fb9e0d-ce35-4f24-a01f-f11e14a419ed"), "نوشين", 7 },
                    { 171, new Guid("17524281-5691-4a52-a7d2-e0981e2573fb"), "نقده", 7 },
                    { 169, new Guid("464d85d8-4dcd-4e5a-a361-b6b04046ca53"), "نازک عليا", 7 },
                    { 151, new Guid("017ff440-7452-4694-8fd5-8b12317939ef"), "سرو", 7 },
                    { 224, new Guid("6f879203-6eab-48f9-a578-f381b9cf7a21"), "قلندر آباد", 8 },
                    { 226, new Guid("251da243-a51c-4a16-8f0e-16ad789a283c"), "لطف آباد", 8 },
                    { 278, new Guid("9d4fea09-ea12-45ec-8165-0dc079f13e5e"), "نوک آباد", 9 },
                    { 277, new Guid("e0058679-6acc-4128-a676-43fa97c38f76"), "نصرت آباد", 9 },
                    { 276, new Guid("a22ed329-c224-40a8-87d5-6454d1fa1c4f"), "ميرجاوه", 9 },
                    { 275, new Guid("2f020b0c-640a-49ba-9a92-43307dd6c6db"), "مهرستان", 9 },
                    { 274, new Guid("fa6e8c49-32d0-4adc-9ddf-54c265ddc5e3"), "محمدي", 9 },
                    { 273, new Guid("f723b3c5-4dbb-4fb9-bebf-e675b2b7d756"), "محمدان", 9 },
                    { 600, new Guid("dd6dcb03-21ab-4743-841c-1aee398a8194"), "مرادلو", 18 },
                    { 272, new Guid("432db985-6015-4584-8d09-b5f856a24c7d"), "محمد آباد", 9 },
                    { 270, new Guid("08647e6b-d0a9-473d-bdf2-6bb859d8d19e"), "فنوج", 9 },
                    { 269, new Guid("6acf7107-eee0-4456-9ab4-667691a63331"), "علي اکبر", 9 },
                    { 268, new Guid("612547a2-9f41-4de1-88f3-fd63e4f7ab5c"), "سيرکان", 9 },
                    { 267, new Guid("adc14c3e-2644-4ad4-a8cc-1bfa836b8b58"), "سوران", 9 },
                    { 266, new Guid("e8037bd8-f0f4-4aac-9036-e727ebaf4f44"), "سرباز", 9 },
                    { 265, new Guid("ed31d899-1f7c-4bea-ab42-4fc364e104e3"), "سراوان", 9 },
                    { 271, new Guid("196d79a0-fdbe-4580-ab1b-ec900fae7b46"), "قصر قند", 9 },
                    { 280, new Guid("5c637466-8445-45b7-ad03-cf2b7978cc66"), "نگور", 9 },
                    { 281, new Guid("ebd586f5-20fc-4662-afa7-5b55da7432af"), "هيدوچ", 9 },
                    { 282, new Guid("c66f8d37-5d95-4bb0-a7a0-ac6a2bbb1086"), "پيشين", 9 },
                    { 297, new Guid("7178581e-5e34-4ab5-bdbf-2b6428b7187b"), "خوسف", 10 },
                    { 296, new Guid("fc4b98c2-74da-4699-abdd-82e46fbf65c2"), "خضري دشت بياض", 10 },
                    { 295, new Guid("553bc8f2-1cde-4276-b407-f73e95b6f1fb"), "حاجي آباد", 10 },
                    { 294, new Guid("7b36f9bb-8db5-4db7-83c9-4f3c26f0a1ee"), "بيرجند", 10 },
                    { 293, new Guid("8a59b1e8-4562-45b6-b1b7-11512dfc1aba"), "بشرويه", 10 },
                    { 292, new Guid("c003c80c-0cec-4161-8ca9-77e1f29aea28"), "اسلاميه", 10 },
                    { 291, new Guid("d3b83f13-a47a-4025-8eb1-e9eb2d6c5a2b"), "اسفدن", 10 },
                    { 290, new Guid("5c1767e7-581a-4fce-bb0d-a813ad64771c"), "اسديه", 10 },
                    { 289, new Guid("7660f20f-2664-4f9f-a8b9-0f298e28e559"), "ارسک", 10 },
                    { 288, new Guid("2590966c-bf60-496a-8868-426068bb8a93"), "آيسک", 10 },
                    { 287, new Guid("b1e3c7f2-7129-4ca6-ba2f-4dcef85d7937"), "آرين شهر", 10 },
                    { 286, new Guid("953430c3-f3a4-4313-9006-11d6537ab79e"), "گلمورتي", 9 },
                    { 285, new Guid("62636923-b9ec-4b4e-a1b7-7ba15d26feb2"), "گشت", 9 },
                    { 284, new Guid("9f292f9f-c6a3-451a-9835-f90eb9e144b0"), "کنارک", 9 },
                    { 283, new Guid("75b1343a-cabd-40cb-8411-b4f38b8b4975"), "چاه بهار", 9 },
                    { 264, new Guid("e453e7e6-18e9-4362-9869-df12f978b3c0"), "زهک", 9 },
                    { 263, new Guid("d990c57e-a3ce-43c7-9cea-2e2c46a0039b"), "زرآباد", 9 },
                    { 262, new Guid("de9e0a41-bfa8-4e52-8231-1e5fe5b47b89"), "زاهدان", 9 },
                    { 261, new Guid("d2fb1795-1723-4fc8-8f47-a2ed83551246"), "زابل", 9 },
                    { 241, new Guid("0de2546b-0d0b-4629-9be6-61be71bdc396"), "چکنه", 8 },
                    { 240, new Guid("463944b9-c191-450e-b83b-374427f807e3"), "چناران", 8 },
                    { 239, new Guid("724e6ac8-d3dd-4696-b855-f9a1e380d424"), "چاپشلو", 8 },
                    { 238, new Guid("4a99c810-cc62-45ca-83f0-af31c6dd35ef"), "يونسي", 8 },
                    { 237, new Guid("22c9b3b9-2a2d-4113-9d2b-9e55d0c95e34"), "همت آباد", 8 },
                    { 236, new Guid("70d88de0-dfb4-49ff-a971-a9f0cc68b378"), "نيل شهر", 8 },
                    { 235, new Guid("e9a3a293-994f-4428-86f3-22644a44107c"), "نيشابور", 8 },
                    { 234, new Guid("f8b58098-d614-4f3a-8c32-15a4d0c2654f"), "نوخندان", 8 },
                    { 233, new Guid("505d2eb3-237b-4dc5-99a9-cdb9b02f76a4"), "نقاب", 8 },
                    { 232, new Guid("30727e20-9b21-4875-b6d6-511ca0131ac7"), "نصرآباد", 8 },
                    { 231, new Guid("c423e506-746c-4645-b80b-7752e07df8a4"), "نشتيفان", 8 },
                    { 230, new Guid("28bb2a63-e648-43e2-bfd1-9d51660538a4"), "ملک آباد", 8 },
                    { 229, new Guid("c762a906-bc8c-483a-95e5-0f93f3480509"), "مشهدريزه", 8 },
                    { 228, new Guid("e8a58050-81e4-46f8-b849-7534bede4787"), "مشهد", 8 },
                    { 227, new Guid("b7e9cfea-d825-44c6-a348-3ac221fb2dca"), "مزدآوند", 8 },
                    { 242, new Guid("b7fca564-eadb-41fc-aaaf-1624eb622689"), "کاخک", 8 },
                    { 225, new Guid("f5525c5d-ebff-4b6d-a974-1497a3942524"), "قوچان", 8 },
                    { 243, new Guid("1c89ae4c-9b1c-4643-b17c-21b5999bcf31"), "کاريز", 8 },
                    { 245, new Guid("618d86c4-72e8-4e82-aa99-964a6fe036b6"), "کدکن", 8 },
                    { 260, new Guid("977cdc18-6d35-4737-bb86-f64bf43779b2"), "راسک", 9 },
                    { 259, new Guid("cb61b2d5-d453-4865-a3a3-e9f3dfcb8eca"), "دوست محمد", 9 },
                    { 258, new Guid("a6671e46-7d59-48d7-bf15-5c15d6d4c924"), "خاش", 9 },
                    { 257, new Guid("2378602a-6aa5-4a88-9533-9e93a0b7a3c4"), "جالق", 9 },
                    { 256, new Guid("46f0a62a-7a0b-49f0-abb6-f3e118103cd1"), "بنجار", 9 },
                    { 255, new Guid("01b3ed92-fd79-4216-814b-7ec5a23a5682"), "بنت", 9 },
                    { 254, new Guid("4a8fa136-6163-45a1-8b87-90e33620e409"), "بمپور", 9 },
                    { 253, new Guid("23542add-63b1-420b-b2fc-74be19f6ffd1"), "بزمان", 9 },
                    { 252, new Guid("b34822ff-8ec2-4f3b-92f0-3f6c3e7a20c5"), "ايرانشهر", 9 },
                    { 251, new Guid("cfe96664-5ccf-430b-a5ea-46921cf4b89f"), "اسپکه", 9 },
                    { 250, new Guid("e7466098-52f8-4b39-97f3-f28aa7db34ec"), "اديمي", 9 },
                    { 249, new Guid("e957a85d-8ee5-4e18-baea-d6a1fcd1b151"), "گناباد", 8 },
                    { 248, new Guid("08a4a647-8cef-4ed7-9f9d-9727ac6046a5"), "گلمکان", 8 },
                    { 247, new Guid("573f3396-b1d4-465b-9e15-c82c92499e34"), "کندر", 8 },
                    { 246, new Guid("652f7ef0-ebd8-4922-b4d7-bbdd140c57a2"), "کلات", 8 },
                    { 244, new Guid("091fbe89-95c5-4143-885c-ac7c339500ab"), "کاشمر", 8 },
                    { 150, new Guid("01ec3ded-2643-4717-9a17-0e46d14309ee"), "سردشت", 7 },
                    { 149, new Guid("dadb00f3-0d7d-43b9-8f42-31e099a6058b"), "زرآباد", 7 },
                    { 148, new Guid("21393cbf-769e-4050-a535-fd4fa3e710ad"), "ربط", 7 },
                    { 52, new Guid("bb087133-6765-4e8e-92da-340d04cdba27"), "هفشجان", 2 },
                    { 51, new Guid("2a0914d5-e78a-447a-bfdc-a04669373ee4"), "هاروني", 2 },
                    { 50, new Guid("4ae24d6b-d485-484f-9c62-145f80deef69"), "نقنه", 2 },
                    { 49, new Guid("a8a11eae-c9b4-4365-9f8b-887393deb92a"), "نافچ", 2 },
                    { 48, new Guid("4fb7e6f2-b0be-4cb7-8482-9d9a8fa1e6e7"), "ناغان", 2 },
                    { 47, new Guid("a93c7309-9274-43c6-a673-3134274065ac"), "منج", 2 },
                    { 53, new Guid("113f6124-6944-4b4f-bd9a-a422c9274d39"), "وردنجان", 2 },
                    { 46, new Guid("ef57b837-eb7a-4462-9719-7a1df7aafec6"), "مال خليفه", 2 },
                    { 44, new Guid("1631b72b-15b3-4347-9e8c-8b7da199ac5a"), "فرخ شهر", 2 },
                    { 43, new Guid("b4fd66b5-8f77-4a55-b502-99b880987c05"), "فرادنبه", 2 },
                    { 42, new Guid("a7017bea-df7a-48e0-ae58-803042c8a83c"), "فارسان", 2 },
                    { 41, new Guid("dbf5e809-4fb4-4a3a-962a-ab5062b9bfd4"), "طاقانک", 2 },
                    { 40, new Guid("96780cb8-f1c7-4cd0-a3ef-3d1669ac50b8"), "صمصامي", 2 },
                    { 39, new Guid("d97a8996-93e7-4d59-9d0b-5b905011fbf8"), "شهرکرد", 2 },
                    { 45, new Guid("bbd0e2ff-8cf0-4662-85a8-ee2cea1b959c"), "لردگان", 2 },
                    { 54, new Guid("b0994d48-1f80-424c-92ab-373b6d76d2e8"), "پردنجان", 2 },
                    { 55, new Guid("0f37863b-5c6c-4ab6-b7dc-52271545ce4b"), "چليچه", 2 },
                    { 56, new Guid("85965003-aa57-4eca-a82c-e9dfe84a2625"), "چلگرد", 2 },
                    { 71, new Guid("da72052a-2d55-42d9-979c-b65c7996421e"), "راز", 3 },
                    { 70, new Guid("4d14825c-45e7-42d7-9d18-b915c5bcadf4"), "درق", 3 },
                    { 69, new Guid("43296747-05ac-4e99-9129-3d5abb3a3632"), "حصارگرمخان", 3 },
                    { 68, new Guid("61ba13d1-e22e-47c6-8ea1-3015efdf5e47"), "جاجرم", 3 },
                    { 67, new Guid("5043a3e2-5152-4fbf-b4dd-ca0b33757320"), "تيتکانلو", 3 },
                    { 66, new Guid("8a4f5b0b-5eeb-41d5-a464-64ce05083941"), "بجنورد", 3 },
                    { 65, new Guid("03b9d83e-0790-46b8-998d-8d67fdf889a9"), "ايور", 3 },
                    { 64, new Guid("96ed16c1-ef57-4fa9-b786-3805174d1a72"), "اسفراين", 3 },
                    { 63, new Guid("351c27aa-cfc1-46d7-8dfb-30defd99aec0"), "آوا", 3 },
                    { 62, new Guid("b4d135f7-e7ed-46ff-b423-cdb3bd6f93d7"), "آشخانه", 3 },
                    { 61, new Guid("d1508641-a07e-48ed-a486-31d912665701"), "گوجان", 2 },
                    { 60, new Guid("2893c6b2-68be-4aa0-b39b-1420ffcc03c8"), "گهرو", 2 },
                    { 59, new Guid("a2021314-1f5b-42d5-bd7e-b5e98fe4a5a8"), "گندمان", 2 },
                    { 58, new Guid("defc163d-b5e2-488c-b9b5-f01e16285533"), "کيان", 2 },
                    { 57, new Guid("1d94e366-bf4b-443d-90aa-6f6bc668f080"), "کاج", 2 },
                    { 38, new Guid("ebff5bf9-740c-4a9d-9e13-59ebf7be7295"), "شلمزار", 2 },
                    { 37, new Guid("1a400c05-f6ef-4f54-8064-2d0d6f6768aa"), "سورشجان", 2 },
                    { 36, new Guid("ae228b8d-653c-47c1-8ac7-5559c236dec3"), "سودجان", 2 },
                    { 35, new Guid("6e51d1f6-2499-4d05-a794-b9716b887e3c"), "سفيد دشت", 2 },
                    { 15, new Guid("c87e0cd1-f0e8-4920-9f53-2cb8f3dd33fe"), "مهردشت", 1 },
                    { 14, new Guid("24e9a31d-110e-4939-a821-e9cf6ab46e2c"), "مروست", 1 },
                    { 13, new Guid("603192bd-c708-4aea-a627-560d9c4a0f75"), "عقدا", 1 },
                    { 12, new Guid("8216601f-b1cd-4d1f-a301-1ecf4f30ef9f"), "شاهديه", 1 },
                    { 11, new Guid("a3bfaea4-2a78-423e-b0ee-d8d5eedc7252"), "زارچ", 1 },
                    { 10, new Guid("bdb48125-1717-4664-9bdd-509a2c0ba4cb"), "خضر آباد", 1 },
                    { 9, new Guid("a46aa8d8-ed27-4538-beed-609eba1885af"), "حميديا", 1 },
                    { 8, new Guid("66b17d87-c55b-42e3-b82c-7fd465bcd1d4"), "تفت", 1 },
                    { 7, new Guid("14f99a6c-6f66-449d-a0e6-4766f44f575b"), "بهاباد", 1 },
                    { 6, new Guid("e6113edf-b650-41d5-b7bb-b42480a54451"), "بفروئيه", 1 },
                    { 5, new Guid("ad0d46bd-03e4-4f93-bcca-0bcbb282c031"), "بافق", 1 },
                    { 4, new Guid("c2fc2f42-e836-4592-b030-f08b86b9d7f3"), "اشکذر", 1 },
                    { 3, new Guid("fd133b11-1e7e-4a0e-8eca-655aa57e526b"), "اردکان", 1 },
                    { 2, new Guid("d897ce71-92e4-4703-a7ed-9932bb433dbb"), "احمد آباد", 1 },
                    { 1, new Guid("583e4e2c-6b34-4e20-8652-ad2e560de048"), "ابرکوه", 1 },
                    { 16, new Guid("df2fbd63-1a9e-499e-a2f9-6c67ccb77fb3"), "مهريز", 1 },
                    { 72, new Guid("be2377a0-50c8-48a8-9e17-0a0ccf36af2b"), "زيارت", 3 },
                    { 17, new Guid("9c136e2a-5139-437a-8c91-2dd68c801b0a"), "ميبد", 1 },
                    { 19, new Guid("3b331dd5-2154-4aa7-9b75-e436ec7fc86a"), "نير", 1 },
                    { 34, new Guid("eaaa9a7d-d226-46f6-8faa-1791f39927b5"), "سردشت لردگان", 2 },
                    { 33, new Guid("dc1ed9e8-a6ff-4bd9-a45b-a39b255d1e1e"), "سرخون", 2 },
                    { 32, new Guid("c134c254-726e-4c71-87b7-c28791b1a962"), "سامان", 2 },
                    { 31, new Guid("56b84205-9e83-443e-baef-5da318580dda"), "دشتک", 2 },
                    { 30, new Guid("dbf8f2e6-df82-415d-affd-9e09f3614c4a"), "دستناء", 2 },
                    { 29, new Guid("42191da4-573e-478d-92a6-ea0ce68f8765"), "جونقان", 2 },
                    { 28, new Guid("61a62d6c-d416-4984-b1c1-46eed3d26c11"), "بن", 2 },
                    { 27, new Guid("5acedfe2-c0f2-4bbc-ac15-2297d5122f45"), "بلداجي", 2 },
                    { 26, new Guid("3ed3deff-6e3c-4f61-8335-af2b233135e8"), "بروجن", 2 },
                    { 25, new Guid("c82fb536-6ee8-4985-92fe-916272fa4479"), "بازفت", 2 },
                    { 24, new Guid("6b320957-8591-46ea-bf25-d67bff549795"), "باباحيدر", 2 },
                    { 23, new Guid("3de4491b-342c-473a-a849-b8af710f6167"), "اردل", 2 },
                    { 22, new Guid("b063a21f-de64-41e9-8961-5dcfc99ae473"), "آلوني", 2 },
                    { 21, new Guid("bc117319-a23e-47cb-a5a5-d714d93e1f0b"), "يزد", 1 },
                    { 20, new Guid("5a47d7d6-52b8-4c23-87a4-a23f5598a214"), "هرات", 1 },
                    { 18, new Guid("6fcbc440-9de0-49dc-9154-46e8e4598dcc"), "ندوشن", 1 },
                    { 73, new Guid("c7731b40-dc00-4275-86d6-01d2f1d7a0ca"), "سنخواست", 3 },
                    { 74, new Guid("bc169420-d777-448b-bc63-c4702bb42521"), "شوقان", 3 },
                    { 75, new Guid("b9430db7-610d-41b6-8c00-1c9920f522a7"), "شيروان", 3 },
                    { 128, new Guid("987d9ba4-0e4b-4d8b-8a2d-a25e0d6a76e4"), "مريوان", 6 },
                    { 127, new Guid("fe4019de-13fe-4790-9821-9f942fcaea61"), "قروه", 6 },
                    { 126, new Guid("86c66004-5e04-4a85-929c-ad6d8b8396da"), "صاحب", 6 },
                    { 125, new Guid("a75ba234-33d3-41ff-8550-c0df67b99092"), "شويشه", 6 },
                    { 124, new Guid("a86f9630-6011-475f-bb6d-83f73363072b"), "سنندج", 6 },
                    { 123, new Guid("ab11cde9-d364-46c5-9229-9ade9616d5b8"), "سقز", 6 },
                    { 122, new Guid("19505638-b7f4-41b0-b655-3d8a5c920391"), "سريش آباد", 6 },
                    { 121, new Guid("ba76a3fb-3e0d-4da0-b9c1-3fc57588189b"), "سرو آباد", 6 },
                    { 120, new Guid("3cad6c7b-f7e6-4200-b749-1d8d735432ce"), "زرينه", 6 },
                    { 119, new Guid("206ce1e6-b498-41ec-8140-a1aa210fbb99"), "ديواندره", 6 },
                    { 118, new Guid("48ef79a4-d4eb-4073-a41b-f4d8d0a9ce4f"), "دهگلان", 6 },
                    { 117, new Guid("93d005df-b9b7-4aba-a42a-a5e5ce2539f0"), "دلبران", 6 },
                    { 116, new Guid("fd4160ba-f568-49ab-9ffb-109fd6cdadce"), "دزج", 6 },
                    { 115, new Guid("016c0ebf-36bb-45b2-b053-3da63d7c793b"), "توپ آغاج", 6 },
                    { 114, new Guid("da8c22fa-ebf8-4f32-a09e-15654ea500a5"), "بيجار", 6 },
                    { 129, new Guid("584ddc2e-6724-4f7c-a5f3-7993a7b443a8"), "موچش", 6 },
                    { 113, new Guid("ae1acac1-bb24-4985-aed1-1e0538c3d971"), "بوئين سفلي", 6 },
                    { 130, new Guid("5d82ea3d-3ba4-46c1-8d0d-0f556e58a8c0"), "ياسوکند", 6 },
                    { 132, new Guid("355631ce-7371-4814-945d-489d0cc86c2f"), "چناره", 6 },
                    { 147, new Guid("f5863a62-9842-4b5d-865e-ec8ff211c848"), "ديزج ديز", 7 },
                    { 146, new Guid("5c30ff89-f60d-46b0-a773-be08f5a010d8"), "خوي", 7 },
                    { 145, new Guid("81effac8-dcca-43cf-96f6-e7376a359a6b"), "خليفان", 7 },
                    { 144, new Guid("74fb7d5c-9ef1-4e5a-91dd-23abc4604254"), "تکاب", 7 },
                    { 143, new Guid("2aec1241-7161-441c-b94c-8b8981f58d19"), "تازه شهر", 7 },
                    { 142, new Guid("8f346500-d8ab-416c-8df0-161490e0a95e"), "بوکان", 7 },
                    { 141, new Guid("615929e6-c620-449c-b7e6-16483e330fa0"), "بازرگان", 7 },
                    { 140, new Guid("11a95576-be0e-42b5-87d4-9a253bca8a57"), "باروق", 7 },
                    { 139, new Guid("9d0686dc-ea7e-4d02-91aa-bee8188840b5"), "ايواوغلي", 7 },
                    { 138, new Guid("43273a8a-d2ee-45e5-b4e4-b6f1f45c5fe4"), "اشنويه", 7 },
                    { 137, new Guid("f76b819d-a6bf-43d6-b3d8-35ec13263d3f"), "اروميه", 7 },
                    { 136, new Guid("2f32760b-c5b0-463c-9f22-cafab8a1639e"), "آواجيق", 7 },
                    { 135, new Guid("fccb761e-210a-48c7-8ca2-8ab22c1ff92f"), "کاني سور", 6 },
                    { 134, new Guid("db9c49b8-0b8d-4e5b-9251-1d2153e14726"), "کاني دينار", 6 },
                    { 133, new Guid("7433acaa-770b-45e6-a67a-f71b9ec96a1f"), "کامياران", 6 },
                    { 131, new Guid("ef4a8818-6c5e-4d7b-b4a3-21f0b8af1517"), "پيرتاج", 6 },
                    { 298, new Guid("2948a86f-0e3a-4cce-b545-356e30aef97e"), "ديهوک", 10 },
                    { 112, new Guid("479ca322-8e17-4d72-9ca0-2eacc8e05216"), "بلبان آباد", 6 },
                    { 110, new Guid("a37d139a-3c9f-4490-b0a0-517a86dffcc0"), "بانه", 6 },
                    { 90, new Guid("32a2e7a8-b577-4541-9be4-b7386f40d129"), "ماهدشت", 4 },
                    { 89, new Guid("a2a8ab85-9921-42c0-9b27-4cedd374c488"), "فرديس", 4 },
                    { 88, new Guid("df1d4fb2-7f0e-4388-80ff-1abde94dd32f"), "طالقان", 4 },
                    { 87, new Guid("60637610-cbbc-4e12-8b1b-f86edbe07ed8"), "شهر جديد هشتگرد", 4 },
                    { 86, new Guid("a87fd495-d402-44bb-a7ba-09040d5eff90"), "تنکمان", 4 },
                    { 85, new Guid("3cdf2370-2688-4235-8822-8bec1c4ca401"), "اشتهارد", 4 },
                    { 84, new Guid("93dc5b4d-0072-4dad-867a-001539130d43"), "آسارا", 4 },
                    { 83, new Guid("4d092699-b1a5-446d-b512-16f415af8562"), "گرمه", 3 },
                    { 82, new Guid("62474b8b-936b-4afc-8f0c-642e1a4a3f52"), "چناران شهر", 3 },
                    { 81, new Guid("6da1b7e7-7a2b-47a2-b176-85850a2d8658"), "پيش قلعه", 3 },
                    { 80, new Guid("513031d3-b56c-4578-833e-ad6afb068c67"), "لوجلي", 3 },
                    { 79, new Guid("ab113653-cf11-4b4b-8881-1e7abac5bb37"), "قوشخانه", 3 },
                    { 78, new Guid("1e30db89-55d0-4110-9f3e-3dc74bbeaeb5"), "قاضي", 3 },
                    { 77, new Guid("895e8644-68c1-4180-bb18-20e2b3fa57d3"), "فاروج", 3 },
                    { 76, new Guid("ad36ab8c-43c8-4f5a-9de3-1034c3918752"), "صفي آباد", 3 },
                    { 91, new Guid("e70a331b-7c4f-4f58-a715-3bc68da3aeec"), "محمد شهر", 4 },
                    { 111, new Guid("01fcf226-99cd-400e-986e-d868acfe6924"), "برده رشه", 6 },
                    { 92, new Guid("a6aa1d68-0161-4e1b-9d06-138c417afbd1"), "مشکين دشت", 4 },
                    { 94, new Guid("27a05be2-346e-4799-a880-7c3dffbee783"), "هشتگرد", 4 },
                    { 109, new Guid("70241acb-f801-4588-9833-a20e542f6377"), "بابارشاني", 6 },
                    { 108, new Guid("12d94fc4-dd27-4fa2-8f5d-6944695fe661"), "اورامان تخت", 6 },
                    { 107, new Guid("1486159e-b2ac-495f-ab4b-a226f8fb2cbe"), "آرمرده", 6 },
                    { 106, new Guid("c5fe17a6-3332-4de6-9a88-e4b5b85afa4f"), "کهک", 5 },
                    { 105, new Guid("bb5d2100-35db-487b-868e-d12fddf19a55"), "قنوات", 5 },
                    { 104, new Guid("ec7d4b27-2bec-496c-8330-15cdc910aaaa"), "قم", 5 },
                    { 103, new Guid("b6018844-00ae-4198-901a-932bd8a7172f"), "سلفچگان", 5 },
                    { 102, new Guid("0c764bde-7c36-4b3c-9421-a4052023ed90"), "دستجرد", 5 },
                    { 101, new Guid("8275b54a-d7f8-4f15-9011-b2663d09307d"), "جعفريه", 5 },
                    { 100, new Guid("07f3e9b3-f441-46ee-9504-115455088a5d"), "گلسار", 4 },
                    { 99, new Guid("451290f5-3cb4-4069-af93-b88fda799214"), "گرمدره", 4 },
                    { 98, new Guid("d22c33d0-6db2-48d0-a265-7124a9966f2b"), "کوهسار", 4 },
                    { 97, new Guid("cf5dd4af-521e-4140-8116-e55b8742d0b2"), "کمال شهر", 4 },
                    { 96, new Guid("8faf1e6e-a282-41b1-b946-9c95659432f0"), "کرج", 4 },
                    { 95, new Guid("0f902c7c-4a72-419f-82f1-bd17cddeec8c"), "چهارباغ", 4 },
                    { 93, new Guid("88a03185-30c0-4658-9d34-7881018c0966"), "نظر آباد", 4 },
                    { 299, new Guid("3602322a-f121-4bff-a8d5-1f1983f650bb"), "زهان", 10 },
                    { 279, new Guid("38efc4da-b7ca-4902-97a0-84d0de62db29"), "نيک شهر", 9 },
                    { 301, new Guid("62e6d568-d162-451a-93f9-aa1913b74ee4"), "سربيشه", 10 },
                    { 504, new Guid("228f6d0a-de7e-4ece-9cf1-bff9fb161aa5"), "سورک", 15 },
                    { 503, new Guid("40668411-3779-474c-a9dd-b8e25345c689"), "سلمان شهر", 15 },
                    { 502, new Guid("cfdcb563-0f13-43ef-9477-19fcbf4b09c5"), "سرخرود", 15 },
                    { 501, new Guid("d7d010fd-87ad-43c7-b867-5bc674f6a817"), "ساري", 15 },
                    { 500, new Guid("9292f062-2e05-4d21-85e9-8260f3da826a"), "زيرآب", 15 },
                    { 499, new Guid("a199388e-b891-4be4-9684-3956176da1db"), "زرگر محله", 15 },
                    { 505, new Guid("596b9dea-8fa3-4c66-8de9-debaa6399f20"), "شيرود", 15 },
                    { 498, new Guid("9778cd11-89f6-467f-ab50-b7c1efe715dd"), "رينه", 15 },
                    { 496, new Guid("c63b0b87-5ca5-4342-9048-c042fadd50c7"), "رستمکلا", 15 },
                    { 495, new Guid("bab4b0ee-d101-4fb9-b9a3-8b6e160fa8dd"), "رامسر", 15 },
                    { 494, new Guid("23eb3b99-6db2-4b08-9ff4-c676e77b9f92"), "دابودشت", 15 },
                    { 493, new Guid("fb915d97-108a-497f-b348-f7436c61c143"), "خوش رودپي", 15 },
                    { 492, new Guid("a0c2b184-9714-4865-9e1b-3b197f742df7"), "خليل شهر", 15 },
                    { 491, new Guid("cae628cd-6c2e-44ee-b2ad-e4fd58ce2e96"), "خرم آباد", 15 },
                    { 497, new Guid("7fff691d-b26e-4499-ae94-3dc8cce7251a"), "رويان", 15 },
                    { 506, new Guid("02c957d2-d4a6-4bf1-9c44-fe6953cbb57a"), "شيرگاه", 15 },
                    { 507, new Guid("999fe43d-6d44-46cf-b311-caf07d431413"), "عباس آباد", 15 },
                    { 508, new Guid("77d772cd-4d45-4b59-92d4-72e18abcee7e"), "فريدونکنار", 15 },
                    { 523, new Guid("630cf8cb-b22d-4574-a179-180496deb240"), "چالوس", 15 },
                    { 522, new Guid("283cefa4-3ba4-4047-be87-f912a9f45742"), "پول", 15 },
                    { 521, new Guid("29426f54-602f-4cf1-bae5-dc7117f0f1c4"), "پل سفيد", 15 },
                    { 520, new Guid("5ab351ec-d99c-439d-a459-2d6441edc41d"), "پايين هولار", 15 },
                    { 519, new Guid("c9b10a7b-1fb1-418c-946c-6aff0987b333"), "هچيرود", 15 },
                    { 518, new Guid("6d229849-6f41-4a68-8d8f-4f05dc79f857"), "هادي شهر", 15 },
                    { 517, new Guid("8f65396a-4821-46cb-9305-bd483f8b32c8"), "نکا", 15 },
                    { 516, new Guid("110d39e5-31ff-4abd-917c-da24e87576ec"), "نوشهر", 15 },
                    { 515, new Guid("6a9b341b-ad22-4085-9560-78962b503ff0"), "نور", 15 },
                    { 514, new Guid("50e59369-1b1c-40a6-9f45-c09b143e3293"), "نشتارود", 15 },
                    { 513, new Guid("c8b22e6f-310c-4bf3-b2e5-c1acd3a04e60"), "مرزيکلا", 15 },
                    { 512, new Guid("1dab940c-90d9-433a-8776-76694b5d1a2b"), "مرزن آباد", 15 },
                    { 511, new Guid("a7a9b189-77d6-4ca4-94f0-49743f1643f1"), "محمود آباد", 15 },
                    { 510, new Guid("74d15de1-d710-49e1-9418-eb6d4da17ee6"), "قائم شهر", 15 },
                    { 509, new Guid("6bd87c88-b012-4326-a8a0-4e4e4bb4cd6f"), "فريم", 15 },
                    { 490, new Guid("ed0e0c7d-7779-474a-8658-599419bb221f"), "جويبار", 15 },
                    { 489, new Guid("78d3d882-96ef-4acd-b9d9-46305085e6c1"), "تنکابن", 15 },
                    { 488, new Guid("297a80c4-8212-4294-847d-60ac08fbd666"), "بهنمير", 15 },
                    { 487, new Guid("06859385-6a04-4d21-9bed-ba280a8fc8a8"), "بهشهر", 15 },
                    { 467, new Guid("82733161-ba54-4300-8896-0fdc19547fcf"), "مزرعه", 14 },
                    { 466, new Guid("26c6428e-4bed-4728-8561-4c67ee555f1d"), "مراوه تپه", 14 },
                    { 465, new Guid("2fac46c4-1912-48b7-9b8d-d8d3c7aa1ec3"), "فراغي", 14 },
                    { 464, new Guid("cc958916-4cb7-4ed6-bc10-a662bbf1f929"), "فاضل آباد", 14 },
                    { 463, new Guid("003719e0-c30e-427e-834e-6bf2c37ae427"), "علي آباد", 14 },
                    { 462, new Guid("88eb5e79-75dd-4614-ba76-4adb1105f586"), "سيمين شهر", 14 },
                    { 461, new Guid("33a02e66-1ce3-4a15-af1e-1dc5f30812a0"), "سنگدوين", 14 },
                    { 460, new Guid("11e4d018-643f-4268-9bc3-a8966d02c162"), "سرخنکلاته", 14 },
                    { 459, new Guid("ea5e58b2-ea08-4284-94db-039a4c6918e1"), "راميان", 14 },
                    { 458, new Guid("c56f340a-f4d7-46c0-a80a-55c83b643f36"), "دلند", 14 },
                    { 457, new Guid("4e6107bb-d3d6-48f9-959e-8c52079c7ca0"), "خان ببين", 14 },
                    { 456, new Guid("422b1bb4-bd52-4bd4-8f43-19b801a902e2"), "جلين", 14 },
                    { 455, new Guid("f6f8009a-c5fb-4fdb-b566-24e6309ad114"), "تاتار عليا", 14 },
                    { 454, new Guid("68614ec3-cb7d-4782-8bc1-7273afc73633"), "بندر گز", 14 },
                    { 453, new Guid("b104244a-1532-4aa5-b918-e10662aa5ad2"), "بندر ترکمن", 14 },
                    { 468, new Guid("f9bd27fa-421b-4830-97a8-d25f12d713b5"), "مينودشت", 14 },
                    { 524, new Guid("a7424904-5f6f-4963-913a-c9889cda4631"), "چمستان", 15 },
                    { 469, new Guid("2b20372a-9f41-46de-b077-af46323aa324"), "نوده خاندوز", 14 },
                    { 471, new Guid("1d77237e-c43c-47bb-a5c5-2214c1948637"), "نگين شهر", 14 },
                    { 486, new Guid("1bc9f4c7-af75-414b-aff4-91c67a2cb88c"), "بلده", 15 },
                    { 485, new Guid("60216be5-bbf8-4db2-9af3-7721e7f2fde9"), "بابلسر", 15 },
                    { 484, new Guid("69e0ffe0-79f1-4293-948d-04dcaf39bcca"), "بابل", 15 },
                    { 483, new Guid("f81a9a5b-7eb7-4f10-9bd9-8a08d05f5be0"), "ايزد شهر", 15 },
                    { 482, new Guid("c191d478-62fb-433d-93de-251846e8c0e1"), "امير کلا", 15 },
                    { 481, new Guid("b6742996-9f0e-4949-9432-0e46233a7b9c"), "امامزاده عبدالله", 15 },
                    { 480, new Guid("ece7acb9-9364-4fc6-b168-ee96b524120e"), "ارطه", 15 },
                    { 479, new Guid("0530eb0e-7d8c-442a-8ddc-4f92e690538c"), "آمل", 15 },
                    { 478, new Guid("9e54b389-da55-493b-8a41-8386aa1d7065"), "آلاشت", 15 },
                    { 477, new Guid("f762cfb2-674c-4e27-bbc7-ebb0d13fde3c"), "گنبدکاووس", 14 },
                    { 476, new Guid("551ed478-6247-403e-a05a-bbe7180af6a8"), "گميش تپه", 14 },
                    { 475, new Guid("ddd148a2-b485-4421-9b50-3b2fecc012bd"), "گرگان", 14 },
                    { 474, new Guid("049f1a1e-f925-48ab-9a46-74d9dee8586f"), "گاليکش", 14 },
                    { 473, new Guid("6452a533-171a-4c08-900c-6e5e3159bb23"), "کلاله", 14 },
                    { 472, new Guid("033aeaaa-0129-464e-93f6-0f4d5b17c500"), "کرد کوي", 14 },
                    { 300, new Guid("22356b2d-a913-4c42-a038-aaa409dd93b2"), "سرايان", 10 },
                    { 452, new Guid("334ef62b-a93f-498d-a55a-ab3d457f2407"), "اينچه برون", 14 },
                    { 525, new Guid("307a5dc2-805e-4c5e-8ae6-b2308ce7d0f8"), "کتالم و سادات شهر", 15 },
                    { 527, new Guid("2d9e86ea-91d4-4229-849e-db2b540d7095"), "کلارآباد", 15 },
                    { 579, new Guid("1c71a6ac-2a8b-4cdf-b724-afb999e228b1"), "پلدختر", 17 },
                    { 578, new Guid("993730fc-97ca-4f8e-8232-733b77eacf87"), "ويسيان", 17 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "CityGUID", "Name", "ProvinceID" },
                values: new object[,]
                {
                    { 577, new Guid("88e02315-3b15-4aa2-afad-6da41f04316d"), "هفت چشمه", 17 },
                    { 576, new Guid("189482c9-f7d4-4e1c-beda-ec5fc1b2a047"), "نورآباد", 17 },
                    { 575, new Guid("ef892aa0-dd60-493a-89c7-b04fea8d8c5b"), "مومن آباد", 17 },
                    { 574, new Guid("f2cc426a-d655-4175-bafb-430b54cefcef"), "معمولان", 17 },
                    { 580, new Guid("0531583c-c1f9-48da-a55b-57171e511860"), "چالانچولان", 17 },
                    { 573, new Guid("dd621a88-d555-43ef-a4d0-1c614e51751f"), "فيروزآباد", 17 },
                    { 571, new Guid("3ffed6a5-b4a4-49df-bfa5-18d709896839"), "سپيد دشت", 17 },
                    { 570, new Guid("39157780-3174-4d2a-aad8-606ad95b9a53"), "سراب دوره", 17 },
                    { 569, new Guid("f7b37ec1-986b-45b8-98b1-9a5b36dc48d3"), "زاغه", 17 },
                    { 568, new Guid("bc0a697b-79ea-422e-954f-cea303780398"), "دورود", 17 },
                    { 567, new Guid("435b2ea6-570e-47e2-8f1a-3d052d07cb06"), "درب گنبد", 17 },
                    { 566, new Guid("b0da02be-3377-4bb5-a64f-0eac7d551615"), "خرم آباد", 17 },
                    { 572, new Guid("1b669085-32a6-4c17-90c4-a96a46cd5f23"), "شول آباد", 17 },
                    { 581, new Guid("ea398087-228a-4fc0-a8d8-6eb415419d07"), "چقابل", 17 },
                    { 582, new Guid("c03bc7df-6633-4c84-91b6-003afc21eee4"), "کوهدشت", 17 },
                    { 583, new Guid("e613e13a-14ac-4924-92c1-3cc64bda28d6"), "کوهناني", 17 },
                    { 598, new Guid("3a0cc51e-d9ab-4573-af60-64843c1060db"), "قصابه", 18 },
                    { 1241, new Guid("68bf4b80-68a7-4a51-b349-74d8c6437c2a"), "گراب سفلي", 31 },
                    { 596, new Guid("89a62024-bc3d-4ea3-bf56-5e59e887741e"), "عنبران", 18 },
                    { 595, new Guid("def21bb6-b30e-4bc8-a56d-861c03ce5fda"), "سرعين", 18 },
                    { 594, new Guid("7e30e854-6875-40c1-b22a-e93ef9f96b88"), "رضي", 18 },
                    { 593, new Guid("0b5d721d-368f-4499-a2a0-503b768effa6"), "خلخال", 18 },
                    { 592, new Guid("4d0f4a09-5177-4d13-88a3-7f5354a0652e"), "جعفر آباد", 18 },
                    { 591, new Guid("96c59cff-578a-4e38-9c63-08acd14d277b"), "تازه کند انگوت", 18 },
                    { 590, new Guid("e865bfdd-b156-4519-8e4f-3c24ad72ed97"), "تازه کند", 18 },
                    { 589, new Guid("cfce6de8-7040-4d2b-a9ce-dece33bdc2cd"), "بيله سوار", 18 },
                    { 588, new Guid("63030f01-a237-48e9-9e30-a483a03d408f"), "اصلاندوز", 18 },
                    { 587, new Guid("5e1e9b22-7a15-475d-b57e-df74e5516491"), "اسلام آباد", 18 },
                    { 586, new Guid("2f24de4b-35a5-4cd9-9c0b-206bbf544d58"), "اردبيل", 18 },
                    { 585, new Guid("ee82e431-e8e4-4cfa-872f-49df52884f21"), "آبي بيگلو", 18 },
                    { 584, new Guid("1593dcff-5c7a-4125-aed8-c7c6bf200cf8"), "گراب", 17 },
                    { 565, new Guid("01db7a77-fb62-4175-900b-58ecad73755c"), "بيرانشهر", 17 },
                    { 564, new Guid("1da1e2f4-ebda-4c8a-87e7-f439462dc675"), "بروجرد", 17 },
                    { 563, new Guid("40e51a0e-80ea-4f15-84e2-f316ffcca733"), "اليگودرز", 17 },
                    { 562, new Guid("5ac54026-f166-4875-85de-151a77e55718"), "الشتر", 17 },
                    { 542, new Guid("e0f010d8-d1d4-41f3-8bb4-430af7bed7ee"), "بوئين زهرا", 16 },
                    { 541, new Guid("5059cb77-e988-4be3-be32-cebb8f0d9af4"), "الوند", 16 },
                    { 540, new Guid("a32b8715-c997-4b74-b4ce-7300ff577a6d"), "اقباليه", 16 },
                    { 539, new Guid("09197062-c7f5-4adf-b832-e9f9f1fd03f3"), "اسفرورين", 16 },
                    { 538, new Guid("3270a9da-8e32-45a1-841a-40132a4c6716"), "ارداق", 16 },
                    { 537, new Guid("1cb34c1a-40e1-42af-840a-1964e59e8455"), "آوج", 16 },
                    { 536, new Guid("0fccd533-6f00-4f34-b637-b7937ba3c916"), "آبگرم", 16 },
                    { 535, new Guid("83b4432f-2f60-4b9c-a094-769c5cc4cddb"), "آبيک", 16 },
                    { 534, new Guid("bd76c846-5fbe-4316-8e32-7d4850ef264b"), "گلوگاه", 15 },
                    { 533, new Guid("0aa6b87b-191b-496d-92bc-eab15ad8555d"), "گزنک", 15 },
                    { 532, new Guid("ff945318-9627-40c0-ad6c-c337bc2c9a5c"), "گتاب", 15 },
                    { 531, new Guid("7aab40d1-bb4a-41cb-b716-4d630c50ee17"), "کياکلا", 15 },
                    { 530, new Guid("93d88a52-3dce-4d07-80af-e288276aad4d"), "کياسر", 15 },
                    { 529, new Guid("0feed3d4-0bec-4647-8876-1ab60607dc73"), "کوهي خيل", 15 },
                    { 528, new Guid("399fe7a0-7038-4bdd-a518-003baf8f15b8"), "کلاردشت", 15 },
                    { 543, new Guid("e4680093-350d-40ff-a449-173a9fa3a14d"), "بيدستان", 16 },
                    { 526, new Guid("7633899d-f80a-4453-a7cc-35828972fa7b"), "کجور", 15 },
                    { 544, new Guid("b5dec4c1-8567-478c-83e0-c822cb15473c"), "تاکستان", 16 },
                    { 546, new Guid("d85ebd8f-f529-4d44-b86e-3281d676209a"), "خرمدشت", 16 },
                    { 561, new Guid("1b5991b1-627a-4769-931c-55e10e077db3"), "اشترينان", 17 },
                    { 560, new Guid("af16ad07-e959-47e4-b461-c8d91403452b"), "ازنا", 17 },
                    { 559, new Guid("acbe9caf-6bea-4c7f-88b8-25a784057179"), "کوهين", 16 },
                    { 558, new Guid("276e8771-f406-4648-8d35-4830ef9764b1"), "نرجه", 16 },
                    { 557, new Guid("fcd63d6f-c998-4486-89c4-1bb40ed06e58"), "معلم کلايه", 16 },
                    { 556, new Guid("b52bfab2-96cd-4a38-a43f-ca0a2bc2d851"), "محمود آباد نمونه", 16 },
                    { 555, new Guid("23a94e56-52ad-4eb3-bda6-2035540fb253"), "محمديه", 16 },
                    { 554, new Guid("e8e9500d-169f-452b-bc90-245e5f8058f1"), "قزوين", 16 },
                    { 553, new Guid("e41b7291-2c6b-4f39-bf4b-42e475dee7b6"), "ضياء آباد", 16 },
                    { 552, new Guid("e6c0ba31-337b-44c9-96ae-fab3bb0ca042"), "شريفيه", 16 },
                    { 551, new Guid("8fe48baf-f6d7-490f-961a-df5e464a35a5"), "شال", 16 },
                    { 550, new Guid("9868967b-9b23-4141-9c3e-e69e17a659d9"), "سگز آباد", 16 },
                    { 549, new Guid("64930c19-c03f-47bd-8c3e-fed70e9012a4"), "سيردان", 16 },
                    { 548, new Guid("0d998e8c-3b87-4ad7-afcd-0f50138287aa"), "رازميان", 16 },
                    { 547, new Guid("8a0d90c7-c9bf-421e-a1dc-5c8bb59c5770"), "دانسفهان", 16 },
                    { 545, new Guid("0de258a6-774f-4626-8ba6-3290365804d8"), "خاکعلي", 16 },
                    { 451, new Guid("d1f60600-9021-4c6f-b4b5-bad6543bd472"), "انبار آلوم", 14 },
                    { 470, new Guid("be17b12d-4bf3-449f-aa4b-170d0f66c95a"), "نوکنده", 14 },
                    { 449, new Guid("ccdac3a7-0100-4ce9-bf23-fb5c323117c0"), "آزاد شهر", 14 },
                    { 353, new Guid("4e63a317-e6ab-4504-9bfb-9d23a346083c"), "سماله", 11 },
                    { 352, new Guid("b7ba563d-5eb2-4d91-ba98-bedc68dae196"), "سردشت", 11 },
                    { 351, new Guid("9dc53911-da3e-4338-ac15-f0fd21aff958"), "سرداران", 11 },
                    { 350, new Guid("ce1aad0e-e5c5-4378-a73b-d8daf5ae17a6"), "سالند", 11 },
                    { 349, new Guid("495522dd-8a95-455d-91f9-299f9611149f"), "زهره", 11 },
                    { 348, new Guid("034f9f36-3a32-44f2-a91f-6d63bd00fc45"), "رفيع", 11 },
                    { 354, new Guid("768ea9da-5baa-4db9-b36f-a58413614442"), "سوسنگرد", 11 },
                    { 347, new Guid("809eb581-9c1a-4091-9f26-1f3017f0aea3"), "رامهرمز", 11 },
                    { 345, new Guid("75a194d8-55c8-4cb2-8061-cf64b6658df5"), "دهدز", 11 },
                    { 344, new Guid("b9b07ff6-2684-49e4-82bf-4bc1252636cb"), "دزفول", 11 },
                    { 343, new Guid("36adbb6f-85a9-4a8d-b80f-32bb78cb44e0"), "دارخوين", 11 },
                    { 342, new Guid("7ca0e4fa-8488-4c1b-98cb-ab829a9ececc"), "خنافره", 11 },
                    { 341, new Guid("c4690497-1e4f-45a9-bc7e-82ff53257953"), "خرمشهر", 11 },
                    { 340, new Guid("e952f398-5643-4be8-8353-f529331d9b60"), "حميديه", 11 },
                    { 346, new Guid("1537de17-cddc-4a8b-bc2d-4e358e859e4b"), "رامشير", 11 },
                    { 450, new Guid("2abd4e7d-4c0c-4b2b-a2d1-5afa752ee7bb"), "آق قلا", 14 },
                    { 356, new Guid("ed00d617-ef18-48f0-b035-149d411b68c3"), "شادگان", 11 },
                    { 357, new Guid("78c61600-6cf3-4f81-a091-cd8ecc1337ab"), "شاوور", 11 },
                    { 372, new Guid("c6e40d09-fffd-4393-9b1c-8785639186b2"), "مشراگه", 11 },
                    { 371, new Guid("4ee4efb8-4fdf-488c-91eb-53406c586a49"), "مسجد سليمان", 11 },
                    { 370, new Guid("3e52a5ff-3cb8-4e77-af64-830313dc8642"), "لالي", 11 },
                    { 369, new Guid("a92eae10-bbd8-4982-8f2e-4436a87938d4"), "قلعه خواجه", 11 },
                    { 368, new Guid("aee2d397-15f4-4b99-a7e8-eecc1f1c82d9"), "قلعه تل", 11 },
                    { 367, new Guid("7ae216f3-fda4-4b7e-a331-53a1879d6475"), "فتح المبين", 11 },
                    { 366, new Guid("cfd2c599-c044-4685-870f-4ebae74db7b8"), "صيدون", 11 },
                    { 365, new Guid("bc8112c2-f1f2-4a34-aab5-92180ac3c092"), "صفي آباد", 11 },
                    { 364, new Guid("4eb402e8-7c4d-466d-9495-c2c5acb77d4f"), "صالح شهر", 11 },
                    { 363, new Guid("46f3411d-f098-4c23-b677-7c9f76f00f96"), "شيبان", 11 },
                    { 362, new Guid("3ce55047-1b44-49a9-8518-cd1fb535ba93"), "شوشتر", 11 },
                    { 361, new Guid("1f8f5488-19f4-4c8a-9d68-d7ec9bb90916"), "شوش", 11 },
                    { 360, new Guid("84ae9aac-2b4b-4968-9555-0f721990db9c"), "شهر امام", 11 },
                    { 359, new Guid("64815653-4f68-47f5-9f07-ff3ac128eadc"), "شمس آباد", 11 },
                    { 358, new Guid("889d0c78-6f69-4875-afd0-2748c79a9d62"), "شرافت", 11 },
                    { 339, new Guid("568358f5-b4ff-43f8-9312-39c339d7d962"), "حمزه", 11 },
                    { 338, new Guid("d01812ec-2935-41a2-9c8b-826381b335ba"), "حسينيه", 11 },
                    { 337, new Guid("92ea2267-476e-4f79-9c13-4778cc065d58"), "حر", 11 },
                    { 336, new Guid("12106bca-d02c-4c07-ae3a-04d8c1189af4"), "جنت مکان", 11 },
                    { 316, new Guid("a04c962f-2261-4c79-ab2d-60397b154356"), "آبژدان", 11 },
                    { 315, new Guid("d2e3cd47-327b-4ec2-857e-b80e6beacd4d"), "آبادان", 11 },
                    { 314, new Guid("d31c6002-f1e2-46a9-926e-120fa51f9e18"), "گزيک", 10 },
                    { 313, new Guid("feeaf1c1-0e36-46f5-b74b-e9c2d1c9b167"), "نيمبلوک", 10 },
                    { 312, new Guid("45334e57-0fbb-4e06-87ec-5a86b682bcd5"), "نهبندان", 10 },
                    { 311, new Guid("8155b84d-62cd-4dc6-bfa6-dcd3c1291b99"), "مود", 10 },
                    { 310, new Guid("88de5322-b195-4b97-a362-ee3ed6280c31"), "محمدشهر", 10 },
                    { 309, new Guid("ae1c9de8-3041-4c59-a94b-7ca0123ced88"), "قهستان", 10 },
                    { 308, new Guid("0e1b2ff0-0dc3-4594-98f2-9f88bb9d5713"), "قائن", 10 },
                    { 307, new Guid("2b31325c-cd1e-47e8-aa1b-5d87935718bc"), "فردوس", 10 },
                    { 306, new Guid("6472cb6b-36a1-4c5a-bb9b-f1eb7d73ca0d"), "عشق آباد", 10 },
                    { 305, new Guid("d96e6162-497d-4a6a-bab2-a01b9f4477af"), "طبس مسينا", 10 },
                    { 304, new Guid("119b585c-6cf7-4ec8-bb72-b327546b0ba4"), "طبس", 10 },
                    { 303, new Guid("d8fa06af-4dd7-4349-9854-b605091f7b11"), "شوسف", 10 },
                    { 302, new Guid("6a5a2fec-62cf-4fe1-9d35-c7330791b347"), "سه قلعه", 10 },
                    { 317, new Guid("65ffa43b-6ef6-4efa-b912-6eb68adc95f6"), "آزادي", 11 },
                    { 373, new Guid("5db64694-d641-4009-8972-5c27d897872f"), "مقاومت", 11 },
                    { 318, new Guid("65157b13-3420-47df-9c96-a6215677685c"), "آغاجاري", 11 },
                    { 320, new Guid("8b43c8ee-4e3b-4123-8cab-83cc8bbef3a0"), "اروند کنار", 11 },
                    { 335, new Guid("47bb55e3-c1a1-4530-84b7-7d50d2324293"), "جايزان", 11 },
                    { 334, new Guid("631b7417-943a-478c-8b6b-84174c2ac8fd"), "تشان", 11 },
                    { 333, new Guid("817b8b66-4e90-43d0-8c9c-d6dcfcd1cd84"), "ترکالکي", 11 },
                    { 332, new Guid("2d04e563-db00-4f62-9447-25f4316fb56e"), "بيدروبه", 11 },
                    { 331, new Guid("7f503bd7-09d2-4029-a401-c3c037b13839"), "بهبهان", 11 },
                    { 330, new Guid("a5262bcb-d3c8-4be3-b28a-490b1a085bb6"), "بندر ماهشهر", 11 },
                    { 329, new Guid("2c2ce30a-d09e-404c-82ab-c8b1ada0ebb9"), "بندر امام خميني", 11 },
                    { 328, new Guid("4f781eab-5ad8-4890-a1c6-e5b2b21da5da"), "بستان", 11 },
                    { 327, new Guid("ad3ab962-0ca0-41ca-b4f9-f27bf58eeb7e"), "باغ ملک", 11 },
                    { 326, new Guid("e9b03015-6f92-4e08-825e-e6fe904d4372"), "ايذه", 11 },
                    { 325, new Guid("9dd07f72-1ef5-45d1-ba08-11af812d6458"), "اهواز", 11 },
                    { 324, new Guid("3dc5f53a-3116-4f6c-9b91-0b82cdbceb97"), "انديمشک", 11 },
                    { 323, new Guid("200bd0a9-4022-4ff2-8770-22b5f05bf8f9"), "اميديه", 11 },
                    { 322, new Guid("4a9d926d-543b-448e-96de-95727baae7cb"), "الوان", 11 },
                    { 321, new Guid("e80693aa-3c93-4493-a9f6-36c741001c97"), "الهايي", 11 },
                    { 319, new Guid("0471310f-3baa-4622-9a86-5831735e615f"), "ابوحميظه", 11 },
                    { 374, new Guid("74477cc8-dd74-452d-a8c9-fea941cb1680"), "ملاثاني", 11 },
                    { 355, new Guid("07a3df2f-498f-4762-99e9-f690ec98a375"), "سياه منصور", 11 },
                    { 376, new Guid("f7b76ca0-b57d-4246-9d06-7096cdffeb8b"), "ميانرود", 11 },
                    { 429, new Guid("c873363a-231f-4116-bded-bffa5cdbe4e3"), "ابهر", 13 },
                    { 428, new Guid("258fc153-0c52-47e4-a829-cee20a0c147d"), "آب بر", 13 },
                    { 427, new Guid("d6920143-16e8-41a5-a76c-1d531f6cf37e"), "کلمه", 12 },
                    { 426, new Guid("1fb7d6cd-1892-4e18-b73a-09cd1cc1e9b2"), "کاکي", 12 },
                    { 425, new Guid("70700b0d-640c-4e02-9e76-837951652c30"), "چغادک", 12 },
                    { 424, new Guid("65c17efb-4d73-4c46-9d16-80809ca72365"), "وحدتيه", 12 },
                    { 423, new Guid("4a353c05-65c3-4cb6-990e-5ff35e55d662"), "نخل تقي", 12 },
                    { 422, new Guid("067dda1e-bfb5-4c3a-bd15-d9f23c2e745f"), "عسلويه", 12 },
                    { 421, new Guid("189bca25-4861-4c9a-8e8f-bfe3a2aad086"), "شنبه", 12 },
                    { 420, new Guid("d0e1487f-79c4-49a1-97db-cd0b9090f186"), "شبانکاره", 12 },
                    { 419, new Guid("11302678-284d-4086-b939-9c00a83677b1"), "سيراف", 12 },
                    { 418, new Guid("416866f4-3c7a-4176-acb2-97b4fa904f20"), "سعد آباد", 12 },
                    { 417, new Guid("8dbc9cbd-4d4e-463e-bf43-2890ab970b45"), "ريز", 12 },
                    { 416, new Guid("74a359e4-a809-4e39-817a-e75f9c603d61"), "دوراهک", 12 },
                    { 415, new Guid("b150a0d3-20f4-49f0-8eb8-6ad6b6bd0bdc"), "دلوار", 12 },
                    { 430, new Guid("469998b3-85a8-4187-959a-aa4abcca88b3"), "ارمخانخانه", 13 },
                    { 414, new Guid("b2457ebd-b84b-4d32-82e5-e371eab4ea7e"), "دالکي", 12 },
                    { 431, new Guid("720de571-8010-4117-86cb-3b30bbb7fd2f"), "حلب", 13 },
                    { 375, new Guid("23215827-f705-43fc-a61e-d9ea8ba78f7e"), "منصوريه", 11 },
                    { 448, new Guid("675b2791-1abb-44b9-bf53-15c532a2cdcb"), "گرماب", 13 },
                    { 447, new Guid("a6b472b3-05a6-4df1-ac4b-79f8c89e37e3"), "کرسف", 13 },
                    { 446, new Guid("1e880799-84fb-4597-a799-f80cbe3a374f"), "چورزق", 13 },
                    { 445, new Guid("e0742cd8-7045-4f6e-af01-898bc2972705"), "هيدج", 13 },
                    { 444, new Guid("b8e3312d-8072-426e-a428-90d6f9aad0a1"), "نيک پي", 13 },
                    { 443, new Guid("d52d9d4a-9642-4565-bded-dc941c879675"), "نوربهار", 13 },
                    { 442, new Guid("c6aabb00-3b8f-4aa8-a0c4-b14afcecf68d"), "ماه نشان", 13 },
                    { 441, new Guid("ac1d5b68-88e7-42cf-a004-04e577137e37"), "قيدار", 13 },
                    { 440, new Guid("53cdcdbc-3b92-4a71-aabb-50a365f6656b"), "صائين قلعه", 13 },
                    { 439, new Guid("72992516-3d95-4a76-9a4b-329677d73a30"), "سهرورد", 13 },
                    { 438, new Guid("3097dc87-b11f-43f0-8bc2-13a402648a49"), "سلطانيه", 13 },
                    { 437, new Guid("724c5049-512b-4315-b115-7dc2bf0724f1"), "سجاس", 13 },
                    { 436, new Guid("09768655-1203-4213-a055-500155125216"), "زنجان", 13 },
                    { 435, new Guid("2a00131e-3a9a-4864-9bba-4a97853279e2"), "زرين رود", 13 },
                    { 434, new Guid("96a8d39c-ec15-4615-9eed-dfba2e5aa1e5"), "زرين آباد", 13 },
                    { 432, new Guid("d17f5fa1-de72-4c63-ac71-fb16c4cf9f17"), "خرمدره", 13 },
                    { 413, new Guid("52952343-7aa4-4742-b56e-a802af56a2bb"), "خورموج", 12 },
                    { 433, new Guid("8b539b8f-6b83-4176-a167-c949a893eab9"), "دندي", 13 },
                    { 411, new Guid("5114393d-9fec-4174-89b2-595fa401c875"), "جم", 12 },
                    { 391, new Guid("fa0d9070-3f8f-4395-8589-a401ef848707"), "گوريه", 11 },
                    { 390, new Guid("5b1af9b4-786e-4248-83db-c2587b3855ee"), "گلگير", 11 },
                    { 389, new Guid("9ae38dcc-ba20-47ef-8dbe-80bb50e6f47d"), "گتوند", 11 },
                    { 388, new Guid("041ab76e-ef52-4a99-943c-501f56a26dff"), "کوت عبدالله", 11 },
                    { 387, new Guid("03411860-43b3-479a-9b46-42a2022cd39a"), "کوت سيدنعيم", 11 },
                    { 386, new Guid("88f53790-bbe1-40cf-bce2-1af8f44348d5"), "چوئبده", 11 },
                    { 385, new Guid("f19041de-4d4c-46eb-b8be-1c8026780765"), "چمران", 11 },
                    { 383, new Guid("7bdf7b79-8440-44bf-9fd8-58a929a4e82a"), "چغاميش", 11 },
                    { 382, new Guid("17b4deb2-8153-41b7-a35b-8eeac625b30a"), "ويس", 11 },
                    { 381, new Guid("7a693c65-04bc-4a6b-bb25-759a783e09ea"), "هويزه", 11 },
                    { 380, new Guid("7e33d93d-cfdc-483c-82dc-a70fa00a947a"), "هنديجان", 11 },
                    { 379, new Guid("b7e1a772-bcaf-4ae7-bd0a-11cb826e3fc0"), "هفتگل", 11 },
                    { 378, new Guid("031d11e1-9bf0-465c-8b6f-31bb3e5d8278"), "مينوشهر", 11 },
                    { 377, new Guid("395fd84d-9ffa-442b-9c98-ebf5932f063d"), "ميداود", 11 },
                    { 412, new Guid("d8e78dd1-2d5d-493c-a3fe-4d261f4fe21c"), "خارک", 12 },
                    { 392, new Guid("195cf816-18e7-4d76-8e31-7a28afde3bda"), "آباد", 12 },
                    { 393, new Guid("9aceb615-5b18-483e-870c-ed4d71e25b5d"), "آبدان", 12 },
                    { 384, new Guid("578ce65e-3082-49bf-86e1-4b901ef3e554"), "چم گلک", 11 },
                    { 395, new Guid("ece2d40e-2e10-4037-8411-e11386e54ea9"), "امام حسن", 12 },
                    { 410, new Guid("7169486d-acba-4414-99bd-3a284cd7ec8d"), "تنگ ارم", 12 },
                    { 394, new Guid("475770a4-07db-405f-b050-91f61178ebd5"), "آبپخش", 12 },
                    { 409, new Guid("7d90074d-68a6-4d0c-9d45-d355d3aa1809"), "بوشکان", 12 },
                    { 408, new Guid("da8dc427-3f30-45da-825a-eee90eebca25"), "بوشهر", 12 },
                    { 407, new Guid("e8a2be1e-3a0b-4070-a15e-7c508028b5ed"), "بنک", 12 },
                    { 405, new Guid("9eded89d-9ac8-4f85-b9b9-23bfdad3d4f4"), "بندر کنگان", 12 },
                    { 404, new Guid("4c420fab-999d-43c8-94ab-d04c3cc66016"), "بندر ريگ", 12 },
                    { 403, new Guid("89a3e735-6d72-4e07-bc41-23188fee3998"), "بندر ديلم", 12 },
                    { 406, new Guid("7751fe0d-3eb6-40c7-8673-3ba671f4c895"), "بندر گناوه", 12 },
                    { 402, new Guid("fa43f410-9ee0-4ea1-bf78-37f132898ec9"), "بندر دير", 12 },
                    { 401, new Guid("c51ec724-c04c-4157-adcc-81372438c87b"), "بردستان", 12 },
                    { 400, new Guid("2fc026a0-4fab-4c21-87fa-c8d6bb71f096"), "بردخون", 12 },
                    { 399, new Guid("f59e7a47-84f5-4e81-a7ef-3fa317a75a01"), "برازجان", 12 },
                    { 398, new Guid("92a82ce3-4137-48a5-bb70-1a46ef325c47"), "بادوله", 12 },
                    { 397, new Guid("6753d3e4-3215-4c91-a8e1-fec2f1d06a43"), "اهرم", 12 },
                    { 396, new Guid("7aa57aa9-1f21-4b09-84e9-b68233fd7e9b"), "انارستان", 12 }
                });

            migrationBuilder.InsertData(
                table: "Code",
                columns: new[] { "CodeID", "CodeGroupID", "CodeGUID", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 10, 4, new Guid("10afdac9-a075-40e1-9207-1813befcf4d6"), "در حال انجام", "Doing" },
                    { 15, 5, new Guid("959b10a3-b8ed-4a9d-bdf3-17ec9b2ceb15"), "سرویس دهنده", "Contractor" },
                    { 14, 5, new Guid("91b3cdab-39c1-40fb-b077-a2d6e611f50a"), "سرویس گیرنده", "Client" },
                    { 13, 5, new Guid("46a09d81-c57f-4655-a8f5-027c66a6cfb1"), "ادمین", "Admin" },
                    { 12, 4, new Guid("61960336-e912-4658-9ab3-59f4c58e0b23"), "لغو شده", "Canceled" },
                    { 11, 4, new Guid("2b9d07c8-5535-495e-8557-da32acb58600"), "انجام شده", "Done" },
                    { 16, 6, new Guid("a05c4f54-5999-42b9-a36f-6a04aa7cd476"), "حقوقی", "Legal" },
                    { 9, 4, new Guid("b5d74bda-849b-427c-a6e0-463c1e5f615b"), "در انتظار تایید", "Waiting For Acceptance" },
                    { 2, 1, new Guid("3f009296-db7a-4fde-a659-4ca1541a2504"), "jpg", "image/jpg" },
                    { 7, 3, new Guid("2b451e4c-c9b8-415a-bcb4-05da15447b89"), "زن", "Female" },
                    { 6, 2, new Guid("cf5a1929-db68-43d6-8fc7-e3b7ccc51678"), "نماینده یک واحد، آموزشگاه یا دیگر مجوز ها هستم", "نماینده یک واحد، آموزشگاه یا دیگر مجوز ها هستم" },
                    { 5, 2, new Guid("2383b70e-f41f-4b67-b0c9-c48706a70a46"), "نماینده یک شرکت هستم", "نماینده یک شرکت هستم" },
                    { 4, 2, new Guid("09cb21ac-d99e-42ba-904d-337bdd561e6e"), "به صورت شخصی فعالیت میکنم", "به صورت شخصی فعالیت میکنم" },
                    { 39, 1, new Guid("029a5514-3db0-4dcd-99f0-d92c869dce1b"), "mp4", "video/mp4" },
                    { 3, 1, new Guid("3209341a-07d4-437b-9301-2d0f909ad713"), "jpeg", "image/jpeg" },
                    { 1, 1, new Guid("fc20e91f-1eb1-4912-87be-1708f2706367"), "png", "image/png" },
                    { 17, 6, new Guid("ccef9d1f-343b-442a-a041-1908e4cbc235"), "حقیقی", "Natural" },
                    { 8, 3, new Guid("6e48b657-2c83-4481-a9c5-009ffe10158b"), "مرد", "Male" },
                    { 18, 7, new Guid("5ba5f957-a910-48a1-a383-42d15b65bf23"), "تایید شده", "Accepted" },
                    { 34, 13, new Guid("1cc5aa3e-1a24-49e2-b543-6b0cfa37bba2"), "اندروید", "Android" },
                    { 20, 7, new Guid("bc1eb3d4-e00d-4542-a3fb-6cb1c730293c"), "لغو شده", "Canceled" },
                    { 36, 13, new Guid("3f61e2f8-b6a6-4793-96be-4841885090ea"), "وب", "Web" },
                    { 35, 13, new Guid("1117fabe-6a4c-4585-a1c4-f53c5e1b0728"), "آی ا اس", "IOS" },
                    { 33, 12, new Guid("3e8bfd8f-867c-45db-a54d-942bee9dbf61"), "مبلغی", "Price" },
                    { 32, 12, new Guid("905e034d-8c46-4e04-8094-e4682f43da31"), "درصدی", "Percentage" },
                    { 29, 11, new Guid("cf7b3eca-f1f2-4f96-89d9-ae534fa3d8ce"), "رسیدگی نشده", "Not Handled" },
                    { 28, 11, new Guid("7bb94299-7355-4a87-9079-9758d0ef926a"), "رسیدگی شده", "Handled" },
                    { 27, 11, new Guid("dc010a0e-1526-4ed8-8ebd-729eb5fe9212"), "در انتظار رسیدگی", "Under Consideration" },
                    { 19, 7, new Guid("151d7878-41d0-4269-b17d-b5098a12a16d"), "در انتظار تایید", "Waiting For Acceptance" },
                    { 26, 10, new Guid("f1105be4-cf0d-47ff-b0ba-41c24ffe594a"), "رسیدگی نشده", "Not Handled" },
                    { 24, 10, new Guid("8d7b55c2-07d5-45d5-b2bb-b6987ce52230"), "در انتظار رسیدگی", "Under Consideration" },
                    { 38, 9, new Guid("dd4cf393-8543-4472-ab78-d67dd0179375"), "گواهی مهارت", "Certificate of Proficiency" },
                    { 37, 9, new Guid("23f5bebb-3d0e-4487-937d-5caee7ae3aef"), "گواهی عدم سو پیشینه", "Certificate of No Criminal Record" },
                    { 30, 9, new Guid("7ba40426-9113-42cb-b3f0-c99c978866bd"), "کارت ملی", "Identity Card" },
                    { 23, 8, new Guid("3ec2601b-a8b7-43e9-9eda-06414e11d0f3"), "اسلایدر 3", "Slider 3" },
                    { 22, 8, new Guid("c91d8c1a-09d5-4951-80cb-37e3ac0c256a"), "اسلایدر 2", "Slider 2" },
                    { 21, 8, new Guid("92bf4934-9778-479a-8d05-55083c4dd5a8"), "اسلایدر 1", "Slider 1" },
                    { 31, 7, new Guid("225ff398-678a-4ca8-b29d-b2a62e81f5e5"), "انجام شده", "Done" },
                    { 25, 10, new Guid("191c5ea9-59c6-4571-97e3-e11e347a4aaf"), "رسیدگی شده", "Handled" }
                });

            migrationBuilder.InsertData(
                table: "PaymentProviderSetting",
                columns: new[] { "PaymentProviderSettingID", "APIKey", "Password", "PaymentProviderID", "PaymentProviderSettingGUID", "Username" },
                values: new object[] { 1, "e9baeffe-cb50-11ea-a256-000c295eb8fc", null, 1, new Guid("f23c33f3-32c1-4867-b7b2-00bc85020532"), null });

            migrationBuilder.InsertData(
                table: "SMSProviderSetting",
                columns: new[] { "SMSProviderSettingID", "APIKey", "Password", "SMSProviderID", "Username" },
                values: new object[] { 1, "532B514B4E305A456D5A737669687A5161444B355544557462576650737634545959532F76517A572B65733D", "raffi1234", 1, "raffi.hovanes@gmail.com" });

            migrationBuilder.InsertData(
                table: "SMSTemplate",
                columns: new[] { "SMSTemplateID", "Name", "SMSProviderSettingID" },
                values: new object[,]
                {
                    { 1, "VerifyAccount", 1 },
                    { 2, "RegisterMessage", 1 },
                    { 3, "NewOrderNotification", 1 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserID", "Email", "FirstName", "GenderCodeID", "IsActive", "IsRegister", "LastName", "ModifiedDate", "PhoneNumber", "ProfileDocumentID", "RegisteredDate", "RoleID", "UserGUID" },
                values: new object[,]
                {
                    { 1, "mahdiroudaki@hotmail.com", "سید مهدی", 8, true, true, "رودکی", new DateTime(2020, 12, 10, 18, 37, 59, 970, DateTimeKind.Local).AddTicks(4814), "09126842446", null, new DateTime(2020, 12, 10, 18, 37, 59, 970, DateTimeKind.Local).AddTicks(4248), 1, new Guid("a7df3694-ad69-4792-b012-ab0617dad251") },
                    { 2, "roozbehshamekhi@hotmail.com", "روزبه", 8, true, true, "شامخی", new DateTime(2020, 12, 10, 18, 37, 59, 970, DateTimeKind.Local).AddTicks(7128), "09128277075", null, new DateTime(2020, 12, 10, 18, 37, 59, 970, DateTimeKind.Local).AddTicks(7106), 3, new Guid("0feddf50-4e47-4a34-a422-05870cd94ea8") },
                    { 3, "mahdiih@ymail.com", "مهدی", 8, true, true, "حکمی زاده", new DateTime(2020, 12, 10, 18, 37, 59, 970, DateTimeKind.Local).AddTicks(7182), "09199390494", null, new DateTime(2020, 12, 10, 18, 37, 59, 970, DateTimeKind.Local).AddTicks(7178), 1, new Guid("e118eabc-64f9-4e18-b41e-3f328abdbfd3") },
                    { 4, "white.luciferrr@gmail.com", "محمد", 8, true, true, "میرزایی", new DateTime(2020, 12, 10, 18, 37, 59, 970, DateTimeKind.Local).AddTicks(7208), "09147830093", null, new DateTime(2020, 12, 10, 18, 37, 59, 970, DateTimeKind.Local).AddTicks(7204), 1, new Guid("d9ce1a18-a6aa-4c1b-91e0-fbb23845cece") },
                    { 5, "raffi.hovanes@gmail.com", "رافی", 8, true, true, "اوانسیان", new DateTime(2020, 12, 10, 18, 37, 59, 970, DateTimeKind.Local).AddTicks(7221), "09125344652", null, new DateTime(2020, 12, 10, 18, 37, 59, 970, DateTimeKind.Local).AddTicks(7217), 1, new Guid("bc6b0e75-17b4-4c66-8821-c5ad3fcfab90") },
                    { 6, "dead.hh98@gmail.com", "حامد", 8, true, true, "حقیقیان", new DateTime(2020, 12, 10, 18, 37, 59, 970, DateTimeKind.Local).AddTicks(7233), "09108347428", null, new DateTime(2020, 12, 10, 18, 37, 59, 970, DateTimeKind.Local).AddTicks(7230), 2, new Guid("198c067a-8f5c-4f0c-80b5-6ff1f51e43bc") }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminID", "AdminGUID", "ModifiedDate", "UserID" },
                values: new object[,]
                {
                    { 1, new Guid("c57f37e0-ba23-4d82-9b3e-1e4e96801d4b"), new DateTime(2020, 12, 10, 18, 37, 59, 970, DateTimeKind.Local).AddTicks(9740), 1 },
                    { 2, new Guid("910b9a7a-cfbd-4231-8306-379116c208cb"), new DateTime(2020, 12, 10, 18, 37, 59, 971, DateTimeKind.Local).AddTicks(842), 3 },
                    { 3, new Guid("99fb40ae-5ff3-4931-9c94-30110af323ec"), new DateTime(2020, 12, 10, 18, 37, 59, 971, DateTimeKind.Local).AddTicks(873), 4 },
                    { 4, new Guid("09b7f43c-d327-4a21-875e-d3d0bc630d91"), new DateTime(2020, 12, 10, 18, 37, 59, 971, DateTimeKind.Local).AddTicks(877), 5 }
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientID", "CityID", "ClientGUID", "ModifiedDate", "UserID" },
                values: new object[] { 1, 751, new Guid("35eae364-5265-4184-84a1-f3391fab77a4"), new DateTime(2020, 12, 10, 18, 37, 59, 971, DateTimeKind.Local).AddTicks(5018), 2 });

            migrationBuilder.InsertData(
                table: "Contractor",
                columns: new[] { "ContractorID", "AboutMe", "Address", "AverageRate", "BusinessTypeCodeID", "CityID", "ContractorGUID", "Credit", "Instagram", "IntroductionCode", "Latitude", "Linkedin", "Longitude", "ModifiedDate", "Telegram", "Telephone", "UserID", "Website", "Whatsapp" },
                values: new object[] { 1, null, null, null, 4, 751, new Guid("b56bfdb0-4f69-490d-8406-0a1287a98400"), 10000, null, "981867", "0", null, "0", new DateTime(2020, 12, 10, 18, 37, 59, 973, DateTimeKind.Local).AddTicks(456), null, null, 6, null, null });

            migrationBuilder.InsertData(
                table: "ContractorCategory",
                columns: new[] { "ContractorCategoryID", "CategoryID", "ContractorCategoryGUID", "ContractorID" },
                values: new object[,]
                {
                    { 1, 3, new Guid("4ae9e421-23cf-4811-96f9-bc4232ca2e71"), 1 },
                    { 2, 4, new Guid("51b7bf71-b365-4129-90a2-e72a5c40ed35"), 1 },
                    { 3, 5, new Guid("420730ca-e6c5-4535-b76d-f1ca06b83ab4"), 1 },
                    { 4, 6, new Guid("39e0dacf-a6a7-4c94-8ed0-4e7b17d30102"), 1 },
                    { 5, 7, new Guid("31390ef8-f13c-4d5e-a3f1-023e7891619c"), 1 },
                    { 6, 8, new Guid("e65165d6-c7dc-4944-a305-1c07d2842055"), 1 },
                    { 7, 9, new Guid("d24d3b43-e5be-4dea-a0bd-f11dca43bd94"), 1 },
                    { 8, 10, new Guid("b9d44a66-f3b9-40c9-a364-5ee38bb277bf"), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UserID",
                table: "Admin",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_DocumentID",
                table: "Advertisement",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ActiveIconDocumentID",
                table: "Category",
                column: "ActiveIconDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CoverDocumentID",
                table: "Category",
                column: "CoverDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_InactiveIconDocumentID",
                table: "Category",
                column: "InactiveIconDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryID",
                table: "Category",
                column: "ParentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_QuadMenuDocumentID",
                table: "Category",
                column: "QuadMenuDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_SecondPageCoverDocumentID",
                table: "Category",
                column: "SecondPageCoverDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTag_CategoryID",
                table: "CategoryTag",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTag_TagID",
                table: "CategoryTag",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_DocumentId",
                table: "ChatMessage",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_OrderRequestID",
                table: "ChatMessage",
                column: "OrderRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_UserID",
                table: "ChatMessage",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceID",
                table: "City",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CityID",
                table: "Client",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_UserID",
                table: "Client",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Code_Code_CGID",
                table: "Code",
                column: "CodeGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserID",
                table: "Comment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_StateCodeID",
                table: "Complaint",
                column: "StateCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_UserID",
                table: "Complaint",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_ContactUsBusinessTypeCodeID",
                table: "ContactUs",
                column: "ContactUsBusinessTypeCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_StateCodeID",
                table: "ContactUs",
                column: "StateCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_BusinessTypeCodeID",
                table: "Contractor",
                column: "BusinessTypeCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_CityID",
                table: "Contractor",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_UserID",
                table: "Contractor",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorCategory_CategoryID",
                table: "ContractorCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorCategory_ContractorID",
                table: "ContractorCategory",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorDiscount_ContractorID",
                table: "ContractorDiscount",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorDiscount_PublicDiscountID",
                table: "ContractorDiscount",
                column: "PublicDiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorDocument_ContractorID",
                table: "ContractorDocument",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorDocument_DocumentID",
                table: "ContractorDocument",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorDocument_TitleCodeID",
                table: "ContractorDocument",
                column: "TitleCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorIntroductionCode_ContractorID",
                table: "ContractorIntroductionCode",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorIntroductionCode_NewContractorID",
                table: "ContractorIntroductionCode",
                column: "NewContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Document_Document_TypeCodeID",
                table: "Document",
                column: "TypeCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CategoryID",
                table: "Order",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientID",
                table: "Order",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ContractorID",
                table: "Order",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StateCodeID",
                table: "Order",
                column: "StateCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequest_ContractorID",
                table: "OrderRequest",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequest_OrderID",
                table: "OrderRequest",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequest_StateCodeID",
                table: "OrderRequest",
                column: "StateCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ContractorID",
                table: "Payment",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentProviderSettingID",
                table: "Payment",
                column: "PaymentProviderSettingID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentProviderSetting_PaymentProviderID",
                table: "PaymentProviderSetting",
                column: "PaymentProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionGroupID",
                table: "Permission",
                column: "PermissionGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_DocumentID",
                table: "Post",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_SliderCodeId",
                table: "Post",
                column: "SliderCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserID",
                table: "Post",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategory_CategoryID",
                table: "PostCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategory_PostID",
                table: "PostCategory",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_CommentID",
                table: "PostComment",
                column: "CommentID");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_PostID",
                table: "PostComment",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_PostID",
                table: "PostTag",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagID",
                table: "PostTag",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateDiscount_ContractorID",
                table: "PrivateDiscount",
                column: "ContractorID");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateDiscount_TypeCodeID",
                table: "PrivateDiscount",
                column: "TypeCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_PublicDiscount_TypeCodeID",
                table: "PublicDiscount",
                column: "TypeCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RolePermission_RP_PermissionID",
                table: "RolePermission",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_RolePermission_RP_RoleID",
                table: "RolePermission",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_SMSProviderSetting_SMSProviderID",
                table: "SMSProviderSetting",
                column: "SMSProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SMSProviderNumber_SPN_SPCID",
                table: "SMSProviderSettingNumber",
                column: "SMSProviderSettingID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SMSResponse_SMS_STID",
                table: "SMSResponse",
                column: "SMSTemplateID");

            migrationBuilder.CreateIndex(
                name: "IX_SMSResponse_UserID",
                table: "SMSResponse",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SMSTemplate_ST_SSID",
                table: "SMSTemplate",
                column: "SMSProviderSettingID");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestion_UserID",
                table: "Suggestion",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Token_RoleCodeID",
                table: "Token",
                column: "RoleCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Token_UserID",
                table: "Token",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TypeCodeID",
                table: "Transaction",
                column: "TypeCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_User_GenderCodeID",
                table: "User",
                column: "GenderCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileDocumentID",
                table: "User",
                column: "ProfileDocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleID",
                table: "User",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_UserPermission_UP_PermissionID",
                table: "UserPermission",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_UserID",
                table: "UserPermission",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Advertisement");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "CategoryTag");

            migrationBuilder.DropTable(
                name: "ChatMessage");

            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "ContractorCategory");

            migrationBuilder.DropTable(
                name: "ContractorDiscount");

            migrationBuilder.DropTable(
                name: "ContractorDocument");

            migrationBuilder.DropTable(
                name: "ContractorIntroductionCode");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PostCategory");

            migrationBuilder.DropTable(
                name: "PostComment");

            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "PrivateDiscount");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DropTable(
                name: "SMSProviderSettingNumber");

            migrationBuilder.DropTable(
                name: "SMSResponse");

            migrationBuilder.DropTable(
                name: "Suggestion");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "UserPermission");

            migrationBuilder.DropTable(
                name: "OrderRequest");

            migrationBuilder.DropTable(
                name: "PublicDiscount");

            migrationBuilder.DropTable(
                name: "PaymentProviderSetting");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "SMSTemplate");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PaymentProvider");

            migrationBuilder.DropTable(
                name: "SMSProviderSetting");

            migrationBuilder.DropTable(
                name: "PermissionGroup");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Contractor");

            migrationBuilder.DropTable(
                name: "SMSProvider");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Code");

            migrationBuilder.DropTable(
                name: "CodeGroup");
        }
    }
}
