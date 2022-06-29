using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using BusinessLogic;
using Database;
using Enchantment_Order.Annotations;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Enchantment_Order
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SavedOrdersPage : Page, INotifyPropertyChanged
    {
        private List<CombinationOrderPresentation> _allCombinationOrders = CombinationOrderDatabase.GetAll().ToCombinationOrderPresentations();

        private List<CombinationOrderPresentation> _combinationOrders;

        internal List<CombinationOrderPresentation> CombinationOrders
        {
            get => _combinationOrders;
            private set { _combinationOrders = value; OnPropertyChanged(); }
        }

        public SavedOrdersPage()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            CombinationOrders = _allCombinationOrders
                .Where(combinationOrder => combinationOrder.Name.ToLower().Contains(SearchBox.Text.ToLower()))
                .ToList();
            EmptyIndicator.Visibility = _allCombinationOrders.Any() ? Visibility.Collapsed : Visibility.Visible;
        }

        private void GoBack(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            Frame.GoBack();
        }

        private void Search(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            Refresh();
        }

        private void OpenSavedOrder(object sender, ItemClickEventArgs e)
        {
            var combinationOrder = (CombinationOrderPresentation)e.ClickedItem;
            Frame.Navigate(typeof(ResultPage), combinationOrder);
        }


        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
