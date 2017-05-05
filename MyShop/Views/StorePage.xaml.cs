using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MyShop
{
    public partial class StorePage : ContentPage
    {
        StoreViewModel viewModel;
        public StorePage(Store store)
        {
            BindingContext = viewModel = new StoreViewModel(store, this);
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var position = new Position(viewModel.Store.Latitude, viewModel.Store.Longitude); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = viewModel.Store.Name,
                Address = viewModel.Store.StreetAddress
            };
            MyMap.Pins.Add(pin);

            MyMap.MoveToRegion(
            MapSpan.FromCenterAndRadius(
            position, Distance.FromMiles(.2)));
        }
    }
}

