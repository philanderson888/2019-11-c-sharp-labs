# Day 34 - CSS continued

# HTML, CSS, Javascript notes continued

Displaying items on a screen

    CSS display: 
    
    	display:block;  		TAKES WHOLE WIDTH
    
    		div, p, h1          BLOCK ELEMENTS 
    
    	display:inline; 		FILL CONTENT WIDTH 
    	display:inline-block;  	ALLOCATE A WIDTH

    
    body{
        background-color: #F5F5F5;
    }
    ul{
        display:block;
        text-align: center;
        padding:2vh 0;
        background-color:#F2EFEF;
    
    }
    li{
        list-style: none;
        display:inline-block;
        width:15%;
    
    }
    li a:hover{
        text-decoration: none;
        font-weight: bold;
    }
    .inline{
        display: inline;
    }
    .inline-block{
        display:inline-block;
        width:50%;
    }
    h2{
        text-align: center;
    }