//Maya ASCII 2017 scene
//Name: rg_grass_02.ma
//Last modified: Sat, Jul 22, 2017 03:28:35 PM
//Codeset: 1252
requires maya "2017";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2017";
fileInfo "version" "2017";
fileInfo "cutIdentifier" "201606150345-997974";
fileInfo "osv" "Microsoft Windows 8 Business Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "education";
createNode transform -n "ALL";
	rename -uid "7FFF53D9-43F5-82BD-3272-A5B567C0F4BF";
createNode transform -n "md_grass_plane" -p "ALL";
	rename -uid "458EC425-4549-665E-C179-E2AB0A1FCACD";
	setAttr -l on ".tx";
	setAttr -l on ".ty";
	setAttr -l on ".tz";
	setAttr -l on ".rx";
	setAttr -l on ".ry";
	setAttr -l on ".rz";
	setAttr -l on ".sx";
	setAttr -l on ".sy";
	setAttr -l on ".sz";
createNode mesh -n "md_grass_planeShape" -p "md_grass_plane";
	rename -uid "9CD714A5-466C-7D76-D2D3-D2B453F4FAF3";
	setAttr -k off ".v";
	setAttr -s 4 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".db" yes;
	setAttr ".bw" 4;
	setAttr ".vcs" 2;
createNode mesh -n "md_grass_planeShape1Orig" -p "md_grass_plane";
	rename -uid "0899E382-470B-327D-B110-A7A16C2428CC";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 8 ".uvst[0].uvsp[0:7]" -type "float2" 0 0 0.33333334 0
		 0.66666669 0 1 0 0 1 0.33333334 1 0.66666669 1 1 1;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt[0:7]" -type "float3"  0 0 -1.5606909 0 0 -1.5606909 
		0 0 -1.5606909 0 0 -1.5606909 0 0 1.5606909 0 0 1.5606909 0 0 1.5606909 0 0 1.5606909;
	setAttr -s 8 ".vt[0:7]"  0 -15.0010700226 2.65941668 1.342593e-015 -5.00035667419 2.65941668
		 2.6851855e-015 5.00035715103 2.65941668 4.027778e-015 15.0010700226 2.65941668 -4.027778e-015 -15.0010700226 -2.65941668
		 -2.6851853e-015 -5.00035667419 -2.65941668 -1.3425929e-015 5.00035715103 -2.65941668
		 0 15.0010700226 -2.65941668;
	setAttr -s 10 ".ed[0:9]"  0 1 0 0 4 0 1 2 0 1 5 1 2 3 0 2 6 1 3 7 0
		 4 5 0 5 6 0 6 7 0;
	setAttr -s 3 -ch 12 ".fc[0:2]" -type "polyFaces" 
		f 4 0 3 -8 -2
		mu 0 4 0 1 5 4
		f 4 2 5 -9 -4
		mu 0 4 1 2 6 5
		f 4 4 6 -10 -6
		mu 0 4 2 3 7 6;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".db" yes;
	setAttr ".bw" 4;
createNode joint -n "grass_jnt_start" -p "ALL";
	rename -uid "54408850-4DB9-4D02-A48D-88AB8F2E0F5E";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".t" -type "double3" 0 -15.000000000000004 0 ;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".jo" -type "double3" 0 0 89.999999999999986 ;
	setAttr ".bps" -type "matrix" 2.2204460492503131e-016 1.0000000000000002 0 0 -1.0000000000000002 2.2204460492503131e-016 0 0
		 0 0 1 0 0 -15.000000000000004 0 1;
	setAttr ".radi" 2;
createNode joint -n "grass_jnt_mid" -p "grass_jnt_start";
	rename -uid "EB2A760D-41CE-C58C-49CB-89ABDF1A288B";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 1;
	setAttr ".t" -type "double3" 15 3.3306690738754688e-015 0 ;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 2.2204460492503131e-016 1.0000000000000002 0 0 -1.0000000000000002 2.2204460492503131e-016 0 0
		 0 0 1 0 0 0 0 1;
	setAttr ".radi" 2;
createNode joint -n "grass_jnt_end" -p "grass_jnt_mid";
	rename -uid "0C00BBF3-494D-524F-BA50-3490A2D93ABB";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 2;
	setAttr ".t" -type "double3" 15 3.3306690738754688e-015 0 ;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".jo" -type "double3" 0 0 -89.999999999999986 ;
	setAttr ".bps" -type "matrix" 1.0000000000000004 0 0 0 0 1.0000000000000004 0 0 0 0 1 0
		 0 15.000000000000004 0 1;
	setAttr ".radi" 2;
