# 🧰 Emir Baycan – C# Portfolio Website

Bu repository, kişisel portfolyo web sitemin kaynak kodlarını içerir. **ASP.NET Core MVC** ile geliştirilmiş; deneyimlerim, projelerim ve teknik becerilerim modern, sürdürülebilir ve modüler bir yapı ile sergilenir. MSSQL veritabanı ve Docker ile "one-click run" desteğiyle kolay kurulum sağlar.

> 🌐 **Canlı Demo:** [emirbaycan.com.tr](https://emirbaycan.com.tr)

---

## 🚀 Özellikler

* **Dinamik İçerik Yönetimi:** Deneyimler, projeler ve yetenekler kolayca güncellenebilir.
* **Duyarlı Tasarım:** Tüm cihazlarda sorunsuz görüntülenme.
* **Modüler Mimari:** Kolayca ölçeklenebilir ve yeni özellikler eklenebilir.
* **SEO ve Performans Optimizasyonu:** Hızlı yükleme, arama motoru dostu yapı.
* **Tek Tuşla Çalıştırma:** Docker Compose ile uygulama ve MSSQL tek komutla ayağa kalkar.
* **Güncel Proje Klasör Yapısı:** Best-practice MVC dizin organizasyonu.

---

## 🛠️ Kullanılan Teknolojiler

* **Frontend:** HTML5, CSS3, JavaScript, Razor Views
* **Backend:** ASP.NET Core MVC, C#
* **Database:** MSSQL (Dockerize edilmiş, Entity Framework Core ile)
* **Containerization:** Docker & Docker Compose
* **Version Control:** Git & GitHub
* **Deployment:** Linux sunucu, Nginx (reverse proxy ile)

---

## 📁 Project Structure

```
MyPortfolioProject/
├── wwwroot/
│   ├── Admin-theme/
│   ├── login-theme/
│   ├── portfolio-theme/
│   ├── css/
│   ├── icons/
│   ├── images/
│   ├── js/
│   ├── lib/
│   ├── ProjectScreenShoots/
│   │   └── full_page.png
│   └── favicon.ico
├── Controllers/
│   ├── AboutController.cs
│   ├── AdminLoginController.cs
│   ├── ContactController.cs
│   ├── DefaultController.cs
│   ├── ExperienceController.cs
│   ├── FeatureController.cs
│   ├── MessageController.cs
│   ├── PortfolioController.cs
│   ├── ProfileController.cs
│   ├── SkillController.cs
│   ├── SocialMediaController.cs
│   ├── StatisticController.cs
│   ├── TestimonialController.cs
│   └── ToDoListController.cs
├── DAL/
│   ├── Context/
│   ├── Entities/
│   └── Extensions/
├── Helpers/
│   └── Images/
├── Migrations/
├── Models/
│   ├── ViewModel/
├── ViewComponents/
│   ├── AdminStatisticComponent/
│   └── LayoutViewComponents/
│       └── (Partial view component dosyaları)
├── Views/
│   ├── About/
│   ├── AdminLogin/
│   ├── Contact/
│   ├── Default/
│   ├── Experience/
│   ├── Feature/
│   ├── Message/
│   ├── Portfolio/
│   ├── Profile/
│   └── Shared/
│       └── Components/
│           └── (Partial view dosyaları)
├── appsettings.json
├── docker-compose.yml
└── Program.cs
```

Proje ekran görüntüleri:

```
wwwroot/ProjectScreenShoots/full_page.png
```

---

## ⚙️ Hızlı Başlangıç (One-Click Run)

### Gereksinimler

* [Docker Desktop](https://www.docker.com/products/docker-desktop/)
* (Opsiyonel: .NET 6 SDK, geliştirme için)

### Kurulum ve Çalıştırma

1. **Projeyi klonla:**

   ```bash
   git clone https://github.com/emirbaycan/portfolio-c-sharp.git
   cd portfolio-c-sharp
   ```
2. **Docker Compose ile başlat:**

   ```bash
   docker-compose up --build
   ```

   Uygulama ve MSSQL veritabanı otomatik olarak başlar.
3. **Tarayıcıdan ulaş:**
   [http://localhost:5000](http://localhost:5000)

---

## 🧪 Test

Testler `Tests/` klasöründe (varsa) bulunur. Çalıştırmak için:

```bash
dotnet test
```

---

## 📸 Ekran Görüntüleri

Ana sayfa genel görünüm:

![Full Page Screenshot](MyPortfolioProject/wwwroot/ProjectScreenShoots/full_page.png)

---

## 📬 İletişim

Her türlü öneri veya iş birliği için:

* **Email**: [emir-baycan@hotmail.com](mailto:emir-baycan@hotmail.com)
* **Website**: [emirbaycan.com.tr](https://emirbaycan.com.tr)

---

## 📄 Lisans

Bu proje [MIT Lisansı](LICENSE) ile lisanslanmıştır.
