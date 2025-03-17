using UnityEditor;
using System;

public class BuildScript
{
    static string[] GetBuildScenes()
    {
        string[] scenes = new string[EditorBuildSettings.scenes.Length];
        for(int i = 0; i < scenes.Length; i++)
        {
            scenes[i] = EditorBuildSettings.scenes[i].path;
        }
        return scenes;
    }

    [MenuItem("Build/Windows")]
    public static void BuildWindows()
    {
        string buildPath = "Builds/Windows/YourGame.exe";
        BuildPipeline.BuildPlayer(GetBuildScenes(), buildPath, BuildTarget.StandaloneWindows64, BuildOptions.None);
    }

    [MenuItem("Build/macOS")]
    public static void BuildMacOS()
    {
        string buildPath = "Builds/macOS/YourGame.app";
        BuildPipeline.BuildPlayer(GetBuildScenes(), buildPath, BuildTarget.StandaloneOSX, BuildOptions.None);
    }
}