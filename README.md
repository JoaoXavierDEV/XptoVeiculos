# XPTO Veículos

Sistema para manipulação, validação e geração de relatórios de números de série de veículos.

## Funcionalidades

- **Geração de números de série com dígito verificador:**  
  Lê números de série sem DV e gera um arquivo com o DV calculado.

- **Validação de números de série completos:**  
  Verifica se os números de série completos (com DV) são válidos.

- **Relatório de automóveis por país:**  
  Gera um relatório com a contagem de automóveis fabricados por país, baseado nos números de série e na lista de países.

## Estrutura dos Arquivos

- `serieSemDV.txt`: Números de série sem DV (14 caracteres por linha).
- `serieComDV.txt`: Saída com números de série e DV (16 caracteres por linha).
- `serieParaVerificar.txt`: Números de série completos para validação.
- `serieVerificada.txt`: Saída da validação dos números de série.
- `paises.txt`: Lista de códigos e nomes de países, separados por `;`.
- `serieParaRelatorio.txt`: Números de série completos para relatório.
- `listaTotais.txt`: Relatório final de automóveis por país.

## Como Executar

1. Coloque todos os arquivos de entrada na pasta `C:\XPTOVeiculos`.
2. Compile e execute o projeto `XptoVeiculos.ConsoleApplication`.
3. Os arquivos de saída serão gerados na mesma pasta.

## Testes

Para rodar os testes unitários, utilize o comando:

```csharp
dotnet test XptoVeiculos.Test/XptoVeiculos.Test.csproj
```
