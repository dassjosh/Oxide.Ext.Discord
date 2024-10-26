using System.Threading.Tasks;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Libraries;

namespace Oxide.Ext.Discord.Callbacks
{
    internal class RegisterTemplateCallback<TTemplate> : BaseAsyncCallback where TTemplate : class
    {
        private BaseTemplateLibrary<TTemplate> _library;
        private TemplateId _id;
        private TTemplate _template;
        private TemplateVersion _version;
        private TemplateVersion _minVersion;
        private IPendingPromise<TTemplate> _promise;
        
        public static void Start(BaseTemplateLibrary<TTemplate> library, TemplateId id, TTemplate template, TemplateVersion version, TemplateVersion minVersion, IPendingPromise<TTemplate> promise)
        {
            RegisterTemplateCallback<TTemplate> register = DiscordPool.Internal.Get<RegisterTemplateCallback<TTemplate>>();
            register.Init(library, id, template, version, minVersion, promise);
            register.Run();
        }
        
        private void Init(BaseTemplateLibrary<TTemplate> library, TemplateId id, TTemplate template, TemplateVersion version, TemplateVersion minVersion, IPendingPromise<TTemplate> promise)
        {
            _library = library;
            _id = id;
            _template = template;
            _minVersion = minVersion;
            _version = version;
            _promise = promise;
        }

        protected override ValueTask HandleCallback()
        {
            _library.HandleRegisterTemplate(_id, _template, _version, _minVersion, _promise);
            return new ValueTask();
        }

        protected override string GetExceptionMessage()
        {
            return $"Template ID: {_id.ToString()} Type: {_library.GetType().GetRealTypeName()}";
        }

        protected override void EnterPool()
        {
            _library = null;
            _id = default;
            _template = null;
            _minVersion = default;
            _promise = null;
        }
    }
}