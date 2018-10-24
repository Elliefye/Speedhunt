/*  Author's info:
 *  - Blog  : http://n00body.squarespace.com/
 *  - E-mail: crunchy.bytes.blog@gmail.com
 *
 *  Usage Requirements:
 *  - If you use a large portion of my codebase, please credit either myself
 *      or the original author for portions of code that have been borrowed
 *  - If you wish to use bits of my code in a commercial project, please use
 *      the provided information to contact me and tell me about it.
 */

Shader "[n00b's RNM]/RNM-Cutout" {
    Properties {
        _MainColor          ("Main Color", Color)           = (1,1,1,1)
        _LightMapColor      ("LightMap Color", Color)       = (1,1,1,0) 
        _LightMapIntensity  ("LightMap Intensity", Float)   = 1
        _CutoutThreshold    ("Cutout Threshold", Range(0,1))= 0.5
        _CutoutMap          ("Cutout Map", 2D)              = "white" {}
        _MainTex            ("Main Texture", 2D)            = "white" {}
        _BumpMap            ("Bump Map", 2D)                = "bump" {}
        _LightMap0          ("LightMap 0", 2D)              = "white" {}
        _LightMap1          ("LightMap 1", 2D)              = "white" {}
        _LightMap2          ("LightMap 2", 2D)              = "white" {}
    }
    SubShader {
        Tags { "RenderType" = "Opaque" }
        CGPROGRAM
            #pragma surface Surface Lambert alphatest:_CutoutThreshold
            
            #define Square(x)   x * x 
            #define DeGamma(x)  Square(x)
            #define ReGamma(x)  sqrt(x)
            
            struct Input 
            {
                float2 uv_MainTex;
                float2 uv2_LightMap0; 
            };
            
            uniform float4      _MainColor;
            uniform float3      _LightMapColor; 
            uniform float       _LightMapIntensity;
            uniform sampler2D   _CutoutMap;
            uniform sampler2D   _MainTex;
            uniform sampler2D   _BumpMap; 
            uniform sampler2D   _LightMap0;
            uniform sampler2D   _LightMap1; 
            uniform sampler2D   _LightMap2; 
           
            void Surface (Input IN, inout SurfaceOutput o) 
            {
                half3 dp;
                half3 DiffuseLight;
                half3 Result;
            
                // Valve RNM basis (Right-Handed)
                // http://www.valvesoftware.com/publications/2004/GDC2004_Half-Life2_Shading.pdf
                half3 RNM_BASIS[3] =
                {
                    half3(sqrt(2.0) / sqrt(3.0),              0.0, 1.0 / sqrt(3.0)), 
                    half3(     -1.0 / sqrt(6.0),  1.0 / sqrt(2.0), 1.0 / sqrt(3.0)),
                    half3(     -1.0 / sqrt(6.0), -1.0 / sqrt(2.0), 1.0 / sqrt(3.0))
                };
            
                // ---- Material ----
                half4 Material  = (half4)tex2D(_MainTex, IN.uv_MainTex);
                half3 Normal    = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex)).xyz;
                
                o.Alpha     = tex2D(_CutoutMap, IN.uv_MainTex).a;
                o.Albedo    = Material.rgb * _MainColor;
                o.Normal    = Normal;
                o.Gloss     = 0.0f; // _SpecColor gets implicitly multiplied (>_<)
                o.Specular  = 1.0f;
                o.Emission  = 0.0f;
                
                // ---- Static Lighting ----                
                // De-Gamma surface materials & lightmaps 
                half3 DiffuseColor      = DeGamma(o.Albedo);
                
                half3 Irradiance0 = DeGamma((half3)tex2D(_LightMap0, IN.uv2_LightMap0).rgb);
                half3 Irradiance1 = DeGamma((half3)tex2D(_LightMap1, IN.uv2_LightMap0).rgb);
                half3 Irradiance2 = DeGamma((half3)tex2D(_LightMap2, IN.uv2_LightMap0).rgb);
                
                // Diffuse Lighting
                // http://www.valvesoftware.com/publications/2004/GDC2004_Half-Life2_Shading.pdf
                dp.x = saturate(dot(o.Normal, RNM_BASIS[0]));
                dp.y = saturate(dot(o.Normal, RNM_BASIS[1]));
                dp.z = saturate(dot(o.Normal, RNM_BASIS[2]));
                dp *= dp;

                dp = dp / dot(dp, half3(1.0f, 1.0f, 1.0f));

                DiffuseLight = dp.x * Irradiance0 +
                                dp.y * Irradiance1 +
                                dp.z * Irradiance2;
                
                // Accumulate in linear space
                Result = DeGamma(_LightMapColor) * _LightMapIntensity *
                        (DiffuseLight * DiffuseColor);
                
                // Re-Gamma result (>_<)
                o.Emission  += ReGamma(Result);
            }
        ENDCG
    }
    Fallback "[n00b's RNM]/RNM"
}
