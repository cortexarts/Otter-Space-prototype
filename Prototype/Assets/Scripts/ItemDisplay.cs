using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
	public Item item;
	public Image icon;
    public Text nameText;

    public void Setup (Item _item)
	{
        item = _item;
		icon.sprite = item.icon;
		nameText.text = item.name;
	}

}
