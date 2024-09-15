using FARMACIA.Models;

namespace FARMACIA.Servicios
{
    public interface IRepositorioFarmacia
    {
        Task crear(MedicamentoViewModel medicamentoViewModel);

        Task<IEnumerable<MedicamentoViewModel>> obtener();
        Task<MedicamentoViewModel> obtenerPorId(int id);

        Task actualizar(MedicamentoViewModel medicamentoViewModel);
        Task borrar(int idMedicamento);
    }
}
