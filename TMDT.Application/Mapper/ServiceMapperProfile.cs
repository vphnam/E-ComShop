using AutoMapper;
using TMDT.Infrastructure.Models;
using TMDT.Shared.Dto;

namespace TMDT.Application.Mapper
{
    public class ServiceMapperProfile: Profile
    {
        public ServiceMapperProfile()
        {
            CreateMap<SizeDto, Size>();
            CreateMap<Size, SizeDto>();

            CreateMap<ColorDto, Color>();
            CreateMap<Color, ColorDto>();

            CreateMap<TypeDto, Type>();
            CreateMap<Type, TypeDto>();

            CreateMap<StyleDto, Style>();
            CreateMap<Style, StyleDto>();

            CreateMap<ProductDetailDto, Product>();
            CreateMap<Product, ProductDetailDto>();

            CreateMap<ProductListDto, Product>();
            CreateMap<Product, ProductListDto>();

            CreateMap<ProductDescDto, ProductDescription>();
            CreateMap<ProductDescription, ProductDescDto>();

            CreateMap<PromotionDto, Promotion>();
            CreateMap<Promotion, PromotionDto>();

            CreateMap<SerialProduct, SerialProductDto>();
            CreateMap<SerialProductDto, SerialProduct>();

            CreateMap<SerialProImage, SerialProImageDto>();
            CreateMap<SerialProImageDto, SerialProImage>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<Customer, UpdateCustomerDto>();
            CreateMap<UpdateCustomerDto, Customer>();

            CreateMap<CustomerDto, UpdateCustomerDto>();
            CreateMap<UpdateCustomerDto, CustomerDto>();

            CreateMap<CardRank, CardRankDto>();
            CreateMap<CardRankDto, CardRank>();

            CreateMap<MembershipCard, MembershipCardDto>();
            CreateMap<MembershipCardDto, MembershipCard>();

            CreateMap<Voucher, VoucherDto>();
            CreateMap<VoucherDto, Voucher>();

            CreateMap<PurchaseOrder, PurchaseOrderDto>();
            CreateMap<PurchaseOrderDto, PurchaseOrder>();

            CreateMap<PurchaseOrder, AddPurchaseOrderDto>();
            CreateMap<AddPurchaseOrderDto, PurchaseOrder>();

            CreateMap<PurchaseOrderLine, AddPurchaseOrderLineDto>();
            CreateMap<AddPurchaseOrderLineDto, PurchaseOrderLine>();

            CreateMap<PurchaseOrderLine, PurchaseOrderLineDto>();
            CreateMap<PurchaseOrderLineDto, PurchaseOrderLine>();

            CreateMap<Feedback, FeedbackDto>();
            CreateMap<FeedbackDto, Feedback>();
        }
    }
}
