using FARMACIA.Models;
using Microsoft.Data.SqlClient;
using Dapper;


namespace FARMACIA.Servicios
{
    public class RepositorioFarmacia : IRepositorioFarmacia
    {
        private readonly string connectionString;

        public RepositorioFarmacia(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task crear(MedicamentoViewModel medicamentoViewModel)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>("sp_insertar_medicamento",
                new
                {
                    nombre_medicamento = medicamentoViewModel.GsNombreMedicamento,
                    precio_medicamento = medicamentoViewModel.GsPrecioMedicamento,
                    descripcion_medicamento = medicamentoViewModel.GsDescripcionMedicamento

                },
                commandType: System.Data.CommandType.StoredProcedure);

            medicamentoViewModel.GsId = id;
        }

        public async Task<IEnumerable<MedicamentoViewModel>> obtener(){
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<MedicamentoViewModel>("sp_mostrar_medicamentos",
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<MedicamentoViewModel> obtenerPorId(int id)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<MedicamentoViewModel>("sp_obtener_medicamento",
                new
                {
                   id = id
                },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task actualizar(MedicamentoViewModel medicamentoViewModel)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("sp_actualizar_medicamento",
                new 
                {
                    id = medicamentoViewModel.GsId,
                    nombre_medicamento = medicamentoViewModel.GsNombreMedicamento,
                    precio_medicamento = medicamentoViewModel.GsPrecioMedicamento,
                    descripcion_medicamento = medicamentoViewModel.GsDescripcionMedicamento
                },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task borrar(int idMedicamento)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("sp_eliminar_medicamento",
                new
                {
                    id = idMedicamento
                },
                commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
