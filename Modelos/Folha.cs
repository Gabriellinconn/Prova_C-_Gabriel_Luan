using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Folha
{

    public Folha(Double valor, Double quantidade, int mes, int ano, String funcionarioId)
    {
        Valor = valor;
        Quantidade = quantidade;
        Mes = mes;
        Ano = ano;
        FuncionarioId = funcionarioId;

    }

    public Double Valor { get; set; }
    public Double Quantidade { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }
    public String FuncionarioId { get; set; }

}