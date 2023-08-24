using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Search : MonoBehaviour
{
    public List<(Text, BuildingName)> names = new List<(Text, BuildingName)>();
    public List<(Text, BuildingName)> currentNames = new List<(Text, BuildingName)>();
    public Font font;
    public TMP_InputField field;
    public Button button;

    void Start()
    {
        var buildings = FindObjectsOfType<BuildingName>();
        // Debug.Log(buildings);
        foreach (var building in buildings)
        {
            var t = CreateText(building.bldgName);
            (Text, BuildingName) tuple = (t, building);
            Debug.Log(tuple);
            currentNames.Add(tuple);
        }
        ListOrder();
        // Debug.Log(names[1]);
        Debug.Log(field.onValueChanged);
        field.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        button.onClick.AddListener(OnClick);

    }

    private Text CreateText(string text)
    {
        var go = new GameObject();
        go.transform.parent = this.gameObject.transform;
        var textElement = go.AddComponent<Text>();
        textElement.font = font;
        textElement.fontSize = 10;
        textElement.text = text;
        return textElement;
    }

    private void ListOrder()
    {
        for (int i = 0; i < currentNames.Count; i++)
            currentNames[i].Item1.GetComponent<RectTransform>().localPosition = new Vector3(-360, 50 - (i * 15), 0);
        for (int i = 0; i < names.Count; i++)
            names[i].Item1.GetComponent<RectTransform>().localPosition = new Vector3(-3600, 5000, 220);
    }

    public void ValueChangeCheck()
    {
        Debug.Log(field.text);
        for (int i = currentNames.Count - 1; i >= 0; i--)
        {
            if (!currentNames[i].Item1.text.StartsWith(field.text, true, null))
            {
                names.Add(currentNames[i]);
                currentNames.RemoveAt(i);
            }
        }

        for (int i = names.Count - 1; i >= 0; i--)
        {
            if (names[i].Item1.text.StartsWith(field.text, true, null))
            {
                currentNames.Add(names[i]);
                names.RemoveAt(i);
            }
        }

        ListOrder();
    }

    private void OnClick()
    {
        if (currentNames.Count != 0)
        {
            currentNames[0].Item2.GoTo();
        }
    }

}