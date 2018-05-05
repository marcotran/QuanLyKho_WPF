using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho_FAST.Model
{
    public class M_NhaCungCap
    {
        public M_NhaCungCap()
        {
            string Ma = "";
            string Ten = "";
            string Diachi = "";
            string DienThoai = "";
            string Email = "";
            string Fax = "";
            string MaSoThue = "";
            string SoTaiKhoan = "";
        }
        
        public string Ma { get; set; }
        public string Ten { get => Ten; set => Ten = value; }
        public string Diachi { get => Diachi; set => Diachi = value; }
        public string DienThoai { get => DienThoai; set => DienThoai = value; }
        public string Email { get => Email; set => Email = value; }
        public string Fax { get => Fax; set => Fax = value; }
        public string MaSoThue { get => MaSoThue; set => MaSoThue = value; }
        public string SoTaiKhoan { get => SoTaiKhoan; set => SoTaiKhoan = value; }

        public M_NhaCungCap Clone()
        {
            return new M_NhaCungCap
            {
                Ma = this.Ma,
                Ten = this.Ten,
                Diachi = this.Diachi,
                DienThoai = this.DienThoai,
                Email = this.Email,
                Fax = this.Fax,
                MaSoThue = this.MaSoThue,
                SoTaiKhoan = this.SoTaiKhoan
            };
        }
    }
}
