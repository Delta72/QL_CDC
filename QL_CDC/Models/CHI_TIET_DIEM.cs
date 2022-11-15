using System;
using System.Collections.Generic;

#nullable disable

namespace QL_CDC.Models
{
    public partial class CHI_TIET_DIEM
    {
        public string ID_N { get; set; }
        public string MSSV_CTBT { get; set; }
        public string DIEM_CTBT { get; set; }
        public int? SOCHINHSUA_CTBT { get; set; }

        public virtual NHOM_THI ID_NNavigation { get; set; }
    }
}
