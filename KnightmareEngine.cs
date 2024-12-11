global using System;
global using Godot;
global using pathmage.ToolKit;
global using pathmage.ToolKit.Collections;
global using static pathmage.ToolKit.Debug.ILogger;
using System.IO;
using System.Reflection;
using pathmage.ToolKit.Debug;

namespace pathmage.KnightmareEngine;

public sealed partial class KnightmareEngine : Node
{
	KnightmareEngine()
	{
		Logger.Singleton = new LoggerWrapper(GD.Print);
	}

	public override void _Ready()
	{
		using var file = LineFile<Test>.CreateOrOpen("user://test.txt");
		file.Array<string>(Test.A, "1", "2", "3", "4");

		var file_arr = file.Array<string>(Test.A);

		foreach (var i in file_arr.Length)
			print(i, file_arr[i]);

		print(nameof(file_arr.Length), file_arr.Length);
	}

	enum Test
	{
		[LineFileArray<string>]
		A,
	}
}

public static partial class Extensions;
