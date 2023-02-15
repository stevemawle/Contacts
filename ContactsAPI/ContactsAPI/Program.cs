
using ContactsAPI.DataLayer;
using ContactsAPI.DB;
using ContactsAPI.Mappers;
using ContactsAPI.Services;

namespace ContactsAPI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            
            using (ContactsContext context = new ContactsContext())
            {
                context.Database.EnsureCreated();
            }
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IContactData, ContactData>();
            builder.Services.AddScoped<IContactMapper, ContactMapper>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}