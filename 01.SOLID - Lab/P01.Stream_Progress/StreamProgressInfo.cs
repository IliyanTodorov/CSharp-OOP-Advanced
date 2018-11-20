using System;
using System.Collections.Generic;
using System.Text;
using P01.Stream_Progress.Contracts;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo : IStreamable
    {
        private IStreamable streamable;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamable streamable)
        {
            this.streamable = streamable;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamable.BytesSent * 100) /
                   this.streamable.Length;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
