using FluentAssertions;

namespace LeapYears.Test;

public class LeapYearsTest
{
    private readonly CalculadoraBisiestos _calculadoraBisiestos = new CalculadoraBisiestos();

    [Fact]
    public void Si_YearEs1996_Debe_RetornarTrue()
    {
        //Arrange
        var year = 1996;
        //Act
        var result = _calculadoraBisiestos.IsLeapYear(year);
        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Si_YearEs2001_Debe_RetornarFalse()
    {
        //Arrange
        var year = 2001;
        //Act
        var result = _calculadoraBisiestos.IsLeapYear(year);
        //Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Si_YearEs2000_Debe_RetornarTrue()
    {
        //Arrange
        var year = 2000;
        //Act
        var result = _calculadoraBisiestos.IsLeapYear(year);
        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Si_YearEs1900_Debe_RetonarFalse()
    {
        //Arrange
        var year = 1900;
        //Act
        var result = _calculadoraBisiestos.IsLeapYear(year);
        //Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Si_YearEs2025_Debe_RetornarFalse()
    {
        //Arrange
        var year = 2025;
        //Act
        var result = _calculadoraBisiestos.IsLeapYear(year);
        //Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(1996)]
    [InlineData(2000)]
    [InlineData(4)]
    public void Si_YearBisiesto_Debe_RetornarTrue(int year)
    {
        //Act
        var result = _calculadoraBisiestos.IsLeapYear(year);
        //Asert
        result.Should().BeTrue();
    }
    
    [Theory]
    [InlineData(2001)]
    [InlineData(2025)]
    [InlineData(1900)]
    public void Si_YearNoEsBisiesto_Debe_RetornarFalse(int year)
    {
        //Act
        var result = _calculadoraBisiestos.IsLeapYear(year);
        //Asert
        result.Should().BeFalse();
    }
}