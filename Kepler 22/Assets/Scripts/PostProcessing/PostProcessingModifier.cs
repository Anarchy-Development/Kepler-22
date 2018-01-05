using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.PostProcessing.Utilities;
using UnityEngine.UI;

public class PostProcessingModifier : MonoBehaviour {

    [Header("Camera")]
    public Camera mainCamera;

    [Header("Post Processing Controller")]
    public PostProcessingController mainController;
    public PostProcessingProfile postProfile;

    [Header("Colors")]
    public Color onColor;
    public Color offColor;

    [Header("FOV Controller")]
    public Slider FOVRange;

    [Header("Bloom Controller")]
    public Image bloomOnButton;
    public Text bloomOnText;
    public Image bloomOffButton;
    public Text bloomOffText;

    [Header("Anti Aliasing Controller")]
    public Image antiOnButton;
    public Text antiOnText;
    public Image antiOffButton;
    public Text antiOffText;

    [Header("Occulusion Controller")]
    public Image occulusionOnButton;
    public Text occulusionOnText;
    public Image occulusionOffButton;
    public Text occulusionOffText;

    [Header("Motion Blur Controller")]
    public Image blurOnButton;
    public Text blurOnText;
    public Image blurOffButton;
    public Text blurOffText;

    [Header("Color Controller")]
    public Image colorOnButton;
    public Text colorOnText;
    public Image colorOffButton;
    public Text colorOffText;

    public float Constrain(float n, float low, float high) {
        return Mathf.Max(Mathf.Min(n, high), low);
    }

    public float Map(float n, float start1, float stop1, float start2, float stop2) {
        float newValue = (n - start1) / (stop1 - start1) * (stop2 - start2) + start2;
        if (start2 < stop2)
            return Constrain(newValue, start2, stop2);
        else
            return Constrain(newValue, stop2, start2);
    }

    void Start() {
        FOVRange.value = Map(mainCamera.fieldOfView, 1, 179, 0, 1);

        if (postProfile.bloom.enabled) {
            bloomOffButton.color = offColor;
            bloomOffText.color = onColor;
            bloomOnButton.color = onColor;
            bloomOnText.color = offColor;
        } else {
            bloomOnButton.color = offColor;
            bloomOnText.color = onColor;
            bloomOffButton.color = onColor;
            bloomOffText.color = offColor;
        }

        if (postProfile.antialiasing.enabled) {
            antiOffButton.color = offColor;
            antiOffText.color = onColor;
            antiOnButton.color = onColor;
            antiOnText.color = offColor;
        } else {
            antiOnButton.color = offColor;
            antiOnText.color = onColor;
            antiOffButton.color = onColor;
            antiOffText.color = offColor;
        }

        if (postProfile.motionBlur.enabled) {
            blurOffButton.color = offColor;
            blurOffText.color = onColor;
            blurOnButton.color = onColor;
            blurOnText.color = offColor;
        } else {
            blurOnButton.color = offColor;
            blurOnText.color = onColor;
            blurOffButton.color = onColor;
            blurOffText.color = offColor;
        }

        if (postProfile.ambientOcclusion.enabled) {
            occulusionOffButton.color = offColor;
            occulusionOffText.color = onColor;
            occulusionOnButton.color = onColor;
            occulusionOnText.color = offColor;
        } else {
            occulusionOnButton.color = offColor;
            occulusionOnText.color = onColor;
            occulusionOffButton.color = onColor;
            occulusionOffText.color = offColor;
        }

        if (postProfile.colorGrading.enabled) {
            colorOffButton.color = offColor;
            colorOffText.color = onColor;
            colorOnButton.color = onColor;
            colorOnText.color = offColor;
        } else {
            colorOnButton.color = offColor;
            colorOnText.color = onColor;
            colorOffButton.color = onColor;
            colorOffText.color = offColor;
        }
    }

    void Update() {
        mainCamera.fieldOfView = Map(FOVRange.value, 0, 1, 1, 179);
    }

    // Bloom Toggles
    public void TurnOnBloom() {
        bloomOffButton.color = offColor;
        bloomOffText.color = onColor;
        bloomOnButton.color = onColor;
        bloomOnText.color = offColor;
        mainController.enableBloom = true;
    }

    public void TurnOffBloom() {
        bloomOnButton.color = offColor;
        bloomOnText.color = onColor;
        bloomOffButton.color = onColor;
        bloomOffText.color = offColor;
        mainController.enableBloom = false;
    }

    // Motion Blur Toggles
    public void TurnOnBlur() {
        blurOffButton.color = offColor;
        blurOffText.color = onColor;
        blurOnButton.color = onColor;
        blurOnText.color = offColor;
        mainController.enableMotionBlur = true;
    }

    public void TurnOffBlur() {
        blurOnButton.color = offColor;
        blurOnText.color = onColor;
        blurOffButton.color = onColor;
        blurOffText.color = offColor;
        mainController.enableMotionBlur = false;
    }

    // Anti Aliasing Toggles
    public void TurnOnAnti() {
        antiOffButton.color = offColor;
        antiOffText.color = onColor;
        antiOnButton.color = onColor;
        antiOnText.color = offColor;
        mainController.enableAntialiasing = true;
    }

    public void TurnOffAnti() {
        antiOnButton.color = offColor;
        antiOnText.color = onColor;
        antiOffButton.color = onColor;
        antiOffText.color = offColor;
        mainController.enableAntialiasing = false;
    }

    // Color Grading Toggles
    public void TurnOnColor() {
        colorOffButton.color = offColor;
        colorOffText.color = onColor;
        colorOnButton.color = onColor;
        colorOnText.color = offColor;
        mainController.enableColorGrading = true;
    }

    public void TurnOffColor() {
        colorOnButton.color = offColor;
        colorOnText.color = onColor;
        colorOffButton.color = onColor;
        colorOffText.color = offColor;
        mainController.enableColorGrading = false;
    }

    // Ambient Occulusion Toggles
    public void TurnOnOcculusion() {
        occulusionOffButton.color = offColor;
        occulusionOffText.color = onColor;
        occulusionOnButton.color = onColor;
        occulusionOnText.color = offColor;
    }

    public void TurnOffOcculusion() {
        occulusionOnButton.color = offColor;
        occulusionOnText.color = onColor;
        occulusionOffButton.color = onColor;
        occulusionOffText.color = offColor;
    }
}
