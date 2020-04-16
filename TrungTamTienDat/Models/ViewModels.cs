using LibModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrungTamTienDat.Models
{
    public class ViewModels
    {
        public List<Album> l_Album { get; set; }
        public List<Anh> l_Anh { get; set; }
        public List<BaiViet> l_BaiViet { get; set; }
        public List<ChuDe> l_ChuDe { get; set; }
        public List<DangKy> l_DangKy { get; set; }
        public List<GiaoVien> l_GiaoVien { get; set; }
        public List<LopHoc> l_LopHoc { get; set; }
        public List<PhanHoi> l_PhanHoi { get; set; }
        public List<MonHoc> l_MonHoc { get; set; }
    }
}