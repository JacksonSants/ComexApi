using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace ComexApi.Models;

public class Cliente
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public List<Livro> Livros{ get; set; }

    public void AddLivro(Livro livro)
    {
        Livros.Add(livro);
    }

    public override string ToString()
    {
        string livrosStr = Livros.Count > 0
            ? string.Join(", ", Livros.Select(l => l.Titulo))
            : "Nenhum livro emprestado";

        return $"Cliente: {Nome}, CPF: {CPF}, Livros: {livrosStr}";
    }

    public void RemovoLivro(Livro livro)
    {
        var currentLivro = Livros.FirstOrDefault(livro => livro.ISBN == livro.ISBN);
        if (currentLivro != null)
        {
            Console.WriteLine("Livro não encontrado.");
        }

        Livros.Remove(currentLivro);
        Console.WriteLine();
        
    }

}
