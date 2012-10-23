using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace _8BitFighter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Player avatar = new Player();
        Player enemy = new Player();
        bool IsAvatarTurn = true;
        
        public MainPage()
        {
            this.InitializeComponent();


        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            updateDisplay();
        }

        private void updateDisplay()
        {
            PlayerHealthDisplay.Value = avatar.health;
            EnemyHealthDisplay.Value = enemy.health;
            if (IsAvatarTurn)
            {
                PlayerAttackControl.IsEnabled = true;
                EnemyAttackControl.IsEnabled = false;
            }
            else
            {
                PlayerAttackControl.IsEnabled = false;
                EnemyAttackControl.IsEnabled = true;
            }

        }

        private void PlayerAttackControl_Click_1(object sender, RoutedEventArgs e)
        {
            enemy.Attacked(1);
            IsAvatarTurn = !IsAvatarTurn;
            updateDisplay();
        }

        private void EnemyAttackControl_Click_1(object sender, RoutedEventArgs e)
        {
            avatar.Attacked(1);
            IsAvatarTurn = !IsAvatarTurn;
            updateDisplay();
        }
    }
}
