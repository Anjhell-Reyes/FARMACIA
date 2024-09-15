using System.ComponentModel.DataAnnotations;

namespace FARMACIA.Models
{
    public class MedicamentoViewModel
    {
        public int GsId { get; set; }

        [Required(ErrorMessage = "El campo 'Nombre de medicamento' es requerido")]
        [StringLength(maximumLength: 35, MinimumLength = 4, ErrorMessage = "La longitud del campo '{0}' debe estar entre {2} y {1} caracteres")]
        public string GsNombreMedicamento { get; set; }

        [Required(ErrorMessage = "El campo 'Precio de medicamento' es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El campo 'Precio de medicamento' debe ser mayor que 0")]
        public decimal GsPrecioMedicamento { get; set; }

        [Required(ErrorMessage = "El campo 'Descripción' es requerido")]
        [StringLength(maximumLength: 1000, ErrorMessage = "La longitud del campo 'Descripción' no puede exceder los {1} caracteres")]
        public string GsDescripcionMedicamento { get; set; }
    }
}
