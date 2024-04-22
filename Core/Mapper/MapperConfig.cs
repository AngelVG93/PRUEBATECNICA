
using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace Core.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderProduct, OrderProductDto>().ReverseMap();
            CreateMap<Permissions, PermissionsDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<RoleUser, RoleUserDto>().ReverseMap();

            CreateMap<User, UserDto>()
            .ReverseMap();

            CreateMap<UserOrder, UserOrderDto>().ReverseMap();
            CreateMap<Login, LoginDto>().ReverseMap();
            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<PermissRolesServices, PermissRolesServicesDto>().ReverseMap();
            CreateMap<RolesServices, RolesServicesDto>().ReverseMap();
        }
    }
}
