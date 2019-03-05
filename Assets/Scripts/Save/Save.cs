using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using UnityEditor.SceneManagement;

public class Save : Editor
{
    //将所有游戏场景导出为XML格式    
    [MenuItem("GameObject/ExportXML")]
    public static void ExportXML()
    {
        string filepath = Application.dataPath + @"/StreamingAssets/my.xml";
        if (!File.Exists(filepath))
        {
            File.Delete(filepath);
        }
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement root = xmlDoc.CreateElement("gameObjects");
        //遍历所有的游戏场景    
        foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
        {
            //当关卡启用           
            if (S.enabled)
            {
                //得到关卡的名称               
                string name = S.path;
                //打开这个关卡               
                //EditorApplication.OpenScene(name);
                //EditorSceneManager.OpenScene(name);
                XmlElement scenes = xmlDoc.CreateElement("scenes");
                scenes.SetAttribute("name", name);
                foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
                {
                    if (obj.tag != "Level")
                    {
                        if (obj.transform.parent == null)
                        {
                            XmlElement gameObject = xmlDoc.CreateElement("gameObjects");
                            gameObject.SetAttribute("name", obj.name);
                            gameObject.SetAttribute("asset", obj.name + ".prefab");
                            XmlElement transform = xmlDoc.CreateElement("transform");
                            XmlElement position = xmlDoc.CreateElement("position");
                            XmlElement position_x = xmlDoc.CreateElement("x");
                            position_x.InnerText = obj.transform.position.x + "";
                            XmlElement position_y = xmlDoc.CreateElement("y");
                            position_y.InnerText = obj.transform.position.y + "";
                            XmlElement position_z = xmlDoc.CreateElement("z");
                            position_z.InnerText = obj.transform.position.z + "";
                            position.AppendChild(position_x);
                            position.AppendChild(position_y);
                            position.AppendChild(position_z);
                            XmlElement rotation = xmlDoc.CreateElement("rotation");
                            XmlElement rotation_x = xmlDoc.CreateElement("x");
                            rotation_x.InnerText = obj.transform.rotation.eulerAngles.x + "";
                            XmlElement rotation_y = xmlDoc.CreateElement("y");
                            rotation_y.InnerText = obj.transform.rotation.eulerAngles.y + "";
                            XmlElement rotation_z = xmlDoc.CreateElement("z");
                            rotation_z.InnerText = obj.transform.rotation.eulerAngles.z + "";
                            rotation.AppendChild(rotation_x);
                            rotation.AppendChild(rotation_y);
                            rotation.AppendChild(rotation_z);
                            XmlElement scale = xmlDoc.CreateElement("scale");
                            XmlElement scale_x = xmlDoc.CreateElement("x");
                            scale_x.InnerText = obj.transform.localScale.x + "";
                            XmlElement scale_y = xmlDoc.CreateElement("y");
                            scale_y.InnerText = obj.transform.localScale.y + "";
                            XmlElement scale_z = xmlDoc.CreateElement("z");
                            scale_z.InnerText = obj.transform.localScale.z + "";
                            scale.AppendChild(scale_x);
                            scale.AppendChild(scale_y);
                            scale.AppendChild(scale_z);
                            transform.AppendChild(position);
                            transform.AppendChild(rotation);
                            transform.AppendChild(scale);
                            gameObject.AppendChild(transform);
                            scenes.AppendChild(gameObject);
                            root.AppendChild(scenes);
                            xmlDoc.AppendChild(root);
                            xmlDoc.Save(filepath);
                        }
                    }
                }
            }
        }
        //刷新Project视图， 不然需要手动刷新哦       
        AssetDatabase.Refresh();
    }

}