# 🚀 ASP.NET Core 9.0 | Dinamik Portfolio & CV Yönetim Platformu

<div align="center">

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-13.0-239120?style=for-the-badge&logo=csharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Tailwind CSS](https://img.shields.io/badge/Tailwind%20CSS-3.4-06B6D4?style=for-the-badge&logo=tailwindcss&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![Entity Framework](https://img.shields.io/badge/EF%20Core-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

### **Uçtan Uca Yönetilebilir, Güvenlik Odaklı Kişisel Web Platformu**

*Statik portfolyoların ötesinde — yaşayan, veri üreten ve her noktası kontrol edilebilen dijital kimlik*

[🌐 Canlı Demo](https://bayraminkaya.com) • [📧 İletişim](mailto:info@bayraminkaya.com)

</div>

---

## 📖 Proje Özeti ve Vizyonu

Bu proje, **ASP.NET Core 9.0 MVC** teknolojisi ile geliştirilmiş kapsamlı bir **İçerik Yönetim Sistemi (CMS)**'dir. Klasik statik portfolyo sitelerinin çok ötesinde; **gerçek zamanlı veri işleme**, **güvenli kimlik doğrulama** ve **modüler mimari** ile inşa edilmiş profesyonel bir platformdur.

### 🎯 Temel Hedefler

| Hedef | Açıklama |
|-------|----------|
| **🔄 Dinamik İçerik** | Statik HTML yerine veritabanından beslenen canlı içerik |
| **🛡️ Kurumsal Güvenlik** | SHA256 + Salt şifreleme, Session tabanlı auth |
| **📊 Veri Odaklı** | Anlık istatistikler, ziyaretçi etkileşimleri |
| **🧩 Modüler Yapı** | ViewComponent mimarisi ile yeniden kullanılabilir kod |
| **🌍 Global Erişim** | Google Translate ile çok dilli destek |

### 💡 Vizyon

> *"Bir geliştirici için portfolyo sitesi sadece bir vitrin değil, aynı zamanda teknik yetkinliğin canlı bir kanıtıdır."*

Bu platform, kod yazmadan tüm içeriklerin yönetilebildiği, ziyaretçi mesajlarının takip edilebildiği ve kariyer geçmişinin profesyonelce sergilenebildiği **eksiksiz bir dijital kimlik çözümü** sunar.

---

## 📸 Proje Vitrini

### 📊 Admin Dashboard — Komuta Merkezi

Stratejik karar alma sürecini destekleyen; **canlı veritabanı istatistikleri**, **mesaj bildirimleri** ve **hızlı erişim kartları** ile donatılmış yönetim paneli.

<details>
<summary>📸 Dashboard Ekran Görüntüsü</summary>

![Dashboard](Images/Ekran görüntüsü 2026-02-09 114534.png)

</details>

---

### 🔐 Güvenli Giriş Sistemi

Modern glassmorphism tasarım, SSL göstergesi ve kurumsal güvenlik hissi veren premium giriş deneyimi.

<details>
<summary>📸 Login Ekran Görüntüsü</summary>

![Login](Images/login.png)

</details>

---

### ⚙️ Admin Panel Modülleri

Her biri bağımsız CRUD operasyonlarına sahip, Tailwind CSS ile tasarlanmış yönetim arayüzleri.

<details>
<summary>📸 Tüm Admin Modüllerini Görüntüle</summary>

| Modül | Ekran Görüntüsü |
|-------|-----------------|
| 📋 **Hakkımda Yönetimi** | ![About](Images/admin-about.png) |
| 💼 **Deneyim Yönetimi** | ![Experience](Images/admin-experience.png) |
| 🎨 **Portfolio Yönetimi** | ![Portfolio](Images/admin-portfolio.png) |
| 🏆 **Sertifika Yönetimi** | ![Certificate](Images/admin-certificate.png) |
| 📧 **Mesaj Kutusu** | ![Messages](Images/admin-messages.png) |
| ⚙️ **Ayarlar** | ![Settings](Images/admin-settings.png) |

</details>

---

### 🌐 Kullanıcı Arayüzü — Dijital Vitrin

Modern UI/UX prensiplerine uygun, tamamen responsive ve veritabanı destekli dinamik ön yüz.

<details>
<summary>📸 Tam Sayfa Görünümü</summary>

| Bölüm | Ekran Görüntüsü |
|-------|-----------------|
| 🏠 **Hero Section** | ![Hero](Images/hero.png) |
| 👤 **Hakkımda** | ![About](Images/about.png) |
| 💼 **Hizmetler** | ![Services](Images/services.png) |
| 📜 **Deneyimler** | ![Experience](Images/experience.png) |
| 🎨 **Portfolio** | ![Portfolio](Images/portfolio.png) |
| 💬 **İletişim** | ![Contact](Images/contact.png) |

</details>

---

## 🔥 Teknik Mimari ve Özellikler

Bu proje, **Clean Code** prensipleri ve **MVC Pattern** üzerinde, ölçeklenebilir bir mimari ile inşa edilmiştir.

### 🏗️ Sistem Mimarisi
```
┌─────────────────────────────────────────────────────────────────┐
│                        PRESENTATION LAYER                        │
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────────┐  │
│  │   Views (.cshtml)│  │  ViewComponents │  │  Static Assets  │  │
│  │   Razor Pages   │  │  Partial Views  │  │  CSS/JS/Images  │  │
│  └─────────────────┘  └─────────────────┘  └─────────────────┘  │
├─────────────────────────────────────────────────────────────────┤
│                        BUSINESS LAYER                            │
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────────┐  │
│  │   Controllers   │  │  Action Filters │  │   Validation    │  │
│  │   15+ Modules   │  │  Auth Filter    │  │   Business Rules│  │
│  └─────────────────┘  └─────────────────┘  └─────────────────┘  │
├─────────────────────────────────────────────────────────────────┤
│                        DATA ACCESS LAYER                         │
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────────┐  │
│  │  EF Core 9.0    │  │   DbContext     │  │    Entities     │  │
│  │  Code First     │  │  ResumeContext  │  │   12 Models     │  │
│  └─────────────────┘  └─────────────────┘  └─────────────────┘  │
├─────────────────────────────────────────────────────────────────┤
│                        DATABASE LAYER                            │
│  ┌─────────────────────────────────────────────────────────────┐│
│  │                    SQL Server 2022                          ││
│  │         Relational Database • Stored Data • Backups         ││
│  └─────────────────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────────┘
```

---

### 🛠️ Backend Teknolojileri

| Teknoloji | Versiyon | Kullanım Alanı |
|-----------|----------|----------------|
| **ASP.NET Core MVC** | 9.0 | Ana web framework, routing, middleware |
| **Entity Framework Core** | 9.0 | ORM, Code First migrations, LINQ queries |
| **C#** | 13.0 | Sunucu tarafı iş mantığı |
| **SQL Server** | 2022 | İlişkisel veritabanı yönetimi |
| **Session Authentication** | - | Güvenli oturum yönetimi |

### 🎨 Frontend Teknolojileri

| Teknoloji | Kullanım Alanı |
|-----------|----------------|
| **Tailwind CSS 3.4** | Admin Panel — Utility-first modern styling |
| **Bootstrap 5.3** | Frontend — Responsive grid ve bileşenler |
| **JavaScript ES6+** | İnteraktif özellikler, DOM manipülasyonu |
| **jQuery 3.7** | AJAX işlemleri, event handling |

### 📚 Entegre Kütüphaneler

| Kütüphane | İşlev |
|-----------|-------|
| **Isotope.js** | Portfolio grid filtreleme ve masonry layout |
| **Magnific Popup** | Profesyonel lightbox görsel galerisi |
| **Slick Slider** | Touch-enabled testimonial carousel |
| **WOW.js** | Scroll-triggered reveal animasyonları |
| **Counter Up** | Animasyonlu istatistik sayaçları |
| **Google Translate API** | Otomatik çok dilli site desteği |

---

### 🗄️ Veritabanı Şeması

Sistemin kalbi olan ilişkisel veritabanı, **12 entity** ve optimize edilmiş sorgular ile çalışır.

| Entity | Açıklama | Temel Alanlar |
|--------|----------|---------------|
| **About** | Kişisel bilgiler | Ad, Unvan, Bio, CV URL, Profil Görseli |
| **Experience** | Kariyer geçmişi | Şirket, Pozisyon, Tarih Aralığı, Detaylar |
| **Portfolio** | Proje vitrini | Başlık, Kategori, Görseller, Proje URL |
| **Service** | Sunulan hizmetler | İkon, Başlık, Açıklama |
| **Skill** | Teknik yetenekler | Kategori, Yetenek Adı, Seviye |
| **Certificate** | Profesyonel sertifikalar | Ad, Kurum, Tarih, Doğrulama URL |
| **Testimonial** | Müşteri referansları | Ad, Pozisyon, Yorum, Avatar |
| **SocialMedia** | Sosyal linkler | Platform, URL, İkon |
| **Statistic** | Sayısal veriler | İkon, Değer, Başlık |
| **Message** | İletişim mesajları | Ad, Email, Konu, Mesaj, Tarih, Okundu |
| **Admin** | Yönetici hesabı | Username, PasswordHash, Profil, LastLogin |
| **Category** | Portfolio kategorileri | Ad, Açıklama |

---

### 🔒 Güvenlik Mimarisi

| Katman | Uygulama | Detay |
|--------|----------|-------|
| **🔐 Şifre Güvenliği** | SHA256 + Salt | Rainbow table saldırılarına karşı koruma |
| **🛡️ Session Yönetimi** | HttpOnly Cookies | XSS saldırılarına karşı koruma |
| **🚧 Yetkilendirme** | Custom Action Filter | Yetkisiz erişim engelleme |
| **💉 SQL Injection** | Parametreli Sorgular | EF Core ile otomatik koruma |
| **🔧 Konfigürasyon** | Ortam Bazlı Ayırım | Development/Production izolasyonu |
| **📁 Hassas Veri** | .gitignore | Production secrets GitHub'da yok |

---

### 🧩 Modüler ViewComponent Yapısı

Tekrar kullanılabilir, bağımsız ve test edilebilir UI bileşenleri:
```
ViewComponents/
├── _DefaultAboutComponentPartial        → Hakkımda bölümü
├── _DefaultExperienceComponentPartial   → Deneyim timeline
├── _DefaultPortfolioComponentPartial    → Proje galerisi
├── _DefaultServiceComponentPartial      → Hizmet kartları
├── _DefaultSkillComponentPartial        → Yetenek modal
├── _DefaultCertificateComponentPartial  → Sertifika vitrini
├── _DefaultTestimonialComponentPartial  → Referans carousel
├── _DefaultStatisticComponentPartial    → İstatistik sayaçları
├── _DefaultSocialMediaComponentPartial  → Sosyal linkler
├── _DefaultContactComponentPartial      → İletişim formu
├── _DefaultSidebarComponentPartial      → Navigasyon menüsü
└── _DefaultScriptsComponentPartial      → Script yönetimi
```

---

## ✨ Öne Çıkan Özellikler

### 🎯 Admin Panel Özellikleri

| Özellik | Açıklama |
|---------|----------|
| 📊 **Canlı Dashboard** | Veritabanından anlık istatistikler |
| 📧 **Mesaj Merkezi** | Okunmamış mesaj bildirimleri |
| 🖼️ **Medya Yönetimi** | Görsel URL'leri ile kolay yönetim |
| ✏️ **Inline Düzenleme** | Her içerik için CRUD operasyonları |
| 🔔 **Bildirim Sistemi** | Yeni mesaj ve aktivite uyarıları |
| 👤 **Profil Yönetimi** | Admin bilgileri ve şifre değiştirme |

### 🌐 Frontend Özellikleri

| Özellik | Açıklama |
|---------|----------|
| 📱 **Tam Responsive** | Mobil, tablet, desktop uyumlu |
| 🌍 **3 Dil Desteği** | Türkçe, İngilizce, Almanca |
| 🎨 **Modern Tasarım** | Glassmorphism, gradient efektler |
| ⚡ **Smooth Animasyonlar** | Scroll-triggered reveal efektleri |
| 🖼️ **Lightbox Galeri** | Profesyonel proje showcase |
| 📄 **CV İndirme** | Tek tıkla özgeçmiş indirme |

---

## 🤖 AI Destekli Geliştirme

Bu proje, modern AI araçları ile geliştirilmiştir:

| Geliştirme Alanı | AI Aracı | Katkı |
|------------------|----------|-------|
| 🎨 **Admin Panel UI** | Google Stitch AI | Tailwind CSS tabanlı modern dashboard tasarımı |
| 🎭 **Frontend Styling** | Claude AI | CSS animasyonlar, responsive düzenlemeler |

> 💡 *AI araçları, geliştirme sürecini hızlandırmak, kod kalitesini artırmak ve modern best practice'leri uygulamak için stratejik olarak kullanılmıştır.*

---

## 🛠️ Teknoloji Yığını (Tech Stack)

<div align="center">

| Backend | Frontend | Veritabanı | Araçlar |
|---------|----------|------------|---------|
| ![.NET](https://img.shields.io/badge/.NET_9-512BD4?style=flat-square&logo=dotnet&logoColor=white) | ![Tailwind](https://img.shields.io/badge/Tailwind-06B6D4?style=flat-square&logo=tailwindcss&logoColor=white) | ![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white) | ![VS 2022](https://img.shields.io/badge/VS_2022-5C2D91?style=flat-square&logo=visualstudio&logoColor=white) |
| ![C#](https://img.shields.io/badge/C%23_13-239120?style=flat-square&logo=csharp&logoColor=white) | ![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=flat-square&logo=bootstrap&logoColor=white) | ![EF Core](https://img.shields.io/badge/EF_Core-512BD4?style=flat-square&logo=dotnet&logoColor=white) | ![GitHub](https://img.shields.io/badge/GitHub-181717?style=flat-square&logo=github&logoColor=white) |
| ![ASP.NET](https://img.shields.io/badge/ASP.NET_MVC-512BD4?style=flat-square&logo=dotnet&logoColor=white) | ![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=flat-square&logo=javascript&logoColor=black) | | ![Plesk](https://img.shields.io/badge/Plesk-52BBE6?style=flat-square&logo=plesk&logoColor=white) |

</div>

---

## 👨‍💻 Geliştirici

<div align="center">

### **Bayram İnkaya**
*Full-Stack .NET Developer & Computer Engineer*

[![LinkedIn](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://linkedin.com/in/bayraminkaya)
[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/bayraminkaya)
[![Website](https://img.shields.io/badge/Portfolio-FF4C60?style=for-the-badge&logo=google-chrome&logoColor=white)](https://bayraminkaya.com)
[![Email](https://img.shields.io/badge/Email-D14836?style=for-the-badge&logo=gmail&logoColor=white)](mailto:info@bayraminkaya.com)

</div>

---

<div align="center">

### ⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!

*Modern web geliştirme pratiklerini ve ASP.NET Core 9.0'ın gücünü keşfedin.*

</div>
