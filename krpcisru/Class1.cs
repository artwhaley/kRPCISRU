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
                        thatdrill.StartResourceConverter();
                        flag = 1;
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
                        flag = 1;
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
                            if (thatdeploy.isDeployed== false) {
                                thatdeploy.DeployModule();
                            }
                            
                        }

                        flag = 1;
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
                            if (thatdeploy.isDeployed== true) {
                                thatdeploy.RetractModule()
                            }

}

flag = 1;
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
                            flag = 1;
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
                            flag = 1;
                        }

                    }
                }
            }
            return flag;
        }


    }
}