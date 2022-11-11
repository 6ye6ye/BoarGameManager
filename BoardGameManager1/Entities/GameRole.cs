using DAL.Entities;

namespace BoardGameManager1.Entities
{
    public class GameRole
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }

      
    }
}
