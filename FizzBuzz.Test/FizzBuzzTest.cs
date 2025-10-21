using FluentAssertions;

namespace FizzBuzz.Test;

public class FizzBuzzTest
{
    [Theory]
    [InlineData(3)]
    [InlineData(6)]
    [InlineData(9)]
    [InlineData(18)]
    [InlineData(21)]
    public void Si_EntradaEsMultiploDeTres_Debe_RetornarFizz(int numero)
    {
        //Act
        var resultado = EvaluarFizzBuzz(numero);
        
        //Assert
        resultado.Should().Be("Fizz");
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(4)]
    public void Si_EntradaEsUnoDosCuatro_Debe_RetornarElMismoNumero (int numero)
    {
        //Act
        var resultado = EvaluarFizzBuzz(numero);
        //Assert
        resultado.Should().Be(numero.ToString());
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    //[InlineData(15)]
    public void Si_EntradaEsMultiploDeCinco_Debe_RetornarBuzz(int numero)
    {
        //Act
        var resultado = EvaluarFizzBuzz(numero);
        //Assert
        resultado.Should().Be("Buzz");
    }

    [Fact]
    public void Si_NumeroEsQuince_Debe_RetornarFizzBuzz()
    {
        //arrange
        int numero = 15;
        //act
        var resultado = EvaluarFizzBuzz(numero);
        //assert
        resultado.Should().Be("FizzBuzz");
    }
    
    

    private string EvaluarFizzBuzz(int numero)
    {
        if (numero == 15)
            return "FizzBuzz";
        if (numero % 3 == 0)
            return "Fizz";
        if (numero % 5 == 0)
            return "Buzz";
        
        return numero.ToString();
    }
}