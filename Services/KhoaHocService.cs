using Microsoft.EntityFrameworkCore;
using GiuaKi.Models;
 
namespace GiuaKi.Services
{
    public class KhoaHocService : IKhoaHocService
    {
        private readonly DataContext _context;
        public KhoaHocService(DataContext context)
        {
            _context = context;
        }

        public void CreateKhoaHoc(KhoaHoc khoaHoc)
        {
            _context.KhoaHocs.Add(khoaHoc);
            _context.SaveChanges();        }

        public void DeleteKhoaHoc(int id)
        {
            var existedKhoaHoc = GetKhoaHocById(id);
            if(existedKhoaHoc == null) return;
            _context.KhoaHocs.Remove(existedKhoaHoc);
            _context.SaveChanges();
        }

        public List<LoaiKhoaHoc> GetLoaiKhoaHocs()
        {
            return _context.LoaiKhoaHocs.ToList();
        }

        public KhoaHoc? GetKhoaHocById(int id)
        {
            return _context.KhoaHocs.Include(p => p.LoaiKhoaHoc).FirstOrDefault(p => p.Id == id);
        }

        public List<KhoaHoc> GetKhoaHocs()
        {
            return _context.KhoaHocs
                    .Include(p => p.LoaiKhoaHoc)
                    .ToList();
        }

        public void UpdateKhoaHoc(KhoaHoc khoaHoc)
        {
            var existedKhoaHoc = GetKhoaHocById(khoaHoc.Id);
            if(existedKhoaHoc == null) return;
            existedKhoaHoc.Name = khoaHoc.Name;
            existedKhoaHoc.Slug = khoaHoc.Slug;
            existedKhoaHoc.TomTatKH = khoaHoc.TomTatKH;
            existedKhoaHoc.NdDetail = khoaHoc.NdDetail;
            existedKhoaHoc.Image = khoaHoc.Image;
            existedKhoaHoc.LoaiKhoaHocId = khoaHoc.LoaiKhoaHocId;
            _context.KhoaHocs.Update(existedKhoaHoc);
            _context.SaveChanges();
        }

        public List<KhoaHoc> SortKhoaHoc()
        {
            return _context.KhoaHocs.OrderBy(o=>o.Name).ToList();
        }

        public List<KhoaHoc> SortLoaiKhoaHoc()
        {
            return _context.KhoaHocs.OrderBy(o=>o.LoaiKhoaHoc.Name).ToList();
        }
        public List<KhoaHoc> SearchNameKH(string name)
        {
            if(_context.KhoaHocs.Where(p => p.Name.ToUpper().Contains(name.ToUpper())).ToList() == null)
            return GetKhoaHocs();
            return _context.KhoaHocs.Where(p => p.Name.ToUpper().Contains(name.ToUpper())).ToList();
        }
    }
}
