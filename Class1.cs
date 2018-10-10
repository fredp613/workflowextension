
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace WordCountWorkflow
{
    public sealed class CreateAccount : CodeActivity
    {
        [RequiredArgument]
        [Input("Input Text")]
        [Default("Related Account")]
        public InArgument<string> InputText { get; set; }



        protected override void Execute(CodeActivityContext executionContext)
        {

            ITracingService tracingService = executionContext.GetExtension<ITracingService>();

            //Create the context
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);


            tracingService.Trace("Creating Account");
            Entity account = new Entity("account");
            account["name"] = this.InputText.Get<string>(executionContext);
            Guid newAcct = service.Create(account);


            



        }
    }
}
