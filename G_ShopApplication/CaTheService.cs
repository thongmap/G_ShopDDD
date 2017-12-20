using G_ShopDomain.Entities;
using G_ShopInfrastructure;
using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace G_ShopApplication
{
    public class CaTheService
    {
        private static IAllRepo<CaThe> CaTheRepo;
        public CaTheService()
        {
            CaTheRepo = new AllRepo<CaThe>();
        }
        public List<CaThe> Get()
        {
            return CaTheRepo.All().ToList();
        }
        public List<CaThe> Find(Expression<Func<CaThe, bool>> predicate)
        {
            return CaTheRepo.Find(predicate).ToList();
        }
        public CaThe GetCaThe_MaLoai_MaCaThe(int MaLoai, int MaCaThe)
        {
            return CaTheRepo.Find(x => x.MaLoai == MaLoai && x.MaCaThe == MaCaThe).FirstOrDefault();
        }
        public List<CaThe> GetNew()
        {
            return CaTheRepo.All().OrderByDescending(x => x.MaCaThe).Take(3).ToList();
        }
        public void AddCaThe(CaThe cathe)
        {
            CaTheRepo.Add(cathe);
        }
        public void Delete(int id)
        {
            CaTheRepo.Delete(CaTheRepo.Get(id));
        }
        public List<CaThe> TimCaThe(string ten)
        {
            return CaTheRepo.Find(x => x.TenCaThe.Contains(ten)).ToList();
        }
        public string TuoiCaThe(int MaCaThe)
        {
            string tuoi;
            var model = CaTheRepo.Find(x=>x.MaCaThe == MaCaThe).FirstOrDefault();
            DateDiff ngaytuoi = new DateDiff(model.NgaySinh, DateTime.Now);
            if (ngaytuoi.ElapsedYears == 0)
                if (ngaytuoi.ElapsedMonths == 0)
                    tuoi = ngaytuoi.ElapsedDays.ToString() + " ngày";
                else
                    tuoi = ngaytuoi.ElapsedMonths.ToString() + " tháng " + ngaytuoi.ElapsedDays.ToString() + " ngày";
            else
                tuoi = ngaytuoi.ElapsedYears.ToString() + " tuổi " + ngaytuoi.ElapsedMonths.ToString() + " tháng " + ngaytuoi.ElapsedDays.ToString() + " ngày";
            return tuoi;
        }
    }
}
