using System.ComponentModel.DataAnnotations;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using provaCsharp.Modelos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext ctx) => {
    Funcionario? funcionarioEncontrado = ctx.Funcionarios.FirstOrDefault(x=> x.Cpf == funcionario.Cpf);
    if(funcionarioEncontrado is null){
        ctx.Funcionarios.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created("", funcionario);
    }

    return Results.BadRequest("Funcionario ja existente");

});

app.MapGet("/api/funcionario/listar", ([FromServices] AppDataContext ctx) => {

    if(ctx.Funcionarios.Any()){
        return Results.Ok(ctx.Funcionarios.ToList());
    }
    return Results.NotFound("Não existem funcionários cadatrados");
});

app.MapPost("/api/folha/cadastrar", ([FromBody] Folha folha, [FromServices] AppDataContext ctx) =>{
    Funcionario? funcionarioEncontrado = ctx.Funcionarios.FirstOrDefault(x=> x.FuncionarioId == Folha.funcionarioId);

});


app.Run();