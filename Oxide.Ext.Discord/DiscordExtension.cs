using System;
using System.Collections.Generic;
using uMod.Common;
using uMod.Ext.Discord.Logging;
using uMod.Extensions;
using ILogger = uMod.Ext.Discord.Logging.ILogger;
using LogLevel = uMod.Ext.Discord.Logging.LogLevel;

namespace uMod.Ext.Discord
{
    public class DiscordExtension : Extension
    {
        private static readonly VersionNumber ExtensionVersion = new VersionNumber(1, 0, 8);
        public const string TestVersion = ".uMod.Alpha.1";
        
        private readonly ILogger _logger;
        
        public DiscordExtension()
        {
            _logger = new Logger(LogLevel.Debug);
        }

        ////public override bool SupportsReloading => true;

        public override string Title => "Discord";
        public override string Author => "PsychoTea & DylanSMR & Tricky";

        public override VersionNumber Version => ExtensionVersion;

        public static string GetExtensionVersion => ExtensionVersion + TestVersion;

        public override string[] DefaultReferences => new[]
        {
            "uMod.Ext.Discord", "websocket-sharp"
        };


        public override void OnModLoad()
        {
            _logger.Info($"Using Discord Extension Version: {GetExtensionVersion}");
            AppDomain.CurrentDomain.UnhandledException += (sender, exception) =>
            {
                _logger.Exception("An exception was thrown!", exception.ExceptionObject as Exception);
            };
        }

        public override void OnShutdown()
        {
            // new List prevents against InvalidOperationException
            foreach (var client in new List<DiscordClient>(Discord.Clients))
            {
                Discord.CloseClient(client);
            }

            _logger.Info("Disconnected all clients - server shutdown.");
        }
    }
}
