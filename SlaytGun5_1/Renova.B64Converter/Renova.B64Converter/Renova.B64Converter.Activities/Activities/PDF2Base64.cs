using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using Renova.B64Converter.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using Renova.B64Converter.Activities.Controllers;

namespace Renova.B64Converter.Activities
{
    [LocalizedDisplayName(nameof(Resources.PDF2Base64_DisplayName))]
    [LocalizedDescription(nameof(Resources.PDF2Base64_Description))]
    public class PDF2Base64 : ContinuableAsyncCodeActivity
    {
        #region Properties

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.PDF2Base64_FullPathToPDF_DisplayName))]
        [LocalizedDescription(nameof(Resources.PDF2Base64_FullPathToPDF_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> FullPathToPDF { get; set; }

        [LocalizedDisplayName(nameof(Resources.PDF2Base64_Base64Text_DisplayName))]
        [LocalizedDescription(nameof(Resources.PDF2Base64_Base64Text_Description))]
        [LocalizedCategory(nameof(Resources.Output_Category))]
        public OutArgument<string> Base64Text { get; set; }

        #endregion


        #region Constructors

        public PDF2Base64()
        {
        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            if (FullPathToPDF == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(FullPathToPDF)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<AsyncCodeActivityContext>> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken)
        {
            // Inputs
            var fullpathtopdf = FullPathToPDF.Get(context);

            B64Controller b64Controller = new B64Controller();
            string base64Text=b64Controller.PDFToBase64(fullpathtopdf);

            // Outputs
            return (ctx) => {
                Base64Text.Set(ctx, base64Text);
            };
        }

        #endregion
    }
}

