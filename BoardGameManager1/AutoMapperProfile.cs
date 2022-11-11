using AutoMapper;
using BoardGameManager1.DTO;
using BoardGameManager1.Entities;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace BoardGameManager1
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AccountDTORegister, User>()
                  .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login));

            CreateMap<Game, GameDTOGetShort>();
            CreateMap<Game, GameDTOGet >();
            CreateMap<GameDTOAdd , Game>();
            CreateMap<GameDTOEdit , Game>();

            CreateMap<GameParty, GamePartyDTOGet>();
              //  .ForMember(dest => dest.GamePartyMembers, opt => opt.MapFrom(src => src.GamePartyMembers));
            CreateMap<GamePartyMember, GamePartyDTOGet>()
                .ForMember(dest => dest.GamePartyMembers, opt => opt.MapFrom(src => src.GameParty.GamePartyMembers));
            CreateMap<GamePartyDTOAdd, GameParty>();
            CreateMap<GamePartyDTOEdit, GameParty>();
            CreateMap<GameParty, GameDTOGetShort>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Game.Id))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Game.Name));



            CreateMap<GamePartyMember, GamePartyMemberDTOGet  >();
            CreateMap<GamePartyMemberDTOEdit , GamePartyMember>();
            CreateMap<GamePartyMemberDTOAdd, GamePartyMember >();

            CreateMap<GameRole, GameRoleDTOGet>();
            CreateMap<GameRoleDTOAdd, GameRole>();

            CreateMap<GameRate, GameRateDTOGet>();
    

            CreateMap<Player, PlayerDTOGet>();


            //CreateMap<RoleForGame, RoleForGameDTOGet>();
            //CreateMap<RoleForGameDTOEdit, RoleForGame >();
            //CreateMap<RoleForGameDTOAdd, RoleForGame>();
            CreateMap<User, UserDTOGetShort>();
            CreateMap<User, UserDTOGet>()
                // .ForMember(dest => dest.Role.Name, opt => opt.MapFrom(src => src.Role.Name))
               //  .ForMember(dest => dest.Role.Id, opt => opt.MapFrom(src => src.Role.Id))
                 ;
            CreateMap<IdentityRole , RoleDTOGet>();
            CreateMap<RoleDTOGet, IdentityRole>();
                    //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Role.Name))
                    //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Role.Id));
            CreateMap<UserDTOGet, User>();


            CreateMap<Player, PlayerDTOGet >();
            // CreateMap<User, UserDTOAdd>();
            // CreateMap<User, UserDTOEdit>();
   

            CreateMap<UserFriend, UserFriendDTOGet>();
            CreateMap<UserFriendDTOEdit, UserFriend>();
            CreateMap<UserFriendDTOAdd, UserFriend>();

            CreateMap<UserGame, UserGameDTOGet>();
            CreateMap<UserGameDTOGet, UserGame>();
            CreateMap<UserGameDTOAdd, UserGame>();
           
            CreateMap<UserGamePlace, UserGamePlaceDTOGet>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
                
            CreateMap<UserGamePlace, CurrentUserGamePlaceDTOGet>();
            //CreateMap<UserGamePlace, UserGamePlaceDTOEdit>();
            //CreateMap<UserGamePlace, UserGamePlaceDTOAdd>();
        }
    }
}
