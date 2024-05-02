using System.Diagnostics;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using provaCsharp.Modelos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext ctx) =>
{
    try
    {
        ctx.Funcionarios.Add(funcionario);
        ctx.SaveChanges();
        return Results.Created("", funcionario);
    }
    catch(Exception){
    throw new Exception("Erro");
}
});

// LISTAR FUNCIONARIO
app.MapGet("/api/funcionario/listar", ([FromServices] AppDataContext ctx) =>
{

    if (ctx.Funcionarios.Any())
    {
        return Results.Ok(ctx.Funcionarios.ToList());
    }
    return Results.NotFound("Não existem funcionários cadatrados!");
});

app.MapPost("/api/folha/cadastrar", ([FromBody] Folha folha, [FromServices] AppDataContext ctx) =>
{
    Folha? folhaEncontrado = ctx.Folhas.FirstOrDefault(x => x.FuncionarioId == folha.FuncionarioId);
    if (folhaEncontrado is null)
    {
        ctx.Folhas.Add(folha);
        ctx.SaveChanges();
        return Results.Created("", folha);

    }
    return Results.BadRequest("Esta Folha já existe!");

});

// LISTAR FOLHA
app.MapGet("/folha/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Folhas.Any())
    {
        return Results.Ok(ctx.Folhas.ToList());
    }
    return Results.NotFound("Não Há folhas");

});

// BUSCAR FOLHA
app.MapGet("/api/folha/buscar/", ([FromRoute] string id,
    [FromServices] AppDataContext ctx) =>
{
    Folha? folha = ctx.Folhas.Find();
    if (folha == null)
    {
        return Results.NotFound("folha não encontrada!");
    }
    return Results.Ok(folha);

}
);


app.Run();