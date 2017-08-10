# wpf-dispatcher-example

The code sample is to support the post in the following link.
http://nohimstechnicalblog.blogspot.com/2017/05/wpf-dispatcher-accessing-ui-thread-from.html
Please refer the blog post for further clarifications.

Only uncomment one of the following approaches and test your application

1.1 Approach->
Calling the Dispatcher Synchronously through the Dispatcher of the UI element

1.2 Approach->
Calling the Dispatcher ASynchronously through the Dispatcher of the UI element

1.3 Approach->
Calling the Dispatcher through the Dispatcher of the UI element
If the user is unsure whether the executing thread has the access to modify UI elements,
first check it using CheckAccess() method      

2.1 Approach-> 
Calling the Dispatcher Synchronously by getting the current Dispatcher from Application
Doesn't required to have access to the UI element to get the Dispatcher

2.2 Approach->
Calling the Dispatcher ASynchronously by getting the current Dispatcher from Application
Doesn't required to have access to the UI element to get the Dispatcher

2.3 Approach->
Calling the Dispatcher by getting the current Dispatcher from Application
If the user is unsure whether the executing thread has the access to modify UI elements,
first check it using CheckAccess() method  
