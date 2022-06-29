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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InitialEnchantmentPickerPage : Page, INotifyPropertyChanged
    {
        private bool _isRefreshing;

        private ItemTypePresentation _target;
        internal ItemTypePresentation Target
        {
            get => _target;
            set { _target = value; OnPropertyChanged(); }
        }

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

        public InitialEnchantmentPickerPage()
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
            Target = (ItemTypePresentation)e.Parameter;
            RefreshList();
        }

        private void RefreshList(EnchantmentPresentation enchantmentClicked = null)
        {
            if (_isRefreshing) return;
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
            var availableEnchantments = _target.CompatibleEnchantmentTypes
                .SelectMany(enchantmentType =>
                {
                    var enchantments = new List<Enchantment>();
                    for (var level = 1; level <= enchantmentType.MaxLevel; level++)
                    {
                        enchantments.Add(new Enchantment(enchantmentType.ToEnchantmentType(), level));
                    }
                    return enchantments;
                })
                .Where(enchantment =>
                    enchantment.Type.IsCompatibleWith(_enchantmentsPicked.ToEnchantments().Select(x => x.Type).ToList()) &&
                    !_enchantmentsPicked.Any(x => enchantment.Type == x.Type.ToEnchantmentType() && enchantment.Level != x.Level) &&
                    enchantment.ToString().ToLower().Contains(SearchBox.Text.ToLower()))
                .ToList();
            _isRefreshing = true;
            AvailableEnchantments = availableEnchantments.ToEnchantmentPresentations();
            foreach (var item in EnchantmentPicker.Items)
            {
                if (_enchantmentsPicked.Any(x => ((EnchantmentPresentation)item).String == x.String))
                {
                    EnchantmentPicker.SelectedItems.Add(item);
                }
            }
            _isRefreshing = false;
        }


        private void GoBack(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            Frame.GoBack();
        }

        private void Search(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            RefreshList();
        }

        private async void Next(object sender, RoutedEventArgs e)
        {
            if (_enchantmentsPicked.Count <= 0)
            {
                Frame.Navigate(typeof(EnchantmentPickerPage), _target.ToItemType().ToNewItem().ToItemPresentation());
            }
            else
            {
                var response = await AddInitialEnchantmentsDialog.ShowAsync();
                if (response == ContentDialogResult.Primary)
                {
                    var renamingCost = !string.IsNullOrWhiteSpace(RenamingCostField.Text) ? Convert.ToInt32(RenamingCostField.Text) : 1;
                    var target = new Item(_target.ToItemType(), _enchantmentsPicked.ToEnchantments(), renamingCost.RenameCostToAnvilUseCount()).ToItemPresentation();
                    Frame.Navigate(typeof(EnchantmentPickerPage), target);
                }
            }
        }

        private void EnchantmentPicker_OnItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshList((EnchantmentPresentation)e.ClickedItem);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
