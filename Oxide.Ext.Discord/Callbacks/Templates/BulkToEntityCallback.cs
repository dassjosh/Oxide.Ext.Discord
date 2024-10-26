using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.Callbacks
{
    internal class BulkToEntityCallback<TTemplate, TEntity> : BaseAsyncCallback 
        where TTemplate : class, IBulkTemplate<TEntity> 
        where TEntity : class
    {
        private TTemplate _template;
        private List<PlaceholderData> _placeholders;
        private IPendingPromise<List<TEntity>> _promise;

        public static void Start(TTemplate template, List<PlaceholderData> data, IPendingPromise<List<TEntity>> promise)
        {
            BulkToEntityCallback<TTemplate, TEntity> callback = DiscordPool.Internal.Get<BulkToEntityCallback<TTemplate, TEntity>>();
            callback.Init(template, data, promise);
            callback.Run();
        }

        private void Init(TTemplate template, List<PlaceholderData> data, IPendingPromise<List<TEntity>> promise)
        {
            _template = template;
            _placeholders = data;
            _promise = promise;
        }
        
        protected override ValueTask HandleCallback()
        {
            try
            {
                List<TEntity> results = new(_placeholders.Count);
                for (int index = 0; index < _placeholders.Count; index++)
                {
                    TEntity field = _template.ToEntity(_placeholders[index]);
                    if (field != null)
                    {
                        results.Add(field);
                    }
                }
                _promise.Resolve(results);
            }
            catch (Exception ex)
            {
                DiscordExtension.GlobalLogger.Exception($"{nameof(BulkToEntityCallback<TTemplate, TEntity>)}.{nameof(HandleCallback)} An error occured processing placeholders.", ex);
                _promise.Reject(ex);
            }

            return new ValueTask();
        }

        protected override string GetExceptionMessage()
        {
            return $"Template: {_template.GetType().GetRealTypeName()} Placeholders: {_placeholders?.Count} Promise: {_promise?.Id}";
        }

        protected override void EnterPool()
        {
            _template = null;
            _placeholders = null;
            _promise = null;
        }
    }
}