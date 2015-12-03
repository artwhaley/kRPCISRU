using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KRPC.Service;
using KRPC.Service.Attributes;  

namespace krpcisru
{
    [KRPCService(GameScene = GameScene.Flight)]
    public static class krpcisru
    {


       

        [KRPCProcedure]
        public static int HarvestStart()
        {
            int flag = 0;
            List<Part> p = FlightGlobals.ActiveVessel.parts;
            foreach (Part thatpart in p)
            {
                foreach (PartModule thatmodule in thatpart.Modules)
                {
                    if (thatmodule is ModuleResourceHarvester)
                    {
                        var thatdrill = thatmodule as ModuleResourceHarvester;
                        if(thatdrill.enabled== true) {
                        }
                        thatdrill.StartResourceConverter();
                        flag++;
                    }
                }
            }
            return flag;
        }

        [KRPCProcedure]
        public static int HarvestStop()
        {
            int flag = 0;
            List<Part> p = FlightGlobals.ActiveVessel.parts;
            foreach (Part thatpart in p)
            {
                foreach (PartModule thatmodule in thatpart.Modules)
                {
                    if (thatmodule is ModuleResourceHarvester)
                    {
                        var thatdrill = thatmodule as ModuleResourceHarvester;
                        thatdrill.StopResourceConverter();
                        flag++;
                    }
                }
            }
            return flag;
        }

        [KRPCProcedure]
        public static int Deploy()
        {

            int flag = 0;
            List<Part> p = FlightGlobals.ActiveVessel.parts;
            foreach (Part thatpart in p)
            {
                foreach (PartModule thatmodule in thatpart.Modules)
                {
                    if (thatmodule is ModuleAnimationGroup)
                    {
                        var thatdeploy = thatmodule as ModuleAnimationGroup;
                        if (thatdeploy.moduleType == "Drill") {
                            flag++;
                            if (thatdeploy.isDeployed== false) {
                                thatdeploy.DeployModule();
                                
                            }
                            
                        }

                        
                    }
                }
            }
            return flag;
          
        }

        [KRPCProcedure]
        public static int Retract()
        {  
        int flag = 0;
        List<Part> p = FlightGlobals.ActiveVessel.parts;
            foreach (Part thatpart in p)
            {
                foreach (PartModule thatmodule in thatpart.Modules)
                {
                    if (thatmodule is ModuleAnimationGroup)
                    {
                        var thatdeploy = thatmodule as ModuleAnimationGroup;
                        if (thatdeploy.moduleType == "Drill") {
                            flag++;
                            if (thatdeploy.isDeployed== true) {
                                thatdeploy.RetractModule();
                                
                            }

}

                    }
                }
            }
            return flag;
          
        }


        [KRPCProcedure]
        public static int IsruStart(string cvname)
        {
            int flag = 0;
            List<Part> p = FlightGlobals.ActiveVessel.parts;
            foreach (Part thatpart in p)
            {
                foreach (PartModule thatmodule in thatpart.Modules)
                {
                    if (thatmodule is ModuleResourceConverter)
                    {
                        var thatconverter = thatmodule as ModuleResourceConverter;
                        if (thatconverter.ConverterName == cvname)
                        {
                            thatconverter.StartResourceConverter();
                            flag++;
                        }

                    }
                }
            }
            return flag;
        }

        [KRPCProcedure]
        public static int IsruStop(string cvname)
        {
            int flag = 0;
            List<Part> p = FlightGlobals.ActiveVessel.parts;
            foreach (Part thatpart in p)
            {
                foreach (PartModule thatmodule in thatpart.Modules)
                {
                    if (thatmodule is ModuleResourceConverter)
                    {
                        var thatconverter = thatmodule as ModuleResourceConverter;
                        if (thatconverter.ConverterName == cvname)
                        {
                            thatconverter.StopResourceConverter();
                            flag++;
                        }

                    }
                }
            }
            return flag;
        }

        [KRPCProcedure]
        public static int IsruStopAll()
        {
            int flag = 0;
            List<Part> p = FlightGlobals.ActiveVessel.parts;
            foreach (Part thatpart in p)
            {
                foreach (PartModule thatmodule in thatpart.Modules)
                {
                    if (thatmodule is ModuleResourceConverter)
                    {
                        var thatconverter = thatmodule as ModuleResourceConverter;
                        if (thatconverter.IsActivated== true)
                        {
                            thatconverter.StopResourceConverter();
                            flag++;
                        }

                    }
                }
            }
            return flag;
        }


        [KRPCProcedure]
        public static string IsruList()
        {
            string returnstring = "";

            List<Part> p = FlightGlobals.ActiveVessel.parts;
            foreach (Part thatpart in p)
            {
                foreach (PartModule thatmodule in thatpart.Modules)
                {
                    if (thatmodule is ModuleResourceConverter)
                    {
                        var thatconverter = thatmodule as ModuleResourceConverter;
                        if (returnstring != "") { returnstring += ","; }
                        returnstring += thatconverter.ConverterName ;
         
                    }
                }
            }
          //  if (isruc.Count() == 0) { isruc.Add("No ISRU Converters Found");}
            return returnstring;
        }


    }
}