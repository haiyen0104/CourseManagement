using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiuaKi.Models
{
    public class LoaiKhoaHoc
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public List<KhoaHoc> KhoaHocs { get; set; }
    }
}