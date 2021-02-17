using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using Cysharp.Threading.Tasks;
using OpenMod.Unturned.Plugins;

[assembly: PluginMetadata("$safeprojectname$",
    DisplayName = "$displayname$"$if$ ($author$ != ""),
    Author = "$author$")]
$else$]
$endif$
namespace $safeprojectname$
{
public class $safeprojectname$Plugin : OpenModUnturnedPlugin
    {
        private readonly IStringLocalizer m_StringLocalizer;

        public $safeprojectname$Plugin(
            IStringLocalizer stringLocalizer,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_StringLocalizer = stringLocalizer;
        }

        protected override async UniTask OnLoadAsync()
        {
			// await UniTask.SwitchToMainThread(); uncomment if you have to access Unturned or UnityEngine APIs
			
            Logger.LogInformation("Hello World!");
			
			// await UniTask.SwitchToThreadPool(); // you can switch back to a different thread
        }

        protected override async UniTask OnUnloadAsync()
        {
            // await UniTask.SwitchToMainThread(); uncomment if you have to access Unturned or UnityEngine APIs
			
            Logger.LogInformation(m_StringLocalizer["plugin_events:plugin_stop"]);
        }
    }
}
