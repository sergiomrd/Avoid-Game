using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public enum GameState {Start, inGame, GameOver};

	public GameState gm;

	public GameObject Menu, GameOver;

	bool pause;
	float count;

	void Awake()
	{
		//gm = GameState.Start;
		pause = false;
	}

	void Update () {

		switch (gm) 
		{
		case GameState.Start:
			break;

		case GameState.inGame:
			
			if (Input.GetKeyDown (KeyCode.Escape) && !pause) 
			{
				pause = true;
				ShowMenu (Menu,true);
				Time.timeScale = 0;
			}
			else if(Input.GetKeyDown (KeyCode.Escape) && pause)
			{
				pause = false;
				ShowMenu(Menu,false);
				Time.timeScale = 1;
			}

			break;

		case GameState.GameOver:
			
			ShowMenu (GameOver, true);
			Time.timeScale = 0;

			break;
		}
			
	
	}
	
	void ShowMenu(GameObject objectToShow, bool choose)
		{
			objectToShow.SetActive (choose);
		}

	public void EndGame()
	{
		
	}
			
}
