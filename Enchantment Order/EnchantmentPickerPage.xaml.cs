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
        private bool _isRefreshing;

        public ItemType TargetPicked;

        private List<ItemPresentation> _booksPicked = new();
        internal List<ItemPresentation> BooksPicked
        {
            get => _booksPicked;
            set { _booksPicked = value; OnPropertyChanged(); }
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

        private List<EnchantmentPresentation> _enchantmentsPicked = new();


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
            var bannedEnchantmentTypes = _enchantmentsPicked
                .SelectMany(x => x.Type.ToEnchantmentType().IncompatibleEnchantmentTypes)
                .ToList();
            var availableEnchantments = TargetPicked.CompatibleEnchantmentTypes
                .Select(enchantmentType => new Enchantment(enchantmentType, enchantmentType.MaxLevel))
                .Where(enchantment => 
                    !bannedEnchantmentTypes.Contains(enchantment.Type) &&
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
