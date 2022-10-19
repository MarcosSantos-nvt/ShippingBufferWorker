using Infra.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.wamasHavan
{
    //CLASSE TESTE PARA SUBIR PRIMEIRA VERSÃO DO WORKER FAVOR EXCLUIR
    public class AcxRevisionRepository
    {
        private readonly IDapperHavanWamas _dapperHavanWamas;
        public AcxRevisionRepository(IDapperHavanWamas dapperHavanWamas)
        {
            _dapperHavanWamas = dapperHavanWamas;
        }

        public void InserirLogTeste(string idMotorista)
        {
            string query = $@"insert into AcxRevision (id, created, createdBy) values (1, GETDATE(), 'teste worker - {idMotorista}')";

            _dapperHavanWamas.InsertHavanWamas(query, null);
        }
    }
}
