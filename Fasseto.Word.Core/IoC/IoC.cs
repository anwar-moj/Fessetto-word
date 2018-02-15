using Ninject;
using System;


namespace Fasseto.Word.Core
{

    /// <summary>
    /// The IoC container for our application
    /// </summary>
    public static class IoC
    {
        #region Public Properties
        /// <summary>
        /// The Kernal for our IoC container
        /// </summary>
        public static IKernel kernel { get; private set; } = new StandardKernel();

        #endregion

        #region Construction

        /// <summary>
        /// Sets up the IoC container, Bind all Information
        /// NOTE: Must called as soon as the application Starts up to ensure
        ///       all services can be found
        /// </summary>
        public static void Setup()
        {
            //Bind all required view models
            BindViewModels();
        }

        /// <summary>
        /// Bind all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            //Bind to a single instance of application view model 
            kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }
        #endregion

        /// <summary>
        /// Get a services form The IoC of the specified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return kernel.Get<T>();
        }
    }
}
