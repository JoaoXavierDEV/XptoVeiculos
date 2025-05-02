using System;
using System.Collections.Generic;
using Xunit;
using XptoVeiculos.ConsoleApplication.Service;

namespace XptoVeiculos.Test
{
    public class NumeroSerieServiceTests
    {
        [Fact]
        public void VerificarSerie_ValidSerie_ReturnsVerdadeiro()
        {
            // Arrange
            string serie = "2122BRAXXA3348-F"; // Série válida com DV correto

            // Act
            string resultado = NumeroSerieService.VerificarSerie(serie);

            // Assert
            Assert.Equal($"{serie} - verdadeiro", resultado);
        }

        [Fact]
        public void VerificarSerie_InvalidSerie_ReturnsFalso()
        {
            // Arrange
            string serie = " 0505MEXXXM5282-4"; // Série inválida com DV incorreto

            // Act
            string resultado = NumeroSerieService.VerificarSerie(serie);

            // Assert
            //Assert.False(serie == resultado);
            Assert.Equal($"{serie} - falso", resultado);
        }

        [Fact]
        public void GerarDV_ValidSerie_ReturnsSerieWithDV()
        {
            // Arrange
            string serie = "2122BRAXXA3348"; // Série válida sem DV
            string expected = "2122BRAXXA3348-F"; // Série esperada com DV

            // Act
            string resultado = NumeroSerieService.GerarDV(serie);

            // Assert
            Assert.Equal(expected, resultado);
        }

        [Fact]
        public void GerarDV_InvalidSerie_ThrowsArgumentException()
        {
            // Arrange
            string serie = "2122BRAXXA33"; // Série inválida (menos de 14 caracteres)

            // Act & Assert
            Assert.Throws<ArgumentException>(() => NumeroSerieService.GerarDV(serie));
        }


    }
}
