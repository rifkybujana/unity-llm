using UnityEngine;
using UnityEditor;
using gentatechnology.llm.Configs;

namespace gentatechnology.llm.Editor
{
    public class ModelComposerEditor : EditorWindow
    {
        private string modelName;
        private string huggingfaceId;
        private string localPath;

        private BuildConfig buildConfig = new BuildConfig();
        private QuantizationConfig quantizationConfig = new QuantizationConfig();

        [MenuItem("Window/Model Composer")]
        public static void ShowWindow()
        {
            // Show existing window instance. If one doesn't exist, make one.
            EditorWindow.GetWindow<ModelComposerEditor>("Model Composer");
        }

        void OnEnable()
        {
            // Set the minimum size of the window to 500 pixels wide and 300 pixels high
            this.minSize = new Vector2(500, 475);
        }

        public void OnGUI()
        {
            GUILayout.BeginVertical();

            // LLM Model Configuration Form
            RenderLLMModelConfigurationForm();
            GUILayout.Space(5); // Add 10 pixels of space

            // Build Configuration Form
            RenderBuildConfigurationForm();
            GUILayout.Space(5); // Add 10 pixels of space

            // Quantization Configuration Form
            RenderQuantizationConfigurationForm();
            GUILayout.Space(10); // Add 10 pixels of space
            GUILayout.FlexibleSpace(); // Add flexible space

            if (GUILayout.Button("Build"))
            {
                Debug.Log("Building model...");
            }

            GUILayout.EndVertical();
        }

        /// <summary>
        /// Renders the LLM Model Configuration form
        /// </summary>
        private void RenderLLMModelConfigurationForm()
        {
            GUILayout.Label("LLM Model Configuration", EditorStyles.boldLabel);
            AddField("Name", ref modelName, "Model Name", "llama_7b");
            AddField("Huggingface ID", ref huggingfaceId, "HuggingFace model ID from https://huggingface.co", "meta-llama/Llama-2-7b-chat-hf");
            AddField("Local Path", ref localPath, "If using localpath, Huggingface ID will be ignored", "Assets/Models/meta-llama/Llama-2-7b-chat-hf/");
        }

        /// <summary>
        /// Renders the Build Configuration form
        /// </summary>
        private void RenderBuildConfigurationForm()
        {
            GUILayout.Label("Build Configuration", EditorStyles.boldLabel);
            AddField("Dtype", ref buildConfig.dtype, "Data type for the model", "float16");
            AddField("Use GPT Attention Plugin", ref buildConfig.useGptAttentionPlugin, "Use GPT Attention Plugin", "float16");
            AddField("Use GEMM Plugin", ref buildConfig.useGemmPlugin, "Use GEMM Plugin", "float16");
            AddField("Weight Only Precision", ref buildConfig.weightOnlyPrecision, "Weight Only Precision", "int_4_awq");
            AddField("Max Input Length", ref buildConfig.maxInputLength, "Max Input Length", 3696);
            AddField("Max Output Length", ref buildConfig.maxOutputLength, "Max Output Length", 4096);
            AddField("Remove Input Padding", ref buildConfig.removeInputPadding, "Remove Input Padding", true);
            AddField("Enable Context FMHA", ref buildConfig.enableContextFMHA, "Enable Context FMHA", true);
            AddField("Use Weight Only", ref buildConfig.useWeightOnly, "Use Weight Only", true);
            AddField("Per Group", ref buildConfig.perGroup, "Per Group", true);
            AddField("Use Inflight Batching", ref buildConfig.useInflightBatching, "Use Inflight Batching", true);
            AddField("Paged KV Cache", ref buildConfig.pagedKvCache, "Paged KV Cache", true);
        }

        /// <summary>
        /// Renders the Quantization Configuration form
        /// </summary>
        private void RenderQuantizationConfigurationForm()
        {
            GUILayout.Label("Quantization Configuration", EditorStyles.boldLabel);
            AddField("Dtype", ref quantizationConfig.dtype, "Data type for the model", "float16");
            AddField("Qformat", ref quantizationConfig.qformat, "Quantization format", "int4_awq");
            AddField("Calibration Size", ref quantizationConfig.calibSize, "Calibration Size", 32);
            AddField("Language", ref quantizationConfig.lang, "Language", "id");
        }

        /// <summary>
        /// Adds a field to the form with a specified label, value, tooltip, and default value. 
        /// The method supports string, bool, and int types. If the value is null or equals the default value, 
        /// it will be set to the provided default value. The method also handles the layout of the field in the form.
        /// </summary>
        /// <typeparam name="T">The type of the value. Supported types are string, bool, and int.</typeparam>
        /// <param name="label">The label of the field.</param>
        /// <param name="value">The value of the field. If null or equals the default value, it will be set to the provided default value.</param>
        /// <param name="tooltip">The tooltip that appears when the mouse hovers over the label of the field. Default is an empty string.</param>
        /// <param name="defaultValue">The default value of the field. If the value is null or equals the default value, it will be set to this value. Default is the default value of type T.</param>
        private void AddField<T>(string label, ref T value, string tooltip = "", T defaultValue = default(T))
        {
            if ((value == null || value.Equals(default(T))) && typeof(T) != typeof(bool))
            {
                value = defaultValue;
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(new GUIContent(label, tooltip), GUILayout.Width(EditorGUIUtility.labelWidth));

            if (typeof(T) == typeof(string))
            {
                string stringValue = (string)(object)value;
                value = (T)(object)EditorGUILayout.TextField(stringValue);
            }
            else if (typeof(T) == typeof(bool))
            {
                bool boolValue = (bool)(object)value;
                value = (T)(object)EditorGUILayout.Toggle(boolValue);
            }
            else if (typeof(T) == typeof(int))
            {
                int intValue = (int)(object)value;
                value = (T)(object)EditorGUILayout.IntField(intValue);
            }
            else
            {
                Debug.LogError("Unsupported type");
            }

            EditorGUILayout.EndHorizontal();
        }
    }
}