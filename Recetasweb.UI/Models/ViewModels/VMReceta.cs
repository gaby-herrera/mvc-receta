namespace Recetasweb.UI.Models.ViewModels
{
    public class VMReceta
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Ingredientes { get; set; }

        public string? Instrucciones { get; set; }

        public int? TiempoDeCoccion { get; set; }
    }
}
