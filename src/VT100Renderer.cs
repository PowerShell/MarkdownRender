// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.IO;
using Markdig.Renderers;
using Markdig.Syntax;

namespace Microsoft.PowerShell.MarkdownRender
{
    /// <summary>
    /// Initializes an instance of the VT100 renderer.
    /// </summary>
    public sealed class VT100Renderer : TextRendererBase<VT100Renderer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VT100Renderer"/> class.
        /// </summary>
        /// <param name="writer">TextWriter to write to.</param>
        /// <param name="optionInfo">PSMarkdownOptionInfo object with options.</param>
        public VT100Renderer(TextWriter writer, PSMarkdownOptionInfo optionInfo) : base(writer)
        {
            EscapeSequences = new VT100EscapeSequences(optionInfo);

            // Root Renderer to handle element spacing
            ObjectRenderers.Add(new MarkdownDocumentRenderer());

            // Add the various element renderers.
            ObjectRenderers.Add(new HeaderBlockRenderer());
            ObjectRenderers.Add(new LineBreakRenderer());
            ObjectRenderers.Add(new CodeInlineRenderer());
            ObjectRenderers.Add(new FencedCodeBlockRenderer());
            ObjectRenderers.Add(new EmphasisInlineRenderer());
            ObjectRenderers.Add(new ParagraphBlockRenderer());
            ObjectRenderers.Add(new LeafInlineRenderer());
            ObjectRenderers.Add(new LinkInlineRenderer());
            ObjectRenderers.Add(new ListBlockRenderer());
            ObjectRenderers.Add(new ListItemBlockRenderer());
            ObjectRenderers.Add(new QuoteBlockRenderer());

            // Table
            ObjectRenderers.Add(new TableRenderer());
        }

        /// <summary>
        /// Gets the current escape sequences.
        /// </summary>
        public VT100EscapeSequences EscapeSequences { get; }

        /// <summary>
        /// Modify the container block to remove empty children and write the children
        /// 
        /// Then write children excluding last line break
        /// </summary>
        public void WriteChildrenJoinNewLine(ContainerBlock obj)
        {
            bool f = true;
            foreach (Block b in obj)
            {
                if (b.Span.IsEmpty) continue;

                if (f) f = false;
                else WriteLine();

                Write(b);
            }
        }
    }
}
