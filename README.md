# MVC5
MVC5 Application

# What is MVC 
    mvc stands for model view controller. it has three layer.
    1 View : for ui look and feel
    2 Model: responsible for data and business logic. it is like customer class, supplier class etc. Model can interact with some service like wcf data layer
    
    3 Controller : coordinator between model and view.
    
In mvc request we say action. so when user create request from mvc site it comes at controller. And controller based on action picks the model and binds to view. this result sent to user browser.

Action(AddCustomer)  ===> Controller ===> costomerModel
                                     ====> View(Customer.aspx) or customer.cshtml



# Routing in mvc :
    Routing simplifies mvc url structure like : Home/Home/GotoHome => Home
    
    For routing there is file available in mvc5 to configure routing. 
    
    App_Start => RouteConfig.cs
    
    This file has routes collection. So routing is the collection of url which maps user friendly url to actual controller and action.
    we get benifits of SEO by user friendly path
    
    We can map multiple url to single route. 
    
    example: 
    
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
       Here Name is key name as every collection has. and Default is value of key. 
       url has url structure. it says that if url structure is like this "{controller}/{action}/{id}" then go and
       invoke the Home controller and Index action.


# routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
      // It is collection of route which wont be served 
      
# How to set start page in mvc ?
      In Mvc there is no start page as request comes to controller so there should be start controller.
      To set start page create a empty url and configure controller and action inside it.
      
      routes.MapRoute(
               name: "Home2",
               url: "",
               defaults: new { controller = "Home", action = "GoToHome", id = UrlParameter.Optional }
           );

