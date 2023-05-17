using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //araba mesajları
        public static string CarListed = "Araçlar listelendi";
        public static string CarByIdListed = "Araçlar Id göre listelendi";
        public static string CarAdded = "Araba ekleme Başarılı";
        public static string CarUpdated = "Araba günceleme başarılı";
        public static string CarNotListed = "Araba bulunamadı";

        //kullanıcı mesajları
        public static string UserNotFind = "Kullanıcı bulunamadı";
        public static string UserByIdListed = "Kullanıcı listelendi";
        public static string UserAllListed = "Kullanıcılar listelendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserUpdated = "Kullanıcı Güncellendi";

        //segment mesajları
        public static string SegmentAdded = "Segment eklendi";
        public static string SegmentUpdated = "Segment güncellendi";
        public static string SegmentDeleted = "Segment silindi";
        public static string SegmentAllListed = "Tüm segmentler listelendi";
        public static string SegmentByIdListed = "Id göre segment listelendi";
    }
}
