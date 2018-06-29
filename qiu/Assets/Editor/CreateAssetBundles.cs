﻿using UnityEditor;
using UnityEngine;

public class CreateAssetBundles
{
    // 打包unity场景文件
    [MenuItem("Assets/Build AssetBundle Scene")]
    static void MyBuild()
    {
        // 需要打包的场景名字
        string[] levels = { "Assets/Scene/earth.unity" };
        // 注意这里【区别】通常我们打包，第2个参数都是指定文件夹目录，在此方法中，此参数表示具体【打包后文件的名字】
        // 记得指定目标平台，不同平台的打包文件是不可以通用的。最后的BuildOptions要选择流格式
        BuildPipeline.BuildPlayer(levels, Application.dataPath + "/earth.unity3d", BuildTarget.WebGL, BuildOptions.BuildAdditionalStreamedScenes);
        // 刷新，可以直接在Unity工程中看见打包后的文件
        AssetDatabase.Refresh();
    }
}