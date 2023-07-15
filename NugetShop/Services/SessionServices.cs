using NugetShop.Models;
using Newtonsoft.Json;
using NugetShop.ViewModels;

namespace NugetShop.Services
{
    public class SessionServices
    {
        public static List<CartView> GetObjFromSesssion(ISession session, string key)
        {
            //Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if(jsonData == null) return new List<CartView>();
            //Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var product = JsonConvert.DeserializeObject<List<CartView>>(jsonData);//Nếu null thì trả về 1 list rỗng
            //if (product == null) return new List<Product>();
/*            else*/ return product;
        }
        public static List<Product> GetObjFromSession(ISession session, string key)
        {
            //Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if (jsonData == null) return new List<Product>();
            //Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var product = JsonConvert.DeserializeObject<List<Product>>(jsonData);//Nếu null thì trả về 1 list rỗng
                                                                                  //if (product == null) return new List<Product>();
            /*            else*/
            return product;
        }
        public static List<CartView> EditSession(ISession session, string key)
        {
            //Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if(jsonData == null) return new List<CartView>();
            //Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn
            var product = JsonConvert.DeserializeObject<List<CartView>>(jsonData);//Nếu null thì trả về 1 list rỗng
            return product;
        }

        public static void SetObjToSession(ISession session, string key, object values)
        {
            var jsonData = JsonConvert.SerializeObject(values);
            session.SetString(key, jsonData);

        }

        public static bool CheckObjInList(Guid id, List<Product> products)
        {
            return products.Any(x=> x.ProductID == id);
        }
    }
}
