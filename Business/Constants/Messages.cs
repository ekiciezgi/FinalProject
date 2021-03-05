using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAddes = "ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";
        internal static string MaintenanceTime="sistem bakımda";
        internal static string ProductsListed="ürünler listelendi";
        internal static string ProductCountOfCategoryError = "ürünler listelendi";
        internal static string ProductNameAlreadyExists = "bu isimde zaten başka bir ürün var ";

        internal static string CategoryLimitExceded = "kategory limiti aşılıdğı için yeni ürün eklenemiyor.";
        internal static string AuthorizationDenied = "yetkiniz yok";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public  static string ProductUpdated="güncellendi";
    }
}
