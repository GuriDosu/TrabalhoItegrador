using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using TrabalhoItegrador.Models;
using System.IO;
using TrabalhoItegrador.Data;

namespace TrabalhoItegrador.Controllers
{
    public class ReclamacaoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ReclamacaoController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public IActionResult Formulario()
        {
            return View("~/Views/Home/Privacy.cshtml", new Reclamacao());
        }

        [HttpPost]
        public async Task<IActionResult> SalvarFormulario(Reclamacao reclamacao, IFormFile Foto)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Home/Privacy.cshtml", reclamacao);
            }

            if (Foto != null && Foto.Length > 0)
            {
                var nomeArquivo = Path.GetFileName(Foto.FileName);
                var caminhoImagem = Path.Combine(_env.WebRootPath, "imagens", nomeArquivo);
                Directory.CreateDirectory((caminhoImagem));

                using (var stream = new FileStream(caminhoImagem, FileMode.Create))
                {
                    await Foto.CopyToAsync(stream);
                }

                reclamacao.imagem_url = "/imagens/" + nomeArquivo;
            }
            reclamacao.id_conta = 1;

            _context.Reclamacoes.Add(reclamacao);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
