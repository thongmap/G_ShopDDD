using G_ShopDomain.Entities;
using G_ShopInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_ShopApplication
{
    public class UserService
    {
        private static IAllRepo<NguoiDung> UserRepo;
        public UserService()
        {
            UserRepo = new AllRepo<NguoiDung>();
        }
        public NguoiDung GetUser(string username)
        {
            return UserRepo.Find(x => x.TenDangNhap == username).First();
        }

        public NguoiDung GetUser(int id)
        {
            return UserRepo.Get(id);
        }
    }
}
