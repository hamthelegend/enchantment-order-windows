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
    public sealed partial class EnchantmentPickerPage : Page, INotifyPropertyChanged
    {

        private ItemPresentation _target;

        private readonly ObservableCollection<ItemPresentation> _booksPicked = new();
        private List<EnchantmentPresentation> _availableEnchantments = new();
        internal List<EnchantmentPresentation> AvailableEnchantments
        {
            get => _availableEnchantments;
            set
            {
                if (_availableEnchantments.SequenceEqual(value)) return;
                _availableEnchantments = value; 
                OnPropertyChanged();
            }
        }

        private List<EnchantmentPresentation> _enchantmentsPicked = new();


        public EnchantmentPickerPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _target = (ItemPresentation) e.Parameter;
            RefreshList();
        }

        private void RefreshList()
        {
            var supposedProduct = _target.ToItem().SupposedProduct(_booksPicked.ToList().ToItems());
            var availableEnchantments = _target.Type.CompatibleEnchantmentTypes
                .Select(enchantmentType => new Enchantment(enchantmentType.ToEnchantmentType(), enchantmentType.MaxLevel))
                .Where(enchantment =>
                    enchantment.Type.IsCompatibleWith(_enchantmentsPicked.ToEnchantments().Select(x => x.Type).ToList()) &&
                    new List<Enchantment> { enchantment }.ToEnchantedBook().HasCompatibleEnchantmentsWith(supposedProduct) &&
                    enchantment.ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                .ToList();
            AvailableEnchantments = availableEnchantments.ToEnchantmentPresentations();
            foreach (var item in EnchantmentPicker.Items)
            {
                if (_enchantmentsPicked.Any(x => ((EnchantmentPresentation)item).String == x.String))
                {
                    EnchantmentPicker.SelectedItems.Add(item);
                }
            }

            GetBestOrderButton.IsEnabled = _booksPicked.Any() || _enchantmentsPicked.Any();
        }


        private void GoBack(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            _booksPicked.Clear();
            _enchantmentsPicked.Clear();
            Frame.GoBack();
        }

        private void Search(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            RefreshList();
        }

        private void AddCustomBook(object sender, RoutedEventArgs e)
        {
            var allBooks = _booksPicked.ToList().ToItems();
            allBooks.AddRange(_enchantmentsPicked.ToEnchantments().Select(x => new List<Enchantment> {x}.ToEnchantedBook()));
            var supposedProduct = _target.ToItem().SupposedProduct(allBooks).ToItemPresentation();
            Frame.Navigate(typeof(AddCustomBooksPage), new AddCustomBookParameters(supposedProduct, bookAdded => _booksPicked.Add(bookAdded)));
        }

        private void OnBookClicked(object sender, ItemClickEventArgs e)
        {
            var bookClicked = (ItemPresentation)e.ClickedItem;
            if (bookClicked != null)
            {
                _booksPicked.Remove(bookClicked);
            }
            RefreshList();
        }

        private void GetBestOrder(object sender, RoutedEventArgs e)
        {
            var allBooks = new List<ItemPresentation>(_booksPicked);
            allBooks.AddRange(_enchantmentsPicked.Select(x => new List<Enchantment> { x.ToEnchantment() }.ToEnchantedBook().ToItemPresentation()));
            var resultPageParameters = new ResultPageParameters(_target, allBooks);
            Frame.Navigate(typeof(ResultPage), resultPageParameters);
        }

        private void OnEnchantmentClicked(object sender, ItemClickEventArgs e)
        {
            var enchantmentClicked = (EnchantmentPresentation)e.ClickedItem;
            if (enchantmentClicked != null)
            {
                var selectedEnchantment = _enchantmentsPicked.FirstOrDefault(x => enchantmentClicked.String == x.String);
                if (selectedEnchantment != null)
                {
                    _enchantmentsPicked.Remove(selectedEnchantment);
                }
                else
                {
                    _enchantmentsPicked.Add(enchantmentClicked);
                }
            }
            RefreshList();
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
