using gentatechnology.llm.Configs;
using UnityEngine;

namespace gentatechnology.llm
{
    [CreateAssetMenu(fileName = "Model", menuName = "LLM/Model")]
    public class Model : ScriptableObject
    {
        public string modelName { get; private set; }
        public string author { get; private set; }
        public string id { get; private set; }

        private BuildConfig buildConfig;
        private QuantizationConfig quantizationConfig;

        private string localPath;

        /// <summary>
        /// Initializes a new instance of the Model class with the specified name, author, id, build configuration, and quantization configuration.
        /// </summary>
        /// <param name="name">The name of the model.</param>
        /// <param name="author">The author of the model.</param>
        /// <param name="id">The unique identifier of the model.</param>
        /// <param name="buildConfig">The build configuration for the model.</param>
        /// <param name="quantizationConfig">The quantization configuration for the model.</param>
        public Model(
            string name, string author, string id, 
            BuildConfig buildConfig, QuantizationConfig quantizationConfig
        )
        {
            // TODO: download model from huggingface to a temporary directory
            // TODO: validate if the model is downloaded successfully
            // TODO: compile the model into tensorrt engine
            // TODO: validate if the model is compiled successfully

            // stub
        }

        /// <summary>
        /// Set the local path of the model
        /// </summary>
        /// <param name="path">path to the model directory</param>
        public void SetLocalPath(string path)
        {
            // TODO: validate path exists
            // TODO: validate if the path contains .engine file
            // TODO: validate if the path contains required tokenizers files

            localPath = path;
        }

        /// <summary>
        /// Build the model with the specified build configuration and quantization configuration.
        /// </summary>
        /// <param name="buildConfig">The build configuration for the model.</param>
        /// <param name="quantizationConfig">The quantization configuration for the model.</param>
        public void Build(BuildConfig buildConfig, QuantizationConfig quantizationConfig)
        {

        }

        /// <summary>
        /// Build the model with the default build configuration and quantization configuration.
        /// </summary>
        public void Build()
        {

        }

        /// <summary>
        /// Load the model from the local path
        /// </summary>
        public void Load()
        {

        }

        /// <summary>
        /// Generates a text based on the provided prompt using the model. The generated text will have a length between the specified minimum length and maximum tokens. 
        /// The temperature, topP, and topK parameters control the randomness and diversity of the generated text.
        /// </summary>
        /// <param name="prompt">The initial text to which the model should generate a continuation.</param>
        /// <param name="minLength">The minimum length of the generated text. Default is 128.</param>
        /// <param name="maxTokens">The maximum length of the generated text in tokens. Default is 256.</param>
        /// <param name="temperature">Controls the randomness of the predictions. A higher value produces more random outputs. Default is 0.7.</param>
        /// <param name="topP">Used in nucleus sampling, denotes the cumulative probability cutoff. Default is 0.</param>
        /// <param name="topK">Used in top-k sampling, denotes the number of highest probability vocabulary tokens to keep for sampling. Default is 0.</param>
        /// <returns>The generated text.</returns>
        public string Generate(
            string prompt, int minLength = 128, int maxTokens = 256, 
            float temperature = 0.7f, float topP = 0, float topK = 0
        )
        {
            return ""; // stub
        }
    }
}