using System.Collections.Generic;

namespace Jaeger.Core.Samplers
{
    // ConstSampler is a sampler that always makes the same decision.
    public class ConstSampler : ISampler
    {
        public bool Decision { get; }

        private readonly Dictionary<string, object> _tags;

        public ConstSampler(bool sample)
        {
            Decision = sample;
            _tags = new Dictionary<string, object> {
                { SamplerConstants.SamplerTypeTagKey, SamplerConstants.SamplerTypeConst },
                { SamplerConstants.SamplerParamTagKey, sample }
            };
        }

        public void Dispose()
        {
            // nothing to do
        }

        public (bool Sampled, Dictionary<string, object> Tags) IsSampled(TraceId id, string operation)
        {
            return (Decision, _tags);
        }
    }
}
