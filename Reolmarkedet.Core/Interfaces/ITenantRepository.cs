using Reolmarkedet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reolmarkedet.Core.Interfaces
{
    public interface ITenantRepository
    {
        Tenant? GetById(int tenantID);
        Tenant? GetByPhone(string phone);
        List<Tenant>? Search(string searchTerm);

        List<Tenant> GetAll();

        int Insert(Tenant tenant);
        void Update(Tenant tenant);
        void Delete(int tenantID);
    }
}

// Hvad har vi brug for i systemet?
// Vi har brug for at kunne hente en lejer ud fra deres ID, og vi har brug for at kunne hente en lejer ud fra deres telefonnummer.
// Vi har også brug for at kunne søge efter lejere ud fra et søgeord f.eks. deres fornavn eller efternavn, og vi har brug for at kunne hente alle lejere.
// Vi har også brug for at kunne indsætte en ny lejer, opdatere en eksisterende lejer og slette en lejer.
// Andet?