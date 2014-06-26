using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using StringCalculator.App;

namespace StringCalculator.Specs
{
    [Subject(typeof (Calculator))]
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<ICalculator, Calculator>
        {
        }

        public class when_input_is_one_number : concern
        {
            Because b = () =>
                result = sut.add("1");

            It should_return_that_number = () =>
                result.ShouldEqual(1);

            static int result;
        }

        public class when_input_is_two_numbers : concern
        {
            Because b = () =>
                result = sut.add("1,2");

            It should_add_the_numbers = () =>
                result.ShouldEqual(3);

            static int result;
        }
    }
}
