using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using API.Models;


namespace API.Models;

public class Funcionario {


    public Funcionario (String nome, String cpf){
    Id = Id;
    Nome = nome;
    Cpf = cpf;
    }

    public string Nome {get;set;}

    public string Cpf {get;set;}
    public int Id {get;set;}



}