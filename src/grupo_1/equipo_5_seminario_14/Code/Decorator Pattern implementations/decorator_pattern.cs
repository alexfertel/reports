using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            BotonDeAyudaDecorator ventanaConBotonDeAyuda = new BotonDeAyudaDecorator(new Ventana());
            BordeDecorator ventanaConBotonDeAyudaYBorde = new BordeDecorator(ventanaConBotonDeAyuda);
            ventanaConBotonDeAyudaYBorde.Dibujar();
            Console.WriteLine();

            BordeDecorator ventanaConBorde = new BordeDecorator(new Ventana());
            ventanaConBorde.Dibujar();
            Console.WriteLine();

            BordeDecorator ventanaConDobleBorde = new BordeDecorator(ventanaConBorde);
            ventanaConDobleBorde.Dibujar();
            Console.WriteLine();
            
            BordeDecorator ventanaConDobleBordeYBotonDeAyuda = new BordeDecorator(new BordeDecorator(ventanaConBotonDeAyuda));
            ventanaConDobleBordeYBotonDeAyuda.Dibujar();
            Console.WriteLine();
            Console.Read();
        }
        //[Clase Component] ver diagrama de clases
        public interface IVentanaAbstracta
        {
            void Dibujar();
        }
        //[Clase ConcreteComponent] ver diagrama de clases, Clase que se desea decorar
        public class Ventana : IVentanaAbstracta
        {
            public void Dibujar() { Console.Write(" Ventana "); }
        }
        //[Clase Decorator] ver diagrama de clases
        public abstract class VentanaDecorator : IVentanaAbstracta
        {
            public VentanaDecorator(IVentanaAbstracta ventanaAbstracta) { _VentanaAbstracta = ventanaAbstracta; }
            protected IVentanaAbstracta _VentanaAbstracta;
            public abstract void Dibujar();
        }
        //[Clase ConcreteDecorator] ver diagrama de clases
        public class BordeDecorator : VentanaDecorator
        {
            public BordeDecorator(IVentanaAbstracta ventanaAbstracta) : base(ventanaAbstracta) { }
            public override void Dibujar() { Console.Write("|"); _VentanaAbstracta.Dibujar(); Console.Write("|"); }            
        }
        //[Clase ConcreteDecorator] ver diagrama de clases
        public class BotonDeAyudaDecorator : VentanaDecorator
        {
            public BotonDeAyudaDecorator(IVentanaAbstracta ventanaAbstracta) : base(ventanaAbstracta) { }
            public override void Dibujar() { _VentanaAbstracta.Dibujar(); Console.Write("[Boton de Ayuda]"); }            
        }
    }
}