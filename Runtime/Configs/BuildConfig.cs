namespace gentatechnology.llm.Configs
{
    public struct BuildConfig
    {
        public string dtype;
        public string useGptAttentionPlugin;
        public string useGemmPlugin;
        public string weightOnlyPrecision;

        public int maxInputLength;
        public int maxOutputLength;

        public bool removeInputPadding;
        public bool enableContextFMHA;
        public bool useWeightOnly;
        public bool perGroup;
        public bool useInflightBatching;
        public bool pagedKvCache;

        public BuildConfig(
            string dtype = "float16", string useGptAttentionPlugin = "float16", string useGemmPlugin = "float16",
            string weightOnlyPrecision = "int_4_awq", int maxInputLength = 3696, int maxOutputLength = 4096,
            bool removeInputPadding = true, bool enableContextFMHA = true, bool useWeightOnly = true,
            bool perGroup = true, bool useInflightBatching = true, bool pagedKvCache = true
        )
        {
            this.dtype = dtype;
            this.useGptAttentionPlugin = useGptAttentionPlugin;
            this.useGemmPlugin = useGemmPlugin;
            this.weightOnlyPrecision = weightOnlyPrecision;
            this.maxInputLength = maxInputLength;
            this.maxOutputLength = maxOutputLength;
            this.removeInputPadding = removeInputPadding;
            this.enableContextFMHA = enableContextFMHA;
            this.useWeightOnly = useWeightOnly;
            this.perGroup = perGroup;
            this.useInflightBatching = useInflightBatching;
            this.pagedKvCache = pagedKvCache;
        }
    }
}