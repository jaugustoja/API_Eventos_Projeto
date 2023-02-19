using Projeto_Final_WEb_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Final_Web_3.Service.Dto;

namespace Projeto_Final_Web_3.Service.Interface
{
    public interface ICityEventService
    {
        public Task<bool> Inserir(CityEventDto cityEvent);
        public Task<List<CityEventDto>> Consultar(string nome);
        public Task<List<CityEventDto>> ConsultarLocalData(string local, DateTime data);
        public Task<List<CityEventDto>> ConsultaPrecoData(decimal minPrice, decimal maxPrice, DateTime data);
        public Task<bool> AtualizarEvento(CityEventDto cityevent, int id);
        public Task<bool> DeletarEvento(int id);
    }
}
