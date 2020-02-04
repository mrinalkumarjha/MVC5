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
		 
		 this data will be maintained in every request. session data will be maintained untill you close browser.
		 
		 
# Models in mvc
		Models are classes which have business logic and provide data. for ex customer class, supplier class.
		
		example:
			public class Customer
		{
			public string CustomerCode { get; set; }
			public string CustomerName { get; set; }
		}
		
# RAZOR 
		RAZOR is view engine to create view.
		

# Controller
		controller takes request select model and return to view. 
		
		Request.Form["CustomerCode"] this way we are getting form value in mvc
		
		 public ActionResult Submit()
        {
            Customer customer = new Customer()
            {
                CustomerCode = Request.Form["CustomerCode"],
                CustomerName = Request.Form["CustomerName"]
            };
            return View("Customer", customer);
        }
		
		// second way to pass as parameter data will be filled auto if name same in input tag and model property.
		public ActionResult Submit(Customer customer)
        {
            return View("Customer", customer);
        }
		
		
 But what if property name dont match with html input name ?
		We use model binder to handle this situation

# ModelBinder
		Suppose there are situation where html input name attribute and mvc model class property name does not match. then auto binding wont happen after posting form.
		So to handle this situation we will use ModelBinder.
		ModelBinder has code which will connect ui with model.
		To create model binder you need to implement IModelBinder interface.
		
		Example Customer binder:
    	 public class CustomerBinder : IModelBinder
		{
			public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
			{
				HttpContextBase httpContext = controllerContext.HttpContext;
				string CustCode = httpContext.Request.Form["txtCustomerCode"];
				string CustName = httpContext.Request.Form["txtCustomerName"];

				Customer customer = new Customer()
				{
					CustomerCode = CustCode,
					CustomerName = CustName
				};

				return customer;
			}
		}
	
		
		// call it in action method
		public ActionResult Submit([ModelBinder(typeof(CustomerBinder))] Customer customer)
        {
            return View("Customer", customer);
        }
		
		 
# Why MVC and MVC vs WebForm ?