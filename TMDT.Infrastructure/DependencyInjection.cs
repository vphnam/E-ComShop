using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDT.Infrastructure.IRepositories;
using TMDT.Infrastructure.Repositories;

namespace TMDT.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            ///Repository
            //size
            services.AddScoped<ISizeRepository, SizeRepository>();
            //color
            services.AddScoped<IColorRepository, ColorRepository>();
            //style
            services.AddScoped<IStyleRepository, StyleRepository>();
            //type
            services.AddScoped<ITypeRepository, TypeRepository>();
            //product
            services.AddScoped<IProductRepository, ProductRepository>();
            //product description
            services.AddScoped<IProductDescriptionRepository, ProductDescriptionRepository>();
            //promotion
            services.AddScoped<IPromotionRepository, PromotionRepository>();
            //serial product
            services.AddScoped<ISerialProductRepository, SerialProductRepository>();
            //serial product image
            services.AddScoped<ISerialProImageRepository, SerialProImageRepository>();
            //ROLE
            services.AddScoped<IRoleRepository, RoleRepository>();
            //employee
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //customer
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            //card rank
            services.AddScoped<ICardRankRepository, CardRankRepository>();
            //membership card
            services.AddScoped<IMembershipCardRepository, MembershipCardRepository>();
            //voucher
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            //purchase order
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            //purchase order line
            services.AddScoped<IPurchaseOrderLineRepository, PurchaseOrderLineRepository>();
            //feedback
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            return services;
        }
    }
}
