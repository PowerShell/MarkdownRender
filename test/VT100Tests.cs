using System;
using System.Runtime.InteropServices;
using Microsoft.PowerShell.MarkdownRender;
using Xunit;

namespace Microsoft.PowerShell.MarkdownRender.Tests
{
    public class VT100Tests
    {
        private const char Esc = (char)0x1b;

        [Fact]
        public void CodeInline()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("`Hello`", MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? $"{Esc}[107;95mHello{Esc}[0m\n" : $"{Esc}[48;2;155;155;155;38;2;30;30;30mHello{Esc}[0m\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void EmphasisInlineBold()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("**Hello**", MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = $"{Esc}[1mHello{Esc}[0m\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void EmphasisInlineItalics()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("*Hello*", MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = $"{Esc}[36mHello{Esc}[0m\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void FencedCodeBlock()
        {
            string inputString = "```PowerShell\n$a = 1\n```";
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert(inputString, MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? $"{Esc}[107;95m$a = 1{Esc}[500@{Esc}[0m\n\n" : $"{Esc}[48;2;155;155;155;38;2;30;30;30m$a = 1{Esc}[500@{Esc}[0m\n\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void Header1()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("# Heading1", MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = $"{Esc}[7mHeading1{Esc}[0m\n\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void Header2()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("## Heading2", MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = $"{Esc}[4;93mHeading2{Esc}[0m\n\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void Header3()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("### Heading3", MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = $"{Esc}[4;94mHeading3{Esc}[0m\n\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void Header4()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("#### Heading4", MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = $"{Esc}[4;95mHeading4{Esc}[0m\n\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void Header5()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("##### Heading5", MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = $"{Esc}[4;96mHeading5{Esc}[0m\n\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void Header6()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("###### Heading6", MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = $"{Esc}[4;97mHeading6{Esc}[0m\n\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void LinkUrl()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("[Bing](https://www.bing.com)", MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = $"{Esc}[4;38;5;117m\"Bing\"{Esc}[0m\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void LinkImage()
        {
            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert("![](image.png)", MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = $"{Esc}[33m[Image]{Esc}[0m\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void OrderedList()
        {
            string inputString = "1. A\n2. B\n3. C\n";

            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert(inputString, MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = $"1. A\n2. B\n3. C\n\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void UnorderedList()
        {
            string inputString = "* A\n* B\n* C\n";

            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert(inputString, MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = $"* A\n* B\n* C\n\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }

        [Fact]
        public void QuoteBlock()
        {
            string inputString = "> Hello";

            var m = Microsoft.PowerShell.MarkdownRender.MarkdownConverter.Convert(inputString, MarkdownConversionType.VT100, new PSMarkdownOptionInfo() );
            string expected = $"> Hello\n\n\n";
            Assert.Equal(expected, m.VT100EncodedString);
        }
    }

    public class PSMarkdownOptionInfoTests
    {
        private void ValidateDarkTheme(PSMarkdownOptionInfo opt)
        {
            bool expectedEnableVT100 = !RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || Environment.OSVersion.Version.Major >= 10;

            Assert.Equal("[1m", opt.EmphasisBold);
            Assert.Equal("[36m", opt.EmphasisItalics);
            Assert.Equal(expectedEnableVT100, opt.EnableVT100Encoding);
            Assert.Equal("[7m", opt.Header1);
            Assert.Equal("[4;93m", opt.Header2);
            Assert.Equal("[4;94m", opt.Header3);
            Assert.Equal("[4;95m", opt.Header4);
            Assert.Equal("[4;96m", opt.Header5);
            Assert.Equal("[4;97m", opt.Header6);
            Assert.Equal("[33m", opt.Image);
            Assert.Equal("[4;38;5;117m", opt.Link);

            string expectedCode = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "[107;95m" : "[48;2;155;155;155;38;2;30;30;30m";
            Assert.Equal(expectedCode, opt.Code);
        }

        private void ValidateLightTheme(PSMarkdownOptionInfo opt)
        {
            bool expectedEnableVT100 = !RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || Environment.OSVersion.Version.Major >= 10;

            Assert.Equal("[1m", opt.EmphasisBold);
            Assert.Equal("[36m", opt.EmphasisItalics);
            Assert.Equal(expectedEnableVT100, opt.EnableVT100Encoding);
            Assert.Equal("[7m", opt.Header1);
            Assert.Equal("[4;33m", opt.Header2);
            Assert.Equal("[4;34m", opt.Header3);
            Assert.Equal("[4;35m", opt.Header4);
            Assert.Equal("[4;36m", opt.Header5);
            Assert.Equal("[4;30m", opt.Header6);
            Assert.Equal("[33m", opt.Image);
            Assert.Equal("[4;38;5;117m", opt.Link);

            string expectedCode = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "[107;95m" : "[48;2;155;155;155;38;2;30;30;30m";
            Assert.Equal(expectedCode, opt.Code);
        }

        [Fact]
        public void PSMarkdownOptionInfo_Default()
        {
            var opt = new PSMarkdownOptionInfo();
            ValidateDarkTheme(opt);
        }

        [Fact]
        public void PSMarkdownOptionInfo_LightTheme()
        {
            var opt = new PSMarkdownOptionInfo();
            opt.SetLightTheme();
            ValidateLightTheme(opt);
        }
    }
}