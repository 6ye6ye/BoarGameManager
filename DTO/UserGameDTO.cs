﻿namespace DTO
{
    public class UserGameDTOGet
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GameId { get; set; }

    }
    public class UserGameDTOAdd
    {
        public int GameId { get; set; }
    }
}