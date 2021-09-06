using CatalystCodeGenerator.Enums;
using CatalystCodeGenerator.Interfaces;
using CatalystCodeGenerator.Models;
using CatalystCodeGenerator.Services;
using CatalystCodeGenerator.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatalystCodeGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*Backlogs
         * 1. WPF UI Validations => FYI: component path textbox is optional; name textbox is required; component combobox required; etc.
         * 2. UI Integrations in the logic
         * 3. Deployment -> WPF Visual Studio Extensions  
         * 4. Update and Delete in DataGrid for Table Schematic
         * 5. WPF UI Enhancement
         * 6. Data Grid Integration for --model => use loops here to get this format {id:number=0; name:string=''; isActive:boolean=false;}
         */

        /* Key Reminders
         * 1. --path is a component path automatically point in the src folder
         * If the angular project is empty. don't include --path in CLI
         * If the angular project is metronic. check the hierarchy of the files if the components is under pages folder include --path=/pages in the  CLI
         * 2. Expected CLI format in 'table' schematic 
              Example: ng g @blastasia/catalyst:table --name=Table --path=/pages --model="{id:number=0; name:string=''; isActive:boolean=false;}"
         */

        private List<object> models = new List<object>();
        private IModelService _modelService;
        public MainWindow()
        {
            InitializeComponent();
            initializeDependencies();
            initializeCmbComponents();
            initializeCmbDataTypes();    
        }

        #region InitializeComponent
        private void initializeDependencies()
        {
            _modelService = new ModelService();
            // Put here the services, etc.
        }
     
        private void initializeCmbDataTypes()
        {
            var dataTypes = Extensions.LoadDataTypes();
            cmbDataTypes.ItemsSource = dataTypes;
        }
        private void initializeCmbComponents()
        {
            var components = Extensions.LoadComponents();
            cmbComponents.ItemsSource = components;
            cmbComponents.SelectedValue = components[0];
        }
      
        #endregion
        private void btnGenerateComponents_Click(object sender, RoutedEventArgs e)
        {
            string component = cmbComponents.SelectedValue.ToString();
            string angularCLI = string.Empty;
           
            if(component == "table")
            {
                string model = "{id:string=''; age:number=0; isActive:boolean=false;}";  // Example Only
                angularCLI = string.Format("ng g @blastasia/catalyst:{0} --name={1} --path=/{2} --model={3}", component, txtName.Text, txtComponentPath.Text,model);
            }
            else
            {
                angularCLI = string.Format("ng g @blastasia/catalyst:{0} --name={1} --path=/{2}", component, txtName.Text, txtComponentPath.Text);
            }
           
            Process.Start("CodeGeneratorUtility.bat");
            var angularCmd = new ProcessStartInfo();
            angularCmd.WorkingDirectory = @"C:\Users\mlomio\source\repos\AngularSchematicTestV2\test1\catalystspa\src\Content\BlastAsia.Catalyst.SPA\ClientApp";
            angularCmd.FileName = "cmd.exe";
            angularCmd.Verb = "runas";
            angularCmd.Arguments = "/c " + angularCLI;
            Process.Start(angularCmd);
        }

        private void btnAddProperty_Click(object sender, RoutedEventArgs e)
        {
         
            var model = _modelService.SetTableModel("id", "number");
            models.Add(model);
            dgModels.ItemsSource = models;
            CollectionViewSource.GetDefaultView(dgModels.ItemsSource).Refresh();
        }

        private void cmbComponents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbComponents.SelectedValue.ToString() == "table")
            {
                lblKey.Visibility = Visibility.Visible;
                txtKey.Visibility = Visibility.Visible;
                lblDataType.Visibility = Visibility.Visible;
                cmbDataTypes.Visibility = Visibility.Visible;
                btnAddProperty.Visibility = Visibility.Visible;
                dgModels.Visibility = Visibility.Visible;
            }
            else
            {
                lblKey.Visibility = Visibility.Hidden;
                txtKey.Visibility = Visibility.Hidden;
                lblDataType.Visibility = Visibility.Hidden;
                cmbDataTypes.Visibility = Visibility.Hidden;
                btnAddProperty.Visibility = Visibility.Hidden;
                dgModels.Visibility = Visibility.Hidden;
            }
        }

       
    }

 


}
