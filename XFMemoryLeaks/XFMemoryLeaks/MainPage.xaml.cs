﻿using System;
using System.Threading;
using Xamarin.Forms;

namespace XFMemoryLeaks
{
    public partial class MainPage : ContentPage
    {
        static int counter;
        public MainPage()
        {
            InitializeComponent();
            Console.WriteLine(GetHashCode().ToString("X"));
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine(Interlocked.Increment(ref counter));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NewPageButton.Clicked += Button_Clicked;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            NewPageButton.Clicked -= Button_Clicked;
        }
        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Console.WriteLine("asd");
            Navigation.PushAsync(new DetailPage());
        }

        void GC_Button_Clicked(System.Object sender, System.EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        ~MainPage()
        {
            Console.WriteLine("About to be collected/disposed");
            Console.WriteLine(GetHashCode().ToString("X"));
            Console.WriteLine(Interlocked.Decrement(ref counter));
        }
    }
}
