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
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using BusinessLogic;
using Enchantment_Order.Annotations;
using Extensions;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Enchantment_Order
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TargetPickerPage : Page, INotifyPropertyChanged
    {

        private List<ItemTypePresentation> _itemTypes = ItemType.Targetable.ToItemTypePresentations();

        internal List<ItemTypePresentation> ItemTypes
        {
            get => _itemTypes;
            private set { _itemTypes = value; OnPropertyChanged(); }
        }

        public TargetPickerPage()
        {
            InitializeComponent();
        }

        private void GoBack(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            Frame.GoBack();
        }

        private void Search(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var searchResult = ItemType.Targetable
                .Where(itemType => itemType.FriendlyName.ToLower().Contains(sender.Text.ToLower()))
                .ToList();
            ItemTypes = searchResult.ToItemTypePresentations();
        }

        private void OnTargetPicked(object sender, SelectionChangedEventArgs e)
        {
            Frame.Navigate(typeof(EnchantmentPickerPage), ((ItemTypePresentation)TargetPicker.SelectedItem).ToItemType());
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
