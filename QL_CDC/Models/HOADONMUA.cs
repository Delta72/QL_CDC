﻿using System;
using System.Collections.Generic;

#nullable disable

namespace QL_CDC.Models
{
    public partial class HOADONMUA
    {
        public HOADONMUA()
        {
            CHITIETHOADON = new HashSet<CHITIETHOADON>();
        }

        public string HD_MSHD { get; set; }
        public string SV_MSSV { get; set; }
        public int TT_MSTT { get; set; }
        public DateTime? HD_NGAYMUA { get; set; }
        public double? HD_TONGGIA { get; set; }

        public virtual SINHVIEN SV_MSSVNavigation { get; set; }
        public virtual TINHTRANGHOADON TT_MSTTNavigation { get; set; }
        public virtual ICollection<CHITIETHOADON> CHITIETHOADON { get; set; }
    }
}