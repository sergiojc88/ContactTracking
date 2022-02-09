using System.Collections.Generic;
using System.Linq;
using ContactTracking.Models;

namespace ContactTracking.Repository
{
    public class RPCandidate
    {
        public static List<Candidate> _listCandidates = new List<Candidate>()
        {
            new Candidate() { Id = 1, FirstName = "Silvester" , LastName = "Apellido 1", EmailAddress = "canditate@gmail.com", PhoneNumber="15346", ResidentialZipCode = "fort lauderdale 12" },
            new Candidate() { Id = 2, FirstName = "Jhon" , LastName = "Apellido 2", EmailAddress = "jhon@gmail.com", PhoneNumber="142357", ResidentialZipCode = "Florida 12" },
            new Candidate() { Id = 3, FirstName = "Bryan" , LastName = "Apellido 3", EmailAddress = "bryan@gmail.com", PhoneNumber="9523356", ResidentialZipCode = "Silversprings 12" }
        };

        public IEnumerable<Candidate> ObtenerClientes()
        {
            return _listCandidates;
        }

        public Candidate ObtenerCliente(int id)
        {
            var candidate = _listCandidates.Where(cli => cli.Id == id);

            return candidate.FirstOrDefault();
        }

        public void Agregar(Candidate newCandidate)
        {
            _listCandidates.Add(newCandidate);
        }

        public IEnumerable<Candidate> searchCandidate(int id, string fname, string lname, string email, string phone, string residential)
        {
            var candidate = _listCandidates.Where(cli => cli.Id == id || cli.FirstName == fname || cli.LastName == lname || cli.EmailAddress == email || cli.PhoneNumber == phone || cli.ResidentialZipCode == residential);

            return candidate;
        }
    }
}
