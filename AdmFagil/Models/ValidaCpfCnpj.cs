using System;
using System.Text.RegularExpressions;

namespace AdmFagil.Models
{
    public static class ValidacaoCpfCnpj
    {
        public static bool ValidarCpfCnpj(string cpfCnpj)
        {
            cpfCnpj = RemoverCaracteresNaoNumericos(cpfCnpj);

            if (string.IsNullOrEmpty(cpfCnpj))
                return false;

            if (cpfCnpj.Length == 11)
            {
                return ValidarCpf(cpfCnpj);
            }
            else if (cpfCnpj.Length == 14)
            {
                return ValidarCnpj(cpfCnpj);
            }
            else
            {
                return false;
            }
        }

        private static bool ValidarCpf(string cpf)
        {
            if (cpf.Length != 11)
                return false;

            if (Regex.IsMatch(cpf, @"^(.)\1+$"))
                return false;

            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];
            }

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];
            }

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        private static bool ValidarCnpj(string cnpj)
        {
            if (cnpj.Length != 14)
                return false;

            int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicadores1[i];
            }

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicadores2[i];
            }

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }

        private static string RemoverCaracteresNaoNumericos(string input)
        {
            return Regex.Replace(input, @"[^\d]", "");
        }
    }
}