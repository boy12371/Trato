﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace Trato.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class V_Buscador : ContentPage
	{
		public V_Buscador ()
		{
			InitializeComponent ();
            v_mapa = new Map(
            MapSpan.FromCenterAndRadius(
                    new Position(20.6719563, -103.416501), Distance.FromMiles(1)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            //If Label is not set, runtime exception
            var pin = new Pin()
            {
                Position = new Position(20.6719563, -103.416501),
                Label = "Some Pin!"
            };
            v_mapa.Pins.Add(pin);
        }
	}
}