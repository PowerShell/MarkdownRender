// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Markdig.Syntax;

namespace Microsoft.PowerShell.MarkdownRender
{
    /// <summary>
    /// Renderer for adding VT100 escape sequences for quote blocks.
    /// </summary>
    internal class QuoteBlockRenderer : VT100ObjectRenderer<QuoteBlock>
    {
        protected override void Write(VT100Renderer renderer, QuoteBlock obj)
        {
            // Iterate through each item and add the quote character before the content.
            foreach (var item in obj)
            {
                renderer.Write(obj.QuoteChar).Write(" ").Write(item);
            }

            // Add blank line after the quote block.
            renderer.WriteLine();
        }
    }
}
