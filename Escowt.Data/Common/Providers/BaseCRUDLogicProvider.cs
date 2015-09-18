using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Escowt.Domain.Common;
using Escowt.Domain.Common.Interfaces;

namespace Escowt.Data.Common.Providers
{
	public abstract class BaseCRUDLogicProvider<TModel> : BaseCRUDProvider<TModel>, IBaseCRUDLogicProvider<TModel>
		where TModel : BaseDomainByLogicDeleteObject
	{
		protected BaseCRUDLogicProvider(EscowtDB contexDB) : base(contexDB)
		{
			
		}

		public bool LogicDelete(Guid modelGuid)
		{
			return LogicRd(modelGuid, true);
		}

		public bool LogicRecover(Guid modelGuid)
		{
			return LogicRd(modelGuid, false);
		}

		bool LogicRd(Guid modelGuid, bool logicDelete)
		{
			bool result;

			using (var transaction = ContextDB.Database.BeginTransaction())
			{
				ContextDB.Database.Log = (s => Debug.WriteLine(s));

				var model = ContextDB.Set<TModel>().FirstOrDefault(m => m.Guid == modelGuid);

				if (model == null)
				{
					return false;
				}
				model.IsDeleted = logicDelete;

				ContextDB.Entry(model).State = EntityState.Modified;

				result = ContextDB.SaveChanges() > 0;

				transaction.Commit();
			}
			return result;
		}
	}
}
