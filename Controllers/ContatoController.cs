using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pottencial.API.Context;
using Pottencial.API.Entities;

namespace Pottencial.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }
        [HttpPost("CadastrarContato")]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterPorId), new { id = contato.Id }, contato);
        }
        [HttpGet("ObterPorId/{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null) return NotFound();

            return Ok(contato);
        }
        [HttpGet("ObterListaContato")]
        public IActionResult ObterListaContato()
        {
            return Ok(_context.Contatos);
        }
        [HttpGet("ObterPorNome/{nome}")]
        public IActionResult ObterPorNome(string nome)
        {
            var contato = _context.Contatos.Where(n => n.Nome.Contains(nome));

            if (contato == null) return NotFound();
            return Ok(contato);
        }

        [HttpPut("AtualizarContato/{id}")]
        public IActionResult AtualizarContato(int id, Contato contato)
        {
            var contatoAtualizado = _context.Contatos.Find(id);

            if (contatoAtualizado == null) return NotFound();

            contatoAtualizado.Id = id;
            contatoAtualizado.Nome = contato.Nome;
            contatoAtualizado.Telefone = contato.Telefone;
            contatoAtualizado.Ativo = contato.Ativo;

            _context.Update(contatoAtualizado);
            _context.SaveChanges();

            return Ok(contatoAtualizado);
        }
        [HttpDelete("ExcluirContato/{id}")]
        public IActionResult Excluir(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null) return NotFound();

            _context.Contatos.Remove(contato);
            _context.SaveChanges();

            return NoContent();
        }
    }
}