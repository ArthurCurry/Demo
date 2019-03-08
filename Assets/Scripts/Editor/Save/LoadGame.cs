using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
//using UnityEditor;

public class LoadGame
{
    //[MenuItem("GameObject/ImprotXML")]
    public static void LoadSenceXML()
    {
        string filepath = Application.dataPath + "/StreamingAssets" + "/my.xml";
        //如果文件存在话开始解析。        
        if (File.Exists(filepath))
        {
            Debug.Log(1);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("gameObjects").ChildNodes;
            foreach (XmlElement scene in nodeList)
            {
                //因为XML是把所有游戏对象全部导出， 所以这里判断一下只解析需要的场景中的游戏对象                
                string path = scene.GetAttribute("name");
                string name = path.Substring(path.LastIndexOf('/') + 1, path.LastIndexOf('.') - path.LastIndexOf('/') - 1);
                Debug.Log(name);
                Debug.Log(Application.loadedLevelName);
                if (!name.Equals(Application.loadedLevelName))
                {
                    //continue;
                }
                foreach (XmlElement gameObjects in scene.ChildNodes)
                {
                    string asset = "Assets/Resources/Prefabs/Save/" + gameObjects.GetAttribute("asset");
                    Vector3 pos = Vector3.zero;
                    Vector3 rot = Vector3.zero;
                    Vector3 sca = Vector3.zero;
                    foreach (XmlElement transform in gameObjects.ChildNodes)
                    {
                        foreach (XmlElement prs in transform.ChildNodes)
                        {
                            if (prs.Name == "position")
                            {
                                foreach (XmlElement position in prs.ChildNodes)
                                {
                                    switch (position.Name)
                                    {
                                        case "x":
                                            pos.x = float.Parse(position.InnerText);
                                            break;
                                        case "y":
                                            pos.y = float.Parse(position.InnerText);
                                            break;
                                        case "z":
                                            pos.z = float.Parse(position.InnerText);
                                            break;
                                    }
                                }
                            }
                            else if (prs.Name == "rotation")
                            {
                                foreach (XmlElement rotation in prs.ChildNodes)
                                {
                                    switch (rotation.Name)
                                    {
                                        case "x":
                                            rot.x = float.Parse(rotation.InnerText);
                                            break;
                                        case "y":
                                            rot.y = float.Parse(rotation.InnerText);
                                            break;
                                        case "z":
                                            rot.z = float.Parse(rotation.InnerText);
                                            break;
                                    }
                                }
                            }
                            else if (prs.Name == "scale")
                            {
                                foreach (XmlElement scale in prs.ChildNodes)
                                {
                                    switch (scale.Name)
                                    {
                                        case "x":
                                            sca.x = float.Parse(scale.InnerText);
                                            break;
                                        case "y":
                                            sca.y = float.Parse(scale.InnerText);
                                            break;
                                        case "z":
                                            sca.z = float.Parse(scale.InnerText);
                                            break;
                                    }
                                }
                            }
                        }
                        //拿到 旋转 缩放 平移 以后克隆新游戏对象        
                        Debug.Log(asset);
                        Object obj = UnityEditor.AssetDatabase.LoadAssetAtPath(asset, typeof(GameObject));
                        GameObject ob = (GameObject)GameObject.Instantiate(obj, pos, Quaternion.Euler(rot));
                        ob.transform.localScale = sca;
                        ob.name = obj.name;
                    }
                }
            }
        }
    }
}
