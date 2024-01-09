using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.FieldCompleteMainMenu
{
	
    public class LoginUserManager : MonoBehaviour
    {
		

		[Header("RESOURCES")]
        public SwitchToMainPanels switchPanelMain;
        public UIElementSound soundScript;
        public Animator wrongAnimator;
        public Text usernameText;
        public Text passwordText;

        [Header("SETTINGS")]
        public string username;
        public string password;

        public void Login()
        {
			LoginUser.UserName = usernameText.text;
			LoginUser.Password = passwordText.text;


			SqlHandler.instance.UserLogin_handler(LoginUser.UserName, LoginUser.Password);
            if (SqlHandler.instance.userMatched)
            {
				StateManager.instance.Login(true);
				switchPanelMain.Animate();
				

			}
            else
            {
                wrongAnimator.Play("Notification In");
                soundScript.Notification();
            }
        }


    }
}