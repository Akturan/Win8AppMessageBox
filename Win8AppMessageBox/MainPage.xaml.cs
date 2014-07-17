using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace Win8AppMessageBox
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet werden kann oder auf die innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Wird aufgerufen, wenn diese Seite in einem Rahmen angezeigt werden soll.
        /// </summary>
        /// <param name="e">Ereignisdaten, die beschreiben, wie diese Seite erreicht wurde. Die
        /// Parametereigenschaft wird normalerweise zum Konfigurieren der Seite verwendet.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            messageBox("Your message", "Your title", false);
        }


        private async void messageBox(string msg, string title, bool type)
        {
            var msgDialog = new MessageDialog(msg, title);
            msgDialog.DefaultCommandIndex = 1;

            if (type == true)
            {
                UICommand okBtn = new UICommand("OK");
                okBtn.Invoked = OkBtnClick;
                msgDialog.Commands.Add(okBtn);


                UICommand cancelBtn = new UICommand("Cancel");
                cancelBtn.Invoked = CancelBtnClick;
                msgDialog.Commands.Add(cancelBtn);
            }

            await msgDialog.ShowAsync();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            messageBox("Message Dialog with custom buttons", "Message dialog", true);
        }

        private void CancelBtnClick(IUICommand command)
        {
            textblock1.Text = "Cancel button clicked";
        }

        private void OkBtnClick(IUICommand command)
        {
            textblock1.Text = "OK button clicked";
        }
        
    }
}
