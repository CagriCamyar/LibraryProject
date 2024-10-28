using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "Sistem şu anda bakımda";

        public static string ImageLimitInvalid = "Urun Icin Maksimum 5 Fotograf Eklenebilir.";
        public static string ImageLimitSucceed = "Urun Fotografi Icin Yeterli Limit Var";
        public static string ImageAdded = "Urun Icin Fotograf Eklendi";
        public static string ImageDeleted = "Urun Icin Fotograf Silindi";
        public static string ImageUpdated = "Urun Icin Fotograf Guncellendi";

        public static string UserAdded = "Yeni Kullanici Eklendi";
        public static string UserDeleted = "Kullanici Silindi";
        public static string UserUpdated = "Kullanici Bilgisi Guncellendi";
        public static string UsersListed = "Kullanicilar Listelendi";
        public static string GetUser = "Sectiginiz Kullanici : ";
        public static string UsersListedWithDetails = "Kullanicilarin Detaylari Listelendi";

        public static string AuthorizationDenied = "Bu Islem Icin Yetkiniz Yok";
        public static string ClaimsListed = "Kullaniciya Ait Claimler Listelendi";
        public static string GetUserByMail = "Bu Maile Sahip Kullanici : ";
    }
}
