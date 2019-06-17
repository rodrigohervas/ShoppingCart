##Intro to Session State Management and Caching in ASP.NET Core 2:

In this example of a basic shopping cart in ASP.NET Core 2 we are going to use **Caching** and a **Session** object.
 
**Caching** makes a copy of the data that we can return much faster than from the original response. Since HTTP is a stateless protocol, and no user information can be stored in its requests, we'll use a **Session** object to maintain the user state. The **Session state** is a scenario where the user data is stored by the app in order to be able to persist this data between requests from a client. 

In this app, the session data is backed by a cache and (with **IMemoryCache** caching) stored in the web server memory.
