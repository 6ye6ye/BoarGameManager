using DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameManager1.DTO
{
    public class UserGamePlaceDTOGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
    }

    public class CurrentUserGamePlaceDTOGet
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    //public class UserGamePlaceDTOAdd
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    //public class UserGamePlaceDTOEdit
    //{
    //    public string Name { get; set; }
    //}
}
