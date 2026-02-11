using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace NovaFramework.Editor
{
    public class BuildProjectTool
    {
        //后期可以添加配置文件添加参数  todo
        private static string defaultOutputPath = Application.dataPath + "/../Publish";
        private static string productName = "DemoGame";
        
        private static string GetCommandLineArg(string name)
        {
            var args = System.Environment.GetCommandLineArgs();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == name && i + 1 < args.Length)
                {
                    return args[i + 1];
                }
            }

            return null;
        }

        [MenuItem("Build/导出WebGL工程")]
        public static void BuildWebGL()
        {
            string outputPath = GetCommandLineArg("-outputPath");

            if (outputPath == null)
            {
                outputPath = defaultOutputPath + "/WebGL";
            }

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            var scenes = EditorBuildSettings.scenes
                .Where(s => s.enabled)
                .Select(s => s.path)
                .ToArray();

            UnityEditor.Build.Reporting.BuildReport report =
                BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.WebGL, BuildOptions.None);
            if (report.summary.totalErrors != 0)
            {
                Debug.LogError("Error: Build \"" + outputPath + "\" failed! " + report.summary.ToString());
            }

            Debug.Log("导出WebGL工程 Finish");
        }

        [MenuItem("Build/导出Android工程")]
        public static void BuildAndroid()
        {
            string outputPath = GetCommandLineArg("-outputPath");

            if (outputPath == null)
            {
                outputPath = Application.dataPath + "/../Publish/Android/base.apk";
            }

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            var scenes = EditorBuildSettings.scenes
                .Where(s => s.enabled)
                .Select(s => s.path)
                .ToArray();

            UnityEditor.Build.Reporting.BuildReport report =
                BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.Android, BuildOptions.None);
            if (report.summary.totalErrors != 0)
            {
                Debug.LogError("Error: Build \"" + outputPath + "\" failed! " + report.summary.ToString());
            }

            Debug.Log("导出Android工程 Finish");
        }
        
        [MenuItem("Build/导出StandaloneWindows64工程")]
        public static void BuildStandaloneWindows64()
        {
            string outputPath = GetCommandLineArg("-outputPath");

            if (outputPath == null)
            {
                outputPath = defaultOutputPath + "/StandaloneWindows64";
            }

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            var scenes = EditorBuildSettings.scenes
                .Where(s => s.enabled)
                .Select(s => s.path)
                .ToArray();

            UnityEditor.Build.Reporting.BuildReport report =
                BuildPipeline.BuildPlayer(scenes, outputPath + "/" + productName, BuildTarget.StandaloneWindows64, BuildOptions.None);
            if (report.summary.totalErrors != 0)
            {
                Debug.LogError("Error: Build \"" + outputPath + "\" failed! " + report.summary.ToString());
            }
            else
            {
                Debug.Log("导出StandaloneWindows64工程 Finish");
            }

            
        }
    }
}