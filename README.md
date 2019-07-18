# Caterpillar.GH
Caterpillar plugin for Robert McNeel and Associate's Grasshopper 3d.

Grasshopper users can download the plugin at: https://www.food4rhino.com/app/caterpillar

## README
Caterpillar GH is the [Grasshopper 3D](https://www.grasshopper3d.com/) implementation of the [Caterpillar Library](https://github.com/interopxyz/Caterpillar) which allows for the conversion between different systems of measurement. Designed for simplicity of use, the primary conversion all takes place in a single component per unit of measure in which three inputs convert a “value” from a source unit of measure to a target unit of measure resulting in an output from the component whose value has been converted from the specified input system of measurement to the output system. The result is a fast simple conversion between common systems of measurement covering, Angle, Area, Energy, Force, Length, Mass, Pressure, Speed, Temperature, Time, and Volume. The components are added to the Math's tab in the Grasshopper ribbon under the Units Category.

![Components](https://github.com/interopxyz/Caterpillar.GH/blob/master/Images/Caterpillar-Ribbon.jpg?raw=true)

Each component has right-click options to select systems of measure including SI (Metric), US Customary, UK Imperial, etc.. which in turn change the options for the source and target. For example under US Customary units such as Inch, Foot, Mile, etc.. are available for selection. Each conversion uses factors based on the SI base value. Each conversion value is rounded to the 36th significant digit when needed. The converted value is then returned through the “result” output. 

![Dropdown](https://github.com/interopxyz/Caterpillar.GH/blob/master/Images/Caterpillar-Dropdowns.jpg?raw=true)

Each components default state is set to the current Rhino Document when applicable.

Built initially for converting US & UK Imperial units to Metric on architectural project, the component set was expanded to cover a wide array of both historic and sometimes archaic units as well as several additional Nation's traditional units. Not all of the options available in the [Caterpillar Library](https://github.com/interopxyz/Caterpillar) are made accessible in the Grasshopper components.


In response to the common need to share files among multiple team members Caterpillar was initially developed as a safeguard against shared files being opened in rhino scenes where units were different. A common issue of a grasshopper file being developed in a scene set to meters and using a divide by distance component would be opened in a scene set to millimeters. The result of which was often a sever lag if not crash of the file. The Rhino unit and metric conversion were developed to anticipate this issue, by allowing grasshopper to detect rhino’s’ unit, such as millimeters and convert them to the unit for which the file was developed, such as meters. 

### NOTE
*Caterpillar is currently an alpha release, as all values available have been preliminarily used but not fully cross-checked or validated. Use at your own risk. It is recommended that preliminary conversions are verified from an independent source before use.*



## Installation & Prerequisites
To use Caterpillar GH you will need 
 - https://www.rhino3d.com/
 - https://www.grasshopper3d.com/   (now comes with Rhinoceros 6)


## References
Conversion factors sourced and cross checked where possible from the following sources

 - http://www.onlineconversion.com/
 - https://www.conversioncenter.net/
 - http://www.kylesconverter.com/
 - https://www.traditionaloven.com/

