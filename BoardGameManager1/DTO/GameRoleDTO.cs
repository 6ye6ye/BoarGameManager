using DAL.Entities;

namespace BoardGameManager1.DTO
{
    public class GameRoleDTOGet
    {
        public int Id { get; set; }
        public int GameId {get;set;}
        public string Name { get; set; }

    }
    public class GameRoleDTOAdd
    {
        public int GameId { get; set; }
        public string Name { get; set; }
    }

    public class GameRoleDTOEdit
    {
        public string Name { get; set; }
    }

}
