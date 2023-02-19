using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Final_Web_3.Service.Dto;
using Projeto_Final_WEb_3;

namespace Projeto_Final_Web_3.Service.Interface
{
    public interface IEventReservationService
    {
        public Task<bool> Inserir(EventReservationDto eventReservation);
        public Task<bool> EditarQuantidade(int numero, long idReservation);
        public Task<List<EventReservationDto>> ConsultaPersonTitle(string nome, string tituloEvento);

        public Task<bool> DeletarReserva(long idReservation);

    }
}
