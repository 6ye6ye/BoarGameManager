﻿namespace DTO
{
    public class UserDTOGetByName
    {

        public string UserName { get; set; }

    }

    public class UserDTOGet
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public RoleDTOGet Role { get; set; }
    }
    public class UserDTOGetShort
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
    //public class UserDTOAdd
    //{
    //    public string Login { get; set; }
    //    public string Name { get; set; }
    //    public string Password { get; set; }
    //}
    //public class UserDTOEdit
    //{
    //    public string Name { get; set; }
    //}
}
