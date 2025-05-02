using System;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static XptoVeiculos.ConsoleApplication.Service.NumeroSerieService;

namespace XptoVeiculos.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputserieSemDV = @"C:\XPTOVeiculos\serieSemDV.txt";
            string outputSerieComDV = @"C:\XPTOVeiculos\serieComDV.txt";

            string inputSerieParaVerificar = @"C:\XPTOVeiculos\serieParaVerificar.txt";
            string outputSerieVerificada = @"C:\XPTOVeiculos\serieVerificada.txt";

            string inputPaises = @"C:\XPTOVeiculos\paises.txt";
            string inputserieParaRelatorio = @"C:\XPTOVeiculos\serieParaRelatorio.txt";
            string outputlistaTotais = @"C:\XPTOVeiculos\listaTotais.txt";

            try
            {
                GerarSerieComDV(inputserieSemDV, outputSerieComDV);

                ValidarSeries(inputSerieParaVerificar, outputSerieVerificada);

                GerarRelatorioAutomoveis(inputserieParaRelatorio, inputPaises, outputlistaTotais);

                Console.WriteLine($"Arquivos gerados com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }

        private static void GerarSerieComDV(string inputFilePath, string outputFilePath)
        {
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"O arquivo {inputFilePath} não foi encontrado.");
                return;
            }

            // Lê todas as linhas do arquivo de entrada
            var lines = File.ReadAllLines(inputFilePath);

            StringBuilder linhasComDV = new StringBuilder();

            foreach (var line in lines)
            {
                linhasComDV.AppendLine(GerarDV(line));
            }

            File.WriteAllText(outputFilePath, linhasComDV.ToString(), Encoding.UTF8);
        }

        private static void ValidarSeries(string inputFilePath, string outputFilePath)
        {
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"O arquivo {inputFilePath} não foi encontrado.");
                return;
            }

            // Lê todas as linhas do arquivo de entrada
            var lines = File.ReadAllLines(inputFilePath);
            StringBuilder linhasVerificadas = new StringBuilder();

            foreach (var line in lines)
            {
                linhasVerificadas.AppendLine(VerificarSerie(line));

            }

            File.WriteAllText(outputFilePath, linhasVerificadas.ToString(), Encoding.UTF8);
        }

        private static void GerarRelatorioAutomoveis(string serieFilePath, string paisesFilePath, string outputFilePath)
        {
            if (!File.Exists(serieFilePath))
            {
                throw new FileNotFoundException($"O arquivo {serieFilePath} não foi encontrado.");
            }

            if (!File.Exists(paisesFilePath))
            {
                throw new FileNotFoundException($"O arquivo {paisesFilePath} não foi encontrado.");
            }

            var series = File.ReadAllLines(serieFilePath);
            var paises = File.ReadAllLines(paisesFilePath);

            // Processa o arquivo de países para criar um dicionário de código -> nome
            var paisesDict = new Dictionary<string, string>();
            foreach (var linha in paises)
            {
                var partes = linha.Split(';');
                if (partes.Length == 2)
                {
                    paisesDict[partes[0]] = partes[1];
                }
            }

            // Filtra e conta os automóveis por país
            var contadorPorPais = new Dictionary<string, int>();
            foreach (var serie in series)
            {
                if (string.IsNullOrWhiteSpace(serie) || serie.Length < 14)
                {
                    continue; 
                }

                string codigoPais = serie.Substring(4, 3); 
                string tipoVeiculo = serie.Substring(9, 1); 

                if (VeiculosPermitidos().Contains(tipoVeiculo) && paisesDict.ContainsKey(codigoPais))
                {
                    string nomePais = paisesDict[codigoPais];
                    if (!contadorPorPais.ContainsKey(nomePais))
                    {
                        contadorPorPais[nomePais] = 0;
                    }
                    contadorPorPais[nomePais]++;
                }
            }

            // Ordena os resultados por nome do país
            var resultadosOrdenados = contadorPorPais.OrderBy(x => x.Key);

            // Gera o arquivo de saída
            var linhasSaida = resultadosOrdenados.Select(x => $"{x.Key}-{x.Value}");

            File.WriteAllLines(outputFilePath, linhasSaida, Encoding.UTF8);
        }


    }
}
