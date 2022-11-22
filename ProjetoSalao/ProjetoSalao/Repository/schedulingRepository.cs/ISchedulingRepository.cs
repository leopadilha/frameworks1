using System;
using ProjetoSalao.Models;

namespace ProjetoSalao.Repository.SchedulingRepository
{
	public interface ISchedulingRepository
	{
		List<Scheduling> listSchedulingDay(DateTime data);

		List<Scheduling> ListAll();

		Scheduling Save(Scheduling scheduling);

		Scheduling FindById(int id);

		void Remove(Scheduling scheduling);

		bool findByDateAndHour(DateTime date,string hour);

		bool FindByDateAndDifferentId(DateTime date, string hour, int id);

		Scheduling Edit(Scheduling scheduling);

		
	}
}

