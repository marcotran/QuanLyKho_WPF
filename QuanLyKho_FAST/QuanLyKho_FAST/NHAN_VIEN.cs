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
    
    public partial class NHAN_VIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAN_VIEN()
        {
            this.KHOes = new HashSet<KHO>();
        }
    
        public string MA_NV { get; set; }
        public string TEN_NV { get; set; }
        public string CHUC_VU { get; set; }
        public Nullable<bool> GIOI_TINH { get; set; }
        public string DIA_CHI { get; set; }
        public string DIEN_THOAI { get; set; }
        public string EMAIL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHO> KHOes { get; set; }
    }
}