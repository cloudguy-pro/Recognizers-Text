﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

using Microsoft.Recognizers.Definitions.Italian;

namespace Microsoft.Recognizers.Text.Number.Italian
{
    public class DoubleExtractor : BaseNumberExtractor
    {
        internal sealed override ImmutableDictionary<Regex, TypeTag> Regexes { get; }

        protected sealed override string ExtractType { get; } = Constants.SYS_NUM_DOUBLE;

        public DoubleExtractor(string placeholder = NumbersDefinitions.PlaceHolderDefault)
        {
            this.Regexes = new Dictionary<Regex, TypeTag>
            {
                {
                    new Regex(NumbersDefinitions.DoubleDecimalPointRegex(placeholder), RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    RegexTagGenerator.GenerateRegexTag(Constants.DOUBLE_PREFIX, Constants.NUMBER_SUFFIX)
                },
                {
                    new Regex(NumbersDefinitions.DoubleWithoutIntegralRegex(placeholder), RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    RegexTagGenerator.GenerateRegexTag(Constants.DOUBLE_PREFIX, Constants.NUMBER_SUFFIX)
                },
                {
                    new Regex(NumbersDefinitions.DoubleWithMultiplierRegex, RegexOptions.Singleline),
                    RegexTagGenerator.GenerateRegexTag(Constants.DOUBLE_PREFIX, Constants.NUMBER_SUFFIX)
                },
                {
                    new Regex(NumbersDefinitions.DoubleWithRoundNumber, RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    RegexTagGenerator.GenerateRegexTag(Constants.DOUBLE_PREFIX, Constants.NUMBER_SUFFIX)
                },
                {
                    new Regex(NumbersDefinitions.DoubleAllFloatRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    RegexTagGenerator.GenerateRegexTag(Constants.DOUBLE_PREFIX, Constants.ITALIAN)
                },
                {
                    new Regex(NumbersDefinitions.DoubleExponentialNotationRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    RegexTagGenerator.GenerateRegexTag(Constants.DOUBLE_PREFIX, Constants.POWER_SUFFIX)
                },
                {
                    new Regex(NumbersDefinitions.DoubleCaretExponentialNotationRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline),
                    RegexTagGenerator.GenerateRegexTag(Constants.DOUBLE_PREFIX, Constants.POWER_SUFFIX)
                },
                {
                    GenerateLongFormatNumberRegexes(LongFormatType.DoubleNumDotComma, placeholder),
                    RegexTagGenerator.GenerateRegexTag(Constants.DOUBLE_PREFIX, Constants.NUMBER_SUFFIX)
                },
                {
                    GenerateLongFormatNumberRegexes(LongFormatType.DoubleNumNoBreakSpaceComma, placeholder),
                    RegexTagGenerator.GenerateRegexTag(Constants.DOUBLE_PREFIX, Constants.NUMBER_SUFFIX)
                }
            }.ToImmutableDictionary();
        }

    }
}
