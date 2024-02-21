namespace gentatechnology.llm.Configs
{
    public struct QuantizationConfig
    {
        public string dtype;
        public string qformat;
        public int calibSize;
        public string lang;

        public QuantizationConfig(
            string dtype = "float16", string qformat = "int4_awq", int calibSize = 32, string lang = "id"
        )
        {
            this.dtype = dtype;
            this.qformat = qformat;
            this.calibSize = calibSize;
            this.lang = lang;
        }
    }
}
