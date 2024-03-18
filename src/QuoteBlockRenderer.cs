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
            renderer.WriteChildrenJoinNewLine(obj);
            renderer.PopIndent();
        }
    }
}
