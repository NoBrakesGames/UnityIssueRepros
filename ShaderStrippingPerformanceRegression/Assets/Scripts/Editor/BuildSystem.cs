using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class BuildSystem
{
    [MenuItem("Repro/Build")]
    public static void Build()
    {
        var opts = new BuildPlayerOptions();
        opts.target = BuildTarget.StandaloneWindows64;
        opts.targetGroup = BuildPipeline.GetBuildTargetGroup(opts.target);
        opts.options = BuildOptions.Development;

        var version = System.DateTime.Now.ToFileTimeUtc();
        var path = Path.Combine(Application.dataPath, "..", "Builds", version.ToString(), "Repro.exe");
        Debug.Log($"Output: {path}");
        opts.locationPathName = path;

        // Build all scenes enabled in the build settings
        {
            var scenes = new List<string>();
            foreach (var scene in EditorBuildSettings.scenes)
            {
                if (!scene.enabled)
                    continue;
                scenes.Add(scene.path);
            }
            opts.scenes = scenes.ToArray();
        }
        
        var report = BuildPipeline.BuildPlayer(opts);
        Debug.Log($"Build report ({report.summary.result}):\nWarnings: {report.summary.totalWarnings}\nErrors: {report.summary.totalErrors}\nTime: {report.summary.totalTime.TotalSeconds} seconds");
    }
}
