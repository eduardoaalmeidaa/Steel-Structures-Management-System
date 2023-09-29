using AdmFagil.Data;
using AdmFagil.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AdmFagil.Controllers
{
    public class ClienteController : Controller
    {
        readonly private ApplicationDbContext _db;

        public ClienteController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ClienteModel> cliente = _db.Cliente;
            return View(cliente);
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

            ClienteModel cliente = _db.Cliente.FirstOrDefault(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ClienteModel cliente = _db.Cliente.FirstOrDefault(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        public IActionResult Exportar()
        {
            var dados = GetDados();

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.AddWorksheet(dados, "Dados Cliente");

                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.sprendsheetml.sheet", "Clientes.xls");
                }
            }
            return Ok();
        }

        private DataTable GetDados()
        {
            DataTable datatable = new DataTable();

            datatable.TableName = "Dados Cliente";

            datatable.Columns.Add("Nome", typeof(string));
            datatable.Columns.Add("Telefone", typeof(string));
            datatable.Columns.Add("Email", typeof(string));
            datatable.Columns.Add("CPF/CNPJ", typeof(string));
            datatable.Columns.Add("Endereço", typeof(string));
            datatable.Columns.Add("Data de Cadastro", typeof(DateTime));

            var dados = _db.Cliente.ToList();

            if (dados.Count > 0)
            {
                dados.ForEach(cliente =>
                {
                    datatable.Rows.Add(cliente.Nome, cliente.Telefone, cliente.Email, cliente.CpfCnpj, cliente.Endereco, cliente.DataCadastro);
                });
            }
            return datatable;
        }

        [HttpPost]
        public IActionResult Cadastrar(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.DataCadastro = DateTime.Now;

                _db.Cliente.Add(cliente);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDB = _db.Cliente.Find(cliente.Id);

                clienteDB.Nome = cliente.Nome;
                clienteDB.Telefone = cliente.Telefone;
                clienteDB.Email = cliente.Email;
                clienteDB.CpfCnpj = cliente.CpfCnpj;
                clienteDB.Endereco = cliente.Endereco;

                _db.Cliente.Update(clienteDB);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

                return RedirectToAction("Index");
            }
            TempData["MensangemErro"] = "Erro ao realizar a Edição";

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Excluir(ClienteModel cliente)
        {
            if (cliente == null)
            {
                return NotFound();
            }
            _db.Cliente.Remove(cliente);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso!";

            return RedirectToAction("Index");
        }
    }
}