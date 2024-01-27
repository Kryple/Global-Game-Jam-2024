using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TitleObject;
    [SerializeField]
    private TextMeshProUGUI ButtonTitleObject;

    public string Title;
    public string ButtonTitle;

    private void Start()
    {
        TitleObject.text = Title;
        ButtonTitleObject.text = ButtonTitle;
    }
}
