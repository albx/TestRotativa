using System;
using Xunit;

namespace TestRotativa.Acl.Tests
{
    public class RotativaPdfPrinterTests
    {
        [Fact]
        public void Ctor_should_throw_ArgumentNullException_if_environment_is_null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new RotativaPdfPrinter(null));
            Assert.Equal("environment", ex.ParamName);
        }
    }
}
