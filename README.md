# javascript-pi
Open Source Community: This application is a tool that allows testing of JavaScript on a Page Interaction event hander without having to recompile the event handler itself.  This is intended to be a development tool only.

An event handler is attached to the JavaScript Test Object in the application.  It will read all the JavaScript objects and try to run the javascript included in the object on the Test Object for any that are not marked as disabled.

You may need to update the NuGet package for the Relativity Test Helpers.  These helpers allowed me to set up a test for the GetAll function and develop it quickly.  Anyone interested in writing integrations tests?  I would love to see actual tests set up and some validation of the javascript execution in the front end. Let us know if you are interested.

I have also included a sample Publish to Relativity config file to help if you try to modify and deploy the application.

While this is an open source project on the Relativity GitHub account, support is only available through through the Relativity developer community. You are welcome to use the code and solution as you see fit within the confines of the license it is released under. However, if you are looking for support or modifications to the solution, we suggest reaching out to a [Relativity Development Partner](https://www.relativity.com/ediscovery-software/app-hub/).

## usage
Once installed, the application consists of 3 objects  
![3objects](https://github.com/relativitydev/javascript-pi/blob/master/documentation/images/3objects.png)  

  -**JavaScripts**  
  ![3objects](https://github.com/relativitydev/javascript-pi/blob/master/documentation/images/javascriptobject.png)  
  This is the object that will contain your JavaScript to test  
  
  *Name* - A name for your Javascript  
  *Description* - A description of it's purpose  
  *Text* - This is the text of the javascript you want the page interaction event handler to execute  
  *View Mode* - If not set, it will fire on both view and edit mode.  
	View Only - it will only fire on view mode  
	Edit Only - it will only fire on edit mode  
  *Disabled* - If disabled is checked, JavascriptPI will ignore this paticular JavaScript.  
  
  -**Javascript Test Object**  
  ![TestOjbect](https://github.com/relativitydev/javascript-pi/blob/master/documentation/images/javascripttestobject.png)  
  This is a test object that the JavaScript PI event handler comes attached to by default.  When viewing these objects, any **JavaScripts** will be executed on this object.  If there are errors in the JavaScripts, there could be a problem with viewing or saving these objects.  
  There is one field of each type on this test object to make your testing easy.  There is also a custom label at the bottom.  
  
  -**Javascript Associated Object Test**  
  ![AssociatedObject](https://github.com/relativitydev/javascript-pi/blob/master/documentation/images/javascripttestobjectassociative.png)  
  This is simple a placeholder object for the single object field and multi-object field on the JavaScript Test Object.  
  
  
## future enhancements
-Right now this simply works with the page interaction eventhandler RegisterStartupScriptBlock.  In the future, I would like to include a select for the other types of script blocks including the file script block.  
-I would like to create a post-install event handler for the application to create a few simple example JavaScripts  
-I would like to add the ids and names of all the lables and inputs on the JavaScript Test Object so that you would not have to look them up to test with them.   
