using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class KnifeDrawer {

    private readonly GameObject _knifeImage;
    private readonly GameObject _knifePanel;
    private readonly List<GameObject> _allKnifes = new List<GameObject>();
    
    public KnifeDrawer(GameObject knifeImage , GameObject knifePanel)
    {
        _knifeImage = knifeImage;
        _knifePanel = knifePanel;
 
    }

    public async void SetKnifes(int num)
    {
 
      await  KnifesClear();

      for(int i=0; i< num; i++)
      {
          GameObject knife = Object.Instantiate(_knifeImage, Vector3.zero, Quaternion.identity);
           _allKnifes.Add(knife);
             knife.name = "test";
            knife.transform.SetParent(_knifePanel.transform);
        }  
    }


    private async Task KnifesClear()
    {
        foreach(GameObject k in _allKnifes)
        {
           Object.Destroy(k.gameObject);
        }
        _allKnifes.Clear();

        await Task.Delay(1000);
    }


	//end
}
