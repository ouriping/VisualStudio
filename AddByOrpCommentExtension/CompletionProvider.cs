using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Language.Intellisense.AsyncCompletion;
using Microsoft.VisualStudio.Language.Intellisense.AsyncCompletion.Data;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace AddByOrpCommentExtension
{
    [Export(typeof(IAsyncCompletionSourceProvider))]
    [ContentType("CSharp")]
    [Name("AddByOrp Completion Provider")]
    internal class CompletionSourceProvider : IAsyncCompletionSourceProvider
    {
        public IAsyncCompletionSource GetOrCreate(ITextView textView)
        {
            if (!textView.Properties.TryGetProperty(typeof(CompletionSource), out CompletionSource source))
            {
                source = new CompletionSource();
                textView.Properties.AddProperty(typeof(CompletionSource), source);
            }
            return source;
        }
    }

    internal class CompletionSource : IAsyncCompletionSource
    {
        public CompletionStartData InitializeCompletion(CompletionTrigger trigger, SnapshotPoint triggerLocation, CancellationToken token)
        {
            // Check if we should trigger completion
            var line = triggerLocation.GetContainingLine();
            var lineText = line.GetText().Substring(0, triggerLocation.Position - line.Start);

            // Trigger on "addbyorp" text
            if (lineText.EndsWith("addbyorp", StringComparison.OrdinalIgnoreCase))
            {
                int startPosition = lineText.LastIndexOf("addbyorp", StringComparison.OrdinalIgnoreCase);
                return new CompletionStartData(
                    CompletionParticipation.ProvidesItems,
                    new SnapshotSpan(line.Start + startPosition, line.Start + lineText.Length)
                );
            }

            return CompletionStartData.DoesNotParticipateInCompletion;
        }

        public async Task<CompletionContext> GetCompletionContextAsync(IAsyncCompletionSession session, CompletionTrigger trigger, SnapshotPoint triggerLocation, SnapshotSpan applicableToSpan, CancellationToken token)
        {
            var items = new List<CompletionItem>();

            // Generate the current date/time formatted comment
            var currentDateTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            var commentText = $"// add by orp {currentDateTime}";

            var item = new CompletionItem(
                displayText: commentText,
                source: this,
                icon: null,
                filters: ImmutableArray<CompletionFilter>.Empty,
                suffix: "",
                insertText: commentText,
                sortText: "aaa_add_by_orp",
                filterText: "addbyorp"
            );

            items.Add(item);

            return new CompletionContext(items.ToImmutableArray());
        }

        public Task<object> GetDescriptionAsync(IAsyncCompletionSession session, CompletionItem item, CancellationToken token)
        {
            var description = "Insert a comment with current date and time: // add by orp YYYY.MM.DD HH:mm:ss";
            return Task.FromResult<object>(description);
        }
    }
}
