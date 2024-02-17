using Microsoft.EntityFrameworkCore;

namespace JashariDenisLB_295_V2
{
    public class Developer : DbContext
    {
        public int DeveloperId { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public string Speciality { get; set; }
    }
}
