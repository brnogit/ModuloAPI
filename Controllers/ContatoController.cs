using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Context;
using ModuloAPI.Entities;

namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        //atributo
        private readonly AgendaContext _context;
        //construtor para receber o context
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);
        }

        [HttpGet("{id}")] //retorna o id do banco de dados
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
            {
                return NotFound();
            }

            return Ok(contato);
        }


        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)// recebe dois parametros, um com ID do contato a ser atualizado. E o contato/JSON para poder atualizar as informações
        {
            var contatoBanco = _context.Contatos.Find(id); // procura o contato por id no banco

            if(contatoBanco == null) //verifica se existe
            {
                return NotFound();
            }

            contatoBanco.Nome = contato.Nome; //vai substituir os dados do contato no banco pelos novos a serem atualizados
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco); //responsavel por atualizar os dados
            _context.SaveChanges(); //salva as mudanças

            return Ok(contatoBanco);
        }
    }
}

// ContatoController responsavel por adicionar informações no banco de dados