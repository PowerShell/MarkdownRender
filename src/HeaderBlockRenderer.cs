// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Markdig.Syntax;

namespace Microsoft.PowerShell.MarkdownRender
{
    /// <summary>
    /// Renderer for adding VT100 escape sequences for headings.
    /// </summary>
    internal class HeaderBlockRenderer : VT100ObjectRenderer<HeadingBlock>
    {
        protected override void Write(VT100Renderer renderer, HeadingBlock obj)
        {
            string headerText = obj?.Inline?.FirstChild?.ToString();

            if (!string.IsNullOrEmpty(headerText))
            {
                // Format header and then add blank line to improve readability.
                switch (obj.Level)
                {
                    case 1:
                        renderer.Write(renderer.EscapeSequences.FormatHeader1(headerText));
                        break;

                    case 2:
                        renderer.Write(renderer.EscapeSequences.FormatHeader2(headerText));
                        break;

                    case 3:
                        renderer.Write(renderer.EscapeSequences.FormatHeader3(headerText));
                        break;

                    case 4:
                        renderer.Write(renderer.EscapeSequences.FormatHeader4(headerText));
                        break;

                    case 5:
                        renderer.Write(renderer.EscapeSequences.FormatHeader5(headerText));
                        break;

                    case 6:
                        renderer.Write(renderer.EscapeSequences.FormatHeader6(headerText));
                        break;
                }
            }
        }
    }
}
