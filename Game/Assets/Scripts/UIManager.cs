using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public static UIManager _instance;
	public Text NameText;
	public Text LevelText;

	private int Level=1;
	private int Value=0;
	private string Name=null;

	private void Awake()
	{
		_instance=this;
	}

	private void Start()
	{
		NameText.text=Name;
	}

	private void Update()
	{
		LevelText.text=Level.ToString();
	}

	public void getName()
	{

	}
	public void addLevel()
	{
		Value+=2;
		int n=Value/10;
		switch (n)
		{
			case 1:Level+=1;	
			break;
			case 2:Level+=1;	
			break;
			case 3:Level+=1;	
			break;
			case 4:Level+=1;	
			break;
			case 5:Level+=1;	
			break;
			default:
			break;
		}
	}
}
