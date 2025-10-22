using FluentAssertions;

namespace MarsRover2;

public class MarsRoverTest
{
    [Theory]
    [InlineData("", "0:0:N")]
    [InlineData("M", "0:1:N")]
    [InlineData("MM", "0:2:N")]
    public void Si_RoverAvanzaNPosiciones_Debe_CambiarNPosicion(string comando, string posicionEsperada)
    {
        //Arrange
        var rover = new Rover();
        //Act
        rover.Ejecutar(comando);
        //Assert
        rover.Posicion.Should().Be(posicionEsperada);
        
    }

    [Theory]
    [InlineData("MMMMMMMMMM", "0:0:N")]
    [InlineData("MMMMMMMMMMMMMMM", "0:5:N")]
    public void Si_RoverEstaEnPosicion00NYAvanzaAlFinalDeLaPlataforma_DebeReiniciarSuPosicionYAvanzarElRestante(string comando, string posicionEsperada)
    {
        //Arrange
        var rover = new Rover();
        //Act
        rover.Ejecutar(comando);
        //Assert
        rover.Posicion.Should().Be(posicionEsperada);
    }

    [Fact]
    public void Si_RoverEstaOrientadoAlNorteYGiraALaDerecha_Debe_OrientarseAlOriente()
    {
        //Arrange
        var rover = new Rover();
        
        //Act
        rover.Ejecutar("R");
        
        //Assert
        rover.Posicion.Should().Be("0:0:E");
    }

    [Fact]
    public void Si_RoverEstaOrientadoAlNorteYGiraALaDerechaDosVeces_Debe_OrientarseAlSur()
    {
        //Arrange
        var rover = new Rover();
        //Act
        rover.Ejecutar("RR");
        //Assert
        rover.Posicion.Should().Be("0:0:S");
    }

    [Fact]
    public void Si_RoverEstaOrientadoAlNorteYGiraALaDerechaTresVeces_Debe_OrientarseAlOccidente()
    {
        //Arrange
        var rover = new Rover();
        //Act
        rover.Ejecutar("RRR");
        //Assert
        rover.Posicion.Should().Be("0:0:W");
    }
}

public class Rover
{
    private const int LimitePlataforma = 9;
    private const int InicioPlataforma = 0;

    private int _coordenadaY = 0;
    private char _direccionBrujula = 'N';

    public string Posicion =>$"0:{_coordenadaY}:{_direccionBrujula}";
    
    
    public void Ejecutar(string comando)
    {
        if (Girar(comando)) return;

        foreach (var _ in comando.ToCharArray())
        {
            Avanzar();
        }
    }

    private void Avanzar()
    {
        if (_coordenadaY == LimitePlataforma)
            _coordenadaY = InicioPlataforma;
        else
            _coordenadaY++;
    }

    private bool Girar(string comando)
    {
        if (comando == "R")
        {
            _direccionBrujula = 'E';
            return true;
        }
        
        if (comando == "RR")
        {
            _direccionBrujula = 'S';
            return true;
        }
        
        if (comando == "RRR")
        {
            _direccionBrujula = 'W';
            return true;
        }

        return false;
    }
}