createNode groupId -n "skinCluster1GroupId";
	rename -uid "7DBC5DEC-4AF6-AEE7-DA22-FA8E513316F0";
	setAttr ".ihi" 0;
createNode objectSet -n "skinCluster1Set";
	rename -uid "3D8EF790-4512-1D60-D3CC-6C9F491247C4";
	setAttr ".ihi" 0;
	setAttr ".vo" yes;
createNode skinCluster -n "skinCluster1";
	rename -uid "339D7479-4EB6-2571-D762-24A464740CF1";
	setAttr -s 8 ".wl";
	setAttr -s 2 ".wl[0].w[0:1]"  0.99997152854610949 2.8471453890513342e-005;
	setAttr -s 2 ".wl[1].w[0:1]"  0.99788321086266651 0.002116789137333556;
	setAttr -s 2 ".wl[2].w[0:1]"  0.0021167883687190411 0.99788321163128102;
	setAttr -s 2 ".wl[3].w[1:2]"  0.5 0.5;
	setAttr -s 2 ".wl[4].w[0:1]"  0.99997152854610949 2.8471453890513342e-005;
	setAttr -s 2 ".wl[5].w[0:1]"  0.99788321086266651 0.002116789137333556;
	setAttr -s 2 ".wl[6].w[0:1]"  0.0021167883687190411 0.99788321163128102;
	setAttr -s 2 ".wl[7].w[1:2]"  0.5 0.5;
	setAttr -s 3 ".pm";
	setAttr ".pm[0]" -type "matrix" 2.2204460492503121e-016 -0.99999999999999978 0 -0
		 0.99999999999999978 2.2204460492503121e-016 -0 0 -0 -0 1 -0 15 3.3306690738754688e-015 -0 1;
	setAttr ".pm[1]" -type "matrix" 2.2204460492503121e-016 -0.99999999999999978 0 -0
		 0.99999999999999978 2.2204460492503121e-016 -0 0 0 -0 1 -0 -0 0 -0 1;
	setAttr ".pm[2]" -type "matrix" 0.99999999999999956 -0 0 -0 -0 0.99999999999999956 -0 0
		 0 -0 1 -0 -0 -14.999999999999996 -0 1;
	setAttr ".gm" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr -s 3 ".ma";
	setAttr -s 3 ".dpf[0:2]"  4 4 4;
	setAttr -s 3 ".lw";
	setAttr -s 3 ".lw";
	setAttr ".mmi" yes;
	setAttr ".ucm" yes;
	setAttr -s 3 ".ifcl";
	setAttr -s 3 ".ifcl";
createNode dagPose -n "bindPose1";
	rename -uid "6FAA7494-46CE-3CBC-2353-96A1D6359BCD";
	setAttr -s 3 ".wm";
	setAttr -s 3 ".xm";
	setAttr ".xm[0]" -type "matrix" "xform" 1 1 1 0 0 0 0 0 -15.000000000000004
		 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0.70710678118654746 0.70710678118654768 1
		 1 1 yes;
	setAttr ".xm[1]" -type "matrix" "xform" 1 1 1 0 0 0 0 15 3.3306690738754688e-015
		 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[2]" -type "matrix" "xform" 1 1 1 0 0 0 0 15 3.3306690738754688e-015
		 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 -0.70710678118654746 0.70710678118654768 1
		 1 1 yes;
	setAttr -s 3 ".m";
	setAttr -s 3 ".p";
	setAttr ".bp" yes;
createNode groupParts -n "skinCluster1GroupParts";
	rename -uid "6E174326-4E76-9B82-71DE-15B6BFBC3AAD";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "vtx[*]";
createNode tweak -n "tweak1";
	rename -uid "672ED248-440B-99AD-2442-989F6116D028";
createNode objectSet -n "tweakSet1";
	rename -uid "C0398AD3-4564-27AC-CD52-4CBDB7F09EC2";
	setAttr ".ihi" 0;
	setAttr ".vo" yes;
createNode groupId -n "groupId2";
	rename -uid "26250E15-4C20-B00E-E061-34B432E2C248";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts2";
	rename -uid "758E2756-46AC-DD89-7688-B39C59A6ECB6";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "vtx[*]";
