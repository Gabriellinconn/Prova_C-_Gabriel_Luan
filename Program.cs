using System.Diagnostics;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using provaCsharp.Modelos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext ctx) =>
{
<<<<<<< HEAD
=======
    try
>>>>>>> 70956959e1efb25622278423a781cc1a57353d11
    {
        ctx.Funcionarios.Add(funcionario);
        ctx.SaveChanges();
        return Results.Created("", funcionario);
    }
<<<<<<< HEAD


=======
    catch(Exception){
    throw new Exception("Erro");
}
>>>>>>> 70956959e1efb25622278423a781cc1a57353d11
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

// CADASTRAR FOLHA
app.MapPost("api/folha/cadastrar", ([FromBody] Folha folha, [FromServices] AppDataContext ctx) =>
{
    Folha? folhaEncontrada = ctx.Folhas.FirstOrDefault(x => x.Id == folha.Id);

    if (folhaEncontrada is null)
    {
        ctx.Folhas.Add(folha);
        ctx.SaveChanges();
        return Results.Created("", folha);

    }
    return Results.BadRequest("Esta Folha já existe!");

});

// LISTAR FOLHA
app.MapGet("api/folha/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Folhas.Any())
    {
        return Results.Ok(ctx.Folhas.ToList());
    }
    return Results.NotFound("Não Há folhas");

});

// BUSCAR FOLHA
app.MapGet("/api/folha/buscar/{id}", ([FromRoute] string id,
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