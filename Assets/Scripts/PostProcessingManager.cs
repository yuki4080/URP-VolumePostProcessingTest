using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    new Camera camera;
    UniversalAdditionalCameraData universalAdditionalCameraData;
    [SerializeField] Volume volume;
    [SerializeField] VolumeProfile profile;

    EffectChanger effectChanger;

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

    [System.Serializable]
    public struct Buttons
    {
        public Button AA_None;
        public Button AA_FXAA;
        public Button AA_SMAA;
        [Space(3)]
        public Button Dit_OFF;
        public Button Dit_ON;
        [Space(3)]
        public Button Bl_OFF;
        public Button Bl_ON;
        [Space(3)]
        public Button CM_OFF;
        public Button CM_ON;
        [Space(3)]
        public Button ChA_OFF;
        public Button ChA_ON;
        [Space(3)]
        public Button CoA_OFF;
        public Button CoA_ON;
        [Space(3)]
        public Button CC_OFF;
        public Button CC_ON;
        [Space(3)]
        public Button CL_OFF;
        public Button CL_ON;
        [Space(3)]
        public Button DoF_OFF;
        public Button DoF_Gaussian;
        public Button DoF_Bokeh;
        [Space(3)]
        public Button FG_OFF;
        public Button FG_ON;
        [Space(3)]
        public Button LD_OFF;
        public Button LD_ON;
        [Space(3)]
        public Button LGG_OFF;
        public Button LGG_ON;
        [Space(3)]
        public Button MB_OFF;
        public Button MB_ON;
        [Space(3)]
        public Button PP_OFF;
        public Button PP_ON;
        [Space(3)]
        public Button SMH_OFF;
        public Button SMH_ON;
        [Space(3)]
        public Button ST_OFF;
        public Button ST_ON;
        [Space(3)]
        public Button Ton_OFF;
        public Button Ton_None;
        public Button Ton_Neutral;
        public Button Ton_ACES;
        [Space(3)]
        public Button Vig_OFF;
        public Button Vig_ON;
        [Space(3)]
        public Button WB_OFF;
        public Button WB_ON;
    }

    [Header("エフェクト切り替えボタン")]
    public Buttons buttons;

    void Awake()
    {
        camera = Camera.main;
        universalAdditionalCameraData = camera.GetComponent<UniversalAdditionalCameraData>();
        AntialiasingModeChange(AntialiasingMode.None); // AntialiasingMode None
        Dithering(false); //Dithering Off
        volume = GetComponent<Volume>();
        profile = volume.profile;
        effectChanger = GetComponent<EffectChanger>();

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
    }

    public void AntialiasingModeChange(AntialiasingMode mode)
    {
        switch (mode)
        {
            case AntialiasingMode.None:
                universalAdditionalCameraData.antialiasing = mode;
                break;
            case AntialiasingMode.FastApproximateAntialiasing:
                universalAdditionalCameraData.antialiasing = mode;
                break;
            case AntialiasingMode.SubpixelMorphologicalAntiAliasing:
                universalAdditionalCameraData.antialiasing = mode;
                break;
        }
    }

    public void Dithering(bool sw)
    {
        universalAdditionalCameraData.dithering = sw;
    }

}
