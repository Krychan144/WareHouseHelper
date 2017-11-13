using WareHouseHelper.BusinesLogic.Action.Base;

namespace WareHouseHelper.BusinesLogic.Configuration.Interfaces
{
    public interface IMigrationHelper : IAction
    {
        void Migrate();
    }
}