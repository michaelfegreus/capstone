//Maya ASCII 2017 scene
//Name: rg_grass_04.ma
//Last modified: Sat, Jul 22, 2017 04:16:56 PM
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
	rename -uid "3168B463-4893-3396-C784-5DBCD639F4BB";
createNode joint -n "grass_jnt_ROOT" -p "ALL";
	rename -uid "17058538-4FCB-CE68-54DD-19ACDC8668A9";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".t" -type "double3" 0 -1 0 ;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".jo" -type "double3" 0 0 89.999999999999986 ;
	setAttr ".bps" -type "matrix" 2.2204460492503131e-016 1.0000000000000002 0 0 -1.0000000000000002 2.2204460492503131e-016 0 0
		 0 0 1 0 0 -1 0 1;
	setAttr ".radi" 2;
createNode joint -n "grass_jnt_end" -p "grass_jnt_ROOT";
	rename -uid "3B021AD1-4B5E-FC8A-89E2-49AB27DC5252";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 1;
	setAttr ".t" -type "double3" 1.3773800503379814 3.0583980910891676e-016 0 ;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".jo" -type "double3" 0 0 -89.999999999999986 ;
	setAttr ".bps" -type "matrix" 1.0000000000000004 0 0 0 0 1.0000000000000004 0 0 0 0 1 0
		 0 0.37738005033798161 0 1;
	setAttr ".radi" 2;
createNode transform -n "md_grass_plane" -p "ALL";
	rename -uid "C370B675-44B5-DBC6-2BEA-E1A9AA43C509";
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
	rename -uid "479E5C79-450F-C324-979B-189C9CEABA0E";
	setAttr -k off ".v";
	setAttr -s 4 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".db" yes;
	setAttr ".bw" 4;
	setAttr ".vcs" 2;
createNode mesh -n "md_grass_planeShape1Orig" -p "md_grass_plane";
	rename -uid "0B3D9EA1-450F-6D80-B9AB-6FB6A584A78D";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 10 ".uvst[0].uvsp[0:9]" -type "float2" 0 0 1 0 0 0.25 1
		 0.25 0 0.5 1 0.5 0 0.75 1 0.75 0 1 1 1;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 10 ".pt[0:9]" -type "float3"  0.049347296 0 0 -0.049347296 
		0 0 0.049347296 0 0 -0.049347296 0 0 0.049347296 0 0 -0.049347296 0 0 0.049347296 
		0 0 -0.049347296 0 0 0.049347296 0 0 -0.049347296 0 0;
	setAttr -s 10 ".vt[0:9]"  -0.24762626 -0.99701679 0 0.24762626 -0.99701679 0
		 -0.24762626 -0.49850839 0 0.24762626 -0.49850839 0 -0.24762626 0 0 0.24762626 0 0
		 -0.24762626 0.49850839 0 0.24762626 0.49850839 0 -0.24762626 0.99701679 0 0.24762626 0.99701679 0;
	setAttr -s 13 ".ed[0:12]"  0 1 0 0 2 0 1 3 0 2 3 1 2 4 0 3 5 0 4 5 1
		 4 6 0 5 7 0 6 7 1 6 8 0 7 9 0 8 9 0;
	setAttr -s 4 -ch 16 ".fc[0:3]" -type "polyFaces" 
		f 4 0 2 -4 -2
		mu 0 4 0 1 3 2
		f 4 3 5 -7 -5
		mu 0 4 2 3 5 4
		f 4 6 8 -10 -8
		mu 0 4 4 5 7 6
		f 4 9 11 -13 -11
		mu 0 4 6 7 9 8;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".db" yes;
	setAttr ".bw" 4;
createNode groupId -n "skinCluster1GroupId";
	rename -uid "91D9722B-4D34-A859-AAE2-B68380E5D09A";
	setAttr ".ihi" 0;
createNode objectSet -n "skinCluster1Set";
	rename -uid "531D792A-44A1-DD2C-7A62-14A942336CCD";
	setAttr ".ihi" 0;
	setAttr ".vo" yes;
createNode skinCluster -n "skinCluster1";
	rename -uid "8322E328-48FA-8828-352F-34B66E0283C8";
	setAttr -s 10 ".wl";
	setAttr -s 2 ".wl[0].w[0:1]"  0.99958448632005392 0.00041551367994607937;
	setAttr -s 2 ".wl[1].w[0:1]"  0.99958448632005392 0.00041551367994607937;
	setAttr -s 2 ".wl[2].w[0:1]"  0.79478931427001953 0.20521068572998047;
	setAttr -s 2 ".wl[3].w[0:1]"  0.79566891491413116 0.20433108508586884;
	setAttr -s 2 ".wl[4].w[0:1]"  0.7182127833366394 0.2817872166633606;
	setAttr -s 2 ".wl[5].w[0:1]"  0.77445641160011292 0.22554358839988708;
	setAttr -s 2 ".wl[6].w[0:1]"  0.503406822681427 0.496593177318573;
	setAttr -s 2 ".wl[7].w[0:1]"  0.40644323825836182 0.59355676174163818;
	setAttr ".wl[8].w[1]"  1;
	setAttr ".wl[9].w[1]"  1;
	setAttr -s 2 ".pm";
	setAttr ".pm[0]" -type "matrix" 2.2204460492503121e-016 -0.99999999999999978 0 -0
		 0.99999999999999978 2.2204460492503121e-016 -0 0 -0 -0 1 -0 0.99999999999999978 2.2204460492503121e-016 -0 1;
	setAttr ".pm[1]" -type "matrix" 0.99999999999999956 -0 0 -0 -0 0.99999999999999956 -0 0
		 0 -0 1 -0 -0 -0.37738005033798144 -0 1;
	setAttr ".gm" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr -s 2 ".ma";
	setAttr -s 2 ".dpf[0:1]"  4 4;
	setAttr -s 2 ".lw";
	setAttr -s 2 ".lw";
	setAttr ".mmi" yes;
	setAttr ".ucm" yes;
	setAttr -s 2 ".ifcl";
	setAttr -s 2 ".ifcl";
