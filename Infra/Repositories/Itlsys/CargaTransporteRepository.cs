using Infra.Interfaces.Repository;

namespace Infra.Repositories.ItlSys
{
    //CLASSE TESTE PARA SUBIR PRIMEIRA VERSÃO DO WORKER FAVOR EXCLUIR
    public class CargaTransporteRepository
    {
        private readonly IDapperItlSys _dapperItlSys;
        public CargaTransporteRepository(IDapperItlSys dapperItlSys)
        {
            _dapperItlSys = dapperItlSys;
        }

        public void InserirLogTeste(string idMotorista)
        {
            string query = $@"insert into CargaTransporteLog (IdFilial, IdUsuario, DataOcorrencia, TipoLog, Justificativa, TipoOperadorLog, IdCargaTransporte)
            values(53, 16985, GETDATE(), 9, 'teste worker - {idMotorista}', 0, 82541)";

            _dapperItlSys.InsertItlsys(query, null);
        }
    }
}
