namespace AndiQuiz.Server.Api.Tests.ControllerTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Setups;
    using MyTested.WebApi;
    using System.Collections.Generic;
    using Common.Constants;

    [TestClass]
    public class QuizControllerTests
    {
        //[TestMethod]
        //public void GetShouldReturnRealEstatesWithoutAuthenticatedUser()
        //{
        //    MyWebApi
        //        .Controller<RealEstatesController>()
        //        .WithResolvedDependencies(Services.GetRealEstateService())
        //        .Calling(c => c.Get("1"))
        //        .ShouldReturn()
        //        .Ok()
        //        .WithResponseModelOfType<List<ListedRealEstateResponseModel>>()
        //        .Passing(model => model.Count == QuizConstants.RealEstatePerPage);
        //}

        //[TestMethod]
        //public void GetShouldReturnReturnRealEstatesWithoutAuthenticatedUserAndPaging()
        //{
        //    MyWebApi
        //        .Controller<RealEstatesController>()
        //        .WithResolvedDependencies(Services.GetRealEstateService())
        //        .Calling(c => c.Get("100"))
        //        .ShouldReturn()
        //        .Ok()
        //        .WithResponseModelOfType<List<ListedRealEstateResponseModel>>()
        //        .Passing(model => model.Count == 0);
        //}
    }
}