createNode dagPose -n "bindPose1";
	rename -uid "7AF5DA51-43D9-5B44-85EC-D981106F0E4A";
	setAttr -s 2 ".wm";
	setAttr -s 2 ".xm";
	setAttr ".xm[0]" -type "matrix" "xform" 1 1 1 0 0 0 0 0 -1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 0 0 0 0 0 0 1 0 0 0.70710678118654746 0.70710678118654768 1 1 1 yes;
	setAttr ".xm[1]" -type "matrix" "xform" 1 1 1 0 0 0 0 1.3773800503379814 3.0583980910891676e-016
		 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 -0.70710678118654746 0.70710678118654768 1
		 1 1 yes;
	setAttr -s 2 ".m";
	setAttr -s 2 ".p";
	setAttr ".bp" yes;
createNode groupParts -n "skinCluster1GroupParts";
	rename -uid "435EB1C3-4FD2-39CD-C14B-45B02CACFFAC";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "vtx[*]";
createNode tweak -n "tweak1";
	rename -uid "E363102D-4B73-FC1B-3A38-C09DA1A8737E";
createNode objectSet -n "tweakSet1";
	rename -uid "1F734C75-4513-D405-557D-16B16AE28535";
	setAttr ".ihi" 0;
	setAttr ".vo" yes;
createNode groupId -n "groupId2";
	rename -uid "60A75E2E-412B-74CB-20C4-C88106588D12";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts2";
	rename -uid "A3B6AB59-4C2A-589C-AFC2-588FDC09CB99";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "vtx[*]";
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
connectAttr "grass_jnt_ROOT.s" "grass_jnt_end.is";
connectAttr "skinCluster1GroupId.id" "md_grass_planeShape.iog.og[0].gid";
connectAttr "skinCluster1Set.mwc" "md_grass_planeShape.iog.og[0].gco";
connectAttr "groupId2.id" "md_grass_planeShape.iog.og[1].gid";
connectAttr "tweakSet1.mwc" "md_grass_planeShape.iog.og[1].gco";
connectAttr "skinCluster1.og[0]" "md_grass_planeShape.i";
connectAttr "tweak1.vl[0].vt[0]" "md_grass_planeShape.twl";
connectAttr "skinCluster1GroupId.msg" "skinCluster1Set.gn" -na;
connectAttr "md_grass_planeShape.iog.og[0]" "skinCluster1Set.dsm" -na;
connectAttr "skinCluster1.msg" "skinCluster1Set.ub[0]";
connectAttr "skinCluster1GroupParts.og" "skinCluster1.ip[0].ig";
connectAttr "skinCluster1GroupId.id" "skinCluster1.ip[0].gi";
connectAttr "bindPose1.msg" "skinCluster1.bp";
connectAttr "grass_jnt_ROOT.wm" "skinCluster1.ma[0]";
connectAttr "grass_jnt_end.wm" "skinCluster1.ma[1]";
connectAttr "grass_jnt_ROOT.liw" "skinCluster1.lw[0]";
connectAttr "grass_jnt_end.liw" "skinCluster1.lw[1]";
connectAttr "grass_jnt_ROOT.obcc" "skinCluster1.ifcl[0]";
connectAttr "grass_jnt_end.obcc" "skinCluster1.ifcl[1]";
connectAttr "grass_jnt_end.msg" "skinCluster1.ptt";
connectAttr "grass_jnt_ROOT.msg" "bindPose1.m[0]";
connectAttr "grass_jnt_end.msg" "bindPose1.m[1]";
connectAttr "bindPose1.w" "bindPose1.p[0]";
connectAttr "bindPose1.m[0]" "bindPose1.p[1]";
connectAttr "grass_jnt_ROOT.bps" "bindPose1.wm[0]";
connectAttr "grass_jnt_end.bps" "bindPose1.wm[1]";
connectAttr "tweak1.og[0]" "skinCluster1GroupParts.ig";
connectAttr "skinCluster1GroupId.id" "skinCluster1GroupParts.gi";
connectAttr "groupParts2.og" "tweak1.ip[0].ig";
connectAttr "groupId2.id" "tweak1.ip[0].gi";
connectAttr "groupId2.msg" "tweakSet1.gn" -na;
connectAttr "md_grass_planeShape.iog.og[1]" "tweakSet1.dsm" -na;
connectAttr "tweak1.msg" "tweakSet1.ub[0]";
connectAttr "md_grass_planeShape1Orig.w" "groupParts2.ig";
connectAttr "groupId2.id" "groupParts2.gi";
connectAttr "md_grass_planeShape.iog" ":initialShadingGroup.dsm" -na;
// End of rg_grass_04.ma
