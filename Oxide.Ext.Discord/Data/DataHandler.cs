using System;
using System.IO;
using Oxide.Core;
using Oxide.Ext.Discord.Data.Ip;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Types;
using ProtoBuf;

namespace Oxide.Ext.Discord.Data
{
    internal sealed class DataHandler : Singleton<DataHandler>
    {
        internal static readonly string RootPath = Path.Combine(Interface.Oxide.DataDirectory, "DiscordExtension");

        private DataHandler() { }

        public void LoadAll()
        {
            if (!Directory.Exists(RootPath))
            {
                Directory.CreateDirectory(RootPath);
            }
            
            Load<DiscordUserData>(new DataFileInfo("discord.users.data", 2));
            Load<DiscordIpData>(new DataFileInfo("discord.ip.data", 1));
        }

        public void OnServerSave() => SaveAll(false);

        public void Shutdown() => SaveAll(true);

        private void SaveAll(bool force)
        {
            Save(DiscordUserData.Instance, force);
            Save(DiscordIpData.Instance, force);
        }
        
        public void Load<TData>(DataFileInfo info) where TData : BaseDataFile<TData>, new()
        {
            int index = 0;
            while (true)
            {
                try
                {
                    if (index >= info.NumBackups)
                    {
                        break;
                    }
                    
                    string path = info.GetPathForIndex(index);
                    if (!File.Exists(path))
                    {
                        continue;
                    }

                    using FileStream file = File.OpenRead(path);
                    TData data = Serializer.Deserialize<TData>(file);
                    if (data != null)
                    {
                        BaseDataFile<TData>.Instance = data;
                        data.OnDataLoaded(info);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    DiscordExtension.GlobalLogger.Exception("An error occured loading the {0} Data File of type {1}", info.FilePath, typeof(TData).FullName, ex);
                }
                finally
                {
                    index++;
                }
            }

            TData newData = new();
            newData.OnDataLoaded(info);
            BaseDataFile<TData>.Instance = newData;
        }
        
        public void Save<TData>(TData data, bool force) where TData : BaseDataFile<TData>, new()
        {
            if (!data.DataUpdated && !force)
            {
                return;
            }
            
            DataFileInfo info = data.FileInfo;

            try
            {
                int numBackups = info.NumBackups;
                string path = info.GetPathForIndex(numBackups);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                for (int i = numBackups - 1; i >= 0; i--)
                {
                    path = info.GetPathForIndex(i);
                    if (File.Exists(path))
                    {
                        File.Move(path, info.GetPathForIndex(i + 1));
                    }
                }

                path = info.GetPathForIndex(0);
                FileMode saveMode = File.Exists(path) ? FileMode.Truncate : FileMode.Create;

                using (FileStream file = File.Open(path, saveMode))
                {
                    Serializer.Serialize(file, BaseDataFile<TData>.Instance);
                }
                    
                data.OnDataSaved();
            }
            catch (Exception ex)
            {
                DiscordExtension.GlobalLogger.Exception("An error occured saving the data file. {0}", typeof(TData).GetRealTypeName(), ex);
            }
        }
    }
}