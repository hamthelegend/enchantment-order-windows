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
using Enchantment_Order.Annotations;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Enchantment_Order
{

    public record AddCustomBookParameters(
        ItemPresentation SupposedProduct,
        Action<ItemPresentation> AddBook);

    public sealed partial class AddCustomBooksPage : Page, INotifyPropertyChanged
    {

        private ItemPresentation _supposedProduct;
        private Action<ItemPresentation> _addBook;

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

        public AddCustomBooksPage()
        {
            InitializeComponent();
        }

        private void RestrictNonDigits(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private readonly List<EnchantmentPresentation> _enchantmentsPicked = new();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var parameters = (AddCustomBookParameters)e.Parameter;
            _supposedProduct = parameters.SupposedProduct;
            _addBook = parameters.AddBook;
            RefreshList();
        }

        private void RefreshList()
        {
            var availableEnchantments = EnchantmentType.All
                .SelectMany(enchantmentType =>
                {
                    var enchantments = new List<Enchantment>();
                    for (var level = 1; level <= enchantmentType.MaxLevel; level++)
                    {
                        enchantments.Add(new Enchantment(enchantmentType, level));
                    }
                    return enchantments;
                })
                .Where(enchantment =>
                    enchantment.Type.IsCompatibleWith(_enchantmentsPicked.ToEnchantments().Select(x => x.Type).ToList()) &&
                    !_enchantmentsPicked.Any(x => enchantment.Type == x.Type.ToEnchantmentType() && enchantment.Level != x.Level) &&
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
        }


        private void GoBack(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            Frame.GoBack();
        }

        private void Search(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            RefreshList();
        }

        private async void AddCustomBook(object sender, RoutedEventArgs e)
        {
            var response = await AddCustomBookDialog.ShowAsync();
            if (response != ContentDialogResult.Primary) return;
            var renamingCost = !string.IsNullOrWhiteSpace(RenamingCostField.Text) ? Convert.ToInt32(RenamingCostField.Text) : 1;
            var book = new Item(ItemType.EnchantedBook, _enchantmentsPicked.ToEnchantments(), renamingCost.RenameCostToAnvilUseCount()).ToItemPresentation();
            _addBook(book);
            Frame.GoBack();
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

            var newBook = new List<Enchantment>(_enchantmentsPicked.ToEnchantments()).ToEnchantedBook();
            AddBookButton.IsEnabled = newBook.HasCompatibleEnchantmentsWith(_supposedProduct.ToItem());
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
