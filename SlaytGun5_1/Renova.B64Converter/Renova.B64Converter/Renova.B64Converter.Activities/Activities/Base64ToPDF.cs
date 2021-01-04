using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using Renova.B64Converter.Activities.Controllers;
using Renova.B64Converter.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;

namespace Renova.B64Converter.Activities
{
    [LocalizedDisplayName(nameof(Resources.Base64ToPDF_DisplayName))]
    [LocalizedDescription(nameof(Resources.Base64ToPDF_Description))]
    public class Base64ToPDF : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.Base64ToPDF_Base64Text_DisplayName))]
        [LocalizedDescription(nameof(Resources.Base64ToPDF_Base64Text_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> Base64Text { get; set; }

        [LocalizedDisplayName(nameof(Resources.Base64ToPDF_FullPathToExport_DisplayName))]
        [LocalizedDescription(nameof(Resources.Base64ToPDF_FullPathToExport_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> FullPathToExport { get; set; }

        #endregion


        #region Constructors

        public Base64ToPDF()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (Base64Text == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(Base64Text)));
            if (FullPathToExport == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(FullPathToExport)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var base64text = Base64Text.Get(context);
            var fullpathtoexport = FullPathToExport.Get(context);

            B64Controller b64Controller = new B64Controller();
            b64Controller.Base64ToPDF(base64text, fullpathtoexport);


            // Outputs
            return (ctx) => {
            };
        }

        #endregion
    }
}

