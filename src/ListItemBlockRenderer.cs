// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Threading;
using Markdig.Syntax;

namespace Microsoft.PowerShell.MarkdownRender
{
    /// <summary>
    /// Renderer for adding VT100 escape sequences for items in a list block.
    /// </summary>
    internal class ListItemBlockRenderer : VT100ObjectRenderer<ListItemBlock>
    {
        protected override void Write(VT100Renderer renderer, ListItemBlock obj)
        {
            // 2 spaces for indentation
            renderer.PushIndent("  ");
            renderer.WriteChildrenJoinNewLine(obj);
            renderer.PopIndent();
        }
    }
}
