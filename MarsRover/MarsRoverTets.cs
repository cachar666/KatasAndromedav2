using System.Transactions;
using FluentAssertions;

namespace MarsRover;

public class MarsRoverTets
{
    [Fact]
    public void Si_PosicionInicialEjeX_Debe_SerCero()
    {
        //Assert
        new Rover().EjeX.Should().Be(0);
    }

    [Fact]
    public void Si_PosicionInicialEjeY_Debe_SerCero()
    {
        //Assert
        new Rover().EjeY.Should().Be(0);
    }

    [Fact]
    public void Si_PosicionInicialOrientacion_Debe_ser_N()
    {
        //Assert
        new Rover().Orientacion.Should().Be("N");
    }

    [Theory]
    [InlineData("M", 1)]
    [InlineData("MM", 2)]
    [InlineData("MMMMM", 5)]
    public void Si_ComandoEsM_Debe_AumentarUnaPosicionEnY(string comando, int posicionYEsperada)
    {
        //Arrange
        Rover rover = new ();
        
        //Act
        rover.Ejecutar(comando);
        
        //Assert
        rover.EjeX.Should().Be(0);
        rover.EjeY.Should().Be(posicionYEsperada);
        rover.Orientacion.Should().Be("N");
    }

    

    [Theory]
    [InlineData("MMMMMMMMMMMMMM", 4)]
    [InlineData("MMMMMMMMMMMMMMMMMMMM", 0)]
    [InlineData("MMMMMMMMMMMMMMMMMMMMMMMMMM", 6)]
    [InlineData("MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM", 0)]
    public void Si_ComandoMEsMayorADiez_Debe_AsignarModuloDeDiezEnPosicionEjeY(string comando, int posicionYEsperada)
    {
        //Arrange
        Rover rover = new();
        
        //Act
        rover.Ejecutar(comando);
        //Assert   
        rover.EjeX.Should().Be(0);
        rover.EjeY.Should().Be(posicionYEsperada);
    }

    [Theory]
    [InlineData("L", "W")]
    [InlineData("LL", "S")]   
    [InlineData("LLL","E")]
    [InlineData("LLLL","N")]
    [InlineData("LLLLL", "W")]   
    [InlineData("LLLLLLLLLLLLLLLL","N")]  
    public void Si_ComandoEsL_Debe_GirarALaIzquierdaNVecesL(string comando , string orientacionEsperada)
    {
        //Arrange
        Rover rover = new();
        //Act
        rover.Ejecutar(comando);
        //Assert
        rover.Orientacion.Should().Be(orientacionEsperada);
    }
    
    [Theory]
    [InlineData("R", "E")]
    [InlineData("RR", "S")]   
    [InlineData("RRR","W")]
    [InlineData("RRRR","N")]
    [InlineData("RRRRRRRR","N")]  
    [InlineData("RRRRRRRRRR","S")]  
    public void Si_ComandoEsR_Debe_GirarALaDerechaNVecesR(string comando , string orientacionEsperada)
    {
        //Arrange
        Rover rover = new();
        //Act
        rover.Ejecutar(comando);
        //Assert
        rover.Orientacion.Should().Be(orientacionEsperada);
    }

    [Theory]
    [InlineData("LLM",9)]
    public void Si_OrientacionEsSYComandoEsM_Debe_DisminuirUnaPosicionEnEjeY(string comando, int posicionYEsperada)
    {
        //Arrange
        Rover rover = new();
        //Act
        rover.Ejecutar(comando);
        //Assert
        rover.EjeY.Should().Be(posicionYEsperada);
    }

}



public class Rover
{
    public int EjeX {get; private set;}

    public int EjeY { get; private set; }

    public string Orientacion { get; set; } = "N";

    public void Ejecutar(string comando)
    {
        if (comando.Contains("M"))
        {
            if (comando.Length >= 10)           
            {                                   
                EjeY = (comando.Length % 10);   
                return;                         
            }                                   
                                    
            EjeY = comando.Length;              
        }
        
        if (comando.Contains("L"))
        {
            if (comando.Length >= 4)
            {
                Orientacion = PuntosCardinalesLeft[comando.Length % 4];  
                return;
            }

            Orientacion = PuntosCardinalesLeft[comando.Length];  
        }
        
        if (comando.Contains("R"))
        {
            if (comando.Length >= 4)
            {
                Orientacion = PuntosCardinalesRight[comando.Length % 4];  
                return;
            }

            Orientacion = PuntosCardinalesRight[comando.Length];  
        }
        
        
        
        
    }

    public static Dictionary<int, string> PuntosCardinalesLeft = new Dictionary<int, string>()
    {
        { 0,"N"}
        ,{ 1,"W"}
        ,{ 2,"S"}
        ,{ 3,"E"}
    };
    
    public static Dictionary<int, string> PuntosCardinalesRight = new Dictionary<int, string>()
    {
        { 0,"N"}
        ,{ 1,"E"}
        ,{ 2,"S"}
        ,{ 3,"W"}
    };
}