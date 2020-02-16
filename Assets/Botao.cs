using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Botao : MonoBehaviour
{
    public void CliqueNoBotao()
    {
        StartCoroutine(FazerReqWeb());
    }

    public IEnumerator FazerReqWeb()
    {
        WWWForm wwwf = new WWWForm();
        wwwf.AddField("SQL", "SELECT * FROM player", System.Text.Encoding.UTF8);

        using (var w = UnityWebRequest.Post("https://spigo.net/sql_to_json.php", wwwf))
        {
            yield return w.SendWebRequest();
            if (w.isNetworkError || w.isHttpError)
            {
                Debug.Log(w.error);
            }
			else 
            {
                Players pContainer = JsonUtility.FromJson<Players>(w.downloadHandler.text);
				if(pContainer.objetos.Length > 0)
                {
                    foreach (Players.Player player in pContainer.objetos) {
                        Debug.Log(player.login);
                    }
                }
			}
		}
    }
}
