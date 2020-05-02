#include <iostream>

//[Clase Component] ver diagrama de clases
class IVentanaAbstracta
{
public:
    virtual void Dibujar() = 0;
};

//[Clase ConcreteComponent] ver diagrama de clases, Clase que se desea decorar
class Ventana : public IVentanaAbstracta
{
public:
    void Dibujar()
    {
        std::cout << " Ventana ";
    }
};

//[Clase Decorator] ver diagrama de clases
class VentanaDecorator : public IVentanaAbstracta
{
public:
    VentanaDecorator(IVentanaAbstracta *ventanaAbstracta)
    {
        _VentanaAbstracta = ventanaAbstracta;
    }

    virtual void Dibujar() = 0;

protected:
    IVentanaAbstracta *_VentanaAbstracta;
};

//[Clase ConcreteDecorator] ver diagrama de clases
class BordeDecorator : public VentanaDecorator
{
public:
    BordeDecorator(IVentanaAbstracta *ventanaAbstracta) : VentanaDecorator(ventanaAbstracta)
    {
    }

    virtual void Dibujar()
    {
        std::cout << "|";
        _VentanaAbstracta->Dibujar();
        std::cout << "|";
    }
};

//[Clase ConcreteDecorator] ver diagrama de clases
class BotonDeAyudaDecorator : public VentanaDecorator
{
public:
    BotonDeAyudaDecorator(IVentanaAbstracta *ventanaAbstracta) : VentanaDecorator(ventanaAbstracta)
    {
    }

    virtual void Dibujar()
    {
        _VentanaAbstracta->Dibujar();
        std::cout << "[Boton de Ayuda]";
    }
};

int main()
{
    BotonDeAyudaDecorator *ventanaConBotonDeAyuda = new BotonDeAyudaDecorator(new Ventana());
    ventanaConBotonDeAyuda->Dibujar();
    std::cout << std::endl;

    BordeDecorator *ventanaConBotonDeAyudaYBorde = new BordeDecorator(ventanaConBotonDeAyuda);
    ventanaConBotonDeAyudaYBorde->Dibujar();
    std::cout << std::endl;

    BordeDecorator *ventanaConBorde = new BordeDecorator(new Ventana());
    ventanaConBorde->Dibujar();
    std::cout << std::endl;

    BordeDecorator *ventanaConDobleBorde = new BordeDecorator(ventanaConBorde);
    ventanaConDobleBorde->Dibujar();
    std::cout << std::endl;

    delete ventanaConBotonDeAyuda;
    delete ventanaConBotonDeAyudaYBorde;
    delete ventanaConBorde;
    delete ventanaConDobleBorde;

    return 0;
}