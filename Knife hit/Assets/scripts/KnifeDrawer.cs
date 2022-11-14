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

    public void SetKnifes(int num)
    {
        for(int i=0; i< _knifePanel.transform.childCount; i++)
        {
            _knifePanel.transform.GetChild(i).gameObject.SetActive(i < num);
        }
    }


	//end
}
