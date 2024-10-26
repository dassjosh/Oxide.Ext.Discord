using System.Collections.Generic;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Callbacks
{
    internal class BulkRegisterTemplateCallback<TTemplate> : BaseAsyncCallback where TTemplate : class
    {
        private BaseTemplateLibrary<TTemplate> _library;
        private TemplateId _id;
        private List<BulkTemplateRegistration<TTemplate>> _templates;
        private TemplateVersion _minVersion;
        private IPendingPromise _promise;
        
        public static void Start(BaseTemplateLibrary<TTemplate> library, TemplateId id, List<BulkTemplateRegistration<TTemplate>> templates, TemplateVersion minVersion, IPendingPromise promise)
        {
            BulkRegisterTemplateCallback<TTemplate> register = DiscordPool.Internal.Get<BulkRegisterTemplateCallback<TTemplate>>();
            register.Init(library, id, templates, minVersion, promise);
            register.Run();
        }
        
        private void Init(BaseTemplateLibrary<TTemplate> library, TemplateId id, List<BulkTemplateRegistration<TTemplate>> templates, TemplateVersion minVersion, IPendingPromise promise)
        {
            _library = library;
            _id = id;
            _templates = templates;
            _minVersion = minVersion;
            _promise = promise;
        }

        protected override ValueTask HandleCallback()
        {
            _library.HandleBulkRegisterTemplate(_id, _templates, _minVersion, _promise);
            return new ValueTask();
        }
        
        protected override string GetExceptionMessage()
        {
            return $"Template ID: {_id.ToString()}  Type: {_library.GetType().GetRealTypeName()}";
        }

        protected override void EnterPool()
        {
            _library = null;
            _id = default;
            _templates = null;
            _minVersion = default;
            _promise = null;
        }
    }
}