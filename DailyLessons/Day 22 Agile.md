# Day 22 - Agile

# Agile

## Review of current knowledge

Epic - overall project 'container'

Backlog = list of tasks ('requirements')

User Stories - each task is written out in a form which a non-tech person can understand

Sprints - select certain items from Backlog and set a goal to complete those few items in a period of time 1-4 weeks

Scrum : way of building software

Manifest file is like a configuration file with instructions / metadata about a project

Scrum Master : helps flow of work (admin overview of work)

Kanban - environment where work never stops - flow of work rather than discrete sprints

## Agile Introduction

### Waterfall

First projects were built using a straight-forward method called Waterfall

SDLC Software Development Life Cycle

Feasibility Study - initial analysis to see if project is a good idea

    ROI Return On Investment
    
    	Money Spent : Money Returned
    
    	How much money will this cost?   Expected income back
    
    	Investor invest £100 - if he can get £110 back at end of year ROI is 10%

Analysis

    Requirements Gathering 
    
    		Talk to customer and find out what is their NEED FOR THIS PROJECT?
    
    				Face to face, phone, surveys etc
    
    		Requirements Engineering
    
    			==> LIST OF REQUIREMENTS (this is the project!)
    
    			BACKLOG = LIST OF REQUIREMENTS

Architecture = High Level Design

    Project planning 
    
    	TIMESCALE
    	BUDGET   A) OVERALL B) IMMEDIATE CASH FLOW
    	MANPOWER
    	RESOURCES EG BUILDINGS ETC
    
    
    Technical
    	OS : Windows or MAC or Linux : Android/IOS Mobile
    	Programming Language : Web/OOP C#, Java, Python, Go
    	Legacy environment
    		Greenfield project - startup with NO LEGACY TO WORRY ABOUT 
    		Brownfield - tie in to legacy
    
    Constraints : restrictions
    	Legal
    	Industry code of conduct 
    	Timescale

Low level design

    'Specification'  ie detail of projects ** instructions for coders **
    
    	UI User interface : visual element, what user SEES
    	UX User experience : flow of screens together, how the app responds and feels
    			- is the flow natural, is the app easy to use 'intuitive'

Build

Testing

    Note
    
    	TDD Test Driven Development means WRITE TESTS FIRST!
    		RED           Code fails tests initially 
    		GREEN         Code written and passes tests
    		REFACTOR      More efficient
    	BDD Tests in human-friendly language (think USER STORIES)
    		Behaviour Driven Development (Selenium, Cucumber, Gherkin syntax)

### Agile : Summary so far

SDLC stages
Feasibility Study : is project feasible
Analysis : Customer Requirements (BACKLOG - LIST OF REQUIREMENTS)
Architecture : High Level Design
Design : Low Level (detailed 'spec')
UI
UX
Technical
Build
Test

    Release to production
    
    	CI/CD Pipeline
    
    	CI Continuous Integration (GitHub code)
    	CD Continuous Deployment (Deploying small commits very often)
    
    	Pipeline : Code => Tests => Send to Production all in one automatic flow
    
    Ongoing Maintenance
    
    	Help Desk
    		Issues
    		1) Bug Fix
    		2) New Feature Request
    
    Documentation
    	1) User
    	2) Technical

Waterfall Model

    Fixed model
    	Analysis=> Design=> Build => Test => Release in ONE FLOW
    
    		Maintenance next
    
    Advantages
    	Good for smaller, repeating projects
    		Car factory => software between models won't change much
    	Good for projects where safety and stability are priority
    		Bridge / Dam ==> software to be robust
    		Military / Mission Critical
    
    			V-model is WATERFALL PLUS EXTRA TESTING
    
    
    
    
    				User List Of Requirements 							UAT User
    					(Backlog) 									  	Acceptance Testing
    					               									(user confirms that
    					               									you have built the
    					               									software correctly)
    
    					Working System 								System Testing
    
    						Join Modules                       Integration Testing
    
    							Code Modules (Unit)       Unit Testing 
    
    Disadvantages Of Waterfall
    
    	Often whole process from start to finish can take several months.
    	Requirements can CHANGE!!!  MESS UP WHOLE PROJECT!!!
    	Waterfall : INFLEXIBLE

