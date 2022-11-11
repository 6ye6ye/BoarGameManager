using DAL.Entities;

namespace BoardGameManager1.DTO
{
    public class GameRateDTOGet
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public  GameDTOGetShort Game { get; set; }
        public virtual UserDTOGetShort User { get; set; }
    }
}
