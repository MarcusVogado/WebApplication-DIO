using System.ComponentModel.DataAnnotations;

namespace WebApplication_DIO.Models
{
	public class Contato
	{
		[Key]
		public int Id { get; set; }
		public string Nome { get; set; } = null!;
		public string Telefone { get; set; } = null!;
		public bool Ativo { get; set; }
	}
}
