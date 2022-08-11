using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedProject.Models
{
    public class Contato
    {
        public IOrganizationService Service { get; set; }

        public Contato(IOrganizationService service)
        {
            this.Service = service;
        }

        private void Create(Guid accountId)
        {
            Entity contato = new Entity("contact");
            contato["dyp_cpf"] = 12345678910;
            contato["firstname"] = "Teste";
            contato["lastname"] = "Conexão";
            this.Service.Create(contato);
        }

        internal EntityCollection RecuperarContatosPorIdDaConta(Guid id, string[] strings)
        {
            throw new NotImplementedException();
        }
    }
}
