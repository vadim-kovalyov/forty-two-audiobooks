using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using FortyTwoAudiobooks.Core.Config;
using FortyTwoAudiobooks.UI.Resources;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Phone.Shell;
using Microsoft.Practices.ServiceLocation;

namespace FortyTwoAudiobooks.UI.App_Start
{
    public class AppConfig
    {
        public static void Configure(Application app)
        {
            DispatcherHelper.Initialize();

            ConfigureDebugger(app);
            ConfigureLanguage(app);
            ConfigureContainer(app);
            ConfigureNavigation(app);

#if DEBUG
            Seeds.Configure();
#endif
        }

        private static void ConfigureLanguage(Application app)
        {
            try
            {
                // Set the font to match the display language defined by the
                // ResourceLanguage resource string for each supported language.
                //
                // Fall back to the font of the neutral language if the Display
                // language of the phone is not supported.
                //
                // If a compiler error is hit then ResourceLanguage is missing from
                // the resource file.
                App.RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);

                // Set the FlowDirection of all elements under the root frame based
                // on the ResourceFlowDirection resource string for each
                // supported language.
                //
                // If a compiler error is hit then ResourceFlowDirection is missing from
                // the resource file.
                FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
                App.RootFrame.FlowDirection = flow;
            }
            catch
            {
                // If an exception is caught here it is most likely due to either
                // ResourceLangauge not being correctly set to a supported language
                // code or ResourceFlowDirection is set to a value other than LeftToRight
                // or RightToLeft.

                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw;
            }
        }

        private static void ConfigureDebugger(Application app)
        {
#if DEBUG
            // Show graphics profiling information while debugging.
            if (Debugger.IsAttached)
            {
                // Display the current frame rate counters
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode,
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Prevent the screen from turning off while under the debugger by disabling
                // the application's idle detection.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
#endif
            }
        }

        private static void ConfigureContainer(Application app)
        {
            ContainerConfig.Configure(app);
        }

        private static void ConfigureNavigation(Application app)
        {
            NavigationService service = (NavigationService)ServiceLocator.Current.GetInstance<INavigationService>();
            NavigationConfig.Configure(service);
        }
    }
}
