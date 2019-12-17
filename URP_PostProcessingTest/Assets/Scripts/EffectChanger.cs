using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System;

public class EffectChanger : MonoBehaviour
{
    PostProcessingManager PPManager;

    #region OutlineDefine
    Outline AA_None;
    Outline AA_FXAA;
    Outline AA_SMAA;

    Outline Dit_OFF;
    Outline Dit_ON;

    Outline Bl_OFF;
    Outline Bl_ON;

    Outline CM_OFF;
    Outline CM_ON;

    Outline ChA_OFF;
    Outline ChA_ON;

    Outline CoA_OFF;
    Outline CoA_ON;

    Outline CC_OFF;
    Outline CC_ON;

    Outline CL_OFF;
    Outline CL_ON;

    Outline DoF_OFF;
    Outline DoF_Gaussian;
    Outline DoF_Bokeh;

    Outline FG_OFF;
    Outline FG_ON;

    Outline LD_OFF;
    Outline LD_ON;

    Outline LGG_OFF;
    Outline LGG_ON;

    Outline MB_OFF;
    Outline MB_ON;

    Outline PP_OFF;
    Outline PP_ON;

    Outline SMH_OFF;
    Outline SMH_ON;

    Outline ST_OFF;
    Outline ST_ON;

    Outline Ton_OFF;
    Outline Ton_None;
    Outline Ton_Neutral;
    Outline Ton_ACES;

    Outline Vig_OFF;
    Outline Vig_ON;

    Outline WB_OFF;
    Outline WB_ON;
    #endregion

    public enum btnName
    {
        Antialiasing_None,
        Antialiasing_FXAA,
        Antialiasing_SMAA,
        Dithering_OFF,
        Dithering_ON,
        Bloom_OFF,
        Bloom_ON,
        ChannelMixed_OFF,
        ChannelMixed_ON,
        ChromaticAberration_OFF,
        ChromaticAberration_ON,
        ColorAdjustments_OFF,
        ColorAdjustments_ON,
        ColorCurves_OFF,
        ColorCurves_ON,
        ColorLookup_OFF,
        ColorLookup_ON,
        DepthofField_OFF,
        DepthofField_Gaussian,
        DepthofField_Bokeh,
        FilmGrain_OFF,
        FilmGrain_ON,
        LensDistortion_OFF,
        LensDistortion_ON,
        LiftGammaGain_OFF,
        LiftGammaGain_ON,
        MotionBlur_OFF,
        MotionBlur_ON,
        PaniniProjection_OFF,
        PaniniProjection_ON,
        ShadowsMidtonesHighlights_OFF,
        ShadowsMidtonesHighlights_ON,
        SplitTones_OFF,
        SplitTones_ON,
        Tonemapping_OFF,
        Tonemapping_None,
        Tonemapping_Neutral,
        Tonemapping_ACES,
        Vignette_OFF,
        Vignette_ON,
        WhiteBalance_OFF,
        WhiteBalance_ON
    }

