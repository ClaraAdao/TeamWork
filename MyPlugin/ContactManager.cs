using SharedProject.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Messages;

namespace MyPlugin
{
    public class ContactManager : PluginImplement
    {

        public override void ExecutePlugin(IServiceProvider serviceProvider)
        {

            Entity contato = this.Context.Stage == 10 ? (Entity)Context.InputParameters["Target"] : (Entity)this.Context.PostEntityImages["PostImage"];

            //10 = Pre-Validation
            //20 - Pre-Operation
            //30 - Post-Operation

            if (Context.Stage == (int)SharedProject.Models.Enumerator.PluginStages.PreValidation)
            {
                string cnpj = contato["dyp_cpf"].ToString();

                QueryExpression recuperarContatoComCnpj = new QueryExpression("contact");
                recuperarContatoComCnpj.Criteria.AddCondition("dyp_cpf", ConditionOperator.Equal, cnpj);
                EntityCollection contatos = this.Service.RetrieveMultiple(recuperarContatoComCnpj);

                if (contatos.Entities.Count() > 0)
                {
                    throw new InvalidPluginExecutionException("CPF já cadastrado, tente novamente!");
                }
            }
        }
    }
}

