using System.Net.Sockets;
using HelloWorld.App;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace HelloWorld.Tests
{
    [Subject(typeof (ISomeGuy))]
    public class SomeGuySpecs
    {
        public abstract class concern : Observes<ISomeGuy, SomeGuy>
        {
        }

        public class when_observation_name : concern
        {
            Because b = () =>
                result = sut.talk();

            It should_return_what_i_expect_it = () =>
                result.ShouldEqual("Hello, World!");

            static string result;
        }
    }
}
