using AutoMapper;
using BoardGameManager1.Entities;
using DAL;
using DAL.Entities;
using DTO;
using Microsoft.AspNetCore.Identity;

namespace BoardGameManager1
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AccountDTORegister, User>()
                  .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login));

            //----Game map
            CreateMap<Game, GameDTOGetShort>();
            CreateMap<Game, GameDTOGet>()
                  .ForMember(dest => dest.Image, opt => opt.MapFrom(src => "https://localhost:5001/images/" + src.Image))
                  .ForMember(dest => dest.AddedToUserGames, opt => opt.MapFrom(src => src.UserGames.Any()));
            CreateMap<GameDTOAdd, Game>();
            CreateMap<GameDTOEdit, Game>();

            //----Game party map
            CreateMap<GameParty, GamePartyDTOGet>()
                 .ForMember(dest => dest.PartyCreatorName, opt => opt.MapFrom(src => src.PartyCreator.UserName))
                 .ForMember(dest => dest.PartyCreatorId, opt => opt.MapFrom(src => src.PartyCreator.Id))
                 .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd")));
            CreateMap<GamePartyDTOAdd, GameParty>();
            CreateMap<GamePartyDTOEdit, GameParty>();
            CreateMap<GameParty, GameDTOGetShort>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Game.Id))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Game.Name));

            //----Game party member map
            CreateMap<GamePartyMember, GamePartyMemberDTOGetShort>()
                .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => src.Player.Name));
            CreateMap<GamePartyMember, GamePartyMemberDTOGet>()
                .ForMember(dest => dest.Game, opt => opt.MapFrom(src => src.GameParty.Game));
            CreateMap<GamePartyMemberDTOEdit, GamePartyMember>();
            CreateMap<GamePartyMemberDTOAdd, GamePartyMember>();

            //----Game role map
            CreateMap<GameRole, GameRoleDTOGet>();
            CreateMap<GameRole, GameRoleDTOGetShort>();
            CreateMap<GameRoleDTOAdd, GameRole>();
            CreateMap<GameRoleDTOEdit, GameRole>();

            //----Game rate map
            CreateMap<GameRate, GameRateDTOGet>();

            //----Player map
            CreateMap<PlayerDTOEdit, Player>();
            CreateMap<Player, PlayerDTOGet>();
            CreateMap<Player, PlayerDTOGetShort>();

            //----Role map
            CreateMap<Role, RoleDTOGet>();
            CreateMap<RoleDTOGet, Role>();
            CreateMap<UserRole, RoleDTOGet>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Role.Id));
           
            //----User map
            CreateMap<User, UserDTOGetShort>();
            CreateMap<User, UserDTOGet>()
                 .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRoles.Select(c => c.Role).FirstOrDefault()));

            //----User friend map
            CreateMap<UserFriend, UserFriendDTOGet>();
            CreateMap<UserFriendDTOEdit, UserFriend>();
            CreateMap<UserFriendDTOAdd, UserFriend>();

            //----User game map
            CreateMap<UserGame, UserGameDTOGet>();
            CreateMap<UserGameDTOGet, UserGame>();
            CreateMap<UserGameDTOAdd, UserGame>();

            //----User game place map

            CreateMap<UserGamePlaceDTOEdit, UserGamePlace>();
            CreateMap<UserGamePlace, UserGamePlaceDTOGet>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            CreateMap<UserGamePlace, UserGamePlaceDTOGetShort>();
        }
    }
}