createNode polyTweakUV -n "polyTweakUV1";
	rename -uid "86FE6160-4FCB-A6EF-0159-E2A861CCA3CB";
	setAttr ".uopa" yes;
	setAttr -s 8 ".uvtk[0:7]" -type "float2" 0.00012272596 1.00012254715
		 -0.33329242 0.66678929 -0.66670752 0.33345598 -1.00012278557 0.00012269616 1.00012278557
		 -0.00012266636 0.66670758 -0.3334561 0.33329242 -0.66678941 -0.00012272596 -1.00012254715;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 4 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "skinCluster1GroupId.id" "md_grass_planeShape.iog.og[2].gid";
connectAttr "skinCluster1Set.mwc" "md_grass_planeShape.iog.og[2].gco";
connectAttr "groupId2.id" "md_grass_planeShape.iog.og[3].gid";
connectAttr "tweakSet1.mwc" "md_grass_planeShape.iog.og[3].gco";
connectAttr "polyTweakUV1.out" "md_grass_planeShape.i";
connectAttr "tweak1.vl[0].vt[0]" "md_grass_planeShape.twl";
connectAttr "polyTweakUV1.uvtk[0]" "md_grass_planeShape.uvst[0].uvtw";
connectAttr "grass_jnt_start.s" "grass_jnt_mid.is";
connectAttr "grass_jnt_mid.s" "grass_jnt_end.is";
connectAttr "skinCluster1GroupId.msg" "skinCluster1Set.gn" -na;
connectAttr "md_grass_planeShape.iog.og[2]" "skinCluster1Set.dsm" -na;
connectAttr "skinCluster1.msg" "skinCluster1Set.ub[0]";
connectAttr "skinCluster1GroupParts.og" "skinCluster1.ip[0].ig";
connectAttr "skinCluster1GroupId.id" "skinCluster1.ip[0].gi";
connectAttr "bindPose1.msg" "skinCluster1.bp";
connectAttr "grass_jnt_start.wm" "skinCluster1.ma[0]";
connectAttr "grass_jnt_mid.wm" "skinCluster1.ma[1]";
connectAttr "grass_jnt_end.wm" "skinCluster1.ma[2]";
connectAttr "grass_jnt_start.liw" "skinCluster1.lw[0]";
connectAttr "grass_jnt_mid.liw" "skinCluster1.lw[1]";
connectAttr "grass_jnt_end.liw" "skinCluster1.lw[2]";
connectAttr "grass_jnt_start.obcc" "skinCluster1.ifcl[0]";
connectAttr "grass_jnt_mid.obcc" "skinCluster1.ifcl[1]";
connectAttr "grass_jnt_end.obcc" "skinCluster1.ifcl[2]";
connectAttr "grass_jnt_start.msg" "bindPose1.m[0]";
connectAttr "grass_jnt_mid.msg" "bindPose1.m[1]";
connectAttr "grass_jnt_end.msg" "bindPose1.m[2]";
connectAttr "bindPose1.w" "bindPose1.p[0]";
connectAttr "bindPose1.m[0]" "bindPose1.p[1]";
connectAttr "bindPose1.m[1]" "bindPose1.p[2]";
connectAttr "grass_jnt_start.bps" "bindPose1.wm[0]";
connectAttr "grass_jnt_mid.bps" "bindPose1.wm[1]";
connectAttr "grass_jnt_end.bps" "bindPose1.wm[2]";
connectAttr "tweak1.og[0]" "skinCluster1GroupParts.ig";
connectAttr "skinCluster1GroupId.id" "skinCluster1GroupParts.gi";
connectAttr "groupParts2.og" "tweak1.ip[0].ig";
connectAttr "groupId2.id" "tweak1.ip[0].gi";
connectAttr "groupId2.msg" "tweakSet1.gn" -na;
connectAttr "md_grass_planeShape.iog.og[3]" "tweakSet1.dsm" -na;
connectAttr "tweak1.msg" "tweakSet1.ub[0]";
connectAttr "md_grass_planeShape1Orig.w" "groupParts2.ig";
connectAttr "groupId2.id" "groupParts2.gi";
connectAttr "skinCluster1.og[0]" "polyTweakUV1.ip";
connectAttr "md_grass_planeShape.iog" ":initialShadingGroup.dsm" -na;
// End of rg_grass_02.ma
