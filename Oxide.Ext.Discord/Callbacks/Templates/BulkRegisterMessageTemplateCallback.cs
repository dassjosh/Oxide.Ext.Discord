using System.Collections.Generic;
using System.Threading.Tasks;
using Oxide.Ext.Discord.Libraries.Templates;
using Oxide.Ext.Discord.Pooling;
using Oxide.Ext.Discord.Promise;

namespace Oxide.Ext.Discord.Callbacks.Templates
{
    internal class BulkRegisterTemplateCallback<T> : BaseAsyncCallback where T : BaseTemplate
    {
        private BaseTemplateLibrary _library;
        private TemplateId _id;
        private List<BulkTemplateRegistration<T>> _templates;
        private TemplateType _type;
        private TemplateVersion _minVersion;
        private IDiscordPromise _promise;
        
        public static void Start(BaseTemplateLibrary library, TemplateId id, List<BulkTemplateRegistration<T>> templates, TemplateType type, TemplateVersion minVersion, IDiscordPromise promise)
        {
            BulkRegisterTemplateCallback<T> register = DiscordPool.Get<BulkRegisterTemplateCallback<T>>();
            register.Init(library, id, templates, type, minVersion, promise);
            register.Run();
        }
        
        private void Init(BaseTemplateLibrary library, TemplateId id, List<BulkTemplateRegistration<T>> templates, TemplateType type, TemplateVersion minVersion, IDiscordPromise promise)
        {
            _library = library;
            _id = id;
            _templates = templates;
            _type = type;
            _minVersion = minVersion;
            _promise = promise;
        }

        protected override  Task HandleCallback()
        {
            return _library.HandleBulkRegisterTemplate(_id, _templates, _type, _minVersion, _promise);
        }

        protected override void EnterPool()
        {
            _library = null;
            _id = default(TemplateId);
            _templates = null;
            _type = default(TemplateType);
            _minVersion = default(TemplateVersion);
            _promise = null;
        }
    }
}