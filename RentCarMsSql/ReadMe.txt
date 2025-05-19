CASE ÇALIŞMASI 

Bir araba-kiralama sitesi yaptık.Siteye giriş yapmamış kullanıcılarda ana sayfada araba kartlarını görecektir.
 
Giriş yapan kullanıcıların giriş yapmamış misafirlerden farkı araba kartlarında kirala butonunun olmasıdır.

Admin ise araba üzerinden crud işlemleri yapacak Araba Kartı ekleyip,çıkartıp,düzenleyip,siliyor.


Projenin genel yapısı Bir ASP.NET MVC uygulamasıdır bir katmanlı mimari kullandık.
Generic bir repository oluşturup entity işlemlerimizi bu Generic Repository üzerinden sağlıyoruz.
Projede database işlemlerimiz için Entity Framework kullanıyoruz.

Projemizdeki js,css dosyaları ilgili projenin wwwroot dosyasında gözüküyor.

JS kütüphanesi Ajaxı projemizde sayfayı yenilemeden Kullanıcı araba kiralama işlemi yapabilmesi için ayarladık.

Dosyanın içerisindeki PostgreSql Querysinde birtakım sorgular yapılmıştır örnek amaçlı.


Proje .NET 9.0'dır.

İlgili tüm NuGet Packageler de dolayısıyla 9.0 uygun paketlerdir örnek olarak 9.0.4