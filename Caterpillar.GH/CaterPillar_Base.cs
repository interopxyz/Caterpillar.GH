using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Windows.Forms;
using GH_IO.Serialization;
using System.Reflection;
using System.Globalization;

namespace Caterpillar.GH
{
    public class CaterPillar_Base : GH_Component
    {

        protected enum RhUnit { Length, Area, Volume };

        protected ComboBox inputs = new ComboBox();
        protected ComboBox outputs = new ComboBox();

        protected int inputIndex = 0;
        protected int outputIndex = 0;

        protected List<Unit> UnitsIn = new List<Unit>();
        protected List<Unit> UnitsOut = new List<Unit>();

        protected string[] systemNames = new string[] { "Rhino" };

        protected int inVal = 0;
        protected int outVal = 0;

        /// <summary>
        /// Initializes a new instance of the CaterPillar_Base class.
        /// </summary>
        public CaterPillar_Base()
          : base("CaterPillar_Base", "Nickname",
              "Description",
              "Category", "Subcategory")
        {
            UpdateMessage();
        }

        public CaterPillar_Base(string Name, string Nickname, string Description, string Category, string Subcategory)
  : base(Name, Nickname,
      Description,
      Category, Subcategory)
        {
            UpdateMessage();
        }

        protected Unit GetRhinoUnits(RhUnit unitType)
        {

            Unit lengthOut = null;
            Unit areaOut = null;
            Unit volumeOut = null;


            switch (Rhino.RhinoDoc.ActiveDoc.ModelUnitSystem)
            {
                default:
                    lengthOut = Lengths.SI.Meter;
                    areaOut = Areas.SI.Meter;
                    volumeOut = Volumes.SI.Meters.Meter;
                    break;
                case Rhino.UnitSystem.Angstroms:
                    lengthOut = Lengths.Metric.Angstrom;
                    areaOut = Areas.Metric.SquareAngstrom;
                    volumeOut = Volumes.Metric.CubicAngstrom;
                    break;
                case Rhino.UnitSystem.AstronomicalUnits:
                    lengthOut = Lengths.Astronomical.AstronomicalUnit;
                    areaOut = Areas.Astronomical.AstronomicalUnit;
                    volumeOut = Volumes.Astronomical.AstronomicalUnit;
                    break;
                case Rhino.UnitSystem.Centimeters:
                    lengthOut = Lengths.SI.Centimeter;
                    areaOut = Areas.SI.Centimeter;
                    volumeOut = Volumes.SI.Meters.Centimeter;
                    break;
                case Rhino.UnitSystem.Decimeters:
                    lengthOut = Lengths.SI.Decimeter;
                    areaOut = Areas.SI.Decimeter;
                    volumeOut = Volumes.SI.Meters.Decimeter;
                    break;
                case Rhino.UnitSystem.Dekameters:
                    lengthOut = Lengths.SI.Dekameter;
                    areaOut = Areas.SI.Dekameter;
                    volumeOut = Volumes.SI.Meters.Dekameter;
                    break;
                case Rhino.UnitSystem.Feet:
                    lengthOut = Lengths.Imperial.Foot;
                    areaOut = Areas.Imperial.Foot;
                    volumeOut = Volumes.Imperial.Foot;
                    break;
                case Rhino.UnitSystem.Gigameters:
                    lengthOut = Lengths.SI.Gigameter;
                    areaOut = Areas.SI.Gigameter;
                    volumeOut = Volumes.SI.Meters.Gigameter;
                    break;
                case Rhino.UnitSystem.Hectometers:
                    lengthOut = Lengths.SI.Hectometer;
                    areaOut = Areas.SI.Hectometer;
                    volumeOut = Volumes.SI.Meters.Hectometer;
                    break;
                case Rhino.UnitSystem.Inches:
                    lengthOut = Lengths.Imperial.Inch;
                    areaOut = Areas.Imperial.Inch;
                    volumeOut = Volumes.Imperial.Inch;
                    break;
                case Rhino.UnitSystem.Kilometers:
                    lengthOut = Lengths.SI.Kilometer;
                    areaOut = Areas.SI.Kilometer;
                    volumeOut = Volumes.SI.Meters.Kilometer;
                    break;
                case Rhino.UnitSystem.LightYears:
                    lengthOut = Lengths.Astronomical.Lightyear;
                    areaOut = Areas.Astronomical.LightYear;
                    volumeOut = Volumes.Astronomical.LightYear;
                    break;
                case Rhino.UnitSystem.Megameters:
                    lengthOut = Lengths.SI.Megameter;
                    areaOut = Areas.SI.Megameter;
                    volumeOut = Volumes.SI.Meters.Megameter;
                    break;
                case Rhino.UnitSystem.Microinches:
                    lengthOut = Lengths.Imperial.Microinch;
                    areaOut = Areas.Imperial.Microinch;
                    volumeOut = Volumes.Imperial.Microinch;
                    break;
                case Rhino.UnitSystem.Microns:
                    lengthOut = Lengths.Metric.Micron;
                    areaOut = Areas.Metric.Micron;
                    volumeOut = Volumes.Metric.Micron;
                    break;
                case Rhino.UnitSystem.Miles:
                    lengthOut = Lengths.Imperial.Mile;
                    areaOut = Areas.Imperial.Mile;
                    volumeOut = Volumes.Imperial.Mile;
                    break;
                case Rhino.UnitSystem.Millimeters:
                    lengthOut = Lengths.SI.Millimeter;
                    areaOut = Areas.SI.Millimeter;
                    volumeOut = Volumes.SI.Meters.Millimeter;
                    break;
                case Rhino.UnitSystem.Mils:
                    lengthOut = Lengths.Imperial.Mil;
                    areaOut = Areas.Imperial.Mil;
                    volumeOut = Volumes.Imperial.Mil;
                    break;
                case Rhino.UnitSystem.NauticalMiles:
                    lengthOut = Lengths.Nautical.NauticalMile;
                    areaOut = Areas.Nautical.NauticalMile;
                    volumeOut = Volumes.Nautical.NauticalMile;
                    break;
                case Rhino.UnitSystem.Parsecs:
                    lengthOut = Lengths.Astronomical.Parsec;
                    areaOut = Areas.Astronomical.Parsec;
                    volumeOut = Volumes.Astronomical.Parsec;
                    break;
                case Rhino.UnitSystem.PrinterPicas:
                    lengthOut = Lengths.Typographic.Pica;
                    areaOut = Areas.Typographic.SquarePica;
                    volumeOut = Volumes.Typographic.CubicPica;
                    break;
                case Rhino.UnitSystem.PrinterPoints:
                    lengthOut = Lengths.Typographic.Point;
                    areaOut = Areas.Typographic.SquarePoint;
                    volumeOut = Volumes.Typographic.CubicPoint;
                    break;
                case Rhino.UnitSystem.Yards:
                    lengthOut = Lengths.Imperial.Yard;
                    areaOut = Areas.Imperial.Yard;
                    volumeOut = Volumes.Imperial.Yard;
                    break;
            }

            switch(unitType)
            {
                default:
                    return lengthOut;
                case RhUnit.Area:
                    return areaOut;
                case RhUnit.Volume:
                    return volumeOut;
            }

        }

