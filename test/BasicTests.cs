using System;
using Microsoft.PowerShell.MarkdownRender;
using Xunit;

namespace Microsoft.PowerShell.MarkdownRender.Tests
{
    public class BasicTests
    {
        private const char Esc = (char)0x1b;

        [Fact]
        public void VT100Renderer()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("# Heading1", MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = $"{Esc}[7mHeading1{Esc}[0m\n\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void HTMLRenderer()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("# Heading1", MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<h1 id=\"heading1\">Heading1</h1>\n";
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void AST_Is_Not_Null()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("# Heading1", MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            Assert.NotNull(m.Tokens);
        }
    }
}
