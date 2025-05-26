using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.DAL.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MyPortfolioProject.DAL.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(
                    connectionString,
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()
                );
            }
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Image> Images { get; set; }

        public string CreatePasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminId = Guid.Parse("E6E21232-145C-44A1-ADE1-9DB6646F39C3");
            var adminRoleId = Guid.Parse("9F4A2DBA-20CA-481C-AF32-70DF2C57B256");

            // User seed data
            var admin = new AppUser
            {
                Id = adminId,
                Name = "Emir",
                Surname = "Baycan",
                UserName = "emir",
                NormalizedUserName = "EMIR",
                Email = "emir-baycan@hotmail.com",
                NormalizedEmail = "EMIR-BAYCAN@HOTMAIL.COM",
                PhoneNumber = "549 615 4243",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            admin.PasswordHash = CreatePasswordHash(admin, "123456");

            modelBuilder.Entity<AppUser>().HasData(admin);

            // Role seed data
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });

            // Admin rolü ataması
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    UserId = adminId,
                    RoleId = adminRoleId
                }
            );

            // About seed data (KENDİ METNİN)
            modelBuilder.Entity<About>().HasData(
                new About
                {
                    Id = 1,
                    Title = "Ben Kimim",
                    SubDescription = "Yazılım Geliştirici, Girişimci, Teknoloji Tutkunu",
                    Details = "Merhaba, ben Emir Baycan. Uzun süredir web ve mobil yazılım geliştirme alanında çalışıyorum. Full-stack web development, yapay zeka, mikroservis mimarisi ve otomasyon üzerine birçok projede yer aldım. Kendi projelerimle girişimcilik yolunda ilerliyorum. Python, C#, JavaScript, React, Angular, Node.js, Docker ve bulut servislerinde tecrübem var. Hedefim; teknolojiyle hayatı kolaylaştıran, sürdürülebilir ve ölçeklenebilir sistemler kurmak. Araştırmaya, öğrenmeye ve üretmeye devam ediyorum."
                });

            // Feature image seed
            var featureImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = featureImageId,
                    FileName = "hero-bg.webp",
                    FileType = "image/webp"
                });

            // Feature seed data 
            modelBuilder.Entity<Feature>().HasData(
                new Feature
                {
                    Id = 1,
                    Title = "Yenilikçi ve Üretken",
                    Description = "Projelerinde çözüm odaklı yaklaşım, yeni teknolojilere hızlı adaptasyon ve girişimcilik tutkusu ile hareket eden bir yazılımcı.",
                    ImageId = featureImageId
                });

            // Contact seed data 
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    Title = "Bana Ulaşın",
                    Description = "Her türlü iş birliği, proje teklifi veya danışmanlık için bana ulaşabilirsiniz. Hızlıca dönüş yaparım.",
                    Phone = "549 615 4243",
                    Email = "emir-baycan@hotmail.com",
                    Address = "Antalya, Türkiye"
                });

            // Proje 1: Kalenuxer
            var kalenuxerImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = kalenuxerImageId,
                    FileName = "kalenuxer/1.webp",
                    FileType = "image/webp"
                });

            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 1,
                    Title = "Kalenuxer",
                    SubTitle = "Yeni nesil web uygulama çatısı",
                    Url = "https://github.com/emirbaycan/Kalenuxer",
                    Description = "Maksimum performans ve esneklik için geliştirilmiş yeni nesil bir web uygulama çatısıdır. Kalenuxer; çoklu dil desteği, ileri düzey küçültme ve karmaşıklaştırma, sunucu tarafı render (SSR), modüler şablonlama (mail, bölüm, sayfa), sınıflandırma, SVG’den ikona dönüştürme, versiyon kontrolü, optimize CSS/JS yapısı ve güçlü yerelleştirme gibi özelliklerle, ölçeklenebilir ve üretime hazır uygulamaların hızlı geliştirilmesini sağlar.",
                    ImageId = kalenuxerImageId
                }
            );

            // Proje 2: My Partners Hukuk Bürosu
            var mypImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = mypImageId,
                    FileName = "myp/1.webp",
                    FileType = "image/webp"
                });

            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 2,
                    Title = "My Partners Hukuk Bürosu",
                    SubTitle = "Dinamik hukuk sitesi",
                    Url = "https://myp.emirbaycan.com.tr",
                    Description = "Kalenuxer’in SSR algoritmalarını kullanarak, dinamik SQL verilerini optimize HTML yapılarına sorunsuzca dönüştüren; gerçek zamanlı içerik güncellemeleri, güvenli müşteri yönetimi ve hukuk ofislerine özel güçlü bir kontrol paneli içeren özel bir web sitesi.",
                    ImageId = mypImageId
                }
            );

            // Proje 3: Hukuki Yeterlilik Akademisi
            var hyaImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = hyaImageId,
                    FileName = "hya/1.webp",
                    FileType = "image/webp"
                });

            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 3,
                    Title = "Hukuki Yeterlilik Akademisi",
                    SubTitle = "Eğitim yönetim paneli",
                    Url = "https://hya.emirbaycan.com.tr",
                    Description = "Kalenuxer ile geliştirilmiş, eğitim firmalarına özel kapsamlı web sitesi ve yönetim paneli. Güvenli ders yönetimi, çok seviyeli kullanıcı erişimi ve gerçek zamanlı güncelleme özellikleriyle ölçeklenebilir ve kolay içerik yönetimi sağlar.",
                    ImageId = hyaImageId
                }
            );
            // Proje 4: Morkoç Hukuk Bürosu
            var morkocImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = morkocImageId,
                    FileName = "morkoc/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 4,
                    Title = "Morkoç Hukuk Bürosu",
                    SubTitle = "Hız ve güvenlik odaklı hukuk sitesi",
                    Url = "https://lawnux.emirbaycan.com.tr",
                    Description = "Kalenuxer tabanlı, hız ve güvenlik odaklı, hukuk sektörüne özel dinamik içerik yönetimi ve dava yönetimi sağlayan web sitesi ve özel kontrol paneli.",
                    ImageId = morkocImageId
                }
            );

            // Proje 5: Karalar Prefabrik
            var kpImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = kpImageId,
                    FileName = "kp/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 5,
                    Title = "Karalar Prefabrik",
                    SubTitle = "Prefabrik konut katalog yönetimi",
                    Url = "https://kp.emirbaycan.com.tr",
                    Description = "Kalenuxer tabanlı, prefabrik konut firmalarına yönelik gelişmiş katalog yönetimi, müşteri etkileşimi ve güçlü arka plan yetenekleriyle tam kapsamlı web sitesi ve yönetim paneli.",
                    ImageId = kpImageId
                }
            );

            // Proje 6: Eyüp Sultan Tulumbacısı
            var estImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = estImageId,
                    FileName = "est/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 6,
                    Title = "Eyüp Sultan Tulumbacısı",
                    SubTitle = "Ürün sergileme ve yönetimi",
                    Url = "https://eyp.emirbaycan.com.tr",
                    Description = "Kalenuxer ile geliştirilen, popüler bir tatlı markası için kullanıcı odaklı ve yüksek dönüşüm sağlayan ürün sergileme ve yönetimi kolay modern bir web sitesi.",
                    ImageId = estImageId
                }
            );

            // Proje 7: Girişimci Hukukçular Derneği
            var ghdImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = ghdImageId,
                    FileName = "ghd/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 7,
                    Title = "Girişimci Hukukçular Derneği",
                    SubTitle = "Dernek üye yönetimi sistemi",
                    Url = "https://ghd.emirbaycan.com.tr",
                    Description = "LAMP stack ile geliştirilmiş, üye yönetimi, etkinlik otomasyonu ve güvenli iletişim modülleri içeren, bir hukuk derneğine özel ilk web platformu ve yönetim sistemi.",
                    ImageId = ghdImageId
                }
            );

            // Proje 8: Hukuk Eğitim Programları
            var hepImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = hepImageId,
                    FileName = "hep/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 8,
                    Title = "Hukuk Eğitim Programları",
                    SubTitle = "Çoklu kurs içerik desteği",
                    Url = "https://hep.emirbaycan.com.tr",
                    Description = "Kalenuxer altyapısıyla geliştirilen, sürekli yeni özelliklerle güncellenen ve çoklu kurs içerik desteği sunan eğitim topluluğu web sitesi ve kontrol paneli.",
                    ImageId = hepImageId
                }
            );

            // Proje 9: Do Eloboost
            var deImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = deImageId,
                    FileName = "de/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 9,
                    Title = "Do Eloboost",
                    SubTitle = "Oyun servisi yönetim paneli",
                    Url = "https://de.emirbaycan.com.tr",
                    Description = "Kalenuxer ile geliştirilen, otomasyon, performans ve güvenlik açısından optimize edilmiş bir online oyun servisi sitesi ve yönetim paneli.",
                    ImageId = deImageId
                }
            );

            // Proje 10: Terapi Kliniği
            var tkImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = tkImageId,
                    FileName = "tk/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 10,
                    Title = "Terapi Kliniği",
                    SubTitle = "Psikologlara özel dinamik web sitesi",
                    Url = "", // Eklemek istersen link ekle
                    Description = "Laravel ve özel JavaScript kütüphaneleriyle kodlanmış, psikologlara yönelik dinamik web sitesi ve kontrol paneli. Laravel’i standart hosting ortamında çalışacak şekilde optimize ettim.",
                    ImageId = tkImageId
                }
            );

            // Proje 11: Murat Bulat Hukuk Bürosu
            var mbImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = mbImageId,
                    FileName = "mb/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 11,
                    Title = "Murat Bulat Hukuk Bürosu",
                    SubTitle = "Otomatik dosya yönetimi, müşteri portalı",
                    Url = "",
                    Description = "LAMP stack üzerinde geliştirilmiş, otomatik dosya yönetimi, güvenli müşteri portalı ve pratik yönetim araçları sunan kapsamlı bir hukuk bürosu web sitesi.",
                    ImageId = mbImageId
                }
            );

            // Proje 12: LAMP ile Portfolio
            var lampImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = lampImageId,
                    FileName = "lamp/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 12,
                    Title = "LAMP ile Portfolio",
                    SubTitle = "Çok dilli portfolyo sitesi",
                    Url = "https://lamp.emirbaycan.com.tr",
                    Description = "Kalenuxer ve LAMP altyapısıyla geliştirilen çok dilli portfolyo siteleri. Tam yığın (full-stack) uzmanlığımı ve ölçeklenebilir mimari yaklaşımımı gösteren projeler.",
                    ImageId = lampImageId
                }
            );

            // Proje 13: React ile Portfolio
            var mernImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = mernImageId,
                    FileName = "mern/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 13,
                    Title = "React ile Portfolio",
                    SubTitle = "React, Node.js tabanlı dinamik portfolyo",
                    Url = "https://mern.emirbaycan.com.tr",
                    Description = "React, Node.js ve MySQL üzerinde Ubuntu/Apache ile çalışan çok dilli portfolyo siteleri. Gelişmiş arayüz teknikleri ve arka uç entegrasyonu ile öne çıkıyor.",
                    ImageId = mernImageId
                }
            );

            // Proje 14: Laravel ve React ile Portfolyo
            var nmlrImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = nmlrImageId,
                    FileName = "nmlr/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 14,
                    Title = "Laravel ve React ile Portfolyo",
                    SubTitle = "Modern UI/UX interaktif site",
                    Url = "https://nmlr.emirbaycan.com.tr",
                    Description = "Laravel, React, Node.js ve Three.js ile tam yığın, interaktif portfolyo siteleri. Modern UI/UX ve güçlü teknik demo niteliğinde.",
                    ImageId = nmlrImageId
                }
            );

            // Proje 15: Next ile Portfolio
            var nextImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = nextImageId,
                    FileName = "next/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 15,
                    Title = "Next ile Portfolio",
                    SubTitle = "Next.js tabanlı çok dilli site",
                    Url = "https://next.emirbaycan.com.tr",
                    Description = "Next.js tabanlı çok dilli portfolyo siteleri. Dinamik içerik, Resend ile e-posta entegrasyonu ve bulut tabanlı ölçeklenebilirlik özellikleri.",
                    ImageId = nextImageId
                }
            );

            // Proje 16: Hesap Oluşturucu
            var acImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = acImageId,
                    FileName = "ac/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 16,
                    Title = "Hesap Oluşturucu",
                    SubTitle = "Otomatik hesap oluşturucu (C# & Selenium)",
                    Url = "",
                    Description = "C#, Selenium, Geckofx ve bulut servisleri (AWS, Google Cloud, Azure) kullanarak geliştirdiğim otomatik hesap oluşturucu. Yüksek hacimli ve tam otomatik kayıt işlemleri için VPN/proxy desteği de mevcut.",
                    ImageId = acImageId
                }
            );

            // Proje 17: Oylayıcı
            var vImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = vImageId,
                    FileName = "v/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 17,
                    Title = "Oylayıcı",
                    SubTitle = "Anonimleştirilmiş insan verisi üretici",
                    Url = "",
                    Description = "Python, Selenium ve Tor Browser IP döngüsüyle, ölçeklenebilir ve anonimleştirilmiş insan verisi üretici. Gerçekçi kullanıcı simülasyonu sağlar.",
                    ImageId = vImageId
                }
            );

            // Proje 18: Hız ve Uzunluk Hesaplayıcı
            var shcImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = shcImageId,
                    FileName = "shc/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 18,
                    Title = "Hız ve Uzunluk Hesaplayıcı",
                    SubTitle = "Nesne yüksekliği hesaplama",
                    Url = "",
                    Description = "Verilen parametrelerle nesne yüksekliğini hassas şekilde hesaplayan Python algoritması. Matematiksel modelleme ve algoritma geliştirme yeteneğini gösterir.",
                    ImageId = shcImageId
                }
            );

            // Proje 19: Dijital Ekran Bulucu
            var dsdImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = dsdImageId,
                    FileName = "dsd/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 19,
                    Title = "Dijital Ekran Bulucu",
                    SubTitle = "Python & YOLO tabanlı ekran tespit",
                    Url = "https://github.com/emirbaycan/yolo_digital_screen_detector",
                    Description = "Python ve YOLO kullanarak, canlı kamera akışlarından dijital ekranları gerçek zamanlı tespit eden bilgisayarla görü uygulaması.",
                    ImageId = dsdImageId
                }
            );

            // Proje 20: Dijital Ekran Okuyucu
            var dsrImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = dsrImageId,
                    FileName = "dsr/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 20,
                    Title = "Dijital Ekran Okuyucu",
                    SubTitle = "Gerçek zamanlı dijital ekran OCR",
                    Url = "https://github.com/emirbaycan/ocr_digital_screen_reader",
                    Description = "Canlı video akışlarında dijital ekranların otomatik tespiti ve OCR ile okuması. Python ile bilgisayarla görü ve karakter tanıma teknolojilerini bir araya getirir.",
                    ImageId = dsrImageId
                }
            );

            // Proje 21: Dijital Ekran Alarmı
            var dsaImageId = Guid.NewGuid();
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    Id = dsaImageId,
                    FileName = "dsa/1.webp",
                    FileType = "image/webp"
                });
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio
                {
                    Id = 21,
                    Title = "Dijital Ekran Alarmı",
                    SubTitle = "Gerçek zamanlı izleme ve uyarı",
                    Url = "https://github.com/emirbaycan/digital_screen_alarm_with_rtsp_camera",
                    Description = "Gerçek zamanlı dijital ekran izleme, eşik değer aşıldığında otomatik görüntü kaydı ve uyarı sistemi.",
                    ImageId = dsaImageId
                }
            );


            modelBuilder.Entity<Testimonial>().HasData(
                new Testimonial
                {
                    Id = 1,
                    NameSurname = "Av. Murat Kara",
                    Title = "My Partners Hukuk Bürosu | Kurucu Avukat",
                    Description = "Emir ile birlikte hukuk büromuzun dijital altyapısını tamamen modernize ettik. Dinamik kontrol paneli ve müşteri yönetimi konusunda beklentimizin çok üstünde çözümler sundu.",
                    ImageUrl = null
                },
                new Testimonial
                {
                    Id = 2,
                    NameSurname = "Murat Kara",
                    Title = "Girişimci Hukukçular Derneği | Kurucu",
                    Description = "Web platformumuzu sıfırdan tasarlayıp tüm üyelik ve etkinlik süreçlerini dijitalleştirdi. Hızlı teslimat ve teknik destek açısından eşsiz bir iş ortağı.",
                    ImageUrl = null
                },
                new Testimonial
                {
                    Id = 3,
                    NameSurname = "Burak Kara",
                    Title = "Karalar Prefabrik | Kurucu",
                    Description = "Kurumsal sitemizi ve katalog yönetim sistemimizi kurduktan sonra müşteri geri dönüşlerimizde %40 artış yaşadık. Yazılım kalitesi ve iş takibi gerçekten çok iyi.",
                    ImageUrl = "hasan-karalar.webp"
                },
                new Testimonial
                {
                    Id = 4,
                    NameSurname = "Muhammet Morkoç",
                    Title = "Hukuki Yeterlilik Akademisi | Kurucu",
                    Description = "Geliştirdiği özel panel ve otomasyonlar sayesinde eğitim süreçlerimiz çok daha verimli hale geldi. Teknik bilgisinin yanı sıra iletişimde de çok profesyonel.",
                    ImageUrl = null
                },
                new Testimonial
                {
                    Id = 5,
                    NameSurname = "Muhammet Morkoç",
                    Title = "Morkoç Hukuk | Avukat",
                    Description = "Özellikle dava ve dosya yönetim sistemimizdeki yenilikçi yaklaşımı sayesinde işlerimizi daha hızlı ve güvenli yürütebiliyoruz. Tavsiye ederim.",
                    ImageUrl = null
                },
                new Testimonial
                {
                    Id = 6,
                    NameSurname = "Uğur",
                    Title = "Freelance İşveren",
                    Description = "Farklı projelerimizde Emir Baycan ile çalışma fırsatım oldu. Her seferinde sonuca odaklı, hızlı ve ölçeklenebilir projeler teslim etti.",
                    ImageUrl = null
                },
                new Testimonial
                {
                    Id = 7,
                    NameSurname = "Berke",
                    Title = "Full-Stack Developer | Takım Arkadaşı",
                    Description = "Teknolojideki yenilikleri takip eden, algoritmik zekası ve analiz gücüyle öne çıkan bir yazılımcı. Takım çalışmalarında ve proje yönetiminde çok güçlü.",
                    ImageUrl = null
                }
            );

            modelBuilder.Entity<Experience>().HasData(
                new Experience
                {
                    Id = 1,
                    Head = "Karalar Kağıt",
                    Title = "Yazılım Uzmanı",
                    Date = "Eylül 2024 - Kasım 2024",
                    Description = "Kurumsal web projelerinin analiz, geliştirme ve entegrasyon süreçlerinde tam sorumluluk üstlendim."
                },
                new Experience
                {
                    Id = 2,
                    Head = "My Partners Hukuk Bürosu",
                    Title = "Yazılım Uzmanı",
                    Date = "Ocak 2024 - Hala çalışıyorum",
                    Description = "Dijital altyapı ve otomasyon projelerinin planlama, geliştirme ve bakımından sorumluyum."
                },
                new Experience
                {
                    Id = 3,
                    Head = "Eyüp Sultan Tulumbacısı",
                    Title = "Web Programcısı",
                    Date = "Ekim 2022 - Aralık 2022",
                    Description = "Web ve e-ticaret platformlarının tasarım, geliştirme ve uygulama süreçlerini yönettim."
                },
                new Experience
                {
                    Id = 4,
                    Head = "Hukuki Yeterlilik Akademisi",
                    Title = "Yazılım Uzmanı",
                    Date = "Mart 2022 - Ağustos 2023",
                    Description = "Eğitim platformunun kullanıcı ve sınav modüllerinin analiz, geliştirme ve uygulama aşamalarında sorumluluk aldım."
                },
                new Experience
                {
                    Id = 5,
                    Head = "Terapi Kliniği",
                    Title = "Yazılım Uzmanı",
                    Date = "Şubat 2022 - Nisan 2022",
                    Description = "Danışan takip sistemi ve online randevu altyapısının geliştirme süreçlerinde görev aldım."
                },
                new Experience
                {
                    Id = 6,
                    Head = "Morkoç Hukuk Bürosu",
                    Title = "Yazılım Uzmanı",
                    Date = "Temmuz 2021 - Eylül 2021",
                    Description = "Doküman yönetim sistemi ve online danışmanlık modüllerinin yazılım süreçlerinde aktif rol oynadım."
                },
                new Experience
                {
                    Id = 7,
                    Head = "Kalenux",
                    Title = "CEO",
                    Date = "Şubat 2021 - Şubat 2023",
                    Description = "Yazılım geliştirme, ekip yönetimi ve iş geliştirme süreçlerinin tamamında sorumluluk üstlendim."
                },
                new Experience
                {
                    Id = 8,
                    Head = "Karalar Prefabrik",
                    Title = "Yazılım Uzmanı",
                    Date = "Eylül 2020 - Kasım 2020",
                    Description = "Kurumsal web sitesi ve müşteri iletişim sistemlerinin analiz ve geliştirme aşamalarında görev aldım."
                },
                new Experience
                {
                    Id = 9,
                    Head = "Hukuk Eğitim Programları",
                    Title = "Web Yazılım Uzmanı",
                    Date = "Ocak 2020 - Ocak 2021",
                    Description = "Eğitim programları için web tabanlı yazılım çözümlerinin geliştirme süreçlerinde görev aldım."
                },
                new Experience
                {
                    Id = 10,
                    Head = "Do Eloboost",
                    Title = "Yazılım Uzmanı",
                    Date = "Ocak 2019 - Ocak 2023",
                    Description = "Oyun tabanlı platformun yazılım altyapısının geliştirilmesi ve otomasyon süreçlerinde sorumluluk aldım."
                },
                new Experience
                {
                    Id = 11,
                    Head = "Murat Bulat Hukuk Bürosu",
                    Title = "Yazılım Uzmanı",
                    Date = "Ocak 2019 - Nisan 2019",
                    Description = "Web tabanlı yazılım ve otomasyon sistemlerinin geliştirilmesinde görev aldım."
                },
                new Experience
                {
                    Id = 12,
                    Head = "Girişimci Hukukçular Derneği",
                    Title = "Yazılım Uzmanı",
                    Date = "Ocak 2018 - Ocak 2019",
                    Description = "Derneğe özel dijital projelerin planlama ve geliştirilme süreçlerinde aktif görev üstlendim."
                }
            );
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Title = "Backend", Value = 100 },
                new Skill { Id = 2, Title = "Frontend", Value = 100 },
                new Skill { Id = 3, Title = "Full-stack Geliştirme", Value = 100 },
                new Skill { Id = 4, Title = "Serverside", Value = 100 }
            );
        }

    }
}
