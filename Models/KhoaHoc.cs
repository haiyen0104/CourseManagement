using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiuaKi.Models
{
    public class KhoaHoc
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Slug { get; set; }
        public string TomTatKH { get; set; }
        public string NdDetail  { get; set; }
        public string Image { get; set; }
        
        public int LoaiKhoaHocId { get; set; }
        public LoaiKhoaHoc LoaiKhoaHoc { get; set; }
    }
}