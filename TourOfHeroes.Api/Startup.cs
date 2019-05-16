﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using TourOfHeroes.Api.Models;

namespace TourOfHeroes.Api
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
         services.AddDbContext<HeroContext>(opt => opt.UseInMemoryDatabase("Heroes"));

         services.AddCors(options =>
         {
            options.AddPolicy("Something",
            builder =>
            {
               builder.WithOrigins("*")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin();
            });
         });

         services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

         services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

         // Register the Swagger generator, defining 1 or more Swagger documents
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new Info { Title = "Tour of Heroes API", Version = "v1" });
         });
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         else
         {
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
         }

         // Enable middleware to serve generated Swagger as a JSON endpoint.
         app.UseSwagger();

         // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
         // specifying the Swagger JSON endpoint.
         app.UseSwaggerUI(c =>
         {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tour of Heroes API V1");
         });

         app.UseCors("Something");

         app.UseHttpsRedirection();
         app.UseMvc();
      }
   }
}