    void Awake()
    {
        PPManager = GetComponent<PostProcessingManager>();
        #region OutlineSettingsInitialize
        AA_None = PPManager.buttons.AA_None.GetComponent<Outline>();
        AA_FXAA = PPManager.buttons.AA_FXAA.GetComponent<Outline>();
        AA_SMAA = PPManager.buttons.AA_SMAA.GetComponent<Outline>();
        Dit_OFF = PPManager.buttons.Dit_OFF.GetComponent<Outline>();
        Dit_ON = PPManager.buttons.Dit_ON.GetComponent<Outline>();
        Bl_OFF = PPManager.buttons.Bl_OFF.GetComponent<Outline>();
        Bl_ON = PPManager.buttons.Bl_ON.GetComponent<Outline>();
        CM_OFF = PPManager.buttons.CM_OFF.GetComponent<Outline>();
        CM_ON = PPManager.buttons.CM_ON.GetComponent<Outline>();
        ChA_OFF = PPManager.buttons.ChA_OFF.GetComponent<Outline>();
        ChA_ON = PPManager.buttons.ChA_ON.GetComponent<Outline>();
        CoA_OFF = PPManager.buttons.CoA_OFF.GetComponent<Outline>();
        CoA_ON = PPManager.buttons.CoA_ON.GetComponent<Outline>();
        CC_OFF = PPManager.buttons.CC_OFF.GetComponent<Outline>();
        CC_ON = PPManager.buttons.CC_ON.GetComponent<Outline>();
        CL_OFF = PPManager.buttons.CL_OFF.GetComponent<Outline>();
        CL_ON = PPManager.buttons.CL_ON.GetComponent<Outline>();
        DoF_OFF = PPManager.buttons.DoF_OFF.GetComponent<Outline>();
        DoF_Gaussian = PPManager.buttons.DoF_Gaussian.GetComponent<Outline>();
        DoF_Bokeh = PPManager.buttons.DoF_Bokeh.GetComponent<Outline>();
        FG_OFF = PPManager.buttons.FG_OFF.GetComponent<Outline>();
        FG_ON = PPManager.buttons.FG_ON.GetComponent<Outline>();
        LD_OFF = PPManager.buttons.LD_OFF.GetComponent<Outline>();
        LD_ON = PPManager.buttons.LD_ON.GetComponent<Outline>();
        LGG_OFF = PPManager.buttons.LGG_OFF.GetComponent<Outline>();
        LGG_ON = PPManager.buttons.LGG_ON.GetComponent<Outline>();
        MB_OFF = PPManager.buttons.MB_OFF.GetComponent<Outline>();
        MB_ON = PPManager.buttons.MB_ON.GetComponent<Outline>();
        PP_OFF = PPManager.buttons.PP_OFF.GetComponent<Outline>();
        PP_ON = PPManager.buttons.PP_ON.GetComponent<Outline>();
        SMH_OFF = PPManager.buttons.SMH_OFF.GetComponent<Outline>();
        SMH_ON = PPManager.buttons.SMH_ON.GetComponent<Outline>();
        ST_OFF = PPManager.buttons.ST_OFF.GetComponent<Outline>();
        ST_ON = PPManager.buttons.ST_ON.GetComponent<Outline>();
        Ton_OFF = PPManager.buttons.Ton_OFF.GetComponent<Outline>();
        Ton_None = PPManager.buttons.Ton_None.GetComponent<Outline>();
        Ton_Neutral = PPManager.buttons.Ton_Neutral.GetComponent<Outline>();
        Ton_ACES = PPManager.buttons.Ton_ACES.GetComponent<Outline>();
        Vig_OFF = PPManager.buttons.Vig_OFF.GetComponent<Outline>();
        Vig_ON = PPManager.buttons.Vig_ON.GetComponent<Outline>();
        WB_OFF = PPManager.buttons.WB_OFF.GetComponent<Outline>();
        WB_ON = PPManager.buttons.WB_ON.GetComponent<Outline>();
        #endregion

        InitializeButtonHighlights();
    }

    public void InitializeButtonHighlights()
    {
        // Initialize button highlights
        AA_None.enabled =
        Dit_OFF.enabled =
        Bl_OFF.enabled =
        CM_OFF.enabled =
        ChA_OFF.enabled =
        CoA_OFF.enabled =
        CC_OFF.enabled =
        CL_OFF.enabled =
        DoF_OFF.enabled =
        FG_OFF.enabled =
        LD_OFF.enabled =
        LGG_OFF.enabled =
        MB_OFF.enabled =
        PP_OFF.enabled =
        SMH_OFF.enabled =
        ST_OFF.enabled =
        Ton_OFF.enabled =
        Vig_OFF.enabled =
        WB_OFF.enabled = true;
    }

    public void EffectChangeInitialize(string eff)
    {
        switch (eff)
        {
            case "Antialiasing":
                AA_None.enabled =
                AA_FXAA.enabled =
                AA_SMAA.enabled = false;
                break;
            case "Dithering":
                Dit_OFF.enabled =
                Dit_ON.enabled = false;
                break;
            case "Bloom":
                Bl_OFF.enabled =
                Bl_ON.enabled = false;
                break;
            case "ChannelMixed":
                CM_OFF.enabled =
                CM_ON.enabled = false;
                break;
            case "ChromaticAberration":
                ChA_OFF.enabled =
                ChA_ON.enabled = false;
                break;
            case "ColorAdjustments":
                CoA_OFF.enabled =
                CoA_ON.enabled = false;
                break;
            case "ColorCurves":
                CC_OFF.enabled =
                CC_ON.enabled = false;
                break;
            case "ColorLookup":
                CL_OFF.enabled =
                CL_ON.enabled = false;
                break;
            case "DepthofField":
                DoF_OFF.enabled =
                DoF_Gaussian.enabled =
                DoF_Bokeh.enabled = false;
                break;
            case "FilmGrain":
                FG_OFF.enabled =
                FG_ON.enabled = false;
                break;
            case "LensDistortion":
                LD_OFF.enabled =
                LD_ON.enabled = false;
                break;
            case "LiftGammaGain":
                LGG_OFF.enabled =
                LGG_ON.enabled = false;
                break;
            case "MotionBlur":
                MB_OFF.enabled =
                MB_ON.enabled = false;
                break;
            case "PaniniProjection":
                PP_OFF.enabled =
                PP_ON.enabled = false;
                break;
            case "ShadowsMidtonesHighlights":
                SMH_OFF.enabled =
                SMH_ON.enabled = false;
                break;
            case "SplitTones":
                ST_OFF.enabled =
                ST_ON.enabled = false;
                break;
            case "Tonemapping":
                Ton_OFF.enabled =
                Ton_None.enabled =
                Ton_Neutral.enabled =
                Ton_ACES.enabled = false;
                break;
            case "Vignette":
                Vig_OFF.enabled =
                Vig_ON.enabled = false;
                break;
            case "WhiteBalance":
                WB_OFF.enabled =
                WB_ON.enabled = false;
                break;
            default:
                break;
        }
    }

