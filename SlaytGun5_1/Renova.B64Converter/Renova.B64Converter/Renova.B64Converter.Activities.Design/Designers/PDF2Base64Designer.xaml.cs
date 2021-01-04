using Microsoft.Win32;
using System.Activities;

namespace Renova.B64Converter.Activities.Design.Designers
{
    /// <summary>
    /// Interaction logic for PDF2Base64Designer.xaml
    /// </summary>
    public partial class PDF2Base64Designer
    {
        public PDF2Base64Designer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Title = "Browser PDF Files";
            openFileDialog.DefaultExt = "pdf";
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.ShowDialog();
            string pdfFullPath = openFileDialog.FileName;

            ModelItem.Properties["FullPathToPDF"].SetValue(new InArgument<string>(pdfFullPath));
        }
    }
}
