using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using System;

namespace VietTransPro
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.AppWindow.MoveAndResize(new Windows.Graphics.RectInt32((int)(this.Bounds.Width / 2), (int)(this.Bounds.Height / 2), 1000, 800));
        }
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text) || LevelComboBox.SelectedValue == null || string.IsNullOrEmpty(ApiKeyTextBox.Text))
            {
                var dialog = new ContentDialog
                {
                    XamlRoot = this.Content.XamlRoot,
                    Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                    Title = "Lỗi",
                    PrimaryButtonText = "OK",
                    DefaultButton = ContentDialogButton.Primary,
                    Content = "Vui lòng điền đầy đủ thông tin."
                };

                await dialog.ShowAsync();
            }
            else
            {
                var frame = new Frame();
                frame.Navigate(typeof(HomePage), null, new SlideNavigationTransitionInfo { Effect = SlideNavigationTransitionEffect.FromRight });
                this.Content = frame;
            }
        }
    }
}
