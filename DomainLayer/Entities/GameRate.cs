using DAL.Entities;

namespace BoardGameManager1.Entities
{
    public class GameRate
    {
        public int Id { get; set; } 
        public int Rate { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
