#nullable enable
using System.ComponentModel;
using Shouldly;

namespace FizzBuzzter
{
    public class BuildFizzBuzzterChainIncrementallyTests
    {
        [Fact]
        public void Should_have_at_least_the_DefaultFizzBusterHandler()
        {
            BuildFizzBuzzterChainIncrementally x = new();
            FizzBuzzterHandler handler = x.Build();

            handler.ShouldBeOfType<DefaultFizzBuzzterHandler>();
            handler.Next.ShouldBeNull();
        }

        [Fact]
        public void Should_build_the_chain_for_two_GenericFizzBuzzterHandlers()
        {
            BuildFizzBuzzterChainIncrementally chainBuilder = new();
            chainBuilder.CreateHandlerFor(3, "Tom");
            chainBuilder.CreateHandlerFor(new DivisorWord(5, "Opgenorth"));

            FizzBuzzterHandler handler = chainBuilder.Build();
            handler.ShouldHaveChainLength(3); // [TO20251003] Two Generic + 1 Default
            handler.ShouldBeGenericFizzBuzzterHandler(3, "Tom");

            FizzBuzzterHandler? link2 = handler.Next;
            link2.ShouldBeGenericFizzBuzzterHandler(5, "Opgenorth");

            // [TO20251003] Make sure that we terminate the chain with the DefaultFizzBuzzterHandler.
            FizzBuzzterHandler? link3 = link2?.Next;
            link3.ShouldBeOfType<DefaultFizzBuzzterHandler>();

            link3.Next.ShouldBeNull();
        }
    }
}
