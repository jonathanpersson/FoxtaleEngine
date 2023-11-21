using System.Collections.Generic;
using System.Xml.Serialization;
using System.Reflection;
using System.IO;
using System.Text;
using System.IO.Compression;
using System;
using Foxtale.Core.Assets.Configuration;
using System.Linq;
using Foxtale.Core.IO;

namespace Foxtale.Core.Assets;

public static class AssetManager
{
    private static Config _config = null;
    public const string DefaultBundle = "BUILTIN";
    public static string AssetDirectory = "Assets";
    public static string AssetsPath 
        => $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}{AssetDirectory}";
    public static string BuildPath => $"{AssetsPath}{Path.DirectorySeparatorChar}dist";
    public static string SourcePath => $"{AssetsPath}{Path.DirectorySeparatorChar}src";
    public static Dictionary<string, Bundle> Bundles { get; } = [];

    public static void Initialize()
    {
        Logger.Log(LogLevel.Information, "Asset Manager initializing...");
        
        if (!Directory.Exists(AssetsPath))
        {
            Logger.Log(LogLevel.Warning, $"Assets directory ({AssetsPath}) does not exist. Creating empty...");
            Directory.CreateDirectory(SourcePath);
            Directory.CreateDirectory(BuildPath);
        }

        _config = GetConfig();

        if (_config.AutoRebuild)
        {
            Logger.Log(LogLevel.Build, "Determining if asset bundles should be rebuilt...");
            if (!ShouldBuild() && Directory.GetDirectories(BuildPath).Length >= 1) return;
            string[] bundles = Directory.GetDirectories(SourcePath);
            List<string> bundleNames = [];
            foreach (string dir in bundles)
            {
                LoadBundleRaw(dir);
                BuildBundles();
                ClearLoadedBundles();
                bundleNames.Add(new DirectoryInfo(dir).Name);
            }
            _config.Bundles = [.. bundleNames];
        }
    }

    private static bool ShouldBuild()
    {
        foreach (string dir in Directory.EnumerateDirectories(SourcePath))
        {
            if (Directory.GetLastWriteTime(dir) > _config.LastBuild) return true;
        }
        return false;
    }

    private static Config GetConfig()
    {
        string configName = IO.Operations.FilterPathSeparators($"{AssetsPath}/config.xml");
        XmlSerializer xml = new(typeof(Config));
        bool createNew = File.Exists(configName);
        using FileStream fs = File.Open(configName, FileMode.OpenOrCreate);
        Config config;

        if (createNew || fs.Length < 10)
        {
            Logger.Log(LogLevel.Build, "Config missing, creating a new one");
            config = Config.GetDefault();
            xml.Serialize(fs, config);
            return config;
        }

        config = (Config)xml.Deserialize(fs);
        fs.Close();
        return config;
    }

    /// <summary>
    /// Create and write active bundles to disk
    /// </summary>
    private static void BuildBundles()
    {
        foreach (KeyValuePair<string, Bundle> bundle in Bundles)
        {
            string fileName = IO.Operations.FilterPathSeparators($"{BuildPath}/{bundle.Key}.fxtb");
            Logger.Log(LogLevel.Build, $"Building bundle \"{bundle.Key}\" in {fileName}");
            byte[] serialized = SerializeBundle(bundle.Value);
            using FileStream fs = File.Create(fileName);
            fs.Write(serialized);
            fs.Close();
        }
    }

    /// <summary>
    /// Serialize and GZip-compress a Bundle
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    private static byte[] SerializeBundle(Bundle b)
    {
        XmlSerializer xml = new(typeof(Bundle));
        StringWriter sw = new();
        xml.Serialize(sw, b);
        byte[] res;

        using (MemoryStream ms = new())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(sw.ToString());
            using GZipStream gz = new(ms, CompressionMode.Compress);
            gz.Write(bytes, 0, bytes.Length);
            res = ms.ToArray();
        }

        return res;
    }

    public static void LoadBundle()
    {
        LoadBundle(DefaultBundle);
    }

    public static void LoadBundle(string name)
    {
        if (_config.LoadRaw)
        {
            LoadBundleRaw(name);
            return;
        }

        //TODO: load serialized bundle
    }

    private static void LoadBundleRaw(string name)
    {
        string bundlePath = IO.Operations.FilterPathSeparators(SourcePath + $"/{name}");
        if (!Directory.Exists(bundlePath))
            throw new DirectoryNotFoundException($"No bundle found at \"{bundlePath}\"!");
        List<string> bundleFiles = IO.Operations.FindAllFiles(bundlePath);

        foreach (string file in bundleFiles)
        {
            string bundleName = file[(bundlePath.Length - 1)..]
                .Trim(Path.PathSeparator);
            FileType ft = IO.Operations.GetFileType(file);

            switch (ft)
            {
                case FileType.Image:
                    break;
                case FileType.Text:
                    break;
                default:
                    break;
            }
        }
    }

    public static void ClearLoadedBundles()
    {
        Bundles.Clear();
    }

    public static T Get<T>(string asset)
    {
        string[] assetUri = IO.Operations.FilterPathSeparators(asset).Split(Path.DirectorySeparatorChar);
        string assetId = "";
        Bundle requested = Bundles[assetUri[0]];
        for (int i = 1; i < assetUri.Length; i++) assetId += assetUri[i];
        return (T)requested[assetId].Data;
    }

    public static bool TryGet<T>(string asset, out T result)
    {
        try
        {
            result = Get<T>(asset);
        }
        catch (Exception e)
        {
            Logger.Log(LogLevel.Error, e.ToString());
            result = default;
            return false;
        }

        return true;
    }
}