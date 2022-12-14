using GiuaKi.Models;
 
namespace GiuaKi.Services
{
    public interface IKhoaHocService
    {
       List<KhoaHoc> GetKhoaHocs();

       //co the lay gia tri null
       KhoaHoc? GetKhoaHocById(int id);

       void CreateKhoaHoc(KhoaHoc khoaHoc);
       void UpdateKhoaHoc(KhoaHoc khoaHoc);
       void DeleteKhoaHoc(int id);
       List<KhoaHoc> SortKhoaHoc();
       List<KhoaHoc> SortLoaiKhoaHoc();
       List<KhoaHoc> SearchNameKH(string name);
       List<LoaiKhoaHoc> GetLoaiKhoaHocs();
    }
}
