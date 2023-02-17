using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class PostProcessingManager : MonoBehaviour
{
    new Camera camera;
    UniversalAdditionalCameraData universalAdditionalCameraData;
    [SerializeField] Volume volume;
    [SerializeField] VolumeProfile profile;
    [SerializeField] UIDocument _uiDocument;

    VisualElement element;
    HidePanelUI hideUi;
    public string _ColorSpace;

    [Header("PPSv3制御可能なエフェクト")]
    public AntialiasingMode antialiasing;
    public Bloom bloom;
    public ChannelMixer channelMixer;
    public ChromaticAberration chromaticAberration;
    public ColorAdjustments colorAdjustments;
    public ColorCurves colorCurves;
    public ColorLookup colorLookup;
    public DepthOfField depthOfField;
    public FilmGrain filmGrain;
    public LensDistortion lensDistortion;
    public LiftGammaGain liftGammaGain;
    public MotionBlur motionBlur;
    public PaniniProjection paniniProjection;
    public ShadowsMidtonesHighlights shadowsMidtonesHighlights;
    public SplitToning splitToning;
    public Tonemapping tonemapping;
    public Vignette vignette;
    public WhiteBalance whiteBalance;

    DropdownField _Antialiasing;
    DropdownField _DepthOfField;
    DropdownField _Tonemapping;
    Button _Bloom;
    Button _ChannelMixer;
    Button _ChromaticAberration;
    Button _ColorAdjustments;
    Button _ColorCurves;
    Button _ColorLookup;
    Button _Dithering;
    Button _FilmGrain;
    Button _LensDistortion;
    Button _LiftGammaGain;
    Button _MotionBlur;
    Button _PaniniProjection;
    Button _ShadowsMidtonesHighlights;
    Button _SplitToning;
    Button _Vignette;
    Button _WhiteBalance;

    Label _Version;
    Button _Close;

    void Awake()
    {
#if UNITY_EDITOR
        _ColorSpace = UnityEditor.PlayerSettings.colorSpace.ToString();
#endif
        camera = Camera.main;
        universalAdditionalCameraData = camera.GetComponent<UniversalAdditionalCameraData>();
        AntialiasingModeChange(AntialiasingMode.None); // AntialiasingMode None
        Dithering(false); //Dithering Off
        volume = GetComponent<Volume>();
        profile = volume.profile;

        // TryGet effect profile
        profile.TryGet(out bloom);
        profile.TryGet(out channelMixer);
        profile.TryGet(out chromaticAberration);
        profile.TryGet(out colorAdjustments);
        profile.TryGet(out colorCurves);
        profile.TryGet(out colorLookup);
        profile.TryGet(out depthOfField);
        profile.TryGet(out filmGrain);
        profile.TryGet(out lensDistortion);
        profile.TryGet(out liftGammaGain);
        profile.TryGet(out motionBlur);
        profile.TryGet(out paniniProjection);
        profile.TryGet(out shadowsMidtonesHighlights);
        profile.TryGet(out splitToning);
        profile.TryGet(out tonemapping);
        profile.TryGet(out vignette);
        profile.TryGet(out whiteBalance);

        // All effects disabled
        bloom.active =
        channelMixer.active =
        chromaticAberration.active =
        colorAdjustments.active =
        colorCurves.active =
        colorLookup.active =
        depthOfField.active =
        filmGrain.active =
        lensDistortion.active =
        liftGammaGain.active =
        motionBlur.active =
        paniniProjection.active =
        shadowsMidtonesHighlights.active =
        splitToning.active =
        tonemapping.active =
        vignette.active =
        whiteBalance.active =
        false;

        // UI Toolkit settings
        element = _uiDocument.rootVisualElement;
        hideUi = gameObject.GetComponent<HidePanelUI>();
        _Close = element.Q<Button>("CloseButton");
        _Close.clickable.clickedWithEventInfo += (Event) => hideUi.HideUI();

        _Version = element.Q<Label>("VersionLabel");

        _Antialiasing = element.Q<DropdownField>("AntialiasingDropdownField");
        _Antialiasing.RegisterValueChangedCallback(Event => 
        {
            switch(_Antialiasing.index)
            {
                case 0:
                    AntialiasingModeChange(AntialiasingMode.None);
                    break;
                case 1:
                    AntialiasingModeChange(AntialiasingMode.FastApproximateAntialiasing);
                    break;
                case 2:
                    AntialiasingModeChange(AntialiasingMode.SubpixelMorphologicalAntiAliasing);
                    break;
#if UNITY_2022_2_OR_NEWER
                case 3:
                    AntialiasingModeChange(AntialiasingMode.TemporalAntiAliasing);
                    break;
#endif
                default:
                    _Antialiasing.index = 0;
                    break;
            }
        }); 

        _DepthOfField = element.Q<DropdownField>("DoFDropdownField");
        _DepthOfField.RegisterValueChangedCallback(Event =>
        {
            switch (_DepthOfField.index)
            {
                case 0:
                    depthOfField.active = false;
                    break;
                case 1:
                    depthOfField.active = true;
                    depthOfField.mode.value = DepthOfFieldMode.Off;
                    break;
                case 2:
                    depthOfField.active = true;
                    depthOfField.mode.value = DepthOfFieldMode.Gaussian;
                    break;
                case 3:
                    depthOfField.active = true;
                    depthOfField.mode.value = DepthOfFieldMode.Bokeh;
                    break;
                default:
                    _DepthOfField.index = 0;
                    break;
            }
        });

        _Tonemapping = element.Q<DropdownField>("TonemappingDropdownField");
        _Tonemapping.RegisterValueChangedCallback(Event =>
        {
            switch (_Tonemapping.index)
            {
                case 0:
                    tonemapping.active = false;
                    break;
                case 1:
                    tonemapping.active = true;
                    tonemapping.mode.value = TonemappingMode.None;
                    break;
                case 2:
                    tonemapping.active = true;
                    tonemapping.mode.value = TonemappingMode.Neutral;
                    break;
                case 3:
                    tonemapping.active = true;
                    tonemapping.mode.value = TonemappingMode.ACES;
                    break;
                default:
                    _Tonemapping.index = 0;
                    break;
            }
        });

        _Bloom = element.Q<Button>("BloomButton");
        _Bloom.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.Bloom, _Bloom);

        _ChannelMixer = element.Q<Button>("ChannelMixerButton");
        _ChannelMixer.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.ChannelMixer, _ChannelMixer);

        _ChromaticAberration = element.Q<Button>("ChromaticAberrationButton");
        _ChromaticAberration.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.ChromaticAberration, _ChromaticAberration);

        _ColorAdjustments = element.Q<Button>("ColorAdjustmentsButton");
        _ColorAdjustments.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.ColorAdjustments, _ColorAdjustments);

        _ColorCurves = element.Q<Button>("ColorCurvesButton");
        _ColorCurves.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.ColorCurves, _ColorCurves);

        _ColorLookup = element.Q<Button>("ColorLookupButton");
        _ColorLookup.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.ColorLookup, _ColorLookup);

        _Dithering = element.Q<Button>("DitheringButton");
        _Dithering.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.Dithering, _Dithering);

        _FilmGrain = element.Q<Button>("FilmGrainButton");
        _FilmGrain.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.FilmGrain, _FilmGrain);

        _LensDistortion = element.Q<Button>("LensDistortionButton");
        _LensDistortion.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.LensDistortion, _LensDistortion);

        _LiftGammaGain = element.Q<Button>("LiftGammaGainButton");
        _LiftGammaGain.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.LiftGammaGain, _LiftGammaGain);

        _MotionBlur = element.Q<Button>("MotionBlurButton");
        _MotionBlur.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.MotionBlur, _MotionBlur);

        _PaniniProjection = element.Q<Button>("PaniniProjectionButton");
        _PaniniProjection.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.PaniniProjection, _PaniniProjection);

        _ShadowsMidtonesHighlights = element.Q<Button>("ShadowsMidtonesHighlightsButton");
        _ShadowsMidtonesHighlights.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.ShadowsMidtonesHighlights, _ShadowsMidtonesHighlights);

        _SplitToning = element.Q<Button>("SplitToningButton");
        _SplitToning.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.SplitToning, _SplitToning);

        _Vignette = element.Q<Button>("VignetteButton");
        _Vignette.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.Vignette, _Vignette);

        _WhiteBalance = element.Q<Button>("WhiteBalanceButton");
        _WhiteBalance.clickable.clickedWithEventInfo += (Event) => EffectSwitcher(Effect.WhiteBalance, _WhiteBalance);
    }

    void Update()
    {
        _Version.text = $"{Application.platform} {SystemInfo.graphicsDeviceVersion}\nUnityVersion: {Application.unityVersion}\nColor Space:{_ColorSpace}";
    }

    public void ShowUI(bool b)
    {
        element.style.display = b ? DisplayStyle.Flex : DisplayStyle.None;
    }

    public void AntialiasingModeChange(AntialiasingMode mode)
    {
        universalAdditionalCameraData.antialiasing = mode;
    }

    public void Dithering(bool sw)
    {
        universalAdditionalCameraData.dithering = sw;
    }

    public void EffectSwitcher(Effect effect, Button button)
    {
        bool flag = button.text == "OFF";

        switch (effect)
        {
            case Effect.Bloom:
                bloom.active = flag;
                break;
            case Effect.ChannelMixer:
                channelMixer.active = flag;
                break;
            case Effect.ChromaticAberration:
                chromaticAberration.active = flag;
                break;
            case Effect.ColorAdjustments:
                colorAdjustments.active = flag;
                break;
            case Effect.ColorCurves:
                colorCurves.active = flag;
                break;
            case Effect.ColorLookup:
                colorLookup.active = flag;
                break;
            case Effect.Dithering:
                Dithering(flag);
                break;
            case Effect.FilmGrain:
                filmGrain.active = flag;
                break;
            case Effect.LensDistortion:
                lensDistortion.active = flag;
                break;
            case Effect.LiftGammaGain:
                liftGammaGain.active = flag;
                break;
            case Effect.MotionBlur:
                motionBlur.active = flag;
                break;
            case Effect.PaniniProjection:
                paniniProjection.active = flag;
                break;
            case Effect.ShadowsMidtonesHighlights:
                shadowsMidtonesHighlights.active = flag;
                break;
            case Effect.SplitToning:
                splitToning.active = flag;
                break;
            case Effect.Vignette:
                vignette.active = flag;
                break;
            case Effect.WhiteBalance:
                whiteBalance.active = flag;
                break;
        }
        button.text = flag ? "ON" : "OFF";
    }

    public enum Effect
    {
        Bloom,
        ChannelMixer,
        ChromaticAberration,
        ColorAdjustments,
        ColorCurves,
        ColorLookup,
        Dithering,
        FilmGrain,
        LensDistortion,
        LiftGammaGain,
        MotionBlur,
        PaniniProjection,
        ShadowsMidtonesHighlights,
        SplitToning,
        Vignette,
        WhiteBalance
    }
}
