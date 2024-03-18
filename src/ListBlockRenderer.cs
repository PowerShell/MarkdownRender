// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Markdig.Syntax;

namespace Microsoft.PowerShell.MarkdownRender
{
    /// <summary>
    /// Renderer for adding VT100 escape sequences for list blocks.
    /// </summary>
    internal class ListBlockRenderer : VT100ObjectRenderer<ListBlock>
    {
        protected override void Write(VT100Renderer renderer, ListBlock obj)
        {
            for (int idx = 0; idx < obj.Count; idx++)
            {
                if (idx > 0) renderer.WriteLine();

                Block block = obj[idx];

                if (obj.IsOrdered)
                {
                    renderer.Write((idx + 1).ToString()).Write(". ");
                }
                else
                {
                    renderer.Write(obj.BulletType).Write(" ");
                }

                renderer.Write(block);

            }
        }
    }
}
