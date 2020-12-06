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
            DetailButton.Clicked += Button_Clicked;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DetailButton.Clicked -= Button_Clicked;
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
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
    }
}
