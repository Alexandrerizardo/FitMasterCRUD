using Microsoft.AspNetCore.Mvc;
using MVCteste.Data;
using MVCteste.Models;

namespace MVCteste.Controllers
{
    public class AlunoController : Controller
    {
        public readonly ApplicationDbContext _context;
        public AlunoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            List<Aluno> alunos = _context.Alunos.ToList();

            if (alunos == null)
            {
                Console.WriteLine("nenhum aluno encontrado!");
            }
            return View(alunos);
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return View(aluno);
            }

            try
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Aluno cadastrado com sucesso!";
                return View();

            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = $"Erro ao cadastrar aluno: {err.Message}";
                return View(aluno);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            try
            {
                var aluno = await _context.Alunos.FindAsync(id);
                if (aluno == null)
                {
                    TempData["MensagemErro"] = "Aluno não encontrado.";
                    return RedirectToAction("Index");
                }
                return View(aluno);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao buscar aluno: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                return View(aluno);
            }

            try
            {
                _context.Update(aluno);
                await _context.SaveChangesAsync();
                ViewBag.Mensagem = "Aluno Editado com sucesso!";
                return View();
            }
            catch (Exception err)
            {

                TempData["MensagemErro"] = $"Erro ao cadastrar aluno: {err.Message}";
                return View(aluno);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var aluno = await _context.Alunos.FindAsync(id);
                if (aluno == null)
                {
                    TempData["MensagemErro"] = "Aluno não Encontrado.";
                    return RedirectToAction("Index");
                }
                return View(aluno);
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = $"Erro ao buscar aluno: {err.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirConfirmado(int id)
        {
            try
            {
                var aluno = await _context.Alunos.FindAsync(id);

                if (aluno == null)
                {
                    TempData["MensagemErro"] = "Aluno não encontrado.";
                    return RedirectToAction("Index");
                }

                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();

                if (aluno == null)
                {
                    TempData["MensagemSucesso"] = "Aluno excluído com sucesso!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao excluir aluno: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
