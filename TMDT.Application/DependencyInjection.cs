using Microsoft.Extensions.DependencyInjection;
using TMDT.Application.IServices;
using TMDT.Application.Managers;
using TMDT.Application.Mapper;
using TMDT.Application.Services;

namespace TMDT.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {      
            ///Add services
            //size
            services.AddScoped<ISizeService, SizeService>();
            //color
            services.AddScoped<IColorService, ColorService>();
            //type
            services.AddScoped<ITypeService, TypeService>();
            //style
            services.AddScoped<IStyleService, StyleService>();
            //product
            services.AddScoped<IProductService, ProductService>();
            //product description
            services.AddScoped<IProductDescriptionService, ProductDescriptionService>();
            //promotion
            services.AddScoped<IPromotionService, PromotionService>();
            //serial product
            services.AddScoped<ISerialProductService, SerialProductService>();
            //serial product image
            services.AddScoped<ISerialProImageService, SerialProImageService>();
            //employee
            services.AddScoped<IEmployeeService, EmployeeService>();
            //customer
            services.AddScoped<ICustomerService, CustomerService>();
            //membership card
            services.AddScoped<IMembershipCardService, MembershipCardService>();
            //voucher
            services.AddScoped<IVoucherService, VoucherService>();
            //purchase order
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            //purchase order line
            services.AddScoped<IPurchaseOrderLineService, PurchaseOrderLineService>();
            //purchase order line
            services.AddScoped<IFeedbackService, FeedbackService>();


            ///Add managers
            //size
            services.AddScoped<SizeManager, SizeManager>();
            //color
            services.AddScoped<ColorManager, ColorManager>();
            //type
            services.AddScoped<TypeManager, TypeManager>();
            //style
            services.AddScoped<StyleManager, StyleManager>();
            //product
            services.AddScoped<ProductManager, ProductManager>();
            //promotion
            services.AddScoped<PromotionManager, PromotionManager>();
            //serial product
            services.AddScoped<SerialProductManager, SerialProductManager>();
            //employee
            services.AddScoped<EmployeeManager, EmployeeManager>();
            //customer
            services.AddScoped<CustomerManager, CustomerManager>();
            //membership card
            services.AddScoped<MembershipCardManager, MembershipCardManager>();
            //membership card
            services.AddScoped<VoucherManager, VoucherManager>();
            //membership card
            services.AddScoped<PurchaseOrderManager, PurchaseOrderManager>();

            ///add mapper list
            AddMapperList(services);
            return services;
        }
        private static void AddMapperList(IServiceCollection services)
        {
            //mapper config profiles
            services.AddAutoMapper(typeof(ServiceMapperProfile).Assembly);
        }
    }
}
