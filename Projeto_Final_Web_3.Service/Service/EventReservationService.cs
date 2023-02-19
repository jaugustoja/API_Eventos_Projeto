using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projeto_Final_Web_3.Service.Interface;
using Projeto_Final_WEb_3;
using Projeto_Final_Web_3.Service.Dto;

namespace Projeto_Final_Web_3.Service.Service
{
    public class EventReservationService : IEventReservationService
    {
        private IEventReservationRepository _repository;
        private IMapper _mapper1;
        public EventReservationService(IEventReservationRepository eventoRepository, IMapper mapper1)
        {
            _repository = eventoRepository;
            _mapper1 = mapper1;
        }
        public async Task<bool> Inserir(EventReservationDto eventReservation)
        {
            EventReservationEntity entity = _mapper1.Map<EventReservationEntity>(eventReservation);
            return await _repository.InserirReserva(entity);
            
        }
        public async Task<bool> EditarQuantidade(int numero, long idReservation)
        {

            return await _repository.EditarQuantidadeReserva(numero, idReservation);
        }
        public async Task<List<EventReservationDto>> ConsultaPersonTitle(string nome, string tituloEvento)
        {
            List<EventReservationEntity> entity = await _repository.ConsultaPersonTitle(nome, tituloEvento);
            if (entity == null)
            {
                return null;
            }

            List<EventReservationDto> lista_dto = _mapper1.Map<List<EventReservationDto>>(entity);
            return lista_dto;
            
        }
        public async Task<bool> DeletarReserva(long idReservation)
        {
            return await _repository.Deletar(idReservation);
        }

    }
}
