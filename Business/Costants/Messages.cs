using Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Costants
{
    public static class Messages
    {
        public static string AddBookMessage = "Kitap eklendi.";
        public static string RemoveBookMessage="Kitap silindi.";
        public static string UpdateBookMessage="Kitap güncellendi.";
        public static string UserRegisteredMessage="Kullanıcı kaydedildi.";
        public static string UserEmailNotFound="Email bulunamadı !";
        public static string PasswordError="Şifre hatalı!";
        public static string SuccessfullLoginMessage="Giriş başarılı.";
        public static string UserAlreadyExist="Kullanıcı zaten mevcut.";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string NotUnique="Kitap mevcut";
    }
}
