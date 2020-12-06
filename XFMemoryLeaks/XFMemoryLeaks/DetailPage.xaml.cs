using System;
using System.Collections.Generic;
using System.Threading;
using Xamarin.Forms;

namespace XFMemoryLeaks
{
    public partial class DetailPage : ContentPage
    {
        static int counter;
        public DetailPage()
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
            DetailButton.Clicked += DetailButton_Clicked;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DetailButton.Clicked -= DetailButton_Clicked;
        }

        void DetailButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Console.WriteLine("asd");
        }

        ~DetailPage()
        {
            // Memory Leak: The destructor is not getting called
            Console.WriteLine("About to be collected/disposed");
            Console.WriteLine(GetHashCode().ToString("X"));
            Console.WriteLine(Interlocked.Decrement(ref counter));
        }

        async void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
