using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using ToDoListApi.Clients;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c => {
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
   
});
var credentials = new BasicAWSCredentials("AKIAWDR5ACKCWYVL25NG", "GQvl7UEz4aKxTixwIhAZwB4IaFkoeFqMS/UFhE8d");
var config = new AmazonDynamoDBConfig()
{
    RegionEndpoint = RegionEndpoint.EUWest3
};
var client = new AmazonDynamoDBClient(credentials, config);
builder.Services.AddSingleton<IAmazonDynamoDB>(client);
builder.Services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
builder.Services.AddScoped<RandomFactClient>();
builder.Services.AddScoped<WeatherClient>();
builder.Services.AddScoped<HolidayClient>();
builder.Services.AddScoped<WordOfDayClient>();
builder.Services.AddScoped<DefinitionOfWordClient>();
builder.Services.AddScoped<TrackOfDayClient>();
builder.Services.AddScoped<FindMusicUriClient>();
builder.Services.AddScoped<TaskClient>();
builder.Services.AddScoped<DBInfoClient>();
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
