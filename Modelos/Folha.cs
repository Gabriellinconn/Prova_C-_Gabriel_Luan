using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using API.Models;


namespace API.Models;

public class Folha
{

    public Folha(Double valor, Double quantidade, int mes, int ano, String funcionarioId){
        Valor = valor;
        Quantidade = quantidade;
        Mes = mes;
        Ano = ano;
        FuncionarioId = funcionarioId; 

    }

    public double Valor {get; set;}
    public double Quantidade {get;set;}
    public int Mes {get;set;}
    public int Ano {get;set;}
    public string FuncionarioId {get;set;}
   
}