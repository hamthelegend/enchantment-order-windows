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
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using BusinessLogic;
using Database;
using Enchantment_Order.Annotations;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Enchantment_Order
{

    public record ResultPageParameters(
        ItemPresentation Target,
        List<ItemPresentation> ItemsPicked);

    public sealed partial class ResultPage : Page, INotifyPropertyChanged
    {

        private List<CombinationPresentation> _combinations = new();
        internal List<CombinationPresentation> Combinations
        {
            get => _combinations;
            set
            {
                if (_combinations.SequenceEqual(value)) return;
                _combinations = value;
                OnPropertyChanged();
            }
        }

        private string _combinationOrderName = "Enchantment order";
        internal string CombinationOrderName
        {
            get => _combinationOrderName;
            set
            {
                if (_combinationOrderName == value) return;
                _combinationOrderName = value;
                OnPropertyChanged();
            }
        }

        private ItemPresentation _finalProduct;
        internal ItemPresentation FinalProduct
        {
            get => _finalProduct;
            set
            {
                if (_finalProduct == value) return;
                _finalProduct = value;
                OnPropertyChanged();
            }
        }

        private int _combinationOrderId = -1;

        public ResultPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var parameters = (ResultPageParameters)e.Parameter;
            GetBestOrder(parameters.Target.ToItem(), parameters.ItemsPicked.ToItems());
        }

        private async void GetBestOrder(Item target, List<Item> itemsPicked)
        {
            var combinationOrder = await Task.Run(() => Anvil.GetBestOrder(target, itemsPicked));
            Combinations = combinationOrder.Combinations.ToCombinationPresentations();
            _combinationOrderId = combinationOrder.Id;
            FinalProduct = combinationOrder.FinalProduct.ToItemPresentation();
        }

        private void GoBack(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            Frame.GoBack();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Name = !string.IsNullOrWhiteSpace(NameField.Text) ? NameField.Text : FinalProduct.Type.FriendlyName;
            var combinationOrder = new CombinationOrder(Combinations.ToCombinations(), Name);
            CombinationOrderDatabase.Add(combinationOrder);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
