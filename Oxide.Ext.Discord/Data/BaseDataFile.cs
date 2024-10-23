
namespace Oxide.Ext.Discord.Data
{
    internal abstract class BaseDataFile<TData> where TData : BaseDataFile<TData>, new()
    {
        internal static TData Instance;
        internal DataFileInfo FileInfo;
        
        internal bool DataUpdated { get; private set; }

        internal virtual void OnDataLoaded(DataFileInfo info)
        {
            FileInfo = info;
        }
        
        internal void OnDataChanged()
        {
            DataUpdated = true;
        }

        internal void OnDataSaved()
        {
            DataUpdated = false;
        }
    }
}