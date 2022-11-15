using System;
using System.Collections.Generic;

#nullable disable

namespace QL_CDC.Models
{
    public partial class CHINH_SUA_DIEM
    {
        public string ID_V { get; set; }
        public string ID_N { get; set; }
        public int? LANCHINHSUA_V { get; set; }
        public string LYDO_V { get; set; }

        public virtual NHOM_THI ID_NNavigation { get; set; }
    }
}
