﻿using UnityEngine;

namespace Michsky.UI.FieldCompleteMainMenu
{
    public class SplashScreenManager : MonoBehaviour
    {
		
        [Header("RESOURCES")]
        public GameObject splashScreen;
        public GameObject splashScreenLogin;
        public GameObject splashScreenRegister;
        public GameObject mainPanels;
        private Animator mainPanelsAnimator;

        BlurManager bManager;

        [Header("SETTINGS")]
        public bool isLoggedIn;
        public bool alwaysShowLoginScreen = true;
        public bool disableSplashScreen;
        public bool enableBlurSystem = true;
		void Awake()
		{
			
		}
		void Update()
		{
            isLoggedIn = StateManager.instance.isLoggedIn;
        }

		void Start()
        {
            isLoggedIn = StateManager.instance.isLoggedIn;
            if (isLoggedIn)
			{
				alwaysShowLoginScreen = !isLoggedIn;
				splashScreen.SetActive(isLoggedIn);
				splashScreenLogin.SetActive(!isLoggedIn);
				splashScreenRegister.SetActive(!isLoggedIn);
			}
			if (enableBlurSystem == true)
            {
                bManager = gameObject.GetComponent<BlurManager>();
                bManager.BlurInAnim();
            }

            if (disableSplashScreen == true)
            {
                splashScreen.SetActive(false);
                splashScreenLogin.SetActive(false);
                splashScreenRegister.SetActive(false);
                mainPanels.SetActive(true);

                mainPanelsAnimator = mainPanels.GetComponent<Animator>();
                mainPanelsAnimator.Play("Main Panel Opening");
            }

            else if (isLoggedIn == false && alwaysShowLoginScreen == true)
            {
                splashScreen.SetActive(false);
                splashScreenLogin.SetActive(true);
                splashScreenRegister.SetActive(true);
            }

            else if (isLoggedIn == false && alwaysShowLoginScreen == false)
            {
                splashScreen.SetActive(false);
                splashScreenLogin.SetActive(true);
                splashScreenRegister.SetActive(true);
            }

            else if (isLoggedIn == false && alwaysShowLoginScreen == false)
            {
                splashScreen.SetActive(false);
                splashScreenLogin.SetActive(true);
                splashScreenRegister.SetActive(true);
            }

            else if (isLoggedIn == true && alwaysShowLoginScreen == true)
            {
                splashScreen.SetActive(false);
                splashScreenLogin.SetActive(true);
                splashScreenRegister.SetActive(true);
            }

            else if (isLoggedIn == true && alwaysShowLoginScreen == false)
            {
                splashScreen.SetActive(true);
                splashScreenLogin.SetActive(false);
                splashScreenRegister.SetActive(false);
            }
        }
    }
}