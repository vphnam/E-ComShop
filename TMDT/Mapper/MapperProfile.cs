using AutoMapper;
using TMDT.Shared.Dto;
using TMDT.ViewModels;

namespace TMDT.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<SizeDto, SizeViewModel>();
            CreateMap<SizeViewModel, SizeDto>();

            CreateMap<ColorDto, ColorViewModel>();
            CreateMap<ColorViewModel, ColorDto>();

            CreateMap<TypeDto, TypeViewModel>();
            CreateMap<TypeViewModel, TypeDto>();

            CreateMap<StyleDto, StyleViewModel>();
            CreateMap<StyleViewModel, StyleDto>();

            CreateMap<ProductDetailViewModel, ProductDetailDto>();
            CreateMap<ProductDetailDto, ProductDetailViewModel>();

            CreateMap<ProductViewModel, ProductDetailDto>();
            CreateMap<ProductDetailDto, ProductViewModel>();

            CreateMap<ProductListViewModel, ProductListDto>();
            CreateMap<ProductListDto, ProductListViewModel>();

            CreateMap<ProductDescriptionViewModel, ProductDescDto>();
            CreateMap<ProductDescDto, ProductDescriptionViewModel>();

            CreateMap<PromotionViewModel, PromotionDto>();
            CreateMap<PromotionDto, PromotionViewModel>();

            CreateMap<SerialProductViewModel, SerialProductDto>();
            CreateMap<SerialProductDto, SerialProductViewModel>();

            CreateMap<SerialProductChangeViewModel, SerialProductDto>();
            CreateMap<SerialProductDto, SerialProductChangeViewModel>();

            CreateMap<SerialProImageViewModel, SerialProImageDto>();
            CreateMap<SerialProImageDto, SerialProImageViewModel>();

            CreateMap<RoleViewModel, RoleDto>();
            CreateMap<RoleDto, RoleViewModel>();

            CreateMap<EmployeeViewModel, EmployeeDto>();
            CreateMap<EmployeeDto, EmployeeViewModel>();

            CreateMap<EmployeeChangeViewModel, EmployeeDto>();
            CreateMap<EmployeeDto, EmployeeChangeViewModel>();

            CreateMap<CustomerViewModel, CustomerDto>();
            CreateMap<CustomerDto, CustomerViewModel>();

            CreateMap<GetCustomerInfoViewModel, CustomerDto>();
            CreateMap<CustomerDto, GetCustomerInfoViewModel>();

            CreateMap<CustomerViewModel, UpdateCustomerDto>();
            CreateMap<UpdateCustomerDto, CustomerViewModel>();

            CreateMap<UpdateCustomerViewModel, UpdateCustomerDto>();
            CreateMap<UpdateCustomerDto, UpdateCustomerViewModel>();

            CreateMap<CardRankViewModel, CardRankDto>();
            CreateMap<CardRankDto, CardRankViewModel>();

            CreateMap<MembershipCardViewModel, MembershipCardDto>();
            CreateMap<MembershipCardDto, MembershipCardViewModel>();

            CreateMap<AddMembershipCardViewModel, MembershipCardDto>();
            CreateMap<MembershipCardDto, AddMembershipCardViewModel>();

            CreateMap<MembershipCardDetailViewModel, MembershipCardDto>();
            CreateMap<MembershipCardDto, MembershipCardDetailViewModel>();

            CreateMap<VoucherViewModel, VoucherDto>();
            CreateMap<VoucherDto, VoucherViewModel>();

            CreateMap<FeedbackViewModel, FeedbackDto>();
            CreateMap<FeedbackDto, FeedbackViewModel>();


            CreateMap<AddPurchaseOrderLineViewModel, AddPurchaseOrderLineDto>();
            CreateMap<AddPurchaseOrderLineDto, AddPurchaseOrderLineViewModel>();


            CreateMap<AddPurchaseOrderViewModel, AddPurchaseOrderDto>();
            CreateMap<AddPurchaseOrderDto, AddPurchaseOrderViewModel>();


            CreateMap<PurchaseOrderDto, PurchaseOrderListViewModel>();

            CreateMap<PurchaseOrderDto, PurchaseOrderDetailViewModel>();


            CreateMap<PurchaseOrderLineViewModel, PurchaseOrderLineDto>();
            CreateMap<PurchaseOrderLineDto, PurchaseOrderLineViewModel>();

            CreateMap<DashBoardTableDto, DashBoardTableViewModel>();
        }
    }
}
