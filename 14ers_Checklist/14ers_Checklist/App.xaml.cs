using System;
using System.Diagnostics;
using System.Resources;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using _14ers_Checklist.Resources;
using _14ers_Checklist.ViewModels;
using _14ers_Checklist.Models;
using System.Linq;


namespace _14ers_Checklist
{
    public partial class App : Application
    {
        private static MainViewModel viewModel = null;
        public static DataBaseContext DB; 

        /// <summary>
        /// A static ViewModel used by the views to bind against.
        /// </summary>
        /// <returns>The MainViewModel object.</returns>

        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public static PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions.
            UnhandledException += Application_UnhandledException;

            // Standard XAML initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // Language display initialization
            InitializeLanguage();

            // Show graphics profiling information while debugging.
            if (Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode,
                // which shows areas of a page that are handed off GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Prevent the screen from turning off while under the debugger by disabling
                // the application's idle detection.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

            // Specify the local database connection string.
            string DBConnectionString = "Data Source=isostore:/Mountains.sdf";

            // Create the database if it does not exist.
            using (DataBaseContext db = new DataBaseContext(DBConnectionString))
            {
                if (db.DatabaseExists() == false)
                {
                    // Create the local database.
                    db.CreateDatabase();
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Elbert" , Height = 14433, Range="Sawatch", Check = false});
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Massive", Height = 14421, Range = "Sawatch", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Harvard", Height = 14420, Range = "Sawatch", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Blanca Peak", Height = 14345, Range = "Sangre de Cristo", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "La Plata Peak", Height = 14336, Range = "Sawatch", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Uncompahgre Peak", Height = 14309, Range = "San Juan Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Crestone Peak", Height = 14294, Range = "Sangre de Cristo", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Lincoln", Height = 14286, Range = "Mosquito Range", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Grays Peak", Height = 14270, Range = "Front Range", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Antero", Height = 14269, Range = "Sawatch", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Torreys Peak", Height = 14267, Range = "Front Range", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Castle Peak", Height = 14265, Range = "Elk Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Quandary Peak", Height = 14265, Range = "Tenmile Range", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Evans", Height = 14264, Range = "Front Range", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Longs Peak", Height = 14255, Range = "Front Range", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Wilson", Height = 14246, Range = "San Juan Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Cameron", Height = 14238, Range = "Mosquito Range", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Shavano", Height = 14229, Range = "Sawatch", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Belford", Height = 14197, Range = "Sawatch", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Crestone Needle", Height = 14197, Range = "Sangre de Cristo", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Princeton", Height = 14197, Range = "Sawatch", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Yale", Height = 14196, Range = "Sawatch", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Bross", Height = 14172, Range = "Mosquito Range", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Kit Carson Peak", Height = 14165, Range = "Sangre de Cristo", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "El Diente Peak", Height = 14159, Range = "San Juan Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Maroon Peak", Height = 14156, Range = "Elk Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Tabeguache Peak", Height = 14155, Range = "Sawatch", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Oxford", Height = 14153, Range = "Sawatch", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Sneffels", Height = 14148, Range = "San Juan Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Democrat", Height = 14150, Range = "Mosquito Range", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Capitol Peak", Height = 14148, Range = "Elk Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Pikes Peak", Height = 14110, Range = "Front Range", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Snowmass Mountain", Height = 14092, Range = "nud", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Eolus", Height = 14083, Range = "San Juan Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Windom Peak", Height = 14082, Range = "San Juan Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Challenger Peak", Height = 14081, Range = "Sangre de Cristo", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Columbia", Height = 14073, Range = "Sawatch", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Missouri Mountain", Height = 14067, Range = "Sawatch", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Humboldt Peak", Height = 14064, Range = "Sangre de Cristo", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Bierstadt", Height = 14060, Range = "Front Range", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Conundrum Peak", Height = 14060, Range = "Elk Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Sunlight Peak", Height = 14059, Range = "San Juan Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Handies Peak", Height = 14048, Range = "San Juan Mountains ", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Culebra Peak", Height = 14047, Range = "Sangre de Cristo", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Ellingwood Point", Height = 14042, Range = "Sangre de Cristo", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Lindsey", Height = 14042, Range = "Sangre de Cristo", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "North Eolus", Height = 14039, Range = "San Juan Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Little Bear Peak", Height = 14037, Range = "Sangre de Cristo", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. Sherman", Height = 14036, Range = "Mosquito Range", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Redcloud Peak", Height = 14034, Range = "San Juan Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Pyramid Peak", Height = 14018, Range = "Elk Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Wilson Peak", Height = 14017, Range = "San Juan Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Wetterhorn Peak", Height = 14015, Range = "San Juan Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "San Luis Peak", Height = 14014, Range = "San Juan Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "North Maroon Peak", Height = 14014, Range = "Elk Mountains", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Mt. of the Holy Cross", Height = 14005, Range = "Sawatch", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Huron Peak", Height = 14003, Range = "Sawatch", Check = false });
                    db.Mountains.InsertOnSubmit(new DataBaseContext.Mountain { Name = "Sunshine Peak", Height = 14001, Range = "San Juan Mountains", Check = false });
                    //create an ascent for each mountain 
                    /*
                    var mountains = from DataBaseContext.Mountain mountain in db.Mountains select mountain;
                    foreach (DataBaseContext.Mountain mountain in mountains)
                    {
                        db.Ascents.InsertOnSubmit(new DataBaseContext.Ascent { _linkedMountainID = mountain.MountainID });
                    }
                    // Save categories to the database.
                     */
                    db.SubmitChanges();
                }


            }
            DB = new DataBaseContext(DBConnectionString);


        }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            // Ensure that application state is restored appropriately
           
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
            // Ensure that required application state is persisted here.
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Handle reset requests for clearing the backstack
            RootFrame.Navigated += CheckForResetNavigation;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        private void CheckForResetNavigation(object sender, NavigationEventArgs e)
        {
            // If the app has received a 'reset' navigation, then we need to check
            // on the next navigation to see if the page stack should be reset
            if (e.NavigationMode == NavigationMode.Reset)
                RootFrame.Navigated += ClearBackStackAfterReset;
        }

        private void ClearBackStackAfterReset(object sender, NavigationEventArgs e)
        {
            // Unregister the event so it doesn't get called again
            RootFrame.Navigated -= ClearBackStackAfterReset;

            // Only clear the stack for 'new' (forward) and 'refresh' navigations
            if (e.NavigationMode != NavigationMode.New && e.NavigationMode != NavigationMode.Refresh)
                return;

            // For UI consistency, clear the entire page stack
            while (RootFrame.RemoveBackEntry() != null)
            {
                ; // do nothing
            }
        }

        #endregion

        // Initialize the app's font and flow direction as defined in its localized resource strings.
        //
        // To ensure that the font of your application is aligned with its supported languages and that the
        // FlowDirection for each of those languages follows its traditional direction, ResourceLanguage
        // and ResourceFlowDirection should be initialized in each resx file to match these values with that
        // file's culture. For example:
        //
        // AppResources.es-ES.resx
        //    ResourceLanguage's value should be "es-ES"
        //    ResourceFlowDirection's value should be "LeftToRight"
        //
        // AppResources.ar-SA.resx
        //     ResourceLanguage's value should be "ar-SA"
        //     ResourceFlowDirection's value should be "RightToLeft"
        //
        // For more info on localizing Windows Phone apps see http://go.microsoft.com/fwlink/?LinkId=262072.
        //
        private void InitializeLanguage()
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
                RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);

                // Set the FlowDirection of all elements under the root frame based
                // on the ResourceFlowDirection resource string for each
                // supported language.
                //
                // If a compiler error is hit then ResourceFlowDirection is missing from
                // the resource file.
                FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
                RootFrame.FlowDirection = flow;
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
    }
}