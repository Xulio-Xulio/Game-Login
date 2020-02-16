using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class VerificaLogin : MonoBehaviour
{
    public InputField txtLogin;
    public InputField txtPassword;
    public Text txtErro;


    public void botaoLogin()
    {
        if (txtLogin.text == "")
        {
            txtErro.text = "Favor digitar o login";
        }
        else if (txtPassword.text == "")
        {
            txtErro.text = "Favor digitar a senha";
        }
        else
        {
            StartCoroutine(VerificaLogi(txtLogin.text, txtPassword.text));
        }

    }

    private IEnumerator VerificaLogi(string login, string password)
    {
        txtErro.text = "";
        WWWForm wwwf = new WWWForm ();
		wwwf.AddField("SQL", "SELECT * FROM player WHERE login = '" + login + "'" , System.Text.Encoding.UTF8);
		
		using (var w = UnityWebRequest.Post("https://spigo.net/sql_to_json.php", wwwf))
		{
			yield return w.SendWebRequest();
			if (w.isNetworkError || w.isHttpError) {
				Debug.Log(w.error);
			}
			else 
            {
                Players pContainer = JsonUtility.FromJson<Players>(w.downloadHandler.text);
				if(pContainer.objetos.Length > 0)
                {
                    foreach (Players.Player player in pContainer.objetos) {
                        if(player.password == password){
                            
                            PlayerPrefs.SetString("login", player.login);
                            PlayerPrefs.SetInt("idPlayer", player.id);
                            
                    
                            SceneManager.LoadScene("cut1");
                            
                        }
                        else
                        {
                            txtErro.text = "Senha está errada";
                        }
                    }
                }
                else
                {
                    txtErro.text = "Login está errado";
                }
			}
		}
    }
}
