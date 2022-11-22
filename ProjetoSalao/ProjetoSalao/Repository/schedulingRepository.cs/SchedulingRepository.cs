using System;
using Microsoft.EntityFrameworkCore;
using ProjetoSalao.Data;
using ProjetoSalao.Models;
using ProjetoSalao.Repository.SchedulingRepository;

namespace ProjetoSalao.Repository.SchedulingRepository
{
	public class SchedulingRepository : ISchedulingRepository
    {

        private readonly BancoContext _bancoContext;

        public SchedulingRepository(BancoContext bancoContext)
		{
            _bancoContext = bancoContext;
		}

        public List<Scheduling> listSchedulingDay(DateTime date)
        {
            
            return _bancoContext.Scheduling
                .Include(a => a.Client)
                .Include(a => a.Service)
                .Where(a => a.Date == date.Date).ToList();
        }

        public List<Scheduling> ListAll()
        {
            return _bancoContext.Scheduling
                .Include(a => a.Client)
                .Include(a => a.Service).ToList();
        }


        public Scheduling Save(Scheduling scheduling)
        {
            _bancoContext.Scheduling.Add(scheduling);
            _bancoContext.SaveChanges();
            return scheduling;
        }

        public Scheduling FindById(int id)
        {
            return _bancoContext.Scheduling.Include(a => a.Client)
            .Include(a => a.Service)
            .FirstOrDefault(client => client.Id == id);
        }

        public void Remove(Scheduling scheduling)
        {
            _bancoContext.Scheduling.Remove(scheduling);
            _bancoContext.SaveChanges();
        }

        public bool findByDateAndHour(DateTime date, string hour)
        {
            var existScheduling = _bancoContext.Scheduling.FirstOrDefault(s => s.Date == date && s.Hour == hour);
            return existScheduling != null;
        }

        public Scheduling Edit(Scheduling scheduling)
        {
            _bancoContext.Scheduling.Update(scheduling);
            _bancoContext.SaveChanges();
            return scheduling;
        }

        public bool FindByDateAndDifferentId(DateTime date, string hour, int id)
        {
            var existisCpf = _bancoContext.Scheduling.FirstOrDefault(scheduling => scheduling.Date == date && scheduling.Hour == hour && scheduling.Id != id);
            return existisCpf != null;
        }
    }
}

