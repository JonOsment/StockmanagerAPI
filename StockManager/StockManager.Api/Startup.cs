using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StockManager.Common;
using StockManager.Interfaces;
using StockManager.Models;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Amazon.DynamoDBv2.Model;
using Amazon;
using Amazon.DynamoDBv2.DataModel;

namespace StockManager.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfig = new AutoMapper.MapperConfiguration(config => {
                config.CreateMap<Models.StockItem, Models.Dto.Dynamo.StockItem>()
                .ForMember(x => x.RangeKey, options => options.Ignore())
                .ForMember(x => x.PartitionKey, options => options.Ignore());
                //.ForMember(x => x.RangeKey, options => options.MapFrom(y => $"{y.ProductType}_{y.ItemName}" ))
                //.ForMember(x => x.PartitionKey, options => options.MapFrom( y => y.StoreId));
                config.CreateMap<Models.Dto.Dynamo.StockItem, Models.StockItem>();
                //.ForMember( x => x.ItemName, options => options.MapFrom(y => y.StoreId))
                //.ForMember(x => x.Type, options => options.MapFrom(y => y.ProductGroup));
                //.ForMember(x => x.Id, options => options.MapFrom(y => y.Id.ToString()));
            });

            var map = mapperConfig.CreateMapper();

            var builder = new ConfigurationBuilder()
            .AddUserSecrets("RemoteDynamoDB")
            .Build();


            var context = CreateDynamoContext();
            
            services.AddMvc();
            services.AddSingleton<IMapper>(map);
            services.AddTransient<IStockManager, StockItemManager>();
            services.AddTransient<IDynamoDBContext>(x => context);
            services.AddTransient<IStockItemRepository, StockItemDynamoRepository>();
        }

        private DynamoDBContext CreateDynamoContext()
        {
            var key = Configuration["aws-access-key"];
            var secret = Configuration["aws-secret-key"];
            var credentials = new BasicAWSCredentials(key, secret);
            var client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USEast2);
            var context = new DynamoDBContext(client);
            return context;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
