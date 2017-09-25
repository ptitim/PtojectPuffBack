using System;
using System.Net;
using Service;
using Service.DTO;
using Xunit;

namespace UnitTest
{
    public class UnitTestTreatment
    {


        /// <summary>
        /// test the merge of two treatment with all of their list not empty
        /// T01
        /// </summary>
        [Fact]
        public void TestMergeValidAllData()
        {
            Console.WriteLine("Begining Test treatment T01");
            var trA = new Treatment();
            var trB = new Treatment();
            
            trA.AddFatalErrorWithCode(HttpStatusCode.Accepted, "hehe");
            trB.AddFatalErrorWithCode(HttpStatusCode.Accepted, "hehe");
            
            trA.AddErrorWithCode(HttpStatusCode.Accepted, "hehe");
            trB.AddErrorWithCode(HttpStatusCode.Accepted, "hehe");
            
            trA.AddWarningWithCode(HttpStatusCode.Accepted, "hehe");
            trB.AddWarningWithCode(HttpStatusCode.Accepted, "hehe");
            
            trA.AddInfoWithCode(HttpStatusCode.Accepted, "hehe");
            trB.AddInfoWithCode(HttpStatusCode.Accepted, "hehe");
            
//            trA.AddObject(new {Id = 1});
//            trB.AddObject(new {test = "not a test"});

            var trMerged = trA.Merge(trB);
            
            Assert.NotEmpty(trMerged.FatalErrors);
            Assert.NotEmpty(trMerged.Errors);
            Assert.NotEmpty(trMerged.Warnings);
            Assert.NotEmpty(trMerged.Info);
            Assert.NotEmpty(trMerged.Objects);
            Console.WriteLine("End of Test treatment T01");
        }

        [Fact]
        public void AddingTwoObjectDifferentType()
        {
            var tr = new Treatment();
            
            tr.AddObject(new EventDto());
            tr.AddObject(new UserDto());

            Assert.IsType<EventDto>(tr.Objects[0]);
            Assert.IsType<UserDto>(tr.Objects[1]);
        }

    }
}