using System;
using Microsoft.PowerShell.MarkdownRender;
using Xunit;

namespace Microsoft.PowerShell.MarkdownRender.Tests
{
    public class HTMLTests
    {
        private const char Esc = (char)0x1b;

        [Fact]
        public void CodeInline()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("`Hello`", MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<p><code>Hello</code></p>\n";
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void EmphasisInlineBold()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("**Hello**", MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<p><strong>Hello</strong></p>\n";
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void EmphasisInlineItalics()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("*Hello*", MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<p><em>Hello</em></p>\n";
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void FencedCodeBlock()
        {
            string inputString = "```PowerShell\n$a = 1\n```";
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert(inputString, MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<pre><code class=\"language-PowerShell\">$a = 1\n</code></pre>\n";
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void Header1()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("# Heading1", MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<h1 id=\"heading1\">Heading1</h1>\n";
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void Header2()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("## Heading2", MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<h2 id=\"heading2\">Heading2</h2>\n";
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void Header3()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("### Heading3", MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<h3 id=\"heading3\">Heading3</h3>\n";
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void Header4()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("#### Heading4", MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<h4 id=\"heading4\">Heading4</h4>\n";;
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void Header5()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("##### Heading5", MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<h5 id=\"heading5\">Heading5</h5>\n";;
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void Header6()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("###### Heading6", MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<h6 id=\"heading6\">Heading6</h6>\n";;
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void LinkUrl()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("[Bing](https://www.bing.com)", MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<p><a href=\"https://www.bing.com\">Bing</a></p>\n";
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void LinkImage()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("![](image.png)", MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<p><img src=\"image.png\" alt=\"\" /></p>\n";
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void OrderedList()
        {
            string inputString = "1. A\n2. B\n3. C\n";

            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert(inputString, MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<ol>\n<li>A</li>\n<li>B</li>\n<li>C</li>\n</ol>\n";
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void UnorderedList()
        {
            string inputString = "* A\n* B\n* C\n";

            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert(inputString, MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<ul>\n<li>A</li>\n<li>B</li>\n<li>C</li>\n</ul>\n";
            Assert.Equal(expected, m.Html);
        }

        [Fact]
        public void QuoteBlock()
        {
            string inputString = "> Hello";

            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert(inputString, MarkdownConversionType.HTML, new PSMarkdownOptionInfo() );
            string expected = "<blockquote>\n<p>Hello</p>\n</blockquote>\n";
            Assert.Equal(expected, m.Html);
        }
    }
}