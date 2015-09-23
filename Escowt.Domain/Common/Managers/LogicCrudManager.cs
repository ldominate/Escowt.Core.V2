using Escowt.Domain.Common.Interfaces;

namespace Escowt.Domain.Common.Managers
{
	public abstract class LogicCrudManager<TModel> : CrudManager<TModel>, ILogicCrudManager<TModel> where TModel : BaseDomainByLogicDeleteObject
	{
		private readonly IBaseCRUDLogicProvider<TModel> _provider;

		protected LogicCrudManager(IBaseCRUDLogicProvider<TModel> provider) : base(provider)
		{
			_provider = provider;
		}


		public bool LogicDelete(System.Guid modelGuid)
		{
			return _provider.LogicDelete(modelGuid);
		}

		public bool LogicRecover(System.Guid modelGuid)
		{
			return _provider.LogicRecover(modelGuid);
		}
	}
}