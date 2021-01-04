using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using System.ComponentModel.Design;
using Renova.B64Converter.Activities.Design.Designers;
using Renova.B64Converter.Activities.Design.Properties;

namespace Renova.B64Converter.Activities.Design
{
    public class DesignerMetadata : IRegisterMetadata
    {
        public void Register()
        {
            var builder = new AttributeTableBuilder();
            builder.ValidateTable();

            var categoryAttribute = new CategoryAttribute($"{Resources.Category}");

            builder.AddCustomAttributes(typeof(PDF2Base64), categoryAttribute);
            builder.AddCustomAttributes(typeof(PDF2Base64), new DesignerAttribute(typeof(PDF2Base64Designer)));
            builder.AddCustomAttributes(typeof(PDF2Base64), new HelpKeywordAttribute(""));

            builder.AddCustomAttributes(typeof(Base64ToPDF), categoryAttribute);
            builder.AddCustomAttributes(typeof(Base64ToPDF), new DesignerAttribute(typeof(Base64ToPDFDesigner)));
            builder.AddCustomAttributes(typeof(Base64ToPDF), new HelpKeywordAttribute(""));


            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
