//Maya ASCII 2016 scene
//Name: md_rock_keyart01.ma
//Last modified: Sun, Jul 23, 2017 09:51:04 PM
//Codeset: 1252
requires maya "2016";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2016";
fileInfo "version" "2016";
fileInfo "cutIdentifier" "201502261600-953408";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -n "pCube1";
	rename -uid "426644A8-43E2-A9EA-01EA-C9B277FEBA33";
createNode mesh -n "pCubeShape1" -p "pCube1";
	rename -uid "21BFCD4B-4960-6DDD-0746-3AA875DAEA78";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 89 ".uvst[0].uvsp[0:88]" -type "float2" 0.51106775 0.25455728
		 0.54427087 0.14322917 0.58333337 0.16666667 0.56770837 0.26041669 0.58041674 0 0.61458337
		 0.13541667 0.625 0.25 0.375 0.25 0.4453125 0.2578125 0.4375 0.375 0.375 0.375 0.5
		 0.375 0.51106775 0.49544269 0.4453125 0.4921875 0.375 0.5 0.625 0.75 0.54427087 0.60677087
		 0.58333337 0.58333337 0.625 0.625 0.56770837 0.48958334 0.625 0.5 0.43055546 0.80555552
		 0.5 0.78125 0.5 0.875 0.40625 0.875 0.625 0.75 0.625 0.875 0.625 1 0.5 0.96875 0.43055549
		 0.94444448 0.625 0 0.75 0 0.75 0.125 0.65625 0.125 0.875 0 0.84375 0.125 0.81944448
		 0.19444446 0.75 0.21875 0.68055558 0.19444448 0.125 0.125 0.25 0.125 0.25 0.1875
		 0.125 0.1875 0.37044272 0.11393229 0.3671875 0.1796875 0.25 0.25 0.125 0.25 0.375
		 0.75 0.48958334 0.73958331 0.5 0.75 0.40625 0.78125 0.625 0.75 0.58041674 1 0.48958334
		 1 0.5 1 0.59375 1 0.375 1 0.40625 0.96875 0.375 0.875 0.375 0.875 0.875 0 0.875 0.125
		 0.875 0.125 0.875 0 0.875 0.25 0.84375 0.21875 0.75 0.25 0.75 0.25 0.65625 0.21875
		 0.625 0.125 0.59375 0 0.5625 0.375 0.625 0.375 0.48177084 0.080729164 0.46875 0.15625
		 0.375 0.625 0.48177084 0.66927087 0.45833334 0.70833331 0.375 0.6875 0.125 0 0.25
		 0 0.25 0.0625 0.125 0.0625 0.375 0 0.36458334 0.057291668 0.48958334 0 0.45833334
		 0.041666668 0.46875 0.59375 0.375 0.5625;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 70 ".vt[0:69]"  -2.63469601 -0.29388738 1.92146146 0.3376343 -0.16548499 3.24183154
		 -0.18023944 2.89747477 1.085020661 3.82588863 0.25143671 1.92146146 -0.18023944 2.89747477 -1.07242012
		 3.82588911 0.25143671 -1.86948466 -2.63469601 -0.29388738 -1.86948466 0.33763453 -0.1654851 -2.91674089
		 -2.10605073 -1.51128268 -1.45875883 0.40091538 -1.66086972 -2.20560622 0.40091527 -1.6608696 2.54581738
		 -2.10605097 -1.51128268 1.55956197 3.293082 -1.38371325 -1.45875859 3.29308176 -1.38371301 1.55956197
		 1.98595428 2.2193222 1.69165087 1.98595428 2.2193222 -1.64676201 -1.81736374 1.51641977 -1.64676189
		 -1.81736374 1.51642001 1.69165087 1.23291481 1.29708397 2.61386585 3.089281797 1.2959944 1.59624434
		 2.40841675 -0.067394853 2.91170573 0.72113383 2.80726027 1.51423073 -0.24473596 3.17561865 0
		 2.231287 2.54476976 0 0.72113383 2.80726027 -1.48587978 1.23291481 1.29708385 -2.45510077
		 2.40841722 -0.067394972 -2.71211553 3.089281797 1.2959944 -1.54181039 -1.20738029 -1.66515541 -2.074338436
		 -2.35691452 -1.65322387 0.028350905 0.39678854 -1.8425386 0.17010543 -1.20738029 -1.66515541 2.30114603
		 2.18410897 -1.62414932 2.30114603 2.18410897 -1.6241492 -2.074338436 3.59803677 -1.57121277 0.028350905
		 -2.12180519 1.73378754 0 -0.962017 2.44277239 -1.48587978 -0.962017 2.44277239 1.51423073
		 -1.48938346 -0.41365051 -2.71211553 -2.5286603 -1.09721303 -1.90876532 0.41329601 -1.11586261 -2.99751019
		 -1.48938358 -0.41365039 2.91170597 0.41329581 -1.11586261 3.33772087 -2.5286603 -1.09721303 1.96546698
		 -3.021292686 -0.25296593 0 3.82319951 -0.81018662 -1.90876532 4.28852558 0.36057079 0
		 3.82319927 -0.81018686 1.96546698 -0.8813886 0.96564579 2.61386585 -0.88138855 0.96564561 -2.45510077
		 -2.35911727 0.57966512 -1.54181039 -2.35911727 0.57966501 1.59624434 2.41988659 0.85601646 2.70070648
		 0.96065575 3.11772227 0 2.41988659 0.8560164 -2.54950166 -1.17386317 -1.84253883 0.11340362
		 2.13824439 -1.84253585 0.11340362 -1.28354573 2.63173842 0 -1.30793166 -1.13300502 -2.80358577
		 -1.3079319 -1.13300502 3.030393124 -2.93557 -1.085282326 0 2.32170272 -0.96898997 -2.80358577
		 4.32369852 -0.75725234 0 2.32170248 -0.96899009 3.030393124 3.4658165 1.54348207 0
		 0.0025683045 1.87587476 2.34866095 -1.70768857 0.31334239 -2.54950166 -2.72554588 0.72947156 0
		 -1.70768857 0.31334251 2.70070648 0.0025683045 1.87587464 -2.23525739;
	setAttr -s 136 ".ed[0:135]"  0 41 1 41 1 1 2 21 1 21 14 1 4 24 1 24 15 1
		 6 38 1 38 7 1 0 51 1 51 17 1 1 20 1 20 3 1 2 22 1 22 4 1 3 46 1 46 5 1 4 36 1 36 16 1
		 5 26 1 26 7 1 6 44 1 44 0 1 6 39 1 39 8 1 7 40 1 40 9 1 8 28 1 28 9 1 1 42 1 42 10 1
		 9 30 1 30 10 1 0 43 1 43 11 1 11 31 1 31 10 1 8 29 1 29 11 1 5 45 1 45 12 1 12 33 1
		 33 9 1 3 47 1 47 13 1 13 34 1 34 12 1 10 32 1 32 13 1 14 19 1 19 3 1 15 27 1 27 5 1
		 14 23 1 23 15 1 14 18 1 18 1 1 7 25 1 25 15 1 16 50 1 50 6 1 17 37 1 37 2 1 16 35 1
		 35 17 1 17 48 1 48 1 1 16 49 1 49 7 1 18 52 1 52 19 1 20 52 1 21 53 1 53 22 1 23 53 1
		 24 53 1 25 54 1 54 26 1 27 54 1 28 55 1 55 29 1 30 55 1 31 55 1 30 56 1 56 32 1 33 56 1
		 34 56 1 35 57 1 57 36 1 37 57 1 22 57 1 38 58 1 58 39 1 40 58 1 28 58 1 41 59 1 59 42 1
		 43 59 1 31 59 1 44 60 1 60 43 1 39 60 1 29 60 1 26 61 1 61 40 1 45 61 1 33 61 1 46 62 1
		 62 45 1 47 62 1 34 62 1 20 63 1 63 47 1 42 63 1 32 63 1 23 64 1 64 27 1 19 64 1 46 64 1
		 48 65 1 65 37 1 18 65 1 21 65 1 49 66 1 66 50 1 38 66 1 44 67 1 67 50 1 51 67 1 35 67 1
		 41 68 1 68 51 1 48 68 1 24 69 1 69 36 1 25 69 1 49 69 1;
	setAttr -s 68 -ch 272 ".fc[0:67]" -type "polyFaces" 
		f 4 54 68 69 -49
		mu 0 4 0 1 2 3
		f 4 10 70 -69 55
		mu 0 4 4 5 2 1
		f 4 -50 -70 -71 11
		mu 0 4 6 3 2 5
		f 4 2 71 72 -13
		mu 0 4 7 8 9 10
		f 4 3 52 73 -72
		mu 0 4 8 0 11 9
		f 4 -74 53 -6 74
		mu 0 4 9 11 12 13
		f 4 -73 -75 -5 -14
		mu 0 4 10 9 13 14
		f 4 56 75 76 19
		mu 0 4 15 16 17 18
		f 4 50 77 -76 57
		mu 0 4 12 19 17 16
		f 4 18 -77 -78 51
		mu 0 4 20 18 17 19
		f 4 26 78 79 -37
		mu 0 4 21 22 23 24
		f 4 27 30 80 -79
		mu 0 4 22 25 26 23
		f 4 -81 31 -36 81
		mu 0 4 23 26 27 28
		f 4 -80 -82 -35 -38
		mu 0 4 24 23 28 29
		f 4 -32 82 83 -47
		mu 0 4 30 31 32 33
		f 4 -31 -42 84 -83
		mu 0 4 31 34 35 32
		f 4 -85 -41 -46 85
		mu 0 4 32 35 36 37
		f 4 -84 -86 -45 -48
		mu 0 4 33 32 37 38
		f 4 62 86 87 17
		mu 0 4 39 40 41 42
		f 4 63 60 88 -87
		mu 0 4 40 43 44 41
		f 4 -89 61 12 89
		mu 0 4 41 44 7 45
		f 4 -88 -90 13 16
		mu 0 4 42 41 45 46
		f 4 6 90 91 -23
		mu 0 4 47 48 49 50
		f 4 7 24 92 -91
		mu 0 4 48 15 51 49
		f 4 -93 25 -28 93
		mu 0 4 49 51 25 22
		f 4 -92 -94 -27 -24
		mu 0 4 50 49 22 21
		f 4 -2 94 95 -29
		mu 0 4 52 53 54 55
		f 4 -1 32 96 -95
		mu 0 4 53 56 57 54
		f 4 -97 33 34 97
		mu 0 4 54 57 29 28
		f 4 -96 -98 35 -30
		mu 0 4 55 54 28 27
		f 4 -22 98 99 -33
		mu 0 4 56 58 59 57
		f 4 -21 22 100 -99
		mu 0 4 58 47 50 59
		f 4 -101 23 36 101
		mu 0 4 59 50 21 24
		f 4 -100 -102 37 -34
		mu 0 4 57 59 24 29
		f 4 -20 102 103 -25
		mu 0 4 60 61 62 63
		f 4 -19 38 104 -103
		mu 0 4 61 64 65 62
		f 4 -105 39 40 105
		mu 0 4 62 65 36 35
		f 4 -104 -106 41 -26
		mu 0 4 63 62 35 34
		f 4 -16 106 107 -39
		mu 0 4 64 66 67 65
		f 4 -15 42 108 -107
		mu 0 4 66 6 68 67
		f 4 -109 43 44 109
		mu 0 4 67 68 38 37
		f 4 -108 -110 45 -40
		mu 0 4 65 67 37 36
		f 4 -12 110 111 -43
		mu 0 4 6 5 69 68
		f 4 -11 28 112 -111
		mu 0 4 5 4 70 69
		f 4 -113 29 46 113
		mu 0 4 69 70 30 33
		f 4 -112 -114 47 -44
		mu 0 4 68 69 33 38
		f 4 -54 114 115 -51
		mu 0 4 12 11 71 19
		f 4 -53 48 116 -115
		mu 0 4 11 0 3 71
		f 4 -117 49 14 117
		mu 0 4 71 3 6 72
		f 4 -116 -118 15 -52
		mu 0 4 19 71 72 20
		f 4 64 118 119 -61
		mu 0 4 43 73 74 44
		f 4 65 -56 120 -119
		mu 0 4 73 4 1 74
		f 4 -121 -55 -4 121
		mu 0 4 74 1 0 8
		f 4 -120 -122 -3 -62
		mu 0 4 44 74 8 7
		f 4 66 122 123 -59
		mu 0 4 75 76 77 78
		f 4 -8 124 -123 67
		mu 0 4 15 48 77 76
		f 4 -60 -124 -125 -7
		mu 0 4 47 78 77 48
		f 4 20 125 126 59
		mu 0 4 79 80 81 82
		f 4 21 8 127 -126
		mu 0 4 80 83 84 81
		f 4 -128 9 -64 128
		mu 0 4 81 84 43 40
		f 4 -127 -129 -63 58
		mu 0 4 82 81 40 39
		f 4 0 129 130 -9
		mu 0 4 83 85 86 84
		f 4 -66 131 -130 1
		mu 0 4 4 73 86 85
		f 4 -10 -131 -132 -65
		mu 0 4 43 84 86 73
		f 4 4 132 133 -17
		mu 0 4 14 13 87 88
		f 4 5 -58 134 -133
		mu 0 4 13 12 16 87
		f 4 -135 -57 -68 135
		mu 0 4 87 16 15 76
		f 4 -134 -136 -67 -18
		mu 0 4 88 87 76 75;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dr" 1;
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
connectAttr "pCubeShape1.iog" ":initialShadingGroup.dsm" -na;
// End of md_rock_keyart01.ma