// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Markdig.Syntax;
using Markdig.Syntax.Inlines;

namespace Microsoft.PowerShell.MarkdownRender
{
    /// <summary>
    /// Renderer for adding VT100 escape sequences for paragraphs.
    /// </summary>
    internal class MarkdownDocumentRenderer : VT100ObjectRenderer<MarkdownDocument>
    {
        protected override void Write(VT100Renderer renderer, MarkdownDocument obj)
        {
            bool f = true;
            foreach (Block item in obj)
            {
                if (item.Span.IsEmpty) continue;

                if (f) f = false;
                else renderer.WriteLine();

                renderer.Write(item);
                renderer.WriteLine();
            }
        }
    }
}
