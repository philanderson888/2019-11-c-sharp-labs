# Day 34 - ASP Intro

# ASP Websites

As we have said, raw HTML, CSS and Javascript are used all over the world.

Also modern websites use NODEJS so that Javascript is running on the SERVER and CLIENT

However Microsoft have used a DIFFERENT APPROACH

    Client                                 Server
    											HTML/CSS/JS
    												.CS c sharp as well
    
    	<=======================================
    	HTML CSS JS  (no C# at all)

Also newer sites use .cshtml which merges HTML and C# using the @ to generate C# on a webpage
(Razor)

We can build two types of websites

    1) ASP regular website with regular links
    2) MVC website for handling data
    		Model 			Data 			eg Class Customer { .... }
    												match Database Customers
    											DbSet<Customer>    Customers
    											       Class        Table in SQL
    
    		View
    						Page
    
    		Controller
    						Inspect URL to make a decision about the INCOMING REQUEST
    								and what to do with it
    									a) Which data to fetch
    									b) Which view (page) user wants to see (routing)
    
    
    						<https://mydomain.com/controller/action/id>
    
                                                 /table    /get
                                                           /post
                                                 /customers/get
                                                 /products /post
    
                                  ................Customers/           GET ALL CUSTOMERS
                                                           /GET   /1   GET CUSTOMER WITH ID=1
                                                           /POST   
                                                           		{BODY:<Customer>}
                                                           		    ==> ADD NEW CUSTOMER
                                                           /POST/1     
                                                           		{BODY:<Customer>}
                                                           			==> UPDATE WHERE ID=1
    
                                                           /GET/NAME    custom query by name
                                                           /PUT         EDIT
                                                           /DELETE      DELETE