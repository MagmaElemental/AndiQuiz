using UniversalQuizBackEnd.Web.Wcf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace UniversalQuizBackEnd.Web.Wcf
{
    [ServiceContract]
    public interface IUsers
    {
        [OperationContract]
        [WebInvoke(Method = "Get", UriTemplate = "users/top.svc")]
        IEnumerable<ListedUserModel> GetAll(string page);
    }
}
