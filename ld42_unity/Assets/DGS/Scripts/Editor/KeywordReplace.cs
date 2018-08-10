using UnityEngine;
using UnityEditor;
using System.Collections;

public class KeywordReplace : UnityEditor.AssetModificationProcessor {

    public static void OnWillCreateAsset(string path) {
        path = path.Replace(".meta", "");
        int index = path.LastIndexOf(".");
        string file = path.Substring(index);
        if(file != ".cs" && file != ".js" && file != ".boo") return;
        index = Application.dataPath.LastIndexOf("Assets");
        path = Application.dataPath.Substring(0, index) + path;
        file = System.IO.File.ReadAllText(path);

        file = file.Replace("#CREATIONDATE#", System.DateTime.Now + "");
        file = file.Replace("#MODIFICATIONDATE#", System.DateTime.Now + "");
        file = file.Replace("#PROJECTNAME#", PlayerSettings.productName);
        file = file.Replace("#COMPANYNAME#", PlayerSettings.companyName);
        file = file.Replace("#AUTHORNAME#", "Ankit Sethi");
        file = file.Replace("#COPYRIGHT#", "@ COPYRIGHT 2017-2018. ALL RIGHTS RESERVED - " + PlayerSettings.companyName);

        System.IO.File.WriteAllText(path, file);
        AssetDatabase.Refresh();
    }
}
