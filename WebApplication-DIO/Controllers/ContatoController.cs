using Microsoft.AspNetCore.Mvc;
using WebApplication_DIO.Context;
using WebApplication_DIO.Models;

namespace WebApplication_DIO.Controllers
{
	public class ContatoController : Controller
	{
		private readonly AgendaContext _context;
		public ContatoController(AgendaContext context)
		{
			_context = context;	
		}
		public IActionResult Index()
		{
			var contatos= _context.Contatos.ToList();
			return View(contatos);
		}
		public IActionResult Criar()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Criar(Contato contato)
		{
			if(ModelState.IsValid)
			{
				_context.Contatos.Add(contato);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(contato);
		}
        public IActionResult Editar(int id)
        {
			var contatoDb = _context.Contatos.Find(id);
			if (contatoDb == null) return NotFound("Contato Não Encontrado");
            return View(contatoDb);
        }
		[HttpPost]
		public IActionResult Editar(Contato contato)
		{
            var contatoDb = _context.Contatos.Find(contato.Id);
			if (contatoDb == null) return NotFound();
			contatoDb.Nome=contato.Nome;
			contatoDb.Telefone=contato.Telefone;
			contatoDb.Ativo=contato.Ativo;
			_context.Contatos.Update(contatoDb);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes(int id)
        {
            var contatoDb = _context.Contatos.Find(id);
            if (contatoDb == null) return NotFound("Contato Não Encontrado");
            return View(contatoDb);
        }
        public IActionResult Deletar(int id)
        {
            var contatoDb = _context.Contatos.Find(id);
            if (contatoDb == null) return NotFound("Contato Não Encontrado");
            return View(contatoDb);
        }
        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoDb = _context.Contatos.Find(contato.Id);
            if (contatoDb == null) return NotFound();  
            _context.Contatos.Remove(contatoDb);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
