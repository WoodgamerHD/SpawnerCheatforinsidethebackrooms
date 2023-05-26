using Il2Cpp;
using Il2CppMirror;
using MelonLoader;
using UnityEngine;
using static UnityEngine.Object;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Spawner
{
    public static class BuildInfo
    {
        public const string Name = "Spawner menu"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Spawner Menu"; // Description for the Mod.  (Set as null if none)
        public const string Author = "WoodgamerHD"; // Author of the Mod.  (MUST BE SET)
        public const string Company = "DO NOT FUCKEN REPOST OR CLAIMS ARE YOURS"; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = ""; // Download Link for the Mod.  (Set as null if none)
    }


    public class Spawner : MelonMod
    {
        private int tab = 0; // Current tab index
        string[] itemNames = new string[]
{
    "AlmondWater", "Arm", "BoilerRoomKeys","Bucket", "CalmingPills", "Cassete", "ClockHands", "CodeAbecedary", "CurvedPipe", "Ear",
    "Extinguisher", "Eye", "Fingers", "Flashlight", "Foot", "FunDoorKey", "Fuse", "GarageCard", "Gear", "GearLeverHandle",
    "GeigerCounter", "Hammer", "Hand", "Ingot6", "Ingot8", "Ingot10", "MotionSensor", "MedallionFish", "MedallionParrot", "MedallionRat",
    "MetalDetector", "MothCoccoon", "MothJelly", "Nose", "PartyHat", "PetrolCanEmpty", "Pipe", "Plier", "ProtectionSuit",
    "Radio", "RedAccesCard", "RedKey", "ScrewDriver", "SewerCanalsKey", "SewerEmergencyKey", "SewerStorageKey",
    "StatueFace", "StorageKey", "Teeth", "Valve", "VynilDish"
};
        string[] Boosteritem = new string[]
    {  "AlmondWater","CalmingPills", "MothJelly","Flashlight","Radio" };

        string[] DarkRoomsParking = new string[] {
            "ClockHands", "Cassete", "ScrewDriver", "Hammer", "RedAccesCard", "Fuse", "Plier","GeigerCounter","Extinguisher","ProtectionSuit","Valve","GarageCard",
            "Ear", "Eye", "Fingers", "Foot", "Hand","Nose","Teeth" };

        string[] OfficeItems = new string[] { "MotionSensor", "CodeAbecedary", "PartyHat", "RedAccesCard","Head" };

        string[] Sewersitems = new string[] { "SewerCanalsKey", "SewerEmergencyKey", "SewerStorageKey",
            "MetalDetector", "MedallionRat", "MedallionFish", "MedallionParrot", "PetrolCanEmpty","PetrolCanFilled","Bucket","Gear","GearLeverHandle" };

        string[] terrorhotelitems = new string[] { "Ingot6", "Ingot8", "Ingot10", "StatueFace", "StorageKey", "VyniiDish", "Candle", "BoilerRoomKeys", "Pipe", "CurvedPipe", "MothCoccoon" };

        private Rect MainWindow;
       
        public static List<NetworkReparent> NetworkReparent = new List<NetworkReparent>();
        public static List<MiscTest> MiscTest = new List<MiscTest>();

        private bool ShowMenuSpawner = true; // Whether to show the menu or not
   
        float natNextUpdateTime;
    

        public override void OnUpdate()
        {
            natNextUpdateTime += Time.deltaTime;

            if (natNextUpdateTime >= 3f)
            {
                MiscTest = FindObjectsOfType<MiscTest>().ToList();
                NetworkReparent = FindObjectsOfType<NetworkReparent>().ToList();
                natNextUpdateTime = 0f;
            }
            if (Keyboard.current.f1Key.wasPressedThisFrame)
            {
                ShowMenuSpawner = !ShowMenuSpawner;

            }

        }
       

        public override void OnInitializeMelon()
        {
           
          
        MainWindow = new Rect(0, 0, 400f, 400f);
        }


        //

        private Vector2 scrollPosition5 = Vector2.zero;
        private static Rect Itemgivewindow = new Rect(60f, 250f, 400, 400);
        public void GiveitemsWindow(int windowID)
        {
            GUILayout.BeginHorizontal();

          
            if (GUILayout.Toggle(tab == 0, "All-items", "Button", GUILayout.ExpandWidth(true)))
            {
                tab = 0;
            }
            if (GUILayout.Toggle(tab == 1, "Aid", "Button", GUILayout.ExpandWidth(true)))
            {
                tab = 1;
            }
            if (GUILayout.Toggle(tab == 2, "Parking", "Button", GUILayout.ExpandWidth(true)))
            {
                tab = 2;
            }
            if (GUILayout.Toggle(tab == 3, "Office", "Button", GUILayout.ExpandWidth(true)))
            {
                tab = 3;
            }
            if (GUILayout.Toggle(tab == 4, "Sewers", "Button", GUILayout.ExpandWidth(true)))
            {
                tab = 4;
            }
            if (GUILayout.Toggle(tab == 5, "Hotel", "Button", GUILayout.ExpandWidth(true)))
            {
                tab = 5;
            }
            GUILayout.EndHorizontal();




            switch (tab)
            {
                case 0:
                    // Begin a scroll view to allow scrolling through the button list
                    scrollPosition5 = GUILayout.BeginScrollView(scrollPosition5);
                    GUILayout.BeginVertical(GUI.skin.box);

                  
                    // Create a button for each option in the options array
                    for (int i = 0; i < itemNames.Length; i++)
                    {
                        if (GUILayout.Button(itemNames[i], GUILayout.ExpandWidth(true)))
                        {
                            // Get the selected location from the locations array
                            string selectedLocation = itemNames[i];

                            foreach (NetworkReparent playert in NetworkReparent)
                            {
                                foreach (MiscTest player in MiscTest)
                                {
                                    //player.DEVMODE_ENABLED = true;
                                    player.CmdSpawnItem(selectedLocation, playert.localplayerParent.position);

                                }
                            }
                        }
                    }
                    GUILayout.EndVertical();
                    GUILayout.EndScrollView();
                    break;
                case 1:
                    

                    // Begin a scroll view to allow scrolling through the button list
                    scrollPosition5 = GUILayout.BeginScrollView(scrollPosition5);
                    GUILayout.BeginVertical(GUI.skin.box);
                    // Create a button for each option in the options array
                    for (int i = 0; i < Boosteritem.Length; i++)
                    {
                        if (GUILayout.Button(Boosteritem[i], GUILayout.ExpandWidth(true)))
                        {
                            // Get the selected location from the locations array
                            string selectedLocation = Boosteritem[i];

                            foreach (NetworkReparent playert in NetworkReparent)
                            {
                                foreach (MiscTest player in MiscTest)
                                {
                                    //player.DEVMODE_ENABLED = true;
                                    player.CmdSpawnItem(selectedLocation, playert.localplayerParent.position);

                                }
                            }
                        }
                    }
                    GUILayout.EndVertical();
                    GUILayout.EndScrollView();

                    break;
                case 2:
                    // Begin a scroll view to allow scrolling through the button list
                    scrollPosition5 = GUILayout.BeginScrollView(scrollPosition5);
                    GUILayout.BeginVertical(GUI.skin.box);
                    // Create a button for each option in the options array
                    for (int i = 0; i < DarkRoomsParking.Length; i++)
                    {
                        if (GUILayout.Button(DarkRoomsParking[i], GUILayout.ExpandWidth(true)))
                        {
                            // Get the selected location from the locations array
                            string selectedLocation = DarkRoomsParking[i];

                            foreach (NetworkReparent playert in NetworkReparent)
                            {
                                foreach (MiscTest player in MiscTest)
                                {
                                    //player.DEVMODE_ENABLED = true;
                                    player.CmdSpawnItem(selectedLocation, playert.localplayerParent.position);

                                }
                            }
                        }
                    }
                    GUILayout.EndScrollView();
                    GUILayout.EndVertical();
                    break;
                case 3:
                    // Begin a scroll view to allow scrolling through the button list
                    scrollPosition5 = GUILayout.BeginScrollView(scrollPosition5);
                    GUILayout.BeginVertical(GUI.skin.box);
                    // Create a button for each option in the options array
                    for (int i = 0; i < OfficeItems.Length; i++)
                    {
                        if (GUILayout.Button(OfficeItems[i], GUILayout.ExpandWidth(true)))
                        {
                            // Get the selected location from the locations array
                            string selectedLocation = OfficeItems[i];

                            foreach (NetworkReparent playert in NetworkReparent)
                            {
                                foreach (MiscTest player in MiscTest)
                                {
                                    //player.DEVMODE_ENABLED = true;
                                    player.CmdSpawnItem(selectedLocation, playert.localplayerParent.position);

                                }
                            }
                        }
                    }
                    GUILayout.EndVertical();
                    GUILayout.EndScrollView();
                    break;
                case 4:
                    // Begin a scroll view to allow scrolling through the button list
                    scrollPosition5 = GUILayout.BeginScrollView(scrollPosition5);
                    GUILayout.BeginVertical(GUI.skin.box);
                    // Create a button for each option in the options array
                    for (int i = 0; i < Sewersitems.Length; i++)
                    {
                        if (GUILayout.Button(Sewersitems[i], GUILayout.ExpandWidth(true)))
                        {
                            // Get the selected location from the locations array
                            string selectedLocation = Sewersitems[i];

                            foreach (NetworkReparent playert in NetworkReparent)
                            {
                                foreach (MiscTest player in MiscTest)
                                {
                                    //player.DEVMODE_ENABLED = true;
                                    player.CmdSpawnItem(selectedLocation, playert.localplayerParent.position);

                                }
                            }
                        }
                    }
                    GUILayout.EndVertical();
                    GUILayout.EndScrollView();
                    break;
                case 5:
                    // Begin a scroll view to allow scrolling through the button list
                    scrollPosition5 = GUILayout.BeginScrollView(scrollPosition5);
                     GUILayout.BeginVertical(GUI.skin.box);
                    // Create a button for each option in the options array
                    for (int i = 0; i < terrorhotelitems.Length; i++)
                    {
                        if (GUILayout.Button(terrorhotelitems[i], GUILayout.ExpandWidth(true)))
                        {
                            // Get the selected location from the locations array
                            string selectedLocation = terrorhotelitems[i];

                            foreach (NetworkReparent playert in NetworkReparent)
                            {
                                foreach (MiscTest player in MiscTest)
                                {
                                    //player.DEVMODE_ENABLED = true;
                                    player.CmdSpawnItem(selectedLocation, playert.localplayerParent.position);

                                }
                            }
                        }
                    }
                    GUILayout.EndVertical();
                    GUILayout.EndScrollView();
                    break;
            }
          
          
            GUI.DragWindow(); // Allow the user to drag the window around



        }


        public override void OnGUI()
        {
          
            if (ShowMenuSpawner)
            {
                // Set the background color
                GUI.backgroundColor = Color.black;

                MainWindow = GUI.Window(9, MainWindow, (GUI.WindowFunction)GiveitemsWindow, "Spawner Menu<WoodgamerHD>"); 

            }

        }
    }
}
