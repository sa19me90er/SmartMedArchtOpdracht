namespace SmartMedArchtOpdracht.Buisiness_Logica.Servics.implementations

{
    public class GreaterThanZero
    {
        public static bool ValidateGerateThanZero(int quantity)
        {
            if (quantity < 1) { return false; }
            else return true;
        }
    }
}
