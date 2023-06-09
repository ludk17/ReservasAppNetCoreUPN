namespace ReservasApp.Logica;

public interface IPersonaLog
{
    bool Validate();
}
public class PersonaLog
{
    private int Edad;
    public static PersonaLog instancia = new PersonaLog();


    public bool Validate()
    {
        throw new Exception();
        return true;
    }
    
    public void SetEdad(int edad)
    {
        Edad = edad;
    }

    public int GetEdad()
    {
        return Edad;
    }
    
    
}