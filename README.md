# XPTO Ve�culos

Sistema para manipula��o, valida��o e gera��o de relat�rios de n�meros de s�rie de ve�culos.

## Funcionalidades

- **Gera��o de n�meros de s�rie com d�gito verificador:**  
  L� n�meros de s�rie sem DV e gera um arquivo com o DV calculado.

- **Valida��o de n�meros de s�rie completos:**  
  Verifica se os n�meros de s�rie completos (com DV) s�o v�lidos.

- **Relat�rio de autom�veis por pa�s:**  
  Gera um relat�rio com a contagem de autom�veis fabricados por pa�s, baseado nos n�meros de s�rie e na lista de pa�ses.

## Estrutura dos Arquivos

- `serieSemDV.txt`: N�meros de s�rie sem DV (14 caracteres por linha).
- `serieComDV.txt`: Sa�da com n�meros de s�rie e DV (16 caracteres por linha).
- `serieParaVerificar.txt`: N�meros de s�rie completos para valida��o.
- `serieVerificada.txt`: Sa�da da valida��o dos n�meros de s�rie.
- `paises.txt`: Lista de c�digos e nomes de pa�ses, separados por `;`.
- `serieParaRelatorio.txt`: N�meros de s�rie completos para relat�rio.
- `listaTotais.txt`: Relat�rio final de autom�veis por pa�s.

## Como Executar

1. Coloque todos os arquivos de entrada na pasta `C:\XPTOVeiculos`.
2. Compile e execute o projeto `XptoVeiculos.ConsoleApplication`.
3. Os arquivos de sa�da ser�o gerados na mesma pasta.

## Testes

Para rodar os testes unit�rios, utilize o comando:

```csharp
dotnet test XptoVeiculos.Test/XptoVeiculos.Test.csproj
```
