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


# Different ways of passing data from controller to view.
		In asp.net various ways of passing data was ViewState, HiddenField, SessionVariable. 
		There is no view state in asp.net mvc.  There is no behind code in mvc. also there is no
		server control in mvc.
		
		THere are 3 mechanism by which you can pass data to view.
		
		1: VIEWDATA/VIEWBAG : if you need to pass data from controller to view or action to view then you will use VIEWDATA/VIEWBAG.
		
		
		example of view data:
		
		in controller :
		public ActionResult GoToHome()
        {
            ViewData["MyTime"] = DateTime.Now.ToString();
            return View();
        }
		
		In View :
		
		<div> 
        Welcome to my first MVC view.
        <br />
        @ViewData["MyTime"];
		</div>
		
		Syntax of view data is so cryptic. so we use viewBag to make better syntax. viewBag is syntaxtic suger over viewdata.
		it simplifies your view data syntax. Internally ViewBag use dynamic keyword. And dynamic keyword uses reflection. So at
		run time dynamic keyword tries to figure out that you have particularproperty available or not.
		Basically viewBag internally use viewdata. it is collection of viewdata.
		
		
		ViewBag does not maintain data between action to action redirect. SO for this reason we use tempdata.
		example : TempData["MyTimeTemp"] = DateTime.Now.ToString(); 
		this will maintained in action redirect also.
		
		
		example using viewbag.
		
		IN CONTROLLER :
		
		public ActionResult GoToHome()
        {
            ViewData["MyTime"] = DateTime.Now.ToString();
            ViewBag.MyTime = DateTime.Now.ToString();
            return View();
        }
		
		IN VIEW:
		
		<div> 
        
        Welcome to my first MVC view.
        <br />
        @ViewData["MyTime"];
        @ViewBag.MyTime;
		</div>
	
		
		2: TEMPDATA :
		ViewBag does not maintain data between action to action redirect. SO for this reason we use tempdata.
		example : TempData["MyTimeTemp"] = DateTime.Now.ToString(); 
		this will maintained in action redirect also. 
		So if you want to maintain data within complete request(action to action redirect then view) you need to use tempdata.
		
		ex:  public ActionResult Index()
        {
            // return View();
            ViewBag.MyTime = DateTime.Now.ToString();
            TempData["MyTimeTemp"] = DateTime.Now.ToString();
            return RedirectToAction("GoToHome", "Home");
        }

        public ActionResult GoToHome()
        {
            ViewData["MyTime"] = DateTime.Now.ToString();
           
            return View();
        }
		
		Here tempdata variable MyTimeTemp will be maintained inside GoToHome also.
		
		
		
		3: SessionVariable: 
		If you want to maintain data between multiple request you need to use old friend session.
		 
		 Session["MyTimeSession"] = DateTime.Now.ToString();
		 
		 this data will be maintained in every request.
		 
		