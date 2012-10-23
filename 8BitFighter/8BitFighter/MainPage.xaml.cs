using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        Dictionary<string, int> WeaponList = new Dictionary<string, int>();
        
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
            SetupWeapons();
            initializeDisplay();
            updateDisplay();
        }

        private void initializeDisplay()
        {
            List<string> Weapons = new List<string>();
            foreach (KeyValuePair<string, int> weapon in WeaponList)
            {
                Weapons.Add(weapon.Key);
            }
            
            WeaponSelect.DataContext = Weapons;

            WeaponSelect.SelectedItem = "Fist";
            int NewWeaponValue = WeaponList[WeaponSelect.SelectedItem.ToString()];
            Debug.WriteLine("You are armed with a {0} with a value of {1}", WeaponSelect.SelectedItem, NewWeaponValue);
            avatar.ChangeWeapon(NewWeaponValue);
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
            enemy.Attacked(avatar.weapon);
            IsAvatarTurn = !IsAvatarTurn;
            updateDisplay();
        }

        private void EnemyAttackControl_Click_1(object sender, RoutedEventArgs e)
        {
            avatar.Attacked(1);
            IsAvatarTurn = !IsAvatarTurn;
            updateDisplay();
        }

        private void SetupWeapons()
        {
            WeaponList.Add("Fist",1);
            WeaponList.Add("Dagger",2);
            WeaponList.Add("Main Gauche", 3);
            WeaponList.Add("Short Sword", 4);
            WeaponList.Add("Mace", 5);
            WeaponList.Add("Sword", 6);
            WeaponList.Add("Broad Sword", 7);
            WeaponList.Add("Halberd", 8);
            WeaponList.Add("Axe", 4);
            WeaponList.Add("Two-Handed Axe", 8);
            WeaponList.Add("Magic Sword", 10);

            foreach (KeyValuePair<string, int> weapon in WeaponList)
            {
                Debug.WriteLine("The {0} has an attack value of {1}", weapon.Key, weapon.Value);
            }
        }

        private void WeaponSelect_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            int NewWeaponValue = WeaponList[WeaponSelect.SelectedItem.ToString()];
            Debug.WriteLine("You selected {0} with a value of {1}", WeaponSelect.SelectedItem, NewWeaponValue);
            avatar.ChangeWeapon(NewWeaponValue);
        }
    }
}
