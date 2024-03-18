// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using Markdig.Helpers;
using Markdig.Syntax;

namespace Microsoft.PowerShell.MarkdownRender
{
    /// <summary>
    /// Renderer for adding VT100 escape sequences for code blocks with language type.
    /// </summary>
    internal class FencedCodeBlockRenderer : VT100ObjectRenderer<FencedCodeBlock>
    {
        protected override void Write(VT100Renderer renderer, FencedCodeBlock obj)
        {
            if (obj?.Lines.Lines != null)
            {
                bool f = true;
                foreach (StringLine codeLine in obj.Lines.Lines)
                {
                    if (!string.IsNullOrWhiteSpace(codeLine.ToString()))
                    {
                        if (f) f = false;
                        else renderer.WriteLine();
                        
                        // If the code block is of type YAML, then tab to right to improve readability.
                        // This specifically helps for parameters help content.
                        if (string.Equals(obj.Info, "yaml", StringComparison.OrdinalIgnoreCase))
                        {
                            renderer.Write("\t").Write(codeLine.ToString());
                        }
                        else
                        {
                            renderer.Write(renderer.EscapeSequences.FormatCode(codeLine.ToString(), isInline: false));
                        }
                    }
                }
            }
        }
    }
}
