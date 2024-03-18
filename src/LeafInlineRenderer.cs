// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Markdig.Syntax.Inlines;

namespace Microsoft.PowerShell.MarkdownRender
{
    /// <summary>
    /// Renderer for adding VT100 escape sequences for leaf elements like plain text in paragraphs.
    /// </summary>
    internal class LeafInlineRenderer : VT100ObjectRenderer<LeafInline>
    {
        protected override void Write(VT100Renderer renderer, LeafInline obj)
        {
            renderer.Write(obj.ToString());
        }
    }
}
