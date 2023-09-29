using AdmFagil.Data;
using AdmFagil.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AdmFagil.Controllers
{
    public class ServicoController : Controller
    {
        readonly private ApplicationDbContext _db;

        public ServicoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ServicoModel> servico = _db.Servico;
            return View(servico);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ServicoModel servico = _db.Servico.FirstOrDefault(x => x.Id == id);

            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ServicoModel servico = _db.Servico.FirstOrDefault(x => x.Id == id);

            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }

        public IActionResult Exportar()
        {
            var dados = GetDados();

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(dados, "Dados Serviço");

                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.sprendsheetml.sheet", "Servicos.xls");
                }
            }
            return Ok();
        }

        private DataTable GetDados()
        {
            DataTable datatable = new DataTable();

            datatable.TableName = "Dados Servico";

            datatable.Columns.Add("Nome do Serviço", typeof(string));
            datatable.Columns.Add("Descrição do Serviço", typeof(string));
            datatable.Columns.Add("Valor", typeof(string));
            datatable.Columns.Add("Data Última Atualização", typeof(DateTime));

            var dados = _db.Servico.ToList();

            if (dados.Count > 0)
            {
                dados.ForEach(servico =>
                {
                    datatable.Rows.Add(servico.ServNome, servico.ServDesc, servico.Preco, servico.DataUltimaAtualizacao);
                });
            }
            return datatable;
        }

        [HttpPost]
        public IActionResult Cadastrar(ServicoModel servico)
        {
            if (ModelState.IsValid)
            {
                servico.DataUltimaAtualizacao = DateTime.Now;

                _db.Servico.Add(servico);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(ServicoModel servico)
        {
            if (ModelState.IsValid)
            {
                var servicoDB = _db.Servico.Find(servico.Id);

                servicoDB.ServNome = servico.ServNome;
                servicoDB.ServDesc = servico.ServDesc;
                servicoDB.Preco = servico.Preco;

                _db.Servico.Update(servicoDB);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

                return RedirectToAction("Index");
            }
            TempData["MensangemErro"] = "Erro ao realizar a Edição";

            return View(servico);
        }

        [HttpPost]
        public IActionResult Excluir(ServicoModel servico)
        {
            if (servico == null)
            {
                return NotFound();
            }
            _db.Servico.Remove(servico);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso!";

            return RedirectToAction("Index");
        }
    }
}