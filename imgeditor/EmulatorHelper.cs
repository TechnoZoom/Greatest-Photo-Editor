//using System;
//using System.Collections.Generic;
//using System.IO.IsolatedStorage;
//using Microsoft.Xna.Framework.Media;

//namespace imgeditor
//{
//    public static class EmulatorHelper
//    {
//        const string flagName = "__emulatorTestImagesAdded";

//        public static void AddDebugImages()
//        {
//            bool alreadyAdded = CheckAlreadyAdded();
//            if (!alreadyAdded)
//            {
//                AddImages();
//                SetAddedFlag();
//            }
//        }

//        private static bool CheckAlreadyAdded()
//        {
//            IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;

//            try
//            {
//                bool alreadyAdded = (bool)userSettings[flagName];
//                return alreadyAdded;
//            }
//            catch (KeyNotFoundException)
//            {
//                return false;
//            }
//            catch (ArgumentException)
//            {
//                return false;
//            }
//        }

//        private static void SetAddedFlag()
//        {
//            IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;
//            userSettings.Add(flagName, true);
//            userSettings.Save();
//        }

//        //private static void AddImages()
//        //{
//        //    //string[] fileNames = { "t1", "t2", "t3", "t4", "t5", "t6", "t7", "t8", "t9", "t10", "t11", "t12", "t13", "t14", "t15", "t16", "t17", "t18", "t19", "t20", "t21", "t22", "t23", "t24", "t25" };
//        //    string[] fileNames = { "t1", "t2", "t3", "t4", "t5","t26","t27","t28","t29","t30","t31","t32"};
//        //    foreach (var fileName in fileNames)
//        //    {
//        //        MediaLibrary myMediaLibrary = new MediaLibrary();
//        //        Uri myUri = new Uri(String.Format(@"TestImages/{0}.jpg", fileName), UriKind.Relative);

//        //        System.IO.Stream photoStream = imgeditor.App.GetResourceStream(myUri).Stream;
//        //        byte[] buffer = new byte[photoStream.Length];
//        //        photoStream.Read(buffer, 0, Convert.ToInt32(photoStream.Length));
//        //        myMediaLibrary.SavePicture(String.Format("{0}.jpg", fileName), buffer);
//        //        photoStream.Close();
//        //    }
//        //}
//    }
//}