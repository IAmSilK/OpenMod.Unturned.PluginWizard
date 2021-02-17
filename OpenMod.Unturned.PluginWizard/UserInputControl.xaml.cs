using System.Windows.Controls;
using System.Windows.Input;

namespace OpenMod.Unturned.PluginWizard
{
    /// <summary>
    /// Interaction logic for UserInputControl.xaml
    /// </summary>
    public partial class UserInputControl : UserControl
    {
        public string Key { get; }

        public string Label { get; }

        public string Input => InputSpecified ? TextBox.Text : "";

        public bool InputSpecified { get; set; }

        private readonly string _defaultInput;

        public UserInputControl(string key, string label, string defaultInput = null!)
        {
            Key = key;
            Label = label;

            DataContext = this;

            InitializeComponent();

            TextBox.Text = _defaultInput = defaultInput;
        }

        private void OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (InputSpecified || !(sender is TextBox textBox)) return;
            
            textBox.Opacity = 1;
            textBox.Text = "";
        }

        private void OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (!(sender is TextBox textBox)) return;

            if (textBox.Text != "")
            {
                InputSpecified = true;
            }
            else
            {
                InputSpecified = false;

                textBox.Opacity = 0.6;
                textBox.Text = _defaultInput;
            }
        }
    }
}
