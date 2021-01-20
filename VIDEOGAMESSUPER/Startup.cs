using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Repository;
using LOCAL.Interface;
using LOCAL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace VIDEOGAMESSUPER
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
            services.AddCors();

            services.AddControllers();

            services.AddScoped<IAnswerRepository, AnswerRepository>();

            services.AddScoped<IAnswerService, AnswerService>();

            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddScoped<ICommentService, CommentService>();

            services.AddScoped<IPlateform_VideoGameRepository, Plateform_VideoGameRepository>();

            services.AddScoped<IPlateform_VideoGameService, Plateform_VideoGameService>();

            services.AddScoped<IQuestionRepository, QuestionRepository>();

            services.AddScoped<IQuestionService, QuestionService>();

            services.AddScoped<IReportRepository, ReportRepository>();

            services.AddScoped<IReportService, ReportService>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IVideoGameRepository, VideoGameRepository>();

            services.AddScoped<IVideoGameService, VideoGameService>();

            services.AddScoped<IUser_VideoGame_Repository, User_VideoGame_Repository>();

            services.AddScoped<IUser_VideoGame_Service, User_VideoGame_Service>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VIDEOGAMESSUPER", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VIDEOGAMESSUPER v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
