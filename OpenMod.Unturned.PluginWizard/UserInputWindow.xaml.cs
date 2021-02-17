using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace OpenMod.Unturned.PluginWizard
{
    /// <summary>
    /// Interaction logic for UserInputWindow.xaml
    /// </summary>
    public partial class UserInputWindow : Window
    {
        public BindingList<UserInputControl> InputControls { get; set; }
            = new BindingList<UserInputControl>();

        public Dictionary<string, string> Inputs =>
            InputControls.ToDictionary(x => x.Key, x => x.Input);

        public UserInputWindow()
        {
            DataContext = this;

            // A code reference to MahApps.Metro is necessary
            var ex = new MahApps.Metro.MahAppsException();

            InitializeComponent();
        }

        public void AddInput(string key, string label, string defaultContent = null!)
        {
            InputControls.Add(new UserInputControl(key, label, defaultContent));
        }

        private void ButtonContinue_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
