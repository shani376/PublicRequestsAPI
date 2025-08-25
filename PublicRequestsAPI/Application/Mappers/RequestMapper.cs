using AutoMapper;
using PublicRequestsAPI.Application.DTOs;
using DbRequest = PublicRequestsAPI.Domain.DbModel.Request;

namespace PublicRequestsAPI.Application.Mappers
{
    public class RequestMappingProfile : Profile
    {
        public RequestMappingProfile()
        {
            CreateMap<DbRequest, Request>();
            CreateMap<Request, DbRequest>();
        }
    }
}