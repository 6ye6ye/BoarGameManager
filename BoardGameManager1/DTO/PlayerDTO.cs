using DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameManager1.DTO
{
    public class PlayerDTOGet
    {
        public int Id { get; set; }
        public string? AccountId { get; set; }
        public string? CreatorId { get; set; }
        public string Name { get; set; }
    }
}


