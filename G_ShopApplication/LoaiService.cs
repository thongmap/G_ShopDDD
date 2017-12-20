using G_ShopDomain.Entities;
using G_ShopInfrastructure;
using System.Collections.Generic;
using System.Linq;

namespace G_ShopApplication
{
    public class LoaiService
    {
        private static IAllRepo<Loai> LoaiRepo;
        public LoaiService()
        {
            LoaiRepo = new AllRepo<Loai>();
        }
        public List<Loai> GetAll()
        {
            return LoaiRepo.All().ToList();
        }
        public string GetTenLoai(int MaLoai)
        {
            return LoaiRepo.Get(MaLoai).TenLoai;
        }
    }
}
