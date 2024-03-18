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
            renderer.PushIndent(obj.QuoteChar + " ");
            for (int i = 0; i < obj.Count; i++)
            {
                Block b = obj[i];
                renderer.Write(b);

                if (i == obj.Count - 1) break;
                renderer.WriteLine();
            }
            renderer.PopIndent();
        }
    }
}
