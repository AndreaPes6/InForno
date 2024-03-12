using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace InForno.Models
{
    public class RoleManager : RoleProvider
    {

        DBContext db = new DBContext();

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] nomeRuolo)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string nomeRuolo)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string nomeRuolo, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string nomeRuolo, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string utentiId)
        {
            string ruolo = db.Utenti.Where(u => u.ID.ToString() == utentiId).FirstOrDefault().Ruolo;
            string[] ruoli = new string[] { ruolo };
            return ruoli;
        }

        public override string[] GetUsersInRole(string nomeRuolo)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string nomeRuolo)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] nomiRuoli)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string nomeRuolo)
        {
            throw new NotImplementedException();
        }

    }
}