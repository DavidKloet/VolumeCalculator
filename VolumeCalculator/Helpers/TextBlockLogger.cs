using Domain.Common;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace VolumeCalculator.Helpers
{
    /// <inheritdoc />
    /// <summary>
    /// Logs messages to the Inlines collection of a <see cref="T:System.Windows.Controls.TextBlock" />
    /// </summary>
    public class TextBlockLogger : ILogger
    {
        private readonly TextBlock _sink;

        public TextBlockLogger(TextBlock sink)
        {
            _sink = sink ?? throw new ArgumentNullException(nameof(sink));
        }

        public void Info(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            var run = new Run(message);

            InsertNewMessage(run);
        }

        public void Error(string error)
        {
            if (error == null) throw new ArgumentNullException(nameof(error));

            var run = new Run(error)
            {
                Foreground = Brushes.Firebrick,
                FontWeight = FontWeights.Bold
            };

            InsertNewMessage(run);
        }

        private void InsertNewMessage(Inline message)
        {
            if (_sink.Inlines.Count > 0)
            {
                _sink.Inlines.InsertBefore(_sink.Inlines.FirstInline, new LineBreak());
                _sink.Inlines.InsertBefore(_sink.Inlines.FirstInline, message);
            }
            else
            {
                _sink.Inlines.Add(message);
            }
        }
    }
}
