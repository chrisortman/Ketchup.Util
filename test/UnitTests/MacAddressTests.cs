using Ketchup.Util.ValueTypes;
using NUnit.Framework;
using Shouldly;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class MacAddressTests
    {
        private MacAddress m1;
        private MacAddress m2;
        private MacAddress m3;
        private MacAddress m4;
        private MacAddress m5;

        [SetUp]
        public void Setup()
        {
            m1 = new MacAddress("0090DB0C6582");
            m2 = new MacAddress("0090DB0C6582");
            m3 = new MacAddress("0090DB0C6589");
            m4 = new MacAddress("0090DB0C6581");
            m5 = new MacAddress("0090DB0C6583");
    
        }

        [Test]
        public void Equality()
        {
        
            (m1 == m2).ShouldBe(true);

            (m3 > m2).ShouldBe(true);
            (m3 != m1).ShouldBe(true);
            m1.Add(1).ShouldBe(m5);
            m1.Subtract(1).ShouldBe(m4);
        }

        [Test]
        public void EqualityNotCaseSensitive()
        {
            (m1 == new MacAddress("0090db0C6582")).ShouldBe(true);
        }

        [Test]
        public void Adjacency()
        {
            var adjacent = m1.Adjacent(2).ToList();

            adjacent.ShouldContain(new MacAddress("0090DB0C6580"));
            adjacent.ShouldContain(new MacAddress("0090DB0C6581"));
            adjacent.ShouldContain(new MacAddress("0090DB0C6583"));
            adjacent.ShouldContain(new MacAddress("0090DB0C6584"));
        }

        [Test]
        public void StringRendering()
        {
            m1.ToString().ShouldBe("0090DB0C6582");
        }

        [Test]
        public void WillPadTo12Chars()
        {
            new MacAddress("90DB0C6582").ToString().ShouldBe("0090DB0C6582");
        }
    }
}