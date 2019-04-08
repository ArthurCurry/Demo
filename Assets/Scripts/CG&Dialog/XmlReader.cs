using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XmlReader {

    private static XmlDocument XMLDout;
    private static XmlReader instance;
    private int Index;
    private string TAG;
    public static XmlReader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new XmlReader();
            }
            return instance;
        }
    }

    public void ReadXML(string path)
    {
        XMLDout = new XmlDocument();
        string url = Application.dataPath + "/" + path;
        XMLDout.Load(url);
    }

    public int getCount(string tag, int index)
    {
        TAG = tag;
        int x = XMLDout.GetElementsByTagName(tag).Count;
        //int inCout = XMLDout.GetElementsByTagName(tag)[index].ChildNodes.Count;
        return x;
    }

    public string GetXML(string tag, int cout)
    {
        string xml = XMLDout.GetElementsByTagName(tag)[Index].ChildNodes[cout].InnerText;
        return xml;
    }

    public void SetIndex(int x)
    {
        Index = x;
    } 
}

