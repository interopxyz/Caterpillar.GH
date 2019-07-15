using System;
using System.Collections.Generic;

using System.Reflection;
using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Windows.Forms;
using System.Linq;
using Grasshopper.Kernel.Parameters;
using System.ComponentModel;
using System.Diagnostics;

namespace Caterpillar.GH.UnitConverters
{
    public class Lengths : CaterPillar_Base
    {
        
        /// <summary>
        /// Initializes a new instance of the Lengths class.
        /// </summary>
        public Lengths()
          : base("Lengths", "Nickname", "Description", "Maths", "Units")
        {
            SetMenuBoxes(new string[] { "SI", "Imperial", "US", "UK", "Astronomical", "Nautical"});
        }

        /// <summary>
        /// Set Exposure level for the component.
        /// </summary>
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.primary; }
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Value", "V", "The value in the source units", GH_ParamAccess.item, 1.0);

            pManager.AddIntegerParameter("Source Units", "S", "The source unit scale", GH_ParamAccess.item, 0);

            pManager.AddIntegerParameter("Target Units", "T", "The target unit scale", GH_ParamAccess.item, 0);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Result", "R", "The converted value", GH_ParamAccess.item);
            pManager.AddGenericParameter("A", "A", "A", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<string> items = new List<string>();

            Type type = typeof(Caterpillar.Lengths.SI);
            var flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;
            MemberInfo[] members = type.GetMembers(flags);
            foreach (MemberInfo mi in members)
            {
                items.Add(mi.Name);
            }
                DA.SetDataList(1, items);
        }

        protected override void SetInputOptions()
        {
            base.SetInputOptions();
            
            Param_Integer param = (Param_Integer)Params.Input[1];
            param.AddNamedValue("4", 0);
            param.AddNamedValue("4", 1);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("60ce550d-c24a-459e-b595-18e4761d482d"); }
        }
    }
}