        /// <summary>
        /// Set Exposure level for the component.
        /// </summary>
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.hidden; }
        }


        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {

        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {

        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

        }

        public string ConvertUnits(double value, int sigDigits = 36)
        {
            double outputValue = value * UnitsIn[inVal].Factor / UnitsOut[outVal].Factor;
            string output = outputValue.ToString("F"+ sigDigits.ToString(), CultureInfo.CurrentCulture);
            output = output.TrimEnd('0');
            output = output + "0";
            return output;
        }

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {

            TableLayoutPanel panelA = TablePanel("Units In", inputs);
            TableLayoutPanel panelB = TablePanel("Units Out", outputs);

            base.AppendAdditionalMenuItems(menu);

            Menu_AppendSeparator(menu);
            Menu_AppendCustomItem(menu, panelA);

            Menu_AppendSeparator(menu);
            Menu_AppendCustomItem(menu, panelB);
        }

        protected List<Unit> GetUnits(Type type)
        {
            List<Unit> results = new List<Unit>();

            var flags = BindingFlags.Public | BindingFlags.Static;
            MemberInfo[] members = type.GetProperties(flags);
            foreach (MemberInfo mi in members)
            {

                Unit obj = (Unit)(((PropertyInfo)mi).GetValue(this));
                results.Add(obj);
            }
            return results;
        }

        private TableLayoutPanel TablePanel(string Title, ComboBox box)
        {
            box.DropDownStyle = ComboBoxStyle.DropDownList;
            box.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

            Label label = new Label();
            label.Text = Title;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.BackColor = System.Drawing.Color.Transparent;
            panel.Height = 25;
            panel.ColumnCount = 2;
            panel.RowCount = 1;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
            panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25));

            panel.Controls.Add(label, 1, 0);
            panel.Controls.Add(box, 0, 0);

            return panel;
        }

        public void SetMenuBoxes(string[] values)
        {
            systemNames = values;

            foreach (string val in values)
            {
                inputs.Items.Add(val);
                outputs.Items.Add(val);
            }
            
            inputs.SelectionChangeCommitted -= (o, e) => { SetInputIndex(); };
            inputs.SelectionChangeCommitted += (o, e) => { SetInputIndex(); };

            outputs.SelectionChangeCommitted -= (o, e) => { SetOutputIndex(); };
            outputs.SelectionChangeCommitted += (o, e) => { SetOutputIndex(); };

            inputs.SelectedIndex = inputIndex;
            outputs.SelectedIndex = outputIndex;

            UpdateMessage();
        }

        private void SetInputIndex()
        {
            inputIndex = inputs.SelectedIndex;
            SetInputOptions();
            UpdateMessage();
            ExpireSolution(true);
        }

        private void SetOutputIndex()
        {
            outputIndex = outputs.SelectedIndex;
            SetOutputOptions();
            UpdateMessage();
            ExpireSolution(true);
        }

        protected virtual void SetInputOptions()
        {

        }

        protected virtual void SetOutputOptions()
        {

        }

        /// <summary>
        /// Adds to the default serialization method to save the current child status so it persists on copy/paste and save/reopen.
        /// </summary>
        public override bool Write(GH_IWriter writer)
        {
            writer.SetInt32("indexIn", inputIndex);
            writer.SetInt32("indexOut", outputIndex);

            return base.Write(writer);
        }

        /// <summary>
        /// Adds to the default deserialization method to retrieve the saved child status so it persists on copy/paste and save/reopen.
        /// </summary>
        public override bool Read(GH_IReader reader)
        {
            inputIndex = reader.GetInt32("indexIn");
            outputIndex = reader.GetInt32("indexOut");

            inputs.SelectedIndex = inputIndex;
            outputs.SelectedIndex = outputIndex;

            SetInputOptions();
            SetOutputOptions();

            UpdateMessage();
            ExpireSolution(true);
            return base.Read(reader);
        }

        private void UpdateMessage()
        {

            Message = systemNames[inputIndex] + " to "+Environment.NewLine+systemNames[outputIndex];
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
            get { return new Guid("b0a75ec1-6b1c-4cb2-92a4-fc9e6317413b"); }
        }
    }
}