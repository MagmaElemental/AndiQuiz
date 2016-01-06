namespace UniversalQuizBackEnd.Web.Wcf
{
    using UniversalQuizBackEnd.Web.Wcf.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Users : BaseService, IUsers
    {
        public IEnumerable<ListedUserModel> GetAll(string page)
        {
            var pageAsNumber = int.Parse(page);

            return this.Users
                .All()
                .OrderBy(u => u.Email)
                .Skip(pageAsNumber * 10)
                .Take(10)
                .Select(u => new ListedUserModel
                {
                    Username = u.UserName,
                    Rating = u.Rank
                })
                .ToList();
        }
    }
}
