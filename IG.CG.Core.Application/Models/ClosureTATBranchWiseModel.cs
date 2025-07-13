using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IG.CG.Core.Application.Models
{
    public class ClosureTATBranchWiseModel
    {
        public string? Region { get; set; }
        public string? Branch { get; set; }
        public string? ProductDivision { get; set; }
        public string? ProductLine { get; set; }
        public string? TotalTicketsCancelledTickets { get; set; }

        public string? TwentyFourHoursTATCount { get; set; }

        public string? TwentyFourHoursTATPercentage { get; set; }

        public string? TwentyFourFourtyEightHoursTATCount { get; set; }

        public string? TwentyFourFourtyEightHoursTATPercentage { get; set; }

        public string? FoutyEightSeventyTwoHoursTATCount { get; set; }

        public string? FoutyEightSeventyTwoHoursTATPercentage { get; set; }

        public string? CummulativeCloserCountZeroSeventyTwoHours { get; set; }

        public string? CummulativeCloserCountzeroseventytwohoursTATPercentage { get; set; }

        public string? SeventyTwoOneTwentyHoursTATCount { get; set; }

        public string? SeventyTwoOneTwentyHoursTATPercentage { get; set; }

        public string? OneTwentyOneSixtyEightHoursTATCount { get; set; }

        public string? OneTwentyOneSixtyEightHoursTATPercentage { get; set; }

        public string? GreaterOneSixtyEightHoursTATCount { get; set; }
        public string? GreaterOneSixtyEightHoursTATPercentage { get; set; }

        public string? CummulativeCloserCountAboveSeventyTwoHours { get; set; }

        public string? CummulativeCloserCountAboveSeventyTwoHoursTATPercentage { get; set; }

        public string? TotalClosedTicketsCount { get; set; }
        public string? TotalClosedTicketsCountPercentage { get; set; }

        public string? OpenCount { get; set; }

        public string? OpenPercentage { get; set; }

        public string? CancelCount { get; set; }

        public string? CancelPercentage { get; set; }
    }
}
