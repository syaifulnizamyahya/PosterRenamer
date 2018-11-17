using Serilog;
using System;
using System.Reflection;
using System.IO;

namespace PosterRenamer
{
	class Program
	{
		static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.WriteTo.Console()
				.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
				.CreateLogger();

			Start();
			Log.Information("Done");
//			Console.ReadKey();
		}

		private static void Start()
		{
			Log.Information("Start");

			var currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			Log.Debug("current path : " + currentPath);

			ProcessDirectory(currentPath);
		}

		private static void ProcessDirectory(string path)
		{
			var directories = Directory.GetDirectories(path);
			Log.Debug("path " + path + " has " + directories.Length + " directories");
			Log.Debug("processing " + path);
			ProcessPoster(path);
			if (directories.Length > 0)
			{
				foreach (var item in directories)
				{
					Log.Debug("sub directories : " + item);
					ProcessDirectory(item);
				}
			}
		}
		
		private static void ProcessCopy(string source, string targetName, DirectoryInfo targetDir, string targetExt)
		{
			Log.Debug("source : " + source);
			try
			{
				var target = targetDir + @"\" + targetName + targetExt;
				Log.Debug("target : " + target);
				File.Copy(source, target, false);
				Log.Information("Copied " + source + " to " + target);
			}
			catch (Exception ex)
			{
				Log.Debug("File already exist. " + ex.Message);
			}

			try
			{
				var target = targetDir + @"\" + targetName + "-poster" + targetExt;
				Log.Debug("target : " + target);
				File.Copy(source, target, false);
				Log.Information("Copied " + source + " to " + target);
			}
			catch (Exception ex)
			{
				Log.Debug("File already exist. " + ex.Message);
			}

			try
			{
				var target = targetDir + @"\" + "poster" + targetExt;
				Log.Debug("target : " + target);
				File.Copy(source, target, false);
				Log.Information("Copied " + source + " to " + target);
			}
			catch (Exception ex)
			{
				Log.Debug("File already exist. " + ex.Message);
			}

			try
			{
				var target = targetDir + @"\" + "folder" + targetExt;
				Log.Debug("target : " + target);
				File.Copy(source, target, false);
				Log.Information("Copied " + source + " to " + target);
			}
			catch (Exception ex)
			{
				Log.Debug("File already exist. " + ex.Message);
			}

		}

		private static void ProcessPoster(string path)
		{

			DirectoryInfo d = new DirectoryInfo(path);
			FileInfo[] mkvFiles = d.GetFiles("*.mkv"); 
			FileInfo[] rarFiles = d.GetFiles("*.part001.rar"); 
			FileInfo[] folder = d.GetFiles("folder.*"); 
			FileInfo[] poster = d.GetFiles("poster.*"); 

			foreach (var item in mkvFiles)
			{
				var sourceName = Path.GetFileNameWithoutExtension(item.Name);
				var sourceDir = item.Directory;

				FileInfo[] mkvPosterJpg = d.GetFiles(sourceName + ".jpg");
				FileInfo[] mkvPosterLongJpg = d.GetFiles(sourceName + "-poster" + ".jpg");
				FileInfo[] mkvPosterPng = d.GetFiles(sourceName + ".png");
				FileInfo[] mkvPosterLongPng = d.GetFiles(sourceName + "-poster" + ".png");

				if (mkvPosterJpg.Length > 0)
				{
					ProcessCopy(mkvPosterJpg[0].FullName, sourceName, sourceDir, ".jpg");
				}

				if (mkvPosterLongJpg.Length > 0)
				{
					ProcessCopy(mkvPosterLongJpg[0].FullName, sourceName, sourceDir, ".jpg");
				}

				if (mkvPosterPng.Length > 0)
				{
					ProcessCopy(mkvPosterPng[0].FullName, sourceName, sourceDir, ".png");
				}

				if (mkvPosterLongPng.Length > 0)
				{
					ProcessCopy(mkvPosterLongPng[0].FullName, sourceName, sourceDir, ".png");
				}

				if (folder.Length > 0)
				{
					ProcessCopy(folder[0].FullName, sourceName, sourceDir, folder[0].Extension);
				}

				if (poster.Length > 0)
				{
					ProcessCopy(poster[0].FullName, sourceName, sourceDir, poster[0].Extension);
				}
			}

			foreach (var item in rarFiles)
			{
				var sourceName = Path.GetFileNameWithoutExtension(item.Name);
				var sourceDir = item.Directory;

				FileInfo[] mkvPosterJpg = d.GetFiles(sourceName + ".jpg");
				FileInfo[] mkvPosterLongJpg = d.GetFiles(sourceName + "-poster" + ".jpg");
				FileInfo[] mkvPosterPng = d.GetFiles(sourceName + ".png");
				FileInfo[] mkvPosterLongPng = d.GetFiles(sourceName + "-poster" + ".png");

				if (mkvPosterJpg.Length > 0)
				{
					ProcessCopy(mkvPosterJpg[0].FullName, sourceName, sourceDir, ".jpg");
				}

				if (mkvPosterLongJpg.Length > 0)
				{
					ProcessCopy(mkvPosterLongJpg[0].FullName, sourceName, sourceDir, ".jpg");
				}

				if (mkvPosterPng.Length > 0)
				{
					ProcessCopy(mkvPosterPng[0].FullName, sourceName, sourceDir, ".png");
				}

				if (mkvPosterLongPng.Length > 0)
				{
					ProcessCopy(mkvPosterLongPng[0].FullName, sourceName, sourceDir, ".png");
				}

				if (folder.Length > 0)
				{
					ProcessCopy(folder[0].FullName, sourceName, sourceDir, folder[0].Extension);
				}
				if (poster.Length > 0)
				{
					ProcessCopy(poster[0].FullName, sourceName, sourceDir, poster[0].Extension);
				}
			}
		}
	}
}
