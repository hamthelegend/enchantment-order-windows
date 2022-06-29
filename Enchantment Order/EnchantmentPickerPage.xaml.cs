using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using BusinessLogic;
using Extensions;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Enchantment_Order
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EnchantmentPickerPage : Page
    {

        public ItemType TargetPicked;
        public ObservableCollection<Enchantment> BooksPicked = new();
        public ObservableCollection<Enchantment> AvailableEnchantments = new();


        public EnchantmentPickerPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            TargetPicked = (ItemType) e.Parameter;
            RefreshList();
        }

        private void RefreshList()
        {
            var bannedEnchantmentTypes = EnchantmentPicker.SelectedItems.SelectMany(x => ((Enchantment)x).Type.IncompatibleEnchantmentTypes).ToList();
            var availableEnchantments = TargetPicked.CompatibleEnchantmentTypes
                .Select(enchantmentType => new Enchantment(enchantmentType, enchantmentType.MaxLevel))
                .Where(enchantment => 
                    !bannedEnchantmentTypes.Contains(enchantment.Type) &&
                    enchantment.ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                .ToList();
            AvailableEnchantments.ReplaceWith(availableEnchantments);
        }


        private void GoBack(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            Frame.GoBack();
        }

        private void Search(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            RefreshList();
        }

        private void OnEnchantmentsPickedChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshList();
        }
    }
}
