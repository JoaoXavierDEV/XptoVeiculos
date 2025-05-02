using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XptoVeiculos.ConsoleApplication.Service
{
    public class NumeroSerieService
    {
        public static string VerificarSerie(string serie)
        {
            string resultado = string.Empty;

            try
            {
                if (ValidarNumeroSerieComDV(serie))
                    return $"{serie} - verdadeiro";
                else
                    return $"{serie} - falso";

            }
            catch (Exception)
            {
                return $"{serie} - falso";
            }

        }

        public static string GerarDV(string serie)
        {
            ValidarNumeroDeSerie(serie);

            return GerarSerieComDigitoVerificador(serie);
        }

        public static List<string> VeiculosPermitidos()
        {
            return new List<string> { "A", "M", "C" };
        }

        private static string GerarSerieComDigitoVerificador(string input)
        {
            int sum = 0;
            foreach (char c in input)
            {
                sum += (int)c; // Soma os valores ASCII dos caracteres
            }

            int remainder = sum % 16; // Calcula o resto da divisão por 16
            string checkDigit = remainder.ToString("X"); // Converte para notação hexadecimal

            return $"{input}-{checkDigit}"; // Retorna o número de série completo com o dígito verificador
        }

        private static bool ValidarNumeroSerieComDV(string serie)
        {
            if (string.IsNullOrWhiteSpace(serie))
            {
                throw new ArgumentException("A série não pode ser nula ou vazia.");
            }
            if (serie.Length != 16)
            {
                throw new ArgumentException("A série deve ter exatamente 16 caracteres.");
            }

            ValidarSerie(serie);

            string serieSemDV = serie[..^2]; // Remove o dígito verificador

            string novaDV = GerarDV(serieSemDV);

            if (serie != novaDV)
            {
                return false;
            }

            return true;
        }

        private static bool ValidarNumeroDeSerie(string serie)
        {
            if (string.IsNullOrWhiteSpace(serie))
            {
                throw new ArgumentException("A série não pode ser nula ou vazia.");
            }
            if (serie.Length != 14)
            {
                throw new ArgumentException("A série deve ter exatamente 14 caracteres.");
            }

            ValidarSerie(serie);


            return true;
        }

        private static void ValidarSerie(string serie)
        {
            // Decodificação do número de série
            string anoFabricacao = serie[..2]; // 21
            string anoModelo = serie[2..4]; // 22
            string codigoPais = serie[4..7]; // BRA
            string reservado = serie[7..9]; // XX
            string tipoVeiculo = serie[9..10]; // A
            string sequencial = serie[10..14]; // 3348

            if (!int.TryParse(anoFabricacao, out _))
            {
                throw new ArgumentException("O ano de fabricação deve ser numérico.");
            }
            if (!int.TryParse(anoModelo, out _))
            {
                throw new ArgumentException("O ano do modelo deve ser numérico.");
            }

            var veiculosPermitidos = VeiculosPermitidos();

            if (!veiculosPermitidos.Contains(tipoVeiculo))
            {
                throw new ArgumentException("O tipo de veículo deve ser 'A', 'M' ou 'C'.");
            }

            if (!int.TryParse(sequencial, out _))
            {
                throw new ArgumentException("O número sequencial deve ser numérico.");
            }
        }
    }
}
