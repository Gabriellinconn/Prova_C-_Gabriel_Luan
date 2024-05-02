using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Funcionario{

public Funcionario(String nome, String cpf){
    Id = Guid.NewGuid().ToString();
    Nome = nome;
    Cpf = cpf;
}

public string Nome {get;set;}

public string Cpf {get;set;}

[Key()]
public string Id {get;set;}



}