# XamarinMemoryLeaksInvestigation
 This sample demonstrates memory leaks in Xamarin Forms solutions
 
 Use [EnableiOSGCLogs.png](EnableiOSGCLogs.png) to enable iOS Garbage Collection Logs
 
 No matter how you assign an EventHandler to the Clicked Event of the button in the Detail Page, the page does not get destroyed when you go back.
 
 If you notice, the Destructor does not get called, which is bad.

Also if you keep an eye out on the memory, even though we perform a GC Collect, the size occupied keeps increasing

And on the main page, even if you tap GC to force a collect, it doesn't detroy the app.

### Things I tried, but didn't make a difference

I tried to assign the event handler in different ways

I tried to add Add a Back button on the detail page to go back instead of the back on the tool bar

### Motivation

I was studying memory management by iOS, and I realized a lot of apps I have worked on make a very common memory management mistake of not unassigning event handler from button clicked events. So I tried to check if Xamarin Forms also has the same issue or if it is automatically handled, and I found that it is an issue here as well. I created the simplest possible sample to demonstrate this. 
