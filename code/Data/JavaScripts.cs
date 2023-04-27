using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kCura.Relativity.Client;
using Relativity.API;
using JavaScriptPI.Helpers.Models;

namespace JavaScriptPI.Helpers
{
    public static class JavaScripts
    {

        public static ICollection<JavaScriptBlock> GetAll(kCura.Relativity.Client.IRSAPIClient client)
        {
            var javaScriptBlocks = new List<JavaScriptBlock>();

            var qry = new kCura.Relativity.Client.DTOs.Query<kCura.Relativity.Client.DTOs.RDO>();
            qry.ArtifactTypeGuid = Helper.Constants.Javascripts.ObjectTypeGuid;
            //qry.Fields = kCura.Relativity.Client.DTOs.FieldValue.AllFields;
            qry.Fields = new List<kCura.Relativity.Client.DTOs.FieldValue> {
                new kCura.Relativity.Client.DTOs.FieldValue(Helper.Constants.Javascripts.Fields.Text)
                , new kCura.Relativity.Client.DTOs.FieldValue(Helper.Constants.Javascripts.Fields.ViewMode)
            };
        
            BooleanCondition onlyActiveJavaScript = new BooleanCondition(Helper.Constants.Javascripts.Fields.Disabled, BooleanConditionEnum.EqualTo, false);
            qry.Condition = onlyActiveJavaScript;

            
            try
            {
                var ActiveJavaScriptsResults = client.Repositories.RDO.Query(qry);

                if (ActiveJavaScriptsResults.Success)
                {
                    foreach (var result in ActiveJavaScriptsResults.Results)
                    {
                        var javaScript = new JavaScriptBlock();
                        var resultArtifact = result.Artifact;
                        javaScript.Text = resultArtifact.Fields.First(x => x.Guids.Contains(Helper.Constants.Javascripts.Fields.Text)).ValueAsLongText;
                        javaScript.ArtifactID = resultArtifact.ArtifactID;
                        var viewModeChoiceField = resultArtifact.Fields.First(x => x.Guids.Contains(Helper.Constants.Javascripts.Fields.ViewMode)).ValueAsSingleChoice;
                        

                        javaScript.ViewMode = JavaScriptBlock.ViewModeValue.All;
                        if (viewModeChoiceField != null)
                        {
                            var viewModeChoice = client.Repositories.Choice.ReadSingle(viewModeChoiceField.ArtifactID);
                            if (viewModeChoice.Guids.Contains(Helper.Constants.Javascripts.Choices.ViewMode.ViewOnly))
                            {
                                javaScript.ViewMode = JavaScriptBlock.ViewModeValue.ViewOnly;
                            }
                            else if (viewModeChoice.Guids.Contains(Helper.Constants.Javascripts.Choices.ViewMode.EditOnly))
                            {
                                javaScript.ViewMode = JavaScriptBlock.ViewModeValue.EditOnly;
                            }
                        }
                        javaScriptBlocks.Add(javaScript);


                        //var jS = new JavaScripts();
                        //jS.text = text;
                    }
                }
                else
                {
                    Console.WriteLine(string.Format("An error occurred reading results: {0}", ActiveJavaScriptsResults.Message));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("An error occurred: {0}", ex.Message));
            }

            return javaScriptBlocks;
        }
    }
}