    public void EffectChangeEvent(int num)
    {
        btnName EffectName = (btnName)Enum.ToObject(typeof(btnName), num);
        switch (EffectName)
        {
            case btnName.Antialiasing_None:
                EffectChangeInitialize("Antialiasing");
                AA_None.enabled = true;
                PPManager.AntialiasingModeChange(AntialiasingMode.None);
                break;
            case btnName.Antialiasing_FXAA:
                EffectChangeInitialize("Antialiasing");
                AA_FXAA.enabled = true;
                PPManager.AntialiasingModeChange(AntialiasingMode.FastApproximateAntialiasing);
                break;
            case btnName.Antialiasing_SMAA:
                EffectChangeInitialize("Antialiasing");
                AA_SMAA.enabled = true;
                PPManager.AntialiasingModeChange(AntialiasingMode.SubpixelMorphologicalAntiAliasing);
                break;
            case btnName.Dithering_OFF:
                EffectChangeInitialize("Dithering");
                Dit_OFF.enabled = true;
                PPManager.Dithering(false);
                break;
            case btnName.Dithering_ON:
                EffectChangeInitialize("Dithering");
                Dit_ON.enabled = true;
                PPManager.Dithering(true);
                break;
            case btnName.Bloom_OFF:
                EffectChangeInitialize("Bloom");
                Bl_OFF.enabled = true;
                PPManager.bloom.active = false;
                break;
            case btnName.Bloom_ON:
                EffectChangeInitialize("Bloom");
                Bl_ON.enabled = true;
                PPManager.bloom.active = true;
                break;
            case btnName.ChannelMixed_OFF:
                EffectChangeInitialize("ChannelMixed");
                CM_OFF.enabled = true;
                PPManager.channelMixer.active = false;
                break;
            case btnName.ChannelMixed_ON:
                EffectChangeInitialize("ChannelMixed");
                CM_ON.enabled = true;
                PPManager.channelMixer.active = true;
                break;
            case btnName.ChromaticAberration_OFF:
                EffectChangeInitialize("ChromaticAberration");
                ChA_OFF.enabled = true;
                PPManager.chromaticAberration.active = false;
                break;
            case btnName.ChromaticAberration_ON:
                EffectChangeInitialize("ChromaticAberration");
                ChA_ON.enabled = true;
                PPManager.chromaticAberration.active = true;
                break;
            case btnName.ColorAdjustments_OFF:
                EffectChangeInitialize("ColorAdjustments");
                CoA_OFF.enabled = true;
                PPManager.colorAdjustments.active = false;
                break;
            case btnName.ColorAdjustments_ON:
                EffectChangeInitialize("ColorAdjustments");
                CoA_ON.enabled = true;
                PPManager.colorAdjustments.active = true;
                break;
            case btnName.ColorCurves_OFF:
                EffectChangeInitialize("ColorCurves");
                CC_OFF.enabled = true;
                PPManager.colorCurves.active = false;
                break;
            case btnName.ColorCurves_ON:
                EffectChangeInitialize("ColorCurves");
                CC_ON.enabled = true;
                PPManager.colorCurves.active = true;
                break;
            case btnName.ColorLookup_OFF:
                EffectChangeInitialize("ColorLookup");
                CL_OFF.enabled = true;
                PPManager.colorLookup.active = false;
                break;
            case btnName.ColorLookup_ON:
                EffectChangeInitialize("ColorLookup");
                CL_ON.enabled = true;
                PPManager.colorLookup.active = true;
                break;
            case btnName.DepthofField_OFF:
                EffectChangeInitialize("DepthofField");
                DoF_OFF.enabled = true;
                PPManager.depthOfField.active = false;
                break;
            case btnName.DepthofField_Gaussian:
                EffectChangeInitialize("DepthofField");
                DoF_Gaussian.enabled = true;
                PPManager.depthOfField.mode.value = DepthOfFieldMode.Gaussian;
                PPManager.depthOfField.active = true;
                break;
            case btnName.DepthofField_Bokeh:
                EffectChangeInitialize("DepthofField");
                DoF_Bokeh.enabled = true;
                PPManager.depthOfField.mode.value = DepthOfFieldMode.Bokeh;
                PPManager.depthOfField.active = true;
                break;
            case btnName.FilmGrain_OFF:
                EffectChangeInitialize("FilmGrain");
                FG_OFF.enabled = true;
                PPManager.filmGrain.active = false;
                break;
            case btnName.FilmGrain_ON:
                EffectChangeInitialize("FilmGrain");
                FG_ON.enabled = true;
                PPManager.filmGrain.active = true;
                break;
            case btnName.LensDistortion_OFF:
                EffectChangeInitialize("LensDistortion");
                LD_OFF.enabled = true;
                PPManager.lensDistortion.active = false;
                break;
            case btnName.LensDistortion_ON:
                EffectChangeInitialize("LensDistortion");
                LD_ON.enabled = true;
                PPManager.lensDistortion.active = true;
                break;
            case btnName.LiftGammaGain_OFF:
                EffectChangeInitialize("LiftGammaGain");
                LGG_OFF.enabled = true;
                PPManager.liftGammaGain.active = false;
                break;
            case btnName.LiftGammaGain_ON:
                EffectChangeInitialize("LiftGammaGain");
                LGG_ON.enabled = true;
                PPManager.liftGammaGain.active = true;
                break;
            case btnName.MotionBlur_OFF:
                EffectChangeInitialize("MotionBlur");
                MB_OFF.enabled = true;
                PPManager.motionBlur.active = false;
                break;
            case btnName.MotionBlur_ON:
                EffectChangeInitialize("MotionBlur");
                MB_ON.enabled = true;
                PPManager.motionBlur.active = true;
                break;
            case btnName.PaniniProjection_OFF:
                EffectChangeInitialize("PaniniProjection");
                PP_OFF.enabled = true;
                PPManager.paniniProjection.active = false;
                break;
            case btnName.PaniniProjection_ON:
                EffectChangeInitialize("PaniniProjection");
                PP_ON.enabled = true;
                PPManager.paniniProjection.active = true;
                break;
            case btnName.ShadowsMidtonesHighlights_OFF:
                EffectChangeInitialize("ShadowsMidtonesHighlights");
                SMH_OFF.enabled = true;
                PPManager.shadowsMidtonesHighlights.active = false;
                break;
            case btnName.ShadowsMidtonesHighlights_ON:
                EffectChangeInitialize("ShadowsMidtonesHighlights");
                SMH_ON.enabled = true;
                PPManager.shadowsMidtonesHighlights.active = true;
                break;
            case btnName.SplitTones_OFF:
                EffectChangeInitialize("SplitTones");
                ST_OFF.enabled = true;
                PPManager.splitToning.active = false;
                break;
            case btnName.SplitTones_ON:
                EffectChangeInitialize("SplitTones");
                ST_ON.enabled = true;
                PPManager.splitToning.active = true;
                break;
            case btnName.Tonemapping_OFF:
                EffectChangeInitialize("Tonemapping");
                Ton_OFF.enabled = true;
                PPManager.tonemapping.active = false;
                break;
            case btnName.Tonemapping_None:
                EffectChangeInitialize("Tonemapping");
                Ton_None.enabled = true;
                PPManager.tonemapping.mode.value = TonemappingMode.None;
                PPManager.tonemapping.active = true;
                break;
            case btnName.Tonemapping_Neutral:
                EffectChangeInitialize("Tonemapping");
                Ton_Neutral.enabled = true;
                PPManager.tonemapping.mode.value = TonemappingMode.Neutral;
                PPManager.tonemapping.active = true;
                break;
            case btnName.Tonemapping_ACES:
                EffectChangeInitialize("Tonemapping");
                Ton_ACES.enabled = true;
                PPManager.tonemapping.mode.value = TonemappingMode.ACES;
                PPManager.tonemapping.active = true;
                break;
            case btnName.Vignette_OFF:
                EffectChangeInitialize("Vignette");
                Vig_OFF.enabled = true;
                PPManager.vignette.active = false;
                break;
            case btnName.Vignette_ON:
                EffectChangeInitialize("Vignette");
                Vig_ON.enabled = true;
                PPManager.vignette.active = true;
                break;
            case btnName.WhiteBalance_OFF:
                EffectChangeInitialize("WhiteBalance");
                WB_OFF.enabled = true;
                PPManager.whiteBalance.active = false;
                break;
            case btnName.WhiteBalance_ON:
                EffectChangeInitialize("WhiteBalance");
                WB_ON.enabled = true;
                PPManager.whiteBalance.active = true;
                break;
            default:
                break;
        }
    }
}
