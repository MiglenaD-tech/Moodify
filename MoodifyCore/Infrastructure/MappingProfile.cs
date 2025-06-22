using AutoMapper;
using MoodifyCore.Data;
using MoodifyCore.DTO;

namespace MoodifyCore.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            // User <-> UserDto
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Activity, ActivityDto>().ReverseMap();
            CreateMap<Playlist, PlaylistDto>().ReverseMap();
            CreateMap<ActivityPlaylist, ActivityPlaylistDto>().ReverseMap();
            CreateMap<ActivityPlaylistLinkDto, ActivityPlaylist>()
                .ForMember(dest => dest.LinkedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
            CreateMap<SensorData, SensorDataDto>().ReverseMap();
            CreateMap<SensorDataCreateDto, SensorData>();
            CreateMap<Feedback, FeedbackDto>().ReverseMap();
            CreateMap<FeedbackCreateDto, Feedback>();

        }

    }
}
