using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Folha
{

    public Folha()
    {

    }
    public int Id { get; set; }
    public Double? Valor { get; set; }
    public Double? Quantidade { get; set; }
    public int Mes { get; set; }
    public int Ano { get; set; }



}