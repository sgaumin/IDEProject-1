using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameJam {
    public class GameManager : MonoBehaviour {

	    public static GameManager instance = null;

	    public enum gameStates {Playing, End};
	    public gameStates gameState = gameStates.Playing;

	    void Awake(){
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }

	    public void LoadScene(string scene){
		    SceneManager.LoadScene (scene);
	    }

	    public void ReloagScene(){
		    SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	    }

        public void QuitGame() {
            Application.Quit();
        }

    }
}
