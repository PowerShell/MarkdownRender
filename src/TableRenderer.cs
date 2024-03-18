// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Markdig.Extensions.Tables;
using Markdig.Syntax;

namespace Microsoft.PowerShell.MarkdownRender
{
    /// <summary>
    /// Renderer for adding VT100 escape sequences for quote blocks.
    /// </summary>
    internal class TableRenderer : VT100ObjectRenderer<Table>
    {
        protected override void Write(VT100Renderer renderer, Table table)
        {
            // TODO: improve table rendering
            // Probably have to create a new renderer, render the content as string,
            // and then process the string to table in order to align the columns
            // Additionally, the new rendered content will not have proper length because of
            // VT100 escape sequences, therefore a sanitization step is needed
            // The sanitization regex is currently in VT100Tests.cs:VT100Tests.MarkdownDocument
            // Console column width can be exposed by renderer in order
            // to prevent tables from being wider than console

            for (int i = 0; i < table.Count; i++)
            {
                Block b = table[i];
                if (b.Span.IsEmpty) continue;

                if (i > 0) renderer.WriteLine();
                if (i == 1)
                {
                    if (table[0] is TableRow head)
                    {
                        foreach (var cell in head)
                        {
                            renderer.Write("|-");
                            renderer.Write(new string('-', cell.Span.End - cell.Span.Start));
                        }
                        renderer.Write("|");
                    }
                    renderer.WriteLine();
                }

                if (b is ContainerBlock cb)
                {
                    foreach (var item in cb)
                    {
                        renderer.Write("| ");
                        renderer.Write(item);
                        renderer.Write(" ");
                    }

                    renderer.Write("|");
                } else
                {
                    renderer.Write(b);
                }
            }
        }
    }
}
