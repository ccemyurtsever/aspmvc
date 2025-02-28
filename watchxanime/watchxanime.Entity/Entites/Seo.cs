using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watchxanime.Entity.Entites
{
    public class Seo
    {
        // Genel Meta Bilgileri
        public string? Title { get; set; } // Sayfa başlığı
        public string? Description { get; set; } // Meta açıklaması
        public string? Keywords { get; set; } // Anahtar kelimeler
        public string? CanonicalUrl { get; set; } // Canonical URL
        public string? Robots { get; set; } // Robots meta etiketi (ör. "index, follow")

        // Open Graph (OG) Etiketleri
        public string? OgTitle { get; set; } // Open Graph başlığı
        public string? OgDescription { get; set; } // Open Graph açıklaması
        public string? OgImage { get; set; } // Open Graph görsel URL'si
        public string? OgUrl { get; set; } // Open Graph URL'si
        public string? OgType { get; set; } // Open Graph türü (ör. "website", "article")

        // Twitter Kartı Etiketleri
        public string? TwitterTitle { get; set; } // Twitter Card başlığı
        public string? TwitterDescription { get; set; } // Twitter Card açıklaması
        public string? TwitterImage { get; set; } // Twitter Card görsel URL'si
        public string? TwitterCardType { get; set; } // Twitter Card tipi (ör. "summary", "summary_large_image")

        // Diğer SEO İlgili Bilgiler
        public string? Author { get; set; } // Yazar bilgisi
        public string? Charset { get; set; } // Karakter seti (ör. "UTF-8")
        public string? Hreflang { get; set; } // Dil ve bölge (ör. "en-US")
        public string? AlternateUrl { get; set; } // Alternatif dil URL'si
        public string? FaviconUrl { get; set; } // Favicon URL'si

        // Sosyal Medya Paylaşım Bağlantıları
        public string? FacebookPageUrl { get; set; } // Facebook sayfa URL'si
        public string? TwitterHandle { get; set; } // Twitter kullanıcı adı (ör. @username)
    }

}
