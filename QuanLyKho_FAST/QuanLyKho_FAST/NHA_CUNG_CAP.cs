//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyKho_FAST
{
    using System;
    using System.Collections.Generic;
    
    public partial class NHA_CUNG_CAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHA_CUNG_CAP()
        {
            this.BANG_KE_NHAP_HANG = new HashSet<BANG_KE_NHAP_HANG>();
            this.BANG_KE_XUAT_HANG = new HashSet<BANG_KE_XUAT_HANG>();
            this.HANG_HOA = new HashSet<HANG_HOA>();
        }
    
        public string MA_NCC { get; set; }
        public string TEN_NCC { get; set; }
        public string DIACHI { get; set; }
        public string DIEN_THOAI { get; set; }
        public string EMAIL { get; set; }
        public string FAX { get; set; }
        public string MA_SO_THUE { get; set; }
        public string SO_TAI_KHOAN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANG_KE_NHAP_HANG> BANG_KE_NHAP_HANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BANG_KE_XUAT_HANG> BANG_KE_XUAT_HANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HANG_HOA> HANG_HOA { get; set; }
    }
}
