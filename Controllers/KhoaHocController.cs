using Microsoft.AspNetCore.Mvc;
using GiuaKi.Models;
using GiuaKi.Services;
 
namespace GiuaKi.Controllers
{
    public class KhoaHocController : Controller
    {
        private readonly IKhoaHocService _khoaHocService;
        public KhoaHocController(IKhoaHocService khoaHocService)
        {
            _khoaHocService = khoaHocService;
        }
 
        public IActionResult Index(string sort,string search)
        {
            var khoaHocs = _khoaHocService.GetKhoaHocs();
            if(search !=null){
                khoaHocs= _khoaHocService.SearchNameKH(search);
            }
            else{

                if(sort != null)
                {
                    switch(sort) 
                    {
                    case "NameKH":
                        khoaHocs = _khoaHocService.SortKhoaHoc();
                        break;
                    case "LoaiKH":
                        khoaHocs = _khoaHocService.SortLoaiKhoaHoc();
                        break;
                    }
                }
            }
            return View(khoaHocs);
        }
        public IActionResult Create()
        {
            var LoaiKhoaHocs = _khoaHocService.GetLoaiKhoaHocs();
            return View(LoaiKhoaHocs);
        }
        public IActionResult Save(KhoaHoc khoaHoc)
        {
            if(khoaHoc.Id == 0){
                _khoaHocService.CreateKhoaHoc(khoaHoc);
            }
            else{
            _khoaHocService.UpdateKhoaHoc(khoaHoc);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var khoaHoc = _khoaHocService.GetKhoaHocById(id);
            if(khoaHoc == null) return RedirectToAction("Create");

            var loaiKhoaHocs = _khoaHocService.GetLoaiKhoaHocs();
            ViewBag.KhoaHoc = khoaHoc;
            return View(loaiKhoaHocs);
        }
        public IActionResult Delete(int id)
        {
            _khoaHocService.DeleteKhoaHoc(id);
            return RedirectToAction("Index");
        }

        public IActionResult Sort(string name)
        {
            if(name == "NameKH")
            {
                var listKH = _khoaHocService.SortKhoaHoc;
                return View(listKH);
            }
            else{
                var listLoaiKH = _khoaHocService.SortLoaiKhoaHoc;
                return View(listLoaiKH);
            }
        }

        public IActionResult Search(string name)
        {
            var listKH = _khoaHocService.SearchNameKH(name);
            return View(listKH);
        }

        public IActionResult Detail(int id)
        {
            var khoaHoc = _khoaHocService.GetKhoaHocById(id);
            if(khoaHoc == null) return RedirectToAction("Create");

            // var loaiKhoaHocs = _khoaHocService.GetLoaiKhoaHocs();
            // ViewBag.KhoaHoc = khoaHoc;
            return View(khoaHoc);
        }
    }
}
