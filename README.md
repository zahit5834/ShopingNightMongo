# ShopingNightMongo

ShopingNightMongo, MongoDB veritabanı kullanan modern bir e-ticaret web uygulamasıdır. ASP.NET Core MVC mimarisi kullanılarak geliştirilmiştir.

## 🚀 Özellikler

- Ürün yönetimi
- Kategori yönetimi
- Müşteri yönetimi
- Galeri yönetimi
- Ürün görseli yönetimi
- Responsive tasarım
- MongoDB veritabanı entegrasyonu

## 🛠️ Teknolojiler

- ASP.NET Core MVC
- MongoDB
- AutoMapper
- Bootstrap
- HTML5/CSS3
- JavaScript

## 📋 Gereksinimler

- .NET 6.0 veya üzeri
- MongoDB Server
- Visual Studio 2022 veya Visual Studio Code

## 🔧 Kurulum

1. Projeyi klonlayın:
```bash
git clone https://github.com/yourusername/ShopingNightMongo.git
```

2. MongoDB'yi yükleyin ve çalıştırın:
- [MongoDB Community Server](https://www.mongodb.com/try/download/community)'ı indirin ve kurun
- MongoDB servisini başlatın

3. Proje dizinine gidin:
```bash
cd ShopingNightMongo
```

4. Bağımlılıkları yükleyin:
```bash
dotnet restore
```

5. Uygulamayı çalıştırın:
```bash
dotnet run
```

## ⚙️ Yapılandırma

`appsettings.json` dosyasında aşağıdaki ayarları yapılandırabilirsiniz:

- MongoDB bağlantı dizesi
- Veritabanı adı
- Koleksiyon isimleri

## 📁 Proje Yapısı

```
ShopingNightMongo/
├── Controllers/        # MVC Controller'lar
├── Models/            # View Model'ler
├── Views/             # Razor View'lar
├── Services/          # İş mantığı servisleri
├── Entities/          # Veritabanı entity'leri
├── Dtos/              # Data Transfer Objects
├── Mapping/           # AutoMapper profilleri
├── Settings/          # Uygulama ayarları
└── wwwroot/           # Statik dosyalar
```

## 🔐 Güvenlik

- HTTPS yönlendirmesi aktif
- HSTS (HTTP Strict Transport Security) aktif
- Güvenli bağlantı yapılandırması

## 📝 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için [LICENSE](LICENSE) dosyasına bakın.

## 👥 Katkıda Bulunma

1. Bu depoyu fork edin
2. Yeni bir branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some amazing feature'`)
4. Branch'inizi push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluşturun

## 📞 İletişim

Proje Sahibi - [@yourusername](https://github.com/yourusername)

Proje Linki: [https://github.com/yourusername/ShopingNightMongo](https://github.com/yourusername/ShopingNightMongo)

## 📸 Ekran Görüntüleri

### Ana Sayfa
![Ana Sayfa](ShopingNightMongo/wwwroot/img/Home.png)

### Kategori Yönetimi
![Kategori Yönetimi](ShopingNightMongo/wwwroot/img/Kategori.png)

### Ürün Yönetimi
![Ürün Yönetimi](ShopingNightMongo/wwwroot/img/Ürün.png)

### Galeri Yönetimi
![Galeri Yönetimi](ShopingNightMongo/wwwroot/img/Galeri.png)

### Ürün Resim Yönetimi
![Ürün Resim Yönetimi](ShopingNightMongo/wwwroot/img/ÜrünResim.png) 