using System;

namespace MFCFE2.Models
{
    public class AgreementModel
    {
        public string AgreementNumber { get; set; }
        public DateTime TanggalBPKB { get; set; }
        public DateTime TanggalBPKBIn { get; set; }
        public string BPKBNo { get; set; }
        public string BranchId { get; set; }
        public DateTime TanggalFaktur { get; set; }
        public string FakturNo { get; set; }
        public string LocationId { get; set; }
        public string PoliceNo { get; set; }
    }
}
