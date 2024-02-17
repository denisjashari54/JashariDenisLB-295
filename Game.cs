using Microsoft.EntityFrameworkCore;

namespace JashariDenisLB_295_V2
{
    public class Game : DbContext
    {
        public int GameId { get; set; }
        public int DeveloperId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
    }
}
