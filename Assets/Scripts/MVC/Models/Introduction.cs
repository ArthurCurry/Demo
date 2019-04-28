using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction {

    public string Title { get; private set; }
    public string IntroText { get; private set; }
    public string ImageIcon { get; private set; }

    public Introduction(string title,string introText,string imageIcon)
    {
        this.Title = title;
        this.IntroText = introText;
        this.ImageIcon = imageIcon;
    }
}
