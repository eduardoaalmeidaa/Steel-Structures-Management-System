using AdmFagil.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

public class ClienteModel : IValidatableObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Digite o Nome do cliente!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Digite o Telefone do cliente!")]
    [StringLength(11, ErrorMessage = "O telefone deve conter 8 ou 9 dígitos.", MinimumLength = 8)]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Digite o E-mail do cliente!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Digite o CPF/CNPJ do cliente!")]
    public string CpfCnpj { get; set; }

    [Required(ErrorMessage = "Digite o Endereço do cliente!")]
    public string Endereco { get; set; }
    public DateTime DataCadastro { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!IsValidEmailDomain(Email))
        {
            yield return new ValidationResult("O E-mail deve conter um domínio!", new[] { nameof(Email) });
        }

        if (!string.IsNullOrEmpty(CpfCnpj) && !ValidacaoCpfCnpj.ValidarCpfCnpj(CpfCnpj))
        {
            yield return new ValidationResult("CPF/CNPJ inválido!", new[] { nameof(CpfCnpj) });
        }
    }

    private bool IsValidEmailDomain(string email)
    {
        var allowedDomains = new[] { "gmail.com", "hotmail.com", "outlook.com" };

        if (!string.IsNullOrEmpty(email))
        {
            var domain = email.Split('@').LastOrDefault();
            return allowedDomains.Contains(domain);
        }

        return false;
    }
}
