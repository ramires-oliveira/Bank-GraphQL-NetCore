using BankGraphQL.DTO.Handlers.Impl.Account;
using BankGraphQL.DTO.Handlers.Impl.User;
using BankGraphQL.DTO.Handlers.Interface.Account;
using BankGraphQL.DTO.Handlers.Interface.User;
using BankGraphQL.GraphQL.Mutations;
using BankGraphQL.GraphQL.Query;
using BankGraphQL.Repositories;
using BankGraphQL.Repositories.Impl;
using BankGraphQL.Repositories.Interface;
using BankGraphQL.Validators;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();

builder.Services.AddDbContext<Context>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DataBase"), new MySqlServerVersion(new Version(8, 0, 26)));
    options.EnableServiceProviderCaching(false);
});

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUpsertAccountHandler, UpsertAccountHandler>();
builder.Services.AddScoped<IUpsertUserHandler, UpsertUserHandler>();

builder.Services.AddScoped<IGetAllUserHandler, GetAllUserHandler>();
builder.Services.AddScoped<IGetByIdUserHandler, GetByIdUserHandler>();

builder.Services.AddScoped<IGetAllAccountHandler, GetAllAccountHandler>();
builder.Services.AddScoped<IGetByIdAccountHandler, GetByIdAccountHandler>();

builder.Services.AddScoped<IWithdrawAccountHandler, WithdrawAccountHandler>();
builder.Services.AddScoped<IDepositAccountHandler, DepositAccountHandler>();
builder.Services.AddScoped<IBalanceAccountHandler, BalanceAccountHandler>();

var app = builder.Build();

app.MapGraphQL();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<Context>();
context.Database.Migrate();

app.Run();
