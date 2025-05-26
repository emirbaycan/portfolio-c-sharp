using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolioProject.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Head = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Details", "SubDescription", "Title" },
                values: new object[] { 1, "Merhaba, ben Emir Baycan. Uzun süredir web ve mobil yazılım geliştirme alanında çalışıyorum. Full-stack web development, yapay zeka, mikroservis mimarisi ve otomasyon üzerine birçok projede yer aldım. Kendi projelerimle girişimcilik yolunda ilerliyorum. Python, C#, JavaScript, React, Angular, Node.js, Docker ve bulut servislerinde tecrübem var. Hedefim; teknolojiyle hayatı kolaylaştıran, sürdürülebilir ve ölçeklenebilir sistemler kurmak. Araştırmaya, öğrenmeye ve üretmeye devam ediyorum.", "Yazılım Geliştirici, Girişimci, Teknoloji Tutkunu", "Ben Kimim" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("9f4a2dba-20ca-481c-af32-70df2c57b256"), "2ad25526-a9fc-4f6c-88af-1ebf6218592b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageId", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e6e21232-145c-44a1-ade1-9db6646f39c3"), 0, "6b9ff6ca-f46d-4f1f-90f4-2b7df2cb5891", "emir-baycan@hotmail.com", true, null, false, null, "Emir", "EMIR-BAYCAN@HOTMAIL.COM", "EMIR", "AQAAAAEAACcQAAAAEB8DM/yOFarDqGjIsF7wPGiSKDNIiFA4v7hobdji53ymKug1dnYN40HoJAvyInhxSw==", "549 615 4243", true, "b3a76777-0506-4a1f-bd1e-af9c954d90ad", "Baycan", false, "emir" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Description", "Email", "Phone", "Title" },
                values: new object[] { 1, "Antalya, Türkiye", "Her türlü iş birliği, proje teklifi veya danışmanlık için bana ulaşabilirsiniz. Hızlıca dönüş yaparım.", "emir-baycan@hotmail.com", "549 615 4243", "Bana Ulaşın" });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "Date", "Description", "Head", "Title" },
                values: new object[,]
                {
                    { 1, "Eylül 2024 - Kasım 2024", "Kurumsal web projelerinin analiz, geliştirme ve entegrasyon süreçlerinde tam sorumluluk üstlendim.", "Karalar Kağıt", "Yazılım Uzmanı" },
                    { 2, "Ocak 2024 - Hala çalışıyorum", "Dijital altyapı ve otomasyon projelerinin planlama, geliştirme ve bakımından sorumluyum.", "My Partners Hukuk Bürosu", "Yazılım Uzmanı" },
                    { 3, "Ekim 2022 - Aralık 2022", "Web ve e-ticaret platformlarının tasarım, geliştirme ve uygulama süreçlerini yönettim.", "Eyüp Sultan Tulumbacısı", "Web Programcısı" },
                    { 4, "Mart 2022 - Ağustos 2023", "Eğitim platformunun kullanıcı ve sınav modüllerinin analiz, geliştirme ve uygulama aşamalarında sorumluluk aldım.", "Hukuki Yeterlilik Akademisi", "Yazılım Uzmanı" },
                    { 5, "Şubat 2022 - Nisan 2022", "Danışan takip sistemi ve online randevu altyapısının geliştirme süreçlerinde görev aldım.", "Terapi Kliniği", "Yazılım Uzmanı" },
                    { 6, "Temmuz 2021 - Eylül 2021", "Doküman yönetim sistemi ve online danışmanlık modüllerinin yazılım süreçlerinde aktif rol oynadım.", "Morkoç Hukuk Bürosu", "Yazılım Uzmanı" },
                    { 7, "Şubat 2021 - Şubat 2023", "Yazılım geliştirme, ekip yönetimi ve iş geliştirme süreçlerinin tamamında sorumluluk üstlendim.", "Kalenux", "CEO" },
                    { 8, "Eylül 2020 - Kasım 2020", "Kurumsal web sitesi ve müşteri iletişim sistemlerinin analiz ve geliştirme aşamalarında görev aldım.", "Karalar Prefabrik", "Yazılım Uzmanı" },
                    { 9, "Ocak 2020 - Ocak 2021", "Eğitim programları için web tabanlı yazılım çözümlerinin geliştirme süreçlerinde görev aldım.", "Hukuk Eğitim Programları", "Web Yazılım Uzmanı" },
                    { 10, "Ocak 2019 - Ocak 2023", "Oyun tabanlı platformun yazılım altyapısının geliştirilmesi ve otomasyon süreçlerinde sorumluluk aldım.", "Do Eloboost", "Yazılım Uzmanı" },
                    { 11, "Ocak 2019 - Nisan 2019", "Web tabanlı yazılım ve otomasyon sistemlerinin geliştirilmesinde görev aldım.", "Murat Bulat Hukuk Bürosu", "Yazılım Uzmanı" },
                    { 12, "Ocak 2018 - Ocak 2019", "Derneğe özel dijital projelerin planlama ve geliştirilme süreçlerinde aktif görev üstlendim.", "Girişimci Hukukçular Derneği", "Yazılım Uzmanı" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FileName", "FileType" },
                values: new object[,]
                {
                    { new Guid("05ec3249-ce8a-4aaa-887f-2efa46d67fe1"), "shc/1.webp", "image/webp" },
                    { new Guid("155fd20a-8c62-429d-8eae-b1583a9d9f9b"), "ghd/1.webp", "image/webp" },
                    { new Guid("1b5bcb6b-f151-4eef-9f5e-8d5d04e4dd18"), "hep/1.webp", "image/webp" },
                    { new Guid("5404c753-92a6-4a1d-be6c-c711a44846d0"), "dsd/1.webp", "image/webp" },
                    { new Guid("6227a847-5af4-4303-80b3-d32b855ab3d3"), "est/1.webp", "image/webp" },
                    { new Guid("6698473a-0aa2-44c8-8911-29d376f36ee5"), "mern/1.webp", "image/webp" },
                    { new Guid("6762255a-b51a-4bce-ab2d-7c4e9693b417"), "dsr/1.webp", "image/webp" },
                    { new Guid("70a72268-fe6b-40e7-853f-15a653baca3c"), "de/1.webp", "image/webp" },
                    { new Guid("70b9afbf-5065-4965-9938-65b424a7ae4d"), "tk/1.webp", "image/webp" },
                    { new Guid("71555402-762b-4091-8ed3-ae1a766cda61"), "myp/1.webp", "image/webp" },
                    { new Guid("823db4cf-5a3c-4fa6-88ea-9ab724221d5f"), "ac/1.webp", "image/webp" },
                    { new Guid("956ef020-cab9-47ed-a227-1dc46b3d334b"), "kp/1.webp", "image/webp" },
                    { new Guid("9eaca445-3d64-41d9-972d-83c7151f7533"), "next/1.webp", "image/webp" },
                    { new Guid("a20810ce-c432-4034-97cc-038e3135a9c6"), "kalenuxer/1.webp", "image/webp" },
                    { new Guid("a4fbc06e-8fc4-4c0a-ba23-d12466aae562"), "morkoc/1.webp", "image/webp" },
                    { new Guid("a8350bea-339b-444a-b0fc-e5f62fd3643c"), "nmlr/1.webp", "image/webp" },
                    { new Guid("abd18ad5-543e-4837-9341-cb171412655c"), "dsa/1.webp", "image/webp" },
                    { new Guid("aecef527-bb88-44d1-97d8-2dcaa84c9678"), "v/1.webp", "image/webp" },
                    { new Guid("b7a81466-3c8d-4a8e-9a65-93a127aa2100"), "hya/1.webp", "image/webp" },
                    { new Guid("cd91d5e5-fd8d-4a0b-897a-ac02d2123605"), "hero-bg.webp", "image/webp" },
                    { new Guid("d3e7f463-61a3-44f5-b636-f74ee99aae55"), "lamp/1.webp", "image/webp" },
                    { new Guid("f178582e-ebbe-43ef-82c2-42d56b4f3988"), "mb/1.webp", "image/webp" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Title", "Value" },
                values: new object[,]
                {
                    { 1, "Backend", 100 },
                    { 2, "Frontend", 100 },
                    { 3, "Full-stack Geliştirme", 100 },
                    { 4, "Serverside", 100 }
                });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "Description", "ImageUrl", "NameSurname", "Title" },
                values: new object[,]
                {
                    { 1, "Emir ile birlikte hukuk büromuzun dijital altyapısını tamamen modernize ettik. Dinamik kontrol paneli ve müşteri yönetimi konusunda beklentimizin çok üstünde çözümler sundu.", null, "Av. Murat Kara", "My Partners Hukuk Bürosu | Kurucu Avukat" },
                    { 2, "Web platformumuzu sıfırdan tasarlayıp tüm üyelik ve etkinlik süreçlerini dijitalleştirdi. Hızlı teslimat ve teknik destek açısından eşsiz bir iş ortağı.", null, "Murat Kara", "Girişimci Hukukçular Derneği | Kurucu" },
                    { 3, "Kurumsal sitemizi ve katalog yönetim sistemimizi kurduktan sonra müşteri geri dönüşlerimizde %40 artış yaşadık. Yazılım kalitesi ve iş takibi gerçekten çok iyi.", "hasan-karalar.webp", "Burak Kara", "Karalar Prefabrik | Kurucu" },
                    { 4, "Geliştirdiği özel panel ve otomasyonlar sayesinde eğitim süreçlerimiz çok daha verimli hale geldi. Teknik bilgisinin yanı sıra iletişimde de çok profesyonel.", null, "Muhammet Morkoç", "Hukuki Yeterlilik Akademisi | Kurucu" },
                    { 5, "Özellikle dava ve dosya yönetim sistemimizdeki yenilikçi yaklaşımı sayesinde işlerimizi daha hızlı ve güvenli yürütebiliyoruz. Tavsiye ederim.", null, "Muhammet Morkoç", "Morkoç Hukuk | Avukat" },
                    { 6, "Farklı projelerimizde Emir Baycan ile çalışma fırsatım oldu. Her seferinde sonuca odaklı, hızlı ve ölçeklenebilir projeler teslim etti.", null, "Uğur", "Freelance İşveren" },
                    { 7, "Teknolojideki yenilikleri takip eden, algoritmik zekası ve analiz gücüyle öne çıkan bir yazılımcı. Takım çalışmalarında ve proje yönetiminde çok güçlü.", null, "Berke", "Full-Stack Developer | Takım Arkadaşı" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("9f4a2dba-20ca-481c-af32-70df2c57b256"), new Guid("e6e21232-145c-44a1-ade1-9db6646f39c3") });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Description", "ImageId", "Title" },
                values: new object[] { 1, "Projelerinde çözüm odaklı yaklaşım, yeni teknolojilere hızlı adaptasyon ve girişimcilik tutkusu ile hareket eden bir yazılımcı.", new Guid("cd91d5e5-fd8d-4a0b-897a-ac02d2123605"), "Yenilikçi ve Üretken" });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "Id", "Description", "ImageId", "SubTitle", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "Maksimum performans ve esneklik için geliştirilmiş yeni nesil bir web uygulama çatısıdır. Kalenuxer; çoklu dil desteği, ileri düzey küçültme ve karmaşıklaştırma, sunucu tarafı render (SSR), modüler şablonlama (mail, bölüm, sayfa), sınıflandırma, SVG’den ikona dönüştürme, versiyon kontrolü, optimize CSS/JS yapısı ve güçlü yerelleştirme gibi özelliklerle, ölçeklenebilir ve üretime hazır uygulamaların hızlı geliştirilmesini sağlar.", new Guid("a20810ce-c432-4034-97cc-038e3135a9c6"), "Yeni nesil web uygulama çatısı", "Kalenuxer", "https://github.com/emirbaycan/Kalenuxer" },
                    { 2, "Kalenuxer’in SSR algoritmalarını kullanarak, dinamik SQL verilerini optimize HTML yapılarına sorunsuzca dönüştüren; gerçek zamanlı içerik güncellemeleri, güvenli müşteri yönetimi ve hukuk ofislerine özel güçlü bir kontrol paneli içeren özel bir web sitesi.", new Guid("71555402-762b-4091-8ed3-ae1a766cda61"), "Dinamik hukuk sitesi", "My Partners Hukuk Bürosu", "https://myp.emirbaycan.com.tr" },
                    { 3, "Kalenuxer ile geliştirilmiş, eğitim firmalarına özel kapsamlı web sitesi ve yönetim paneli. Güvenli ders yönetimi, çok seviyeli kullanıcı erişimi ve gerçek zamanlı güncelleme özellikleriyle ölçeklenebilir ve kolay içerik yönetimi sağlar.", new Guid("b7a81466-3c8d-4a8e-9a65-93a127aa2100"), "Eğitim yönetim paneli", "Hukuki Yeterlilik Akademisi", "https://hya.emirbaycan.com.tr" },
                    { 4, "Kalenuxer tabanlı, hız ve güvenlik odaklı, hukuk sektörüne özel dinamik içerik yönetimi ve dava yönetimi sağlayan web sitesi ve özel kontrol paneli.", new Guid("a4fbc06e-8fc4-4c0a-ba23-d12466aae562"), "Hız ve güvenlik odaklı hukuk sitesi", "Morkoç Hukuk Bürosu", "https://lawnux.emirbaycan.com.tr" },
                    { 5, "Kalenuxer tabanlı, prefabrik konut firmalarına yönelik gelişmiş katalog yönetimi, müşteri etkileşimi ve güçlü arka plan yetenekleriyle tam kapsamlı web sitesi ve yönetim paneli.", new Guid("956ef020-cab9-47ed-a227-1dc46b3d334b"), "Prefabrik konut katalog yönetimi", "Karalar Prefabrik", "https://kp.emirbaycan.com.tr" },
                    { 6, "Kalenuxer ile geliştirilen, popüler bir tatlı markası için kullanıcı odaklı ve yüksek dönüşüm sağlayan ürün sergileme ve yönetimi kolay modern bir web sitesi.", new Guid("6227a847-5af4-4303-80b3-d32b855ab3d3"), "Ürün sergileme ve yönetimi", "Eyüp Sultan Tulumbacısı", "https://eyp.emirbaycan.com.tr" },
                    { 7, "LAMP stack ile geliştirilmiş, üye yönetimi, etkinlik otomasyonu ve güvenli iletişim modülleri içeren, bir hukuk derneğine özel ilk web platformu ve yönetim sistemi.", new Guid("155fd20a-8c62-429d-8eae-b1583a9d9f9b"), "Dernek üye yönetimi sistemi", "Girişimci Hukukçular Derneği", "https://ghd.emirbaycan.com.tr" },
                    { 8, "Kalenuxer altyapısıyla geliştirilen, sürekli yeni özelliklerle güncellenen ve çoklu kurs içerik desteği sunan eğitim topluluğu web sitesi ve kontrol paneli.", new Guid("1b5bcb6b-f151-4eef-9f5e-8d5d04e4dd18"), "Çoklu kurs içerik desteği", "Hukuk Eğitim Programları", "https://hep.emirbaycan.com.tr" },
                    { 9, "Kalenuxer ile geliştirilen, otomasyon, performans ve güvenlik açısından optimize edilmiş bir online oyun servisi sitesi ve yönetim paneli.", new Guid("70a72268-fe6b-40e7-853f-15a653baca3c"), "Oyun servisi yönetim paneli", "Do Eloboost", "https://de.emirbaycan.com.tr" },
                    { 10, "Laravel ve özel JavaScript kütüphaneleriyle kodlanmış, psikologlara yönelik dinamik web sitesi ve kontrol paneli. Laravel’i standart hosting ortamında çalışacak şekilde optimize ettim.", new Guid("70b9afbf-5065-4965-9938-65b424a7ae4d"), "Psikologlara özel dinamik web sitesi", "Terapi Kliniği", "" },
                    { 11, "LAMP stack üzerinde geliştirilmiş, otomatik dosya yönetimi, güvenli müşteri portalı ve pratik yönetim araçları sunan kapsamlı bir hukuk bürosu web sitesi.", new Guid("f178582e-ebbe-43ef-82c2-42d56b4f3988"), "Otomatik dosya yönetimi, müşteri portalı", "Murat Bulat Hukuk Bürosu", "" },
                    { 12, "Kalenuxer ve LAMP altyapısıyla geliştirilen çok dilli portfolyo siteleri. Tam yığın (full-stack) uzmanlığımı ve ölçeklenebilir mimari yaklaşımımı gösteren projeler.", new Guid("d3e7f463-61a3-44f5-b636-f74ee99aae55"), "Çok dilli portfolyo sitesi", "LAMP ile Portfolio", "https://lamp.emirbaycan.com.tr" },
                    { 13, "React, Node.js ve MySQL üzerinde Ubuntu/Apache ile çalışan çok dilli portfolyo siteleri. Gelişmiş arayüz teknikleri ve arka uç entegrasyonu ile öne çıkıyor.", new Guid("6698473a-0aa2-44c8-8911-29d376f36ee5"), "React, Node.js tabanlı dinamik portfolyo", "React ile Portfolio", "https://mern.emirbaycan.com.tr" },
                    { 14, "Laravel, React, Node.js ve Three.js ile tam yığın, interaktif portfolyo siteleri. Modern UI/UX ve güçlü teknik demo niteliğinde.", new Guid("a8350bea-339b-444a-b0fc-e5f62fd3643c"), "Modern UI/UX interaktif site", "Laravel ve React ile Portfolyo", "https://nmlr.emirbaycan.com.tr" },
                    { 15, "Next.js tabanlı çok dilli portfolyo siteleri. Dinamik içerik, Resend ile e-posta entegrasyonu ve bulut tabanlı ölçeklenebilirlik özellikleri.", new Guid("9eaca445-3d64-41d9-972d-83c7151f7533"), "Next.js tabanlı çok dilli site", "Next ile Portfolio", "https://next.emirbaycan.com.tr" },
                    { 16, "C#, Selenium, Geckofx ve bulut servisleri (AWS, Google Cloud, Azure) kullanarak geliştirdiğim otomatik hesap oluşturucu. Yüksek hacimli ve tam otomatik kayıt işlemleri için VPN/proxy desteği de mevcut.", new Guid("823db4cf-5a3c-4fa6-88ea-9ab724221d5f"), "Otomatik hesap oluşturucu (C# & Selenium)", "Hesap Oluşturucu", "" },
                    { 17, "Python, Selenium ve Tor Browser IP döngüsüyle, ölçeklenebilir ve anonimleştirilmiş insan verisi üretici. Gerçekçi kullanıcı simülasyonu sağlar.", new Guid("aecef527-bb88-44d1-97d8-2dcaa84c9678"), "Anonimleştirilmiş insan verisi üretici", "Oylayıcı", "" },
                    { 18, "Verilen parametrelerle nesne yüksekliğini hassas şekilde hesaplayan Python algoritması. Matematiksel modelleme ve algoritma geliştirme yeteneğini gösterir.", new Guid("05ec3249-ce8a-4aaa-887f-2efa46d67fe1"), "Nesne yüksekliği hesaplama", "Hız ve Uzunluk Hesaplayıcı", "" },
                    { 19, "Python ve YOLO kullanarak, canlı kamera akışlarından dijital ekranları gerçek zamanlı tespit eden bilgisayarla görü uygulaması.", new Guid("5404c753-92a6-4a1d-be6c-c711a44846d0"), "Python & YOLO tabanlı ekran tespit", "Dijital Ekran Bulucu", "https://github.com/emirbaycan/yolo_digital_screen_detector" },
                    { 20, "Canlı video akışlarında dijital ekranların otomatik tespiti ve OCR ile okuması. Python ile bilgisayarla görü ve karakter tanıma teknolojilerini bir araya getirir.", new Guid("6762255a-b51a-4bce-ab2d-7c4e9693b417"), "Gerçek zamanlı dijital ekran OCR", "Dijital Ekran Okuyucu", "https://github.com/emirbaycan/ocr_digital_screen_reader" },
                    { 21, "Gerçek zamanlı dijital ekran izleme, eşik değer aşıldığında otomatik görüntü kaydı ve uyarı sistemi.", new Guid("abd18ad5-543e-4837-9341-cb171412655c"), "Gerçek zamanlı izleme ve uyarı", "Dijital Ekran Alarmı", "https://github.com/emirbaycan/digital_screen_alarm_with_rtsp_camera" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Features_ImageId",
                table: "Features",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ImageId",
                table: "Portfolios",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "ToDoLists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
