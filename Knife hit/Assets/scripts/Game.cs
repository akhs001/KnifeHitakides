
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Game : Singleton<Game> , IObserver , ISaveLoad
{
	public GameObject[] knifes;			//All type of knives

	public GameObject knifePanel;
	public GameObject knifeImage;
	

	public Transform kniveSpawnPosition;	
			
	
	[SerializeField]private GameObject startScreen;     

	private  KnifeManager _kniveManager;
	public GameObject messagePanel;

	public GameObject[] knifesinSelection;
	public GameObject knifeSelectionPanel;
	
	public Text fpsCounter;

	public Button startGameBtn;

	public AppleUIDrawer AppleCounter;

	public GameObject boss;
	
	
	private void Awake() {
		//Initialize Apple counter
		AppleCounter = new AppleUIDrawer();
	
		Application.targetFrameRate = 60;

		//Get saved apples
		if(!PlayerPrefs.HasKey("Apples")) {
			PlayerPrefs.SetInt ("Apples", 0);
		}
		
	}


    private void OnEnable()
    {
		EventManager.StartListening(this, "Splice", GameEnd);
		EventManager.StartListening(this, "KnifeHit", () => { SoundManager.Instance.PlaySound("hit");InitKnife(); });
    }

    private void OnDisable()
    {
		EventManager.StopListening(this, "Splice", GameEnd);
		EventManager.StopListening(this, "KnifeHit", () => { SoundManager.Instance.PlaySound("hit"); InitKnife(); });
	}

    public void OpenKnifesSelectionScreen() {
		SoundManager.Instance.PlaySound("click");
		knifeSelectionPanel.SetActive (true);
		for(var i=0; i<knifesinSelection.Length; i++) {
			if(isKnifeUnlocked(i+1)) {
				knifesinSelection [i].GetComponent<Image> ().color = new Color (255, 255, 255, 255);
				knifesinSelection [i].GetComponent<Button> ().enabled = true;
			} else {
				knifesinSelection [i].GetComponent<Image> ().color = new Color (0, 0, 0, 0.2f);
				knifesinSelection [i].GetComponent<Button> ().enabled = false;
			}
		}
	}

	int numKnives = 3;
	public void StartGame (int level )  //if continue from checkpoint check is true;
	{
		_kniveManager = new KnifeManager(numKnives);
		Instantiate(LevelManager.Instance.allLevels[LevelManager.Instance.CurrentLevel].sprite); //kormos.SetActive (true);
		// ClearKnifes(); 

		SoundManager.Instance.PlaySound("click");
		startScreen.SetActive (false);
		InitKnife();

	}



	public void InitKnife()
	{

		if (_kniveManager.KnivesLeft <= 0) return;

		_kniveManager.CurrentKnive = Object.Instantiate(Game.Instance.knifes[_kniveManager.CurrentType],
		 Game.Instance.kniveSpawnPosition.position, Quaternion.Euler(0, 0, -90));

		if (_kniveManager.IsLastKnive)
		{
			_kniveManager.CurrentKnive.GetComponent<knifeScript>().isFinalKnife = true;
		}
	}


	//check if a knife is unlocked
	private bool isKnifeUnlocked(int knifeNum)
	{
		return true;
	}

	public void UnlockKnife(int knife) {
		string key = "Knife" + knife;
		PlayerPrefs.SetInt (key, 1);
		Message.Instance.ShowMessage("You unlocked a new Knife");
	}
	



	//GameOver
	public async void GameEnd ()
	{

		await Task.Delay(1000);

		StartGame(1);
	}
	

	private float _deltatime;
	
	//check for mouse pressed here and launch knife
	private float _timer;
	private void Update ()
	{	
		_deltatime += (Time.deltaTime - _deltatime) * 0.1f;
		float fps = 1.0f / _deltatime;

		fpsCounter.text = "FPS: " + (int)fps;
	}

    public void Save()
    {
		print($"Saving game");
    }

    public void Load()
    {
		print($"Loading Game");
    }
}
