using System;
using kCura.EventHandler;
using kCura.Relativity.Client;
using Relativity.API;
using JavaScriptPI.Helpers.Models;

namespace JavaScriptPI.EventHandler
{
    [kCura.EventHandler.CustomAttributes.Description("Will Execute JavaScript based on JavaScript Objects")]
    [System.Runtime.InteropServices.Guid("23e98cef-bf69-452c-8e83-4620975cd97b")]
    public class JavaScriptPIEH : kCura.EventHandler.PageInteractionEventHandler
    {
        public override Response PopulateScriptBlocks()
        {


            //Create a response object with default values
            kCura.EventHandler.Response retVal = new kCura.EventHandler.Response();
            retVal.Success = true;
            retVal.Message = String.Empty;
            //var client = Relativity.API.Services.Helper.GetServicesManager().CreateProxy<kCura.Relativity.Client.IRSAPIClient>(Relativity.API.ExecutionIdentity.System);
            IRSAPIClient client = Helper.GetServicesManager().CreateProxy<IRSAPIClient>(ExecutionIdentity.System);
            client.APIOptions.WorkspaceID = Helper.GetActiveCaseID();

            // var javaScriptHelper = new JavaScriptPI();

            var JavaScripts = JavaScriptPI.Helpers.JavaScripts.GetAll(client);
            
            int counter = 0;
            string scriptBlockName = "";
            bool addBlockType = false;

            foreach (var js in JavaScripts)
            {
               
                if (js.ViewMode == JavaScriptBlock.ViewModeValue.ViewOnly && this.PageMode == kCura.EventHandler.Helper.PageMode.Edit)
                {
                    addBlockType = false;
                }
                else if (js.ViewMode == JavaScriptBlock.ViewModeValue.EditOnly && this.PageMode == kCura.EventHandler.Helper.PageMode.View)
                {
                    addBlockType = false;
                }
                else
                {
                    addBlockType = true;
                }

                if (addBlockType == true)
                {
                    scriptBlockName = "ScriptBlockName" + counter.ToString();
                    counter++;
                    this.RegisterStartupScriptBlock(new kCura.EventHandler.ScriptBlock() { Key = scriptBlockName, Script = js.Text });

                }
                //this.RegisterClientScriptBlock(new kCura.EventHandler.ScriptBlock() { Key = "alertFunc", Script = alertFunction });
            }

            //if (this.PageMode == kCura.EventHandler.Helper.PageMode.Edit)
            //{
            //    this.RegisterStartupScriptBlock(new kCura.EventHandler.ScriptBlock() { Key = "registerEventsScript", Script = registerEventsScript });
            //}

            return retVal;

        }

   //     public override Response PopulateScriptBlocks()
   //     {
   //         //Create a response object with default values
   //         kCura.EventHandler.Response retVal = new kCura.EventHandler.Response();
   //         retVal.Success = true;
   //         retVal.Message = String.Empty;

   //         /*

			////Let's get the url to our custom pages so we can pull in script/css pages from there
   //   String applicationPath = getApplicationPath(this.Application.ApplicationUrl);

   //   // Before the elements are loaded on a page, register the JavaScript file. 
   //   // You can load a JavaScript file into Relativity via a custom page.
   //   this.RegisterLinkedClientScript(applicationPath + "javascript/myjavascriptfunctions.js");

   //   // You can also register functions directly.
   //   String alertFunction = "<script type=\"text/javascript\"> function alertWithText(text){alert(text);}</script>";
   //   this.RegisterClientScriptBlock(new kCura.EventHandler.ScriptBlock() { Key = "alertFunc", Script = alertFunction });

   //   // After the elements are loaded on the page, register the JavaScript.
   //   this.RegisterLinkedStartupScript(applicationPath + "functionCall.js");

   //   // You can also call functions directly
   //   String alert = "<script type=\"text/javascript\"> alertWithText('Successfully called a function registered earlier!');</script>";
   //   this.RegisterStartupScriptBlock(new kCura.EventHandler.ScriptBlock() { Key = "alertKey", Script = alert });

   //   // Your custom page can include a .css file for loading into a page.
   //   this.RegisterLinkedCss(applicationPath + "styles/loadedCSS.css");
			  
			// */

   //         return retVal;
   //     }
    }
}
