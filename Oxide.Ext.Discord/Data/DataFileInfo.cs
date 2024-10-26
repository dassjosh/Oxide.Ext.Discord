using System.IO;

namespace Oxide.Ext.Discord.Data
{
    internal class DataFileInfo
    {
        public readonly string FilePath;
        public readonly int NumBackups;
        
        private readonly string[] _backupPaths;

        public DataFileInfo(string fileName, int numBackups)
        {
            FilePath = Path.Combine(DataHandler.RootPath, fileName);
            NumBackups = numBackups;
            _backupPaths = new string[numBackups + 1];
        }

        public string GetPathForIndex(int index)
        {
            if (index == 0)
            {
                return FilePath;
            }

            string backup = _backupPaths[index];
            if (backup != null)
            {
                return backup;
            }

            backup = $"{FilePath}.{index.ToString()}";
            _backupPaths[index] = backup;

            return backup;
        }
    }
}