30/01/2016
Hi,

First of all apologies for the sporadic attention this has received over the past two days.
As I mentioned to Victoria, one of our kids is currently in hospital so there have been many interruptions.

The brief mentions providing instructions on how to run the solution in a Linux environment.
Hand on heart, I've never ported a .NET app to Linux.  I'm aware that Mono provides a Linux port of the .NET runtime.  I'm guessing integration with Apache would happen via an Apache module.


Anyway, this is a simple MS MVC app which attempts to meet the brief for your tech test project.
Since the original mark-up uses the PHP 'next-element' array syntax, I've taken the liberty of making the whole thing use
jQuery.ajax to retrieve and post the form data.

So the basic flow is.

~\views\person\index.cshtml holds the form and table.  This file contains the script block that will 
	- call the server to retrieve the data
	- populate the knockout view model on successfully getting the data
	- bind the knockout view model to the page
	- read the form data back to the knockout view model
	- post the databack to the server


JSON is the chosen data format for these calls. 
You would rarely these days, especially on a mobile device, post the whole page back just to get some data on to a server.

I choose knockout because of the simple, lightweight, modular solution it offers to the whole 'data for a page' problem.
The next thing would be to add client-side validation, all of which is pretty straight forward using the knockout validation extenders.
You can even set condtions on the validation with the 'onlyIf' directive - i.e only validate this field if checkbox x is checked.

Server-side implementation uses a classic MVC pattern to separate out the concerns.  Client-side ajax calls into a controller
(this could quite easily be a web API), the controller calls a service, the service returns the data.  The service implements the 
IPersonService interface, so changing the service implementation (say, to use a DB instead of a text file) won't break client (controller) code.

In this case the posted JSON data is serialized and deserialzed to and from the data file.

I've used MOQ to show how I'd implement unit testing.  
You'd add test for membership, authentication,  file access etc.

For JS testing I'd use Jamsine.
I'd normally use requireJS to resolve JS module dependencies.

OK this started life as an VS 2015 template so there's stuff to clean out. 

For your purposes the key files are:
~\Views\Person\Index.cshtml 
~\Controllers\PersonController.cs
~\ServiceInterfaces\IPersonService.cs
~\Services\PersonService.cs
SkyTechTest.Tests\Services\PersonServiceTests.cs


A note on environments
I'm currently re-skilling (is that even a word?) _back_ to LAMP after 8 years in the .NET world. 
My first big projects were all on LAMP, but with hand-knitted PHP and no use of a framework.
I had thought about doing this test using Laravel but chickened out given the time constraints and not being up-to-speed on Laravel yet.


Look forward to hearing from you.
Mark Davenport

