Agile

    Agile Manifesto
    
    	Embrace certain values
    
    		WORKING SOFTWARE OVER DOCUMENTATION (value brought is only measured in actual
    												working code)
    
    		FACE TO FACE COMMUNICATION is ALWAYS BEST  (DAILY STANDUP)
    		
    		COLLABORATION OVER NEGOTIATION (IE CUSTOMER IS SOMEONE WE WORK WITH)
    
    		EMBRACE CHANGE OVER FOLLOWING A PLAN (TO A POINT OF REASON OF COURSE)
    
    			BUSINESS CONDITIONS MAY CHANGE AT SHORT NOTICE

Scrum

    Scrum is the PRACTICAL OUTWORKING OF AGILE
    
    	Over the years we've had different names
    
    		XP Extreme Programming (Pair programming)
    		Lean (build minimum)
    
    Today scrum is accepted as 'norm' for programmers working together scrum.org
    
    3 Roles
    
    	Scrum Master 		Not in charge  !   Servant-enabler to whole team, 
    						Remove 'blockers' (hindrances) to team
    						Organise meetings, book rooms, admin around team
    
    	Product Owner 		Go-between between DEV TEAM AND CUSTOMER
    
    						DEV TEAM ------ PRODUCT OWNER -----------CUSTOMER
    						                   BACKLOG
    						               LIST OF REQUIREMENTS
    
    	Dev Team			Self-organising
    						Jointly responsible for commitments made
    							(Under-promise and Over-deliver)	
    						3-9 people multi-skilled

Summary so far : Agile

    Manifesto : thinking behind it 
    
    Roles		Scrum master (enabler)
    			Product owner 			Client go-between & owns BACKLOG LIST
    			Dev Team 				3-9 people, self organising, multi-skilled

Agile In Practice

    BACKLOG => LIST OF REQUIREMENTS IE build this!
    
    	USER STORIES => HUMAN SIDE OF BACKLOG REQUIREMENTS
    
    		WEIGHT (PRIORITY)
    		COST   (DEGREE OF DIFFICULTY)
    
    SPRINT 0 - FIRST SPRINT 
    
    	GOAL : PRODUCE 'MVP' MINIMUM VIABLE PRODUCT IE FIRST WORKING VERSION, AS SIMPLE AS POSSIBLE
    
    	EACH SPRINT : 4 MEETINGS
    
    		SPRINT PLAN    Select 'for development' one or two features from MAIN BACKLOG.
    						Create 'SPRINT BACKLOG' 
    						Plan timescale eg 2 weeks
    						Define 'DONE' eg Passing x TESTS
    
    		DAILY STANDUP   DID YESTERDAY , DOING TODAY, BLOCKERS (PROBLEMS)
    
    		SPRINT REVIEW   Invite customer to view our FINISHED PRODUCT (ITERATION / VERSION)
    							((Working software is measure of success))
    
    		SPRINT RETRO    Retrospective - internal review privately of what went good/bad/
    										could be improved
    
    SPRINT 1,2,3,4 ETC UNTIL FINAL PRODUCT IS BUILT
    
    	IDEA IS THAT GOALS (BACKLOG) CAN CHANGE.  SPRINTS SMALL HELPS US TO BE 'AGILE' AND
    	TO BE SENSITIVE TO CLIENT IF THEY NEED CHANGE.
    
    	BUT!!!
    
    		Use our PROFESSIONAL SKILLS TO GUIDE CUSTOMER IN ANY DECISIONS / THOUGHT PROCESSES
    		WHICH THEY WANT TO CHANGE IE SPEC.  Don't let them just be unprofessional in the
    		way they change the spec.
    
    
    	Sprints help because they provide CLEAR, PRECISE PERIODS OF WORK WITH A CLEAR GOAL

Other types of Agile

    Kanban
    
    	JIT Just In Time : lean process for delivery at right time to minimise high stock levels
    
    	Kanban is a development METHODOLOGY ((WAY OF DOING WORK)) such that the work never
    		stops but is going 24/7 and useful for eg manufacturing plants
    
    
    		BACKLOG    SELECTED FOR DEV    IN PROGRESS      FOR REVIEW          COMPLETE
    
    
    		                                  LIMIT
    		                                  AMOUNT
    		                                  HERE