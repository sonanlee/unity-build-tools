using UnityEditor;

namespace Soma.Build
{
    public static class BuildUtils
    {
        public const string SetupsDirectory = "Assets/Plugins/build-tool/Editor/BuildTools/";
        private const string WindowsExtension = ".exe";

        public static BuildPlayerOptions GetBuildPlayerOptionsFromBuildSetupEntry(BuildSetupEntry setupEntry, string rootDirPath, string[] defaultScenes)
        {
            var buildPlayerOptions = new BuildPlayerOptions {target = setupEntry.target};

            if (setupEntry.useDefaultBuildScenes)
            {
                buildPlayerOptions.scenes = defaultScenes;
            }
            else
            {
                buildPlayerOptions.scenes = setupEntry.customScenes.ToArray();
            }

            var pathName = rootDirPath + "/" + setupEntry.buildName;
            if (setupEntry.target == BuildTarget.StandaloneWindows || setupEntry.target == BuildTarget.StandaloneWindows64)
            {
                if (!pathName.Contains(WindowsExtension))
                {
                    pathName += WindowsExtension;
                }
            }

            buildPlayerOptions.locationPathName = pathName;


            if (!string.IsNullOrEmpty(setupEntry.assetBundleManifestPath))
            {
                buildPlayerOptions.assetBundleManifestPath = setupEntry.assetBundleManifestPath;
            }

            var buildOptions = BuildOptions.None;
            if (setupEntry.debugBuild)
            {
                buildOptions |= BuildOptions.Development;
            }

            if (setupEntry.strictMode)
            {
                buildOptions |= BuildOptions.StrictMode;
            }

            if (setupEntry.target == BuildTarget.iOS)
            {
                if (setupEntry.iosSymlinkLibraries)
                {
                    buildOptions |= BuildOptions.SymlinkSources;
                }
            }

            if (setupEntry.detailedBuildReport)
            {
                buildOptions |= BuildOptions.DetailedBuildReport;
            }

            buildPlayerOptions.options = buildOptions;

            return buildPlayerOptions;
        }
    }